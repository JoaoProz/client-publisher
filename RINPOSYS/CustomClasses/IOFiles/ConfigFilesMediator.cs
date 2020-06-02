using RINPOSYS.CustomClasses.Devices.GenericDevice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Manages interaction with config files
    /// </summary>
    class ConfigFilesMediator
    {
        /// <summary>
        /// Directory
        /// </summary>
        private const string ConfigDirectory = "RINPOSYS";

        /// <summary>
        /// Sub-directory
        /// </summary>
        private const string SubConfigDirectory = "Config Files";

        /// <summary>
        /// Sub-directory
        /// </summary>
        private const string SubLogsDirectory = "Logs";
        
        ///// <summary>
        ///// Path to logs file
        ///// </summary>
        //private const string LogsFile = "RINPOSYS Log";

        /// <summary>
        /// Path to config files sub-directory
        /// </summary>
        private string path;

        /// <summary>
        /// Path to logs sub-directory
        /// </summary>
        private string logsPath;

        /// <summary>
        /// Updates content in log component of type RichTextBox
        /// </summary>
        private readonly Action<string, int> WriteLog;

        /// <summary>
        /// Mutex used only for synchronization of logs file access.
        /// </summary>
        private static Mutex logsMutex = new Mutex();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="WriteLog"></param>
        /// <remarks>
        /// Creates config files directory if they don't exist
        /// </remarks>
        public ConfigFilesMediator(Action<string, int> WriteLog)
        {
            this.WriteLog = WriteLog;

            ConfigDirectoryInit(out path, out logsPath);
        }

        #region Treat files

        /// <summary>
        /// Opens specified configuration configFileType file
        /// </summary>
        /// <param name="configFileType"></param>
        public void OpenConfigFile(ConfigFileType configFileType)
        {
            string filePath;

            switch (configFileType)
            {
                case ConfigFileType.MMParameters:
                    filePath = ConfigFileInit(path, ConfigFileMMParameters.Filename, ConfigFileMMParameters.DefaultContent());
                    break;
                case ConfigFileType.Devices:
                    filePath = ConfigFileInit(path, ConfigFileDevices.Filename, ConfigFileDevices.DefaultContent());
                    break;
                case ConfigFileType.Notes:
                    filePath = ConfigFileInit(path, ConfigFileNotes.Filename, ConfigFileNotes.DefaultContent());
                    break;
                case ConfigFileType.MySQL:
                    filePath = ConfigFileInit(path, ConfigFileMySQL.Filename, ConfigFileMySQL.DefaultContent());
                    break;
                case ConfigFileType.EPCDatasets:
                    filePath = ConfigFileInit(path, ConfigFileEPCs.Filename, ConfigFileEPCs.DefaultContent());
                    break;
                case ConfigFileType.Log:

                    string date = DateTime.Now.ToShortDateString().Replace('/', '-');

                    filePath = Path.Combine(logsPath, String.Format("{0}.log", date));

                    break;

                default:
                    return;
            }

            /// Open file
            Process.Start(filePath);
        }

        /// <summary>
        /// Creates Mathematical Model parameters config file if it doesn't exist, and updates Mathematical Model parameters with the values from config file
        /// </summary>
        public void TreatMMParametersFile()
        {
            /// Creates Mathematical Model parameters config file with default content if it doesn't exist
            string filePath = ConfigFileInit(path, ConfigFileMMParameters.Filename, ConfigFileMMParameters.DefaultContent());

            /// Reads each lines from config file
            ConfigFileMMParameters.ReadFile(filePath);
        }

        /// <summary>
        /// Creates Devices config file if it doesn't exist, and updates list of Devices with the values from config file
        /// </summary>
        /// <returns>
        /// Returns the list of Devices
        /// </returns>
        public List<Device> TreatDevicesFile()
        {
            /// Creates Devices parameters config file with default content if it doesn't exist
            string filePath = ConfigFileInit(path, ConfigFileDevices.Filename, ConfigFileDevices.DefaultContent());

            /// Initialization of a list of Devices
            List<Device> devices = new List<Device>();

            /// Reads each lines from config file
            ConfigFileDevices.ReadFile(filePath, ref devices, WriteLog);

            return devices;
        }

        /// <summary>
        /// Creates Notes config file if it doesn't exist, and updates notes with the values from config file
        /// </summary>
        /// <returns>
        /// Returns notes
        /// </returns>
        public string TreatNotesFile()
        {
            /// Creates Notes config file with default content if it doesn't exist
            string filePath = ConfigFileInit(path, ConfigFileNotes.Filename, ConfigFileNotes.DefaultContent());

            string notes = "";

            /// Reads each lines from config file
            ConfigFileNotes.ReadFile(filePath, ref notes);

            return notes;
        }

        /// <summary>
        /// Creates MySQL config file if it doesn't exist, and updates a connection string with the values from config file
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>
        /// Return connection string
        /// </returns>
        public string TreatMySQLFile(ref string tableName)
        {
            /// Creates MySQL config file with default content if it doesn't exist
            string filePath = ConfigFileInit(path, ConfigFileMySQL.Filename, ConfigFileMySQL.DefaultContent());

            string connStr = "";

            /// Reads each lines from config file
            ConfigFileMySQL.ReadFile(filePath, ref tableName, ref connStr);

            return connStr;
        }

        public void TreatEPCDataSets()
        {
            /// Creates EPCDatasets config file with default content if it doesn't exist
            string filePath = ConfigFileInit(path, ConfigFileEPCs.Filename, ConfigFileEPCs.DefaultContent());

            /// Reads each lines from config file
            ConfigFileEPCs.ReadFile(filePath);
        }

        #endregion

        #region configs

        /// <summary>
        /// Resets Config Files folder
        /// </summary>
        public void ResetConfigFiles()
        {
            string currentDirName = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            path = Path.Combine(currentDirName, ConfigDirectory, SubConfigDirectory);

            /// Removes Config Files folder
            Directory.Delete(path, true);

            /// Create Config Files folder
            ConfigDirectoryInit(out path, out logsPath);
        }

        /// <summary>
        /// Creates directories of RINPOSYS if they don't exist already
        /// </summary>
        /// <param name="path"></param>
        /// <param name="logsPath"></param>
        /// <remarks>
        /// Updates path vareable
        /// </remarks>
        private static void ConfigDirectoryInit(out string path, out string logsPath)
        {
            string currentDirName = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            path = Path.Combine(currentDirName, ConfigDirectory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(@"" + currentDirName + @"\" + ConfigDirectory);
            }

            path = Path.Combine(path, SubConfigDirectory);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(@"" + currentDirName + @"\" + ConfigDirectory + @"\" + SubConfigDirectory);
            }

            logsPath = Path.Combine(currentDirName, ConfigDirectory, SubLogsDirectory);
            if (!Directory.Exists(logsPath))
            {
                Directory.CreateDirectory(@"" + currentDirName + @"\" + ConfigDirectory + @"\" + SubLogsDirectory);
            }
        }

        /// <summary>
        /// Create config file if it doesn't exist in path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filename"></param>
        /// <param name="defaultContent"></param>
        /// <returns>
        /// Returns file path
        /// </returns>
        private static string ConfigFileInit(string path, string filename, string defaultContent)
        {
            string filePath = Path.Combine(path, filename);

            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, defaultContent);
            }

            return filePath;
        }

        /// <summary>
        /// Identifies if line should be ignored
        /// </summary>
        /// <param name="line"></param>
        /// <returns>
        /// Returns true if line should be ignored
        /// Returns false if line shouldn't be ignored
        /// </returns>
        internal static bool IgnoreLine(string line)
        {
            if (line.Length == 0)
            {
                /// line is empty

                return true;
            }

            if (line[0] == '#')
            {
                /// line is considered a 'comment'

                return true;
            }

            return false;
        }

        /// <summary>
        /// Appends strLog to logs file
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteLogToFile(string strLog)
        {
            string date = DateTime.Now.ToShortDateString().Replace('/', '-');
            string time = DateTime.Now.ToLongTimeString();

            string filePath = Path.Combine(logsPath, String.Format("{0}.log", date) );

            try
            {
                logsMutex.WaitOne();

                if (!File.Exists(filePath))
                {
                    /// file doesn't exit
                    using (File.Create(filePath))
                    {

                        /// Get a FileSecurity object that represents the 
                        /// current security settings.
                        FileSecurity fSecurity = File.GetAccessControl(filePath);

                        /// Add FullControl to Users group
                        fSecurity.AddAccessRule(new FileSystemAccessRule(
                           new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null),
                           FileSystemRights.FullControl,
                           AccessControlType.Allow));

                        /// Set FullControl to Users group to file
                        File.SetAccessControl(filePath, fSecurity);
                    }
                }

                File.AppendAllText(filePath, String.Format("{0} - {1}{2}", time, strLog, Environment.NewLine));
            }
            finally
            {
                logsMutex.ReleaseMutex();
            }

        }

        #endregion
    }
}
