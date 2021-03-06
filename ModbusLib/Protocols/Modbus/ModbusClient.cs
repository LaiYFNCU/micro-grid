
/*
 * Copyright 2012 Mario Vernari (http://cetdevelop.codeplex.com/)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace ModbusLib.Protocols
{
    /// <summary>
    /// Modbus client proxy
    /// </summary>
    public class ModbusClient
        : IProtocol
    {
        public ModbusClient(IProtocolCodec codec)
        {
            Codec = codec;
        }

        /// <summary>
        /// The reference to the codec to be used
        /// </summary>
        public IProtocolCodec Codec { get; private set; }

        public event ModbusCommand.OutgoingData OutgoingData;
        public event ModbusCommand.IncommingData IncommingData;
        public void OnOutgoingData(byte[] data)
        {
            if (OutgoingData != null) OutgoingData(data);
        }

        public void OnIncommingData(byte[] data, int len)
        {
            if (IncommingData != null) IncommingData(data, len);
        }

        /// <summary>
        /// The address of the remote device
        /// </summary>
        public byte Address { get; set; }



        /// <summary>
        /// Entry-point for submitting any command
        /// </summary>
        /// <param name="port">The client port for the transport</param>
        /// <param name="command">The command to be submitted</param>
        /// <returns>The result of the query</returns>
        public CommResponse ExecuteGeneric(
            ICommClient port,
            ModbusCommand command)
        {
            var data = new ClientCommData(this);
            data.UserData = command;
            Codec.ClientEncode(data);

            var rVal = port.Query(data);
            if (data.OutgoingData != null)
                OnOutgoingData(data.OutgoingData.ToArray());
            if (data.IncomingData != null)
                OnIncommingData(data.IncomingData.ToArray(), data.IncomingData.Length);
            return rVal;
        }

        public void ExecuteAsync(
            ICommClient port,
            ModbusCommand command)
        {
            var data = new ClientCommData(this);
            data.UserData = command;
            Codec.ClientEncode(data);
            port.QueryAsync(data);
        }

    }
}
