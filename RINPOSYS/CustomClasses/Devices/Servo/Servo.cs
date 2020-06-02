using RINPOSYS.CustomClasses.Devices.GenericDevice;
using System;

namespace RINPOSYS.CustomClasses.Devices.Servo
{
    /// <summary>
    /// Provides control on a servo with connection/disconnection as well as scanning distances
    /// </summary>
    public class Servo : DeviceWithSerialPortControl
    {
        /// <summary>
        /// Indicates angle returned by Servo
        /// </summary>
        /// <remarks>
        /// When initialized, value is 0, which means that Servo start with its angle at 0º
        /// Any other value means that the Servo has moved and thus, changed its angle value
        /// </remarks>
        public int Angle { get; private set; } = 0;

        /// <summary>
        /// Shows device type and its port in a string format
        /// </summary>
        /// <remarks>
        /// Used only for logging
        /// </remarks>
        public override string Identifier { get => "Servo" + " (" + PortStr + ") "; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="port"></param>
        /// <param name="WriteLog"></param>
        public Servo(string id, string port, Action<string, int> WriteLog) : base(id, port, DeviceBaudRate.Servo, DeviceBaudRate.ServoStr, WriteLog)
        {

        }

        /// <summary>
        /// Connects to Servo
        /// </summary>
        /// <returns>
        /// true: Connection successful
        /// false: Failed connection
        /// </returns>
        public override bool Connect()
        {
            try
            {
                /// Open Port
                OpenPort();

                /// Send Command 'Start' to Servo
                SendData(ServoCommands.Start);

                /// Get response from Servo
                string data = ReadData();

                /// Close Port
                ClosePort();

                Connected = true;

                WriteLog(Identifier + "connected successfully", 0);
            }
            catch (Exception ex)
            {
                WriteLog(Identifier + "failed to connect: " + ex.Message, 1);
                return false;
            }
            finally
            {
                Port.Dispose();
            }

            return true;
        }

        /// <summary>
        /// Disconnects Servo
        /// </summary>
        /// <returns>
        /// true: Disconnection successful
        /// false: Failed disconnection
        /// </returns>
        public override bool Disconnect()
        {
            WriteLog(Identifier + "disconnected successfully", 0);

            return true;
        }

        /// <summary>
        /// Opens communication, tells Servo to move, gets new angle from Servo, closes communication after
        /// </summary>
        /// <param name="servo"></param>
        public static void DoActionProcess(Servo servo)
        {
            try
            {
                /// Open Port
                servo.OpenPort();

                /// Send Command 'Change' to Servo
                servo.SendData(ServoCommands.Change);

                /// Get response from Servo
                string data = servo.ReadData();

                /// Get angle from response
                servo.Angle = Convert.ToInt32(data);

                /// Close Port
                servo.ClosePort();

                WriteLog(servo.Identifier + servo.Angle, 0);
            }
            catch (Exception ex)
            {
                WriteLog(servo.Identifier + ex.Message, 1);
            }
            finally
            {
                servo.Port.Dispose();
            }
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns>
        /// Returns string with useful parameters
        /// </returns>
        public override string ToString()
        {
            return String.Format("Servo: {0} | BR: {1}",
                PortStr,
                BaudRateStr);
        }
    }
}
