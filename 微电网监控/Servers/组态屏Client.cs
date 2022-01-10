using ModbusLib;
using ModbusLib.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 微电网监控.Models;

namespace 微电网监控.Servers
{
    public class 组态屏Client
    {
        组态屏Model 组态屏;
        public event Action<string> MessageLog;
        ModbusClient modbusClient;
        Socket socket;
        private int _transactionId;
        private ICommClient _portClient;

        public 组态屏Client(组态屏Model 组态屏)
        {
            this.组态屏 = 组态屏;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(new IPEndPoint(组态屏.IP, 组态屏.Port));
            _portClient = socket.GetClient();
            modbusClient = new ModbusClient(new ModbusTcpCodec()) { Address = 1 };
            //modbusClient.OutgoingData += DriverOutgoingData;
            //modbusClient.IncommingData += DriverIncommingData;
        }

        private void DriverIncommingData(byte[] data, int len)
        {
            var hex = new StringBuilder(len);
            for (int i = 0; i < len; i++)
            {
                hex.AppendFormat("{0:x2} ", data[i]);
            }
            MessageLog.Invoke(String.Format("RX: {0}", hex));
        }

        private void DriverOutgoingData(byte[] data)
        {
            var hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                hex.AppendFormat("{0:x2} ", b);
            MessageLog.Invoke(String.Format("TX: {0}", hex));
        }

        public void ValueChangedEventHandler(string key, string preValue)
        {
            switch (组态屏.配置文件内容[key].数据区域)
            {
                case 数据区域.输出继电器0区:
                    try
                    {
                        var command = new ModbusCommand(ModbusCommand.FuncWriteCoil)
                        {
                            Offset = 组态屏.配置文件内容[key].StartAddress,
                            Count = 1,
                            TransId = _transactionId++,
                            Data = new ushort[1]
                        };
                        if (preValue == "1") command.Data[0] = 1;
                        else command.Data[0] = 0;
                        var result = modbusClient.ExecuteGeneric(_portClient, command);
                    }
                    catch (Exception ex)
                    { }
                    break;
                case 数据区域.输出寄存器4区:
                    try
                    {
                        var command = new ModbusCommand(ModbusCommand.FuncWriteMultipleRegisters)
                        {
                            Offset = 组态屏.配置文件内容[key].StartAddress,
                            Count = 组态屏.配置文件内容[key].Length,
                            TransId = _transactionId++,
                            Data = new ushort[组态屏.配置文件内容[key].Length]
                        };
                        switch (组态屏.配置文件内容[key].数据类型)
                        {
                            case 数据类型.无符号16位整型:
                                command.Data[0] = ushort.Parse(preValue);
                                break;
                            case 数据类型.有符号16位整型:
                                command.Data[0] = (ushort)(Int16.Parse(preValue));
                                break;
                            case 数据类型.无符号32位整型:
                                if (int.Parse(preValue) < 0)
                                    return;
                                uint data = uint.Parse(preValue);
                                command.Data[0] = (ushort)(data >> 16);
                                command.Data[1] = (ushort)data;
                                break;
                            case 数据类型.有符号32位整型:
                                int a = int.Parse(preValue);
                                command.Data[0] = (ushort)(int.Parse(preValue) >> 16);
                                command.Data[1] = (ushort)(int.Parse(preValue));
                                break;
                            case 数据类型.单精度浮点数:
                                ushort[] dat = new ushort[2];
                                float[] flo = new float[1];
                                flo[0] = float.Parse(preValue);
                                Buffer.BlockCopy(flo, 0, dat, 0, 4);
                                command.Data[0] = dat[1];
                                command.Data[1] = dat[0];
                                break;
                            case 数据类型.字符串:
                                break;
                            default:
                                break;
                        }
                        var result = modbusClient.ExecuteGeneric(_portClient, command);
                    }
                    catch { }
                    break;
                case 数据区域.输入继电器1区:
                case 数据区域.输入寄存器3区:
                    MessageBox.Show("只读数据并不能修改。");
                    break;

                default:
                    break;
            }
        }

