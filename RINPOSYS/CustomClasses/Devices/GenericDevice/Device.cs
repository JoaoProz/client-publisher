using RINPOSYS.CustomClasses.Devices.DeviceInterfaces;
using System;

namespace RINPOSYS.CustomClasses.Devices.GenericDevice
{
    /// <summary>
    /// Represents a physical Device and provides connection actions 
    /// </summary>
    public abstract class Device : IConnectable
    {
        /// <summary>
        /// Device identifier
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// Device COM port in string format
        /// </summary>
        public string PortStr { get; set; }

        /// <summary>
        /// Device BaudRate
        /// </summary>
        public string BaudRateStr { get; set; }

        /// <summary>
        /// Used for logging purposes
        /// </summary>
        protected static Action<string, int> WriteLog;

        /// <summary>
        /// Shows device type and its port in a string format
        /// </summary>
        /// <remarks>
        /// Used only for logging purposes
        /// </remarks>
        public virtual string Identifier { get => "Device(" + PortStr + ")"; }

        /// <summary>
        /// Indicates the Device connection state
        /// </summary>
        public bool Connected { get; set; } = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="portStr"></param>
        /// <param name="baudRateStr"></param>
        /// <param name="writeLog"></param>
        public Device(string id, string portStr, string baudRateStr, Action<string, int> writeLog)
        {
            ID = id;
            PortStr = portStr;
            BaudRateStr = baudRateStr;
            
            WriteLog = writeLog;
        }

        /// <summary>
        /// Connects to Device
        /// </summary>
        /// <returns>
        /// true: Connection successful;
        /// false: Failed connection.
        /// </returns>
        public abstract bool Connect();

        /// <summary>
        /// Disconnects Device
        /// </summary>
        /// <returns>
        /// true: Disconnection successful;
        /// false: Failed disconnection.
        /// </returns>
        public abstract bool Disconnect();
    }
}
