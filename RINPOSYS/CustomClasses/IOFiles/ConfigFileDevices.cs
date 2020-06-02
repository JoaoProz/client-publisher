using RINPOSYS.CustomClasses.Devices.GenericDevice;
using RINPOSYS.CustomClasses.Devices.LaserModule;
using RINPOSYS.CustomClasses.Devices.Servo;
using RINPOSYS.CustomClasses.Devices.UHFReader;
using RINPOSYS.CustomClasses.RFIDReads;
using RINPOSYS.CustomClasses.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Manages interaction with Devices config file
    /// </summary>
    internal static class ConfigFileDevices
    {
        /// <summary>
        /// config file filename
        /// </summary>
        internal const string Filename = "Devices.txt";

        /// <summary>
        /// Reads and validates each line of config file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="devices"></param>
        /// <param name="WriteLog"></param>
        internal static void ReadFile(string filePath, ref List<Device> devices, Action<string, int> WriteLog)
        {
            string[] lines = File.ReadAllLines(filePath);

            int deviceNumber = 1;

            string deviceType = null;

            Dictionary<string, string> deviceInfo = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                if (ConfigFilesMediator.IgnoreLine(line))
                {
                    if (deviceType != null)
                    {
                        CreateDevice(ref devices, deviceType, deviceInfo, ref deviceNumber, WriteLog);

                        deviceType = null;
                        deviceInfo.Clear();
                    }

                    continue;
                }

                LineValidations(ref deviceType, line);

                ReadLine(line, deviceInfo);
            }

            if (deviceType != null)
            {
                CreateDevice(ref devices, deviceType, deviceInfo, ref deviceNumber, WriteLog);
            }
        }

        /// <summary>
        /// Creates device and adds it to devices List
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="deviceType"></param>
        /// <param name="deviceInfo"></param>
        /// <param name="deviceNumber"></param>
        /// <param name="WriteLog"></param>
        private static void CreateDevice(ref List<Device> devices, string deviceType, Dictionary<string, string> deviceInfo, ref int deviceNumber, Action<string, int> WriteLog)
        {
            string id = "Device " + deviceNumber;
            string portStr;

            switch (deviceType)
            {
                case "Reader":

                    string beepStr;
                    string antPositionXStr;
                    string antPositionYStr;
                    string qValueStr;
                    string sessionStr;
                    string targetStr;
                    string powerStr;
                    string freqMinStr;
                    string freqMaxStr;

                    #region Validate Reader with all necessary parameters

                    if (!deviceInfo.TryGetValue("port", out portStr))
                    {
                        throw new Exception("\tDevice config -> Reader with port value not found");
                    }
                    else if (!deviceInfo.TryGetValue("beep", out beepStr))
                    {
                        throw new Exception("\tDevice config -> Reader with beep value not found");
                    }
                    else if (!deviceInfo.TryGetValue("antenna_pos_x (m)", out antPositionXStr))
                    {
                        throw new Exception("\tDevice config -> Reader with antenna_pos_x value not found");
                    }
                    else if (!deviceInfo.TryGetValue("antenna_pos_y (m)", out antPositionYStr))
                    {
                        throw new Exception("\tDevice config -> Reader with antenna_pos_y value not found");
                    }
                    else if (!deviceInfo.TryGetValue("q_value", out qValueStr))
                    {
                        throw new Exception("\tDevice config -> Reader with q_value not found");
                    }
                    else if (!deviceInfo.TryGetValue("session", out sessionStr))
                    {
                        throw new Exception("\tDevice config -> Reader with session value not found");
                    }
                    else if (!deviceInfo.TryGetValue("target", out targetStr))
                    {
                        throw new Exception("\tDevice config -> Reader with target value not found");
                    }
                    else if (!deviceInfo.TryGetValue("power (dBm)", out powerStr))
                    {
                        throw new Exception("\tDevice config -> Reader with power value not found");
                    }
                    else if (!deviceInfo.TryGetValue("freq_min (MHz)", out freqMinStr))
                    {
                        throw new Exception("\tDevice config -> Reader with freq_min value not found");
                    }
                    else if (!deviceInfo.TryGetValue("freq_max (MHz)", out freqMaxStr))
                    {
                        throw new Exception("\tDevice config -> Reader with freq_max value not found");
                    }

                    decimal minFreq = Convert.ToDecimal(freqMinStr);
                    decimal maxFreq = Convert.ToDecimal(freqMaxStr);

                    if (!RegionFrequencyConverter.ValidFrequency(minFreq))
                    {
                        throw new Exception("\tDevice config -> Reader with invalid freq_min value");
                    }
                    else if (!RegionFrequencyConverter.ValidFrequency(maxFreq))
                    {
                        throw new Exception("\tDevice config -> Reader with invalid freq_max value");
                    }
                    else if (maxFreq < minFreq)
                    {
                        throw new Exception("\tDevice config -> Reader cannot have freq_max < freq_min");
                    }

                    #endregion

                    #region create UHFReader

                    bool beep = beepStr == "1" ? true : false;

                    decimal pos_x = Convert.ToDecimal(antPositionXStr);
                    decimal pos_y = Convert.ToDecimal(antPositionYStr);

                    Antenna ant = new Antenna(deviceNumber, pos_x, pos_y);

                    UHFReader reader = new UHFReader(id, portStr, ant, beep, Convert.ToByte(powerStr), minFreq, maxFreq,  WriteLog);

                    reader.InvParams.QValue = Convert.ToByte(qValueStr);
                    reader.InvParams.Session = Convert.ToByte(sessionStr);
                    reader.InvParams.Target = Convert.ToByte(targetStr);

                    devices.Add(reader);

                    #endregion

                    deviceNumber++;

                    break;
                case "Laser":

                    string directionStr;
                    string offsetStr;

                    #region Validate Laser with all necessary parameters

                    if (!deviceInfo.TryGetValue("port", out portStr))
                    {
                        throw new Exception("\tDevice config -> Laser with port value not found");
                    }
                    else if (!deviceInfo.TryGetValue("direction", out directionStr))
                    {
                        throw new Exception("\tDevice config -> Laser with direction value not found");
                    }
                    else if (!deviceInfo.TryGetValue("offset (m)", out offsetStr))
                    {
                        throw new Exception("\tDevice config -> Laser with offset value not found");
                    }

                    #endregion

                    #region create LaserModule

                    decimal offset = Convert.ToDecimal(offsetStr);

                    if (directionStr == "X")
                    {
                        devices.Add(new LaserModule(id, portStr, LaserDirection.X, offset, WriteLog));
                    }
                    else if (directionStr == "Y")
                    {
                        devices.Add(new LaserModule(id, portStr, LaserDirection.Y, offset, WriteLog));
                    }

                    #endregion

                    deviceNumber++;

                    break;
                case "Servo":

                    #region Validate Servo with all necessary parameters

                    if (!deviceInfo.TryGetValue("port", out portStr))
                    {
                        throw new Exception("\tDevice config -> Servo with port value not found");
                    }

                    #endregion

                    #region create Servo

                    Servo servo = new Servo(id, portStr, WriteLog);

                    devices.Add(servo);

                    #endregion

                    deviceNumber++;

                    break;
            }
        }

        /// <summary>
        /// Generates default content for config file
        /// </summary>
        /// <returns>
        /// Return string with default content
        /// </returns>
        internal static string DefaultContent()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("#Examples");
            sb.AppendLine();
            sb.AppendLine("##Example UHFReader");
            sb.AppendLine("#type: <{Reader}>");
            sb.AppendLine("#port: <{COM[1;50]>");
            sb.AppendLine("#beep: <{0,1}>");
            sb.AppendLine("#antenna_pos_x (m): <{Number}>");
            sb.AppendLine("#antenna_pos_y (m): <{Number}>");
            sb.AppendLine("#q_value: <[0,15]>");
            sb.AppendLine("#session: <{0,1,2,3}>");
            sb.AppendLine("#target: <{0,1}>");
            sb.AppendLine("#power (dBm): <[0,26]>");
            sb.AppendLine("#freq_min (MHz): <[865.1,867.9]>");
            sb.AppendLine("#freq_max (MHz): <[865.1,867.9]>");
            sb.AppendLine();
            sb.AppendLine("##Example Laser Module");
            sb.AppendLine("#type: <{Laser}>");
            sb.AppendLine("#port: <{COM[1;50]>");
            sb.AppendLine("#direction: <{X,Y}>");
            sb.AppendLine("#offset (m): <{Number}>");
            sb.AppendLine();
            sb.AppendLine("##Example Servo");
            sb.AppendLine("#type: <{Servo}>");
            sb.AppendLine("#port: <{COM[1;50]>");
            sb.AppendLine();
            sb.AppendLine("#-------------------");
            sb.AppendLine();
            sb.AppendLine("#UHFReader");
            sb.AppendLine("type: Reader");
            sb.AppendLine("port: COM9");
            sb.AppendLine("beep: 0");
            sb.AppendLine("antenna_pos_x (m): 0");
            sb.AppendLine("antenna_pos_y (m): 0");
            sb.AppendLine("q_value: 4");
            sb.AppendLine("session: 0");
            sb.AppendLine("target: 0");
            sb.AppendLine("power (dBm): 26");
            sb.AppendLine("freq_min (MHz): 865.1");
            sb.AppendLine("freq_max (MHz): 867.9");
            sb.AppendLine();
            sb.AppendLine("##Laser Module");
            sb.AppendLine("#type: Laser");
            sb.AppendLine("#port: COM8");
            sb.AppendLine("#direction: X");
            sb.AppendLine("#offset (m): 0");
            sb.AppendLine();
            sb.AppendLine("##Servo");
            sb.AppendLine("#type: Servo");
            sb.AppendLine("#port: COM7");

            return sb.ToString();
        }

        /// <summary>
        /// Validates line
        /// </summary>
        /// <param name="type"></param>
        /// <param name="line"></param>
        private static void LineValidations(ref string type, string line)
        {
            string[] lineSplit = line.Split(':');

            if (lineSplit.Count() < 2)
            {
                /// line isn't in 'x: y' format

                throw new Exception("\tDevices parameters config -> Invalid line: '" + line + "'");
            }

            string key = lineSplit[0];
            string value = lineSplit[1].Trim();

            if (key == "type")
            {
                switch (value)
                {
                    case "Reader":
                    case "Laser":
                    case "Servo":
                        type = value;
                        break;
                    default: throw new Exception("\tDevice config -> Invalid type: '" + value + "'. Can only be '{Reader,Laser,Servo}'");
                }
            }
            else if (key == "port")
            {
                if (value.Length < 4 || value.Length > 5)
                {
                    /// line doesn't follow COM format 'COMx'

                    throw new Exception("\tDevice config -> Invalid port: '" + value + "'. Should follow example 'COM6'");
                }
            }
            else if (key == "direction")
            {
                if (value != "X" && value != "Y")
                {
                    /// invalid value for direction

                    throw new Exception("\tDevice config -> Invalid direction: '" + value + "'. Can only be '{X,Y}'");
                }
            }
            else if (key == "beep")
            {
                if (value != "0" && value != "1")
                {
                    /// invalid value for beep

                    throw new Exception("\tDevice config -> Invalid beep: '" + value + "'. Can only be '{0,1}'");
                }
            }
            else if (key == "antenna_pos_x (m)")
            {
                try
                {
                    Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    /// antenna_pos_x is NaN

                    throw new Exception("\tDevice config -> Invalid antenna_pos_x: '" + value + "'. Should follow example '1.6'");
                }
            }
            else if (key == "antenna_pos_y (m)")
            {
                try
                {
                    Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    /// antenna_pos_y is NaN

                    throw new Exception("\tDevice config -> Invalid antenna_pos_y: '" + value + "'. Should follow example '1.6'");
                }
            }
            else if (key == "q_value")
            {
                try
                {
                    int q = Convert.ToInt32(value);

                    if (q < 0 || q > 15)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    /// invalid value for q_value

                    throw new Exception("\tDevice config -> Invalid q_value: '" + value + "'. Should follow example '4'");
                }
            }
            else if (key == "session")
            {
                try
                {
                    int q = Convert.ToInt32(value);

                    if (q < 0 || q > 3)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    /// invalid value for session

                    throw new Exception("\tDevice config -> Invalid session: '" + value + "'. Should follow example '{0,1,2,3}'");
                }
            }
            else if (key == "target")
            {
                if (value != "0" && value != "1")
                {
                    /// invalid value for target

                    throw new Exception("\tDevice config -> Invalid target: '" + value + "'. Can only have a value of '{0,1}'");
                }
            }
            else if (key == "power (dBm)")
            {
                try
                {
                    int p = Convert.ToInt32(value);

                    if (p < 0 || p > 26)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    /// invalid value for power

                    throw new Exception("\tDevice config -> Invalid power: '" + value + "'. Should follow example '26'");
                }
            }
            else if (key == "freq_min (MHz)")
            {
                try
                {
                    decimal f = Convert.ToDecimal(value);

                    if (f < 865.1m || f > 867.9m)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                { 
                    /// invalid value for frequencies

                    throw new Exception("\tDevice config -> Invalid minimum frequency: '" + value + "'. Valid frequencies => '[865.1;867.9]'");
                }
            }
            else if (key == "freq_max (MHz)")
            {
                try
                {
                    decimal f = Convert.ToDecimal(value);

                    if (f < 865.1m || f > 867.9m)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    /// invalid value for frequencies

                    throw new Exception("\tDevice config -> Invalid maximum frequency: '" + value + "'. Valid frequencies => '[865.1;867.9]'");
                }
            }
            else if (key == "offset (m)")
            {
                try
                {
                    Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    /// offset is NaN

                    throw new Exception("\tDevice config -> Invalid offset: '" + value + "'. Should follow example '1.6'");
                }
            }
        }

        /// <summary>
        /// Reads line and updates device information
        /// </summary>
        /// <param name="line"></param>
        /// <param name="deviceInfo"></param>
        private static void ReadLine(string line, Dictionary<string, string> deviceInfo)
        {
            string[] lineSplit = line.Split(':');
            
            string key = lineSplit[0];
            string value = lineSplit[1].Trim();

            deviceInfo.Add(key, value);
        }
    }
}
