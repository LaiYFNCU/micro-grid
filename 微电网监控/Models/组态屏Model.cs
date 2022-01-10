using ModbusLib.Protocols;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using 微电网监控.Servers;

namespace 微电网监控.Models
{
    public class 组态屏Model : BindableBase
    {
        private Dictionary<string, StringClass> _dicData;
        public Dictionary<string, 数据信息> 配置文件内容 { get; set; }
        public 组态屏Client client;
        public KeyValuePair<string, StringClass> SelectedItem { get; set; }

        public 组态屏Model(string name, IPAddress iPAddress, int port, Dictionary<string, 数据信息> 配置文件内容)
        {
            Name = name;
            IP = iPAddress;
            Port = port;
            this.配置文件内容 = 配置文件内容;
            DicData = new Dictionary<string, StringClass>();
            foreach (var str in 配置文件内容.Keys)
            {
                _dicData.Add(str, new StringClass(str, "default"));
            }
        }

        public string Name { get; set; }
        public IPAddress IP { get; set; }
        public int Port { get; set; }

        public Dictionary<string, StringClass> DicData
        {
            get { return _dicData; }
            set { SetProperty(ref _dicData, value); }
        }
    }
}
