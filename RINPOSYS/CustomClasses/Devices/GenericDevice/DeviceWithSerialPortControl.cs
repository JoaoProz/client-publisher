using System;
using System.IO.Ports;

namespace RINPOSYS.CustomClasses.Devices.GenericDevice
{
    /// <summary>
    /// Controls opening/closing of Ports as well as Sending/Reading data from communication buffer
    /// </summary>
    public abstract class DeviceWithSerialPortControl : Device
    {
        /// <summary>
        /// Serial Port
        /// </summary>
        protected SerialPort Port { get; set; }

        /// <summary>
        /// Device Baudrate
        /// </summary>
        protected int BaudRate { get; }

        /// <summary>
        /// Necessary amount of time in seconds to timeout any Port operation on this class
        /// </summary>
        private const int readTimeout = 10000;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="port"></param>
        /// <param name="baudRate"></param>
        /// <param name="baudRateStr"></param>
        /// <param name="WriteLog"></param>
        public DeviceWithSerialPortControl(string id, string port, int baudRate, string baudRateStr, Action<string, int> WriteLog) : base(id, port, baudRateStr, WriteLog)
        {
            BaudRate = baudRate;
        }

        /// <summary>
        /// Opens Serial Port
        /// </summary>
        protected void OpenPort()
        {
            /// Initialize SerialPort
            Port = new SerialPort()
            {
                PortName = PortStr,
                BaudRate = BaudRate,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                Handshake = Handshake.None,

                ReadTimeout = readTimeout
            };

            /// Open SerialPort
            Port.Open();
        }

        /// <summary>
        /// Closes Serial Port
        /// </summary>
        protected void ClosePort()
        {
            if (Port != null && Port.IsOpen)
            {
                /// Close SerialPort
                Port.Close();
            }

        }

        /// <summary>
        /// Read data from buffer 
        /// </summary>
        /// <returns>
        /// Returns string with response
        /// </returns>
        protected virtual string ReadData()
        {
            return Port.ReadLine();
        }

        /// <summary>
        /// Send data to buffer
        /// </summary>
        /// <param name="command"></param>
        protected virtual void SendData(char command)
        {
            Port.WriteLine("" + command);
        }
    }
}
