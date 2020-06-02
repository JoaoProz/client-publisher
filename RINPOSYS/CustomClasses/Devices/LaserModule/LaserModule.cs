using RINPOSYS.CustomClasses.Devices.GenericDevice;
using RINPOSYS.CustomClasses.Utils;
using System;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace RINPOSYS.CustomClasses.Devices.LaserModule
{
    /// <summary>
    /// Provides control on a Laser module with connection/disconnection as well as scanning distances
    /// </summary>
    public class LaserModule : DeviceWithSerialPortControl
    {
        /// <summary>
        /// Laser module direction
        /// </summary>
        public LaserDirection Direction { get; set; }

        /// <summary>
        /// Indicates Read distance by Laser module
        /// </summary>
        /// <remarks>
        /// When initialized, value is decimal.MinValue, which means that Laser module doesn't have a distance read yet
        /// Any other value means that the Laser module has gotten a distance read
        /// </remarks>
        public decimal Distance { get; set; } = decimal.MinValue;

        /// <summary>
        /// Offset position of Laser module
        /// </summary>
        public decimal Offset { get; private set; }

        /// <summary>
        /// Shows device type and its port in a string format
        /// </summary>
        /// <remarks>
        /// Used only for logging
        /// </remarks>
        public override string Identifier { get => "Laser " + Direction + " (" + PortStr + ") "; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="port"></param>
        /// <param name="direction"></param>
        /// <param name="offset"></param>
        /// <param name="WriteLog"></param>
        public LaserModule(string id, string port, LaserDirection direction, decimal offset, Action<string, int> WriteLog) : base(id, port, DeviceBaudRate.Laser, DeviceBaudRate.LaserStr, WriteLog)
        {
            Direction = direction;

            Offset = offset;
        }

        /// <summary>
        /// Connects to Laser Module
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

                /// Send Command 'Open' to Laser module
                SendData(LaserCommands.Open);

                /// Get response from Laser module
                string response = ReadData();

                /// Send Command 'Close' to Laser module
                SendData(LaserCommands.Close);

                /// Get response from Laser module
                response = ReadData();

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
        /// Disconnects Laser module
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
        /// Read data from buffer 
        /// </summary>
        /// <returns>
        /// Returns string with response
        /// Returns exception if an error occurred
        /// </returns>
        protected override string ReadData()
        {
            /* THE RECEIVED STRING IS FORMATED AS:
             *  <MM>:<T><O>.<te><h><th>m,<SQ0><SQ1><SQ2><SQ3>
             *  MM: MEASUREMENT MODE
             *  T: TENS
             *  O: ONES
             *  te: TENTHS
             *  h: HUNDREDTHS
             *  th: THOUSANDTHS
             *  SQ: SIGNAL QUALITY
             *  
             *  -> Smaller SQ value stands for more reliable distance result
             *  -> If the distance is no more than 10.000 m, the tens digit will be replace by a space character
             */

            string response = "";

            /// Get response from Laser module
            response = Port.ReadLine();

            /// Identifies response type (information/error)
            string resType = response.Substring(2, 2);

            /// If error
            if (resType == "Er")
            {
                string errStr = response.Substring(2, 4);

                /// Get error code
                int errCode = Convert.ToInt32(errStr.Substring(2, 2));

                StringBuilder message = new StringBuilder();
                message.AppendFormat("{0}: {1}", errStr, LaserLogMessages.GetReturnCodeDesc(errCode));

                throw new LaserException(message.ToString(), errCode);
            }

            return response;
        }

        /// <summary>
        /// Gets Status from Laser Module (Temperature and voltage)
        /// </summary>
        /// <returns>
        /// Returns string with temperature and voltage
        /// </returns>
        public string GetLaserStatus()
        {
            try
            {
                /// Open Port 
                OpenPort();

                /// Send Command 'Status' to Laser module
                SendData(LaserCommands.Status);

                /// Get response from Laser module
                string s = ReadData();

                WriteLog(Identifier + "Get Status: (" + s.TrimEnd() + ")", 0);

                ClosePort();

                return s;
            }
            catch (Exception ex)
            {
                string s = Identifier + "Get Status: " + ex.Message;
                WriteLog(s, 1);
                return "F - See logs";
            }
            finally
            {
                Port.Dispose();
            }
        }

        /// <summary>
        /// Turns laser infrared LED ON or OFF 
        /// </summary>
        /// <param name="turnOn"></param>
        public void TurnLaser(bool turnOn)
        {
            try
            {
                /// Open Port
                OpenPort();

                if (turnOn)
                {
                    ///Turn Laser infrared LED ON
                    SendData(LaserCommands.Open);
                }
                else
                {
                    ///Turn Laser infrared LED OFF
                    SendData(LaserCommands.Close);
                }

                /// Get response from Laser module
                ReadData();

                WriteLog(Identifier + "laser " + (turnOn ? "ON" : "OFF"), 0);

                /// Close Port
                ClosePort();

            }
            catch (Exception ex)
            {
                string s = Identifier + ex.Message;
                WriteLog(s, 1);
            }
            finally
            {
                Port.Dispose();
            }
        }

        /// <summary>
        /// Gets distance read from laser
        /// </summary>
        /// <param name="response"></param>
        /// <returns>
        /// Returns distance read from laser
        /// </returns>
        private decimal GetDistanceFromRead(string response)
        {
            string str = response.Substring(2).Substring(0, 6);

            decimal value = Convert.ToDecimal(str);

            return value;
        }

        /// <summary>
        /// Applies offset to obtained distance
        /// </summary>
        /// <param name="distance"></param>
        private void ApplyLaserModuleOffset()
        {
            if (Offset < 0)
            {
                /// if Offset is negative, transform Distance value to a negative one

                Distance *= -1;
            }

            Distance += Offset;
        }

        /// <summary>
        /// Opens communication, then gets new distance read from laser module, closing communication after
        /// </summary>
        /// <param name="laser"></param>
        public static void DoScanProcess(LaserModule laser)
        {
            /// Interval between sending 'D' command and after received response from the 'D' command
            int interval = 1000;

            try
            {
                /// Open Port
                laser.OpenPort();

                /// Send Command 'AutoMode' to Laser module
                laser.SendData(LaserCommands.AutoMode);

                Thread.Sleep(interval/2);

                /// Get response from Laser module
                string response = laser.ReadData();

                Thread.Sleep(interval/2);

                /// Get distance from response
                laser.Distance = laser.GetDistanceFromRead(response);

                /// Apply offset to obtained distance
                laser.ApplyLaserModuleOffset();

                WriteLog(laser.Identifier + response.TrimEnd(), 0);
            }
            catch (LaserException ex)
            {
                int errCode = ex.ErrCode;

                WriteLog(laser.Identifier + ex.Message, 1);

                if (errCode == 1 || errCode == 4)
                {
                    /// 1: Power input too low, power voltage should >= 2.0V
                    /// 4: Module temperature is too high(> +40℃)
                    
                    /// Pause scan process for 1 minute
                    Thread.Sleep(60000);
                }
            }
            catch (Exception ex)
            {
                WriteLog(laser.Identifier + ex.Message, 1);
            }
            finally
            {
                /// Close Port
                laser.ClosePort();
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
            return String.Format("Laser: {0} | BR: {1} | Direction: {2} | Offset: {3}m",
                PortStr,
                BaudRateStr,
                Direction,
                Offset);
        }
    }
}