        public void UpdateData()
        {
            foreach (var KeyValue in 组态屏.配置文件内容)
            {
                if (KeyValue.Value.数据区域 == 数据区域.输出继电器0区)
                {
                    var command = new ModbusCommand(ModbusCommand.FuncReadCoils)
                    {
                        Offset = KeyValue.Value.StartAddress,
                        Count = KeyValue.Value.Length,
                        TransId = _transactionId++,
                    };
                    var result = modbusClient.ExecuteGeneric(_portClient, command);
                    组态屏.DicData[KeyValue.Key].Value = command.Data[0] == 0 ? "关" : "开";
                }
                if (KeyValue.Value.数据区域 == 数据区域.输入继电器1区)
                {
                    var command = new ModbusCommand(ModbusCommand.FuncReadInputDiscretes)
                    {
                        Offset = KeyValue.Value.StartAddress,
                        Count = KeyValue.Value.Length,
                        TransId = 0,
                    };
                    var result = modbusClient.ExecuteGeneric(_portClient, command);
                    组态屏.DicData[KeyValue.Key].Value = command.Data[0] == 0 ? "关" : "开";
                }
                if (KeyValue.Value.数据区域 == 数据区域.输入寄存器3区)
                {
                    var command = new ModbusCommand(ModbusCommand.FuncReadInputRegisters)
                    {
                        Offset = KeyValue.Value.StartAddress,
                        Count = KeyValue.Value.Length,
                        TransId = _transactionId++,
                    };
                    var result = modbusClient.ExecuteGeneric(_portClient, command);
                    if (result.Status == CommResponse.Ack)
                    {
                        switch (KeyValue.Value.数据类型)
                        {
                            case 数据类型.开关量:
                                组态屏.DicData[KeyValue.Key].Value = command.Data[0] == 0 ? "关" : "开";
                                break;
                            case 数据类型.无符号16位整型:
                                组态屏.DicData[KeyValue.Key].Value = command.Data[0].ToString();
                                break;
                            case 数据类型.有符号16位整型:
                                组态屏.DicData[KeyValue.Key].Value = command.Data[0].ToString();
                                break;
                            case 数据类型.无符号32位整型:
                            case 数据类型.有符号32位整型:
                                组态屏.DicData[KeyValue.Key].Value = (command.Data[0] * 256 + command.Data[1]).ToString();
                                break;
                            case 数据类型.单精度浮点数:
                                var data = new ushort[2] { command.Data[1], command.Data[0] };
                                float[] floatData = new float[data.Length / 2];
                                Buffer.BlockCopy(data, 0, floatData, 0, data.Length * 2);
                                组态屏.DicData[KeyValue.Key].Value = floatData[0].ToString();
                                break;
                            case 数据类型.字符串:
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (KeyValue.Value.数据区域 == 数据区域.输出寄存器4区)
                {
                    var command = new ModbusCommand(ModbusCommand.FuncReadMultipleRegisters)
                    {
                        Offset = KeyValue.Value.StartAddress,
                        Count = KeyValue.Value.Length,
                        TransId = 0,
                    };
                    var result = modbusClient.ExecuteGeneric(_portClient, command);
                    if (result.Status == CommResponse.Ack)
                    {
                        switch (KeyValue.Value.数据类型)
                        {
                            case 数据类型.开关量:
                                组态屏.DicData[KeyValue.Key].Value = command.Data[0] == 0 ? "关" : "开";
                                break;
                            case 数据类型.无符号16位整型:
                                组态屏.DicData[KeyValue.Key].Value = (command.Data[0]).ToString();
                                break;
                            case 数据类型.有符号16位整型:
                                组态屏.DicData[KeyValue.Key].Value = ((Int16)command.Data[0]).ToString();
                                break;
                            case 数据类型.无符号32位整型:
                                组态屏.DicData[KeyValue.Key].Value = ((UInt32)(((UInt32)command.Data[0]) << 16 | command.Data[1])).ToString();
                                break;
                            case 数据类型.有符号32位整型:
                                组态屏.DicData[KeyValue.Key].Value = ((Int32)(((Int32)command.Data[0]) << 16 | command.Data[1])).ToString();
                                break;
                            case 数据类型.单精度浮点数:
                                var data = new ushort[2] { command.Data[1], command.Data[0] };
                                float[] floatData = new float[data.Length / 2];
                                Buffer.BlockCopy(data, 0, floatData, 0, data.Length * 2);
                                组态屏.DicData[KeyValue.Key].Value = floatData[0].ToString();
                                break;
                            case 数据类型.字符串:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
