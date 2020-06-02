using RINPOSYS.CustomClasses.Algorithm;
using RINPOSYS.CustomClasses.DBConnectors;
using RINPOSYS.CustomClasses.RFIDReads;
using RINPOSYS.CustomClasses.ExcelInterop;
using System;
using System.Collections.Generic;
using System.Threading;
using RINPOSYS.CustomClasses.Utils;
using RINPOSYS.CustomClasses.Devices.UHFReader;
using RINPOSYS.CustomClasses.Devices.LaserModule;
using RINPOSYS.CustomClasses.Devices.Servo;
using RINPOSYS.CustomClasses.Devices.GenericDevice;
using RINPOSYS.CustomClasses.IOFiles;
using System.Globalization;

namespace RINPOSYS.CustomClasses
{
    /// <summary>
    /// Manages all data necessary for the localization system
    /// </summary>
    class DataController
    {
        /// <summary>
        /// Represents notes/observations about current setup.
        /// <para>Ex: Warehouse location.</para>
        /// </summary>
        public string notes;

        /// <summary>
        /// List of devices (UHFReader/Laser/Servo).
        /// </summary>
        public List<Device> Devices { get; set; }

        /// <summary>
        /// Class that deals with MySQL connection and interaction.
        /// </summary>
        public MySQLMediator mySQLMediator;

        /// <summary>
        /// Class that deals with configuration files.
        /// </summary>
        private ConfigFilesMediator configFilesMediator;

        /// <summary>
        /// Updates content in log component of type RichTextBox. 
        /// </summary>
        private readonly Action<string, int> WriteLog;

        /// <summary>
        /// Updates grid of MetaTags in form.
        /// </summary>
        private readonly Action<MetaTag> UpdateUIGridMetaTagsDel;

        /// <summary>
        /// Clears content on grid of MetaTags in form.
        /// </summary>
        private readonly Action ClearUIGridMetaTagsDel;

        /// <summary>
        /// Removes MetaTag from grid of MetaTags in form.
        /// </summary>
        private readonly Action<MetaTag> RemoveFromUIGridMetaTagsDel;

        /// <summary>
        /// Updates grid of Tags in form.
        /// </summary>
        private readonly Action<List<Tag>> UpdateUIGridTagsDel;

        /// <summary>
        /// Mutex used only for synchronization of each UHFReader's read process.
        /// </summary>
        private static Mutex readersMutex = new Mutex();

        /// <summary>
        /// Mutex used for synchronization of Laser's or Servo's process, as well as for the algorithm's process.
        /// </summary>
        private static Mutex dwspcMutex = new Mutex();

        /// <summary>
        /// Represents if read process is active or not.
        /// </summary>
        public static bool onReads = false;

        /// <summary>
        /// Represents if process is using lasers.
        /// </summary>
        private static bool usingLasers = false;

        /// <summary>
        /// Represents if process is using a servo.
        /// </summary>
        private static bool usingServo = false;

        /// <summary>
        /// Reader counter
        /// </summary>
        /// <remarks>
        /// Used to identify the 1st and 2nd readers
        /// </remarks>
        private static int readerCounter = 1;

        /// <summary>
        /// Flag that represents if Mathematical Model should be used
        /// </summary>
        public static bool useMM = false;

        /// <summary>
        /// Flag that represents if TDM delta read should be used
        /// </summary>
        public static bool useDeltaRead = false;

        /// <summary>
        /// TDM Delta read duration
        /// </summary>
        public static int deltaRead = 0;

        /// <summary>
        /// Running threads
        /// </summary>
        private List<Thread> threadsUsed = new List<Thread>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="writeLog"></param>
        /// <param name="updateUIGridMetaTagsDel"></param>
        /// <param name="removeFromUIGridMetaTagsDel"></param>
        /// <param name="clearUIGridMetaTagsDel"></param>
        /// <param name="updateUIGridTagsDel"></param>
        public DataController(
            Action<string, int> writeLog,
            Action<MetaTag> updateUIGridMetaTagsDel,
            Action<MetaTag> removeFromUIGridMetaTagsDel,
            Action clearUIGridMetaTagsDel,
            Action<List<Tag>> updateUIGridTagsDel)
        {
            WriteLog = writeLog;
            UpdateUIGridMetaTagsDel = updateUIGridMetaTagsDel;
            RemoveFromUIGridMetaTagsDel = removeFromUIGridMetaTagsDel;
            ClearUIGridMetaTagsDel = clearUIGridMetaTagsDel;
            UpdateUIGridTagsDel = updateUIGridTagsDel;

            /// Used to workaround the replacing of '.' to ',' when converting strings into floating-point numbers
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            /// Initializes Devices list 
            Devices = new List<Device>();

            /// Initializes Config files Mediator
            configFilesMediator = new ConfigFilesMediator(WriteLog);

            ///// Initializes config files manager and loads all configuration files
            //LoadConfigFiles();

            ///// Tests if MySQL connection is successful
            //TestMySQLConnection();
        }

        #region Config Files interactions

        /// <summary>
        /// Resets Config Files folder and loads all Config Files
        /// </summary>
        public void ResetConfigFiles()
        {
            /// Resets Config Files folder
            configFilesMediator.ResetConfigFiles();

            /// Loads all Config Files
            LoadConfigFiles();
        }

        /// <summary>
        /// Loads 4 configuration files:<para />
        ///     1 - Mathematical Model Parameters configuration file;<para />
        ///     2 - Devices configuration file;<para />
        ///     3 - Notes configuration file;<para />
        ///     4 - MySQL configuration file.
        /// </summary>
        public void LoadConfigFiles()
        {
            WriteLog("Loading configuration files...", 0);

            configFilesMediator = new ConfigFilesMediator(WriteLog);

            LoadMMParametersConfigFile();
            LoadDevicesConfigFile();
            LoadNotesFromFile();
            LoadMySQLConfigFile();
            LoadEPCDatasetsConfigFile();
        }

        /// <summary>
        /// Gets parameter values used in the mathematic model from Mathematical Model Parameters configuration file.
        /// </summary>
        public void LoadMMParametersConfigFile()
        {
            try
            {
                configFilesMediator.TreatMMParametersFile();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, 1);
                return;
            }

            string strLog = "\tLoaded Mathematical Model parameters configuration file successfully";
            WriteLog(strLog, 0);
        }

        /// <summary>
        /// Gets devices information from Devices configuration file.
        /// </summary>
        public void LoadDevicesConfigFile()
        {
            /// Disconnect any connected device
            foreach (Device d in Devices)
            {
                if (d.Connected)
                {
                    d.Disconnect();
                }
            }

            try
            {
                Devices = configFilesMediator.TreatDevicesFile();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, 1);
                return;
            }

            string strLog = "\tLoaded Devices configuration file successfully";
            WriteLog(strLog, 0);
        }

        /// <summary>
        /// Gets notes from Notes configuration file.
        /// </summary>
        public void LoadNotesFromFile()
        {
            try
            {
                notes = configFilesMediator.TreatNotesFile();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, 1);
                return;
            }

            string strLog = "\tLoaded Notes file successfully";
            WriteLog(strLog, 0);
        }

        /// <summary>
        /// Gets MySQL configuration from MySQL configuration file.
        /// </summary>
        public void LoadMySQLConfigFile()
        {
            try
            {
                string tableName = "";
                string connStr = configFilesMediator.TreatMySQLFile(ref tableName);

                mySQLMediator = new MySQLMediator(connStr, tableName);
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, 1);
                return;
            }

            string strLog = "\tLoaded MySQL configuration file successfully";
            WriteLog(strLog, 0);
        }

        /// <summary>
        /// Gets EPCs datasets from EPCDataset configuration file.
        /// </summary>
        public void LoadEPCDatasetsConfigFile()
        {
            try
            {
                configFilesMediator.TreatEPCDataSets();
            }
            catch (Exception ex)
            {
                WriteLog(ex.Message, 1);
                return;
            }

            string strLog = "\tLoaded EPCDatasets configuration file successfully";
            WriteLog(strLog, 0);
        }

        /// <summary>
        /// Appends strLog to logs file
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteLogToFile(string strLog)
        {
            configFilesMediator.WriteLogToFile(strLog);
        }

        /// <summary>
        /// Opens specified configuration configFileType file
        /// </summary>
        /// <param name="configFileType"></param>
        public void OpenConfigFile(ConfigFileType configFileType)
        {
            configFilesMediator.OpenConfigFile(configFileType);
        }

        #endregion

        #region MySQL actions

        /// <summary>
        /// Verifies if Mysql Connection is able to be successful.
        /// </summary>
        public void TestMySQLConnection()
        {
            WriteLog(String.Format("Using MySQL parameters: {0}", mySQLMediator.ConnStrNoPassword), 0);

            try
            {
                mySQLMediator.TestConnection();
            }
            catch (Exception ex)
            {
                string errStr = "MySQL connection test failed: " + ex.Message;
                WriteLog(errStr, 1);
                return;
            }

            string s = "MySQL connection test successful";
            WriteLog(s, 0);
        }

        /// <summary>
        /// Tries to Insert list of tags into MySQL table.
        /// </summary>
        /// <param name="tags"></param>
        public void InsertTagsOnDB(List<Tag> tags)
        {
            try
            {
                mySQLMediator.InsertTags(tags, notes);

                string logStr = "MySQL insert tags finished successfully";
                WriteLog(logStr, 0);
            }
            catch (Exception ex)
            {
                string errStr = "MySQL insert tags error: " + ex.Message;
                WriteLog(errStr, 1);
                return;
            }
        }

        #endregion

        #region Connect / Disconnect All Devices

        /// <summary>
        /// Calls all device's (UHFReader/Laser/Servo) Connect method.
        /// </summary>
        public void ConnectAllDevices()
        {
            int devicesConnectedCounter = 0;

            foreach (Device d in Devices)
            {
                if (d.Connect())
                {
                    devicesConnectedCounter++;
                }
            }

            if (devicesConnectedCounter > 0)
            {
                WriteLog("Devices connected (" + devicesConnectedCounter + "/" + Devices.Count + ")", 0);
            }
            else
            {
                WriteLog("No Device connected", 0);
            }
        }

        /// <summary>
        /// Calls all devices (UHFReader/Laser/Servo) Disconnect method.
        /// </summary>
        public void DisconnectAllDevices()
        {
            foreach (Device d in Devices)
            {
                d.Disconnect();
            }

            WriteLog("All devices disconnected (" + Devices.Count + ")", 0);
        }

        #endregion

        #region Readings

        /// <summary>
        /// Starts read process.
        /// <para>A thread is created for each device process.</para>
        /// <para>A thread is created for the algorithm, that applies the mathematical model.</para>
        /// </summary>
        /// <param name="devicesConnected"></param>
        public void StartReads(List<Device> devicesConnected)
        {
            ClearUIGridMetaTagsDel();

            if (devicesConnected != null)
            {
                Devices = devicesConnected;
            }

            LogUsedDevicesAndMMInformation();

            onReads = true;

            #region create threads for devices

            for (int i = 0; i < Devices.Count; i++)
            {
                if (!Devices[i].Connected)
                {
                    continue;
                }

                if (Devices[i] is UHFReader)
                {
                    UHFReader r = (Devices[i] as UHFReader);
                    r.Reset();

                    #region create thread

                    ParameterizedThreadStart processTaskThread = delegate { UseResource(r, readerCounter++, UpdateUIGridMetaTagsDel); };

                    Thread deviceThread = new Thread(processTaskThread)
                    {
                        Name = String.Format("R{0}", i)
                    };

                    #endregion

                    deviceThread.Start();

                    threadsUsed.Add(deviceThread);

                    ExcelMediator.ExcelProcessForRSSIs(r, i + 1);
                }
                else if (Devices[i] is LaserModule)
                {
                    LaserModule l = (Devices[i] as LaserModule);

                    #region create thread

                    ParameterizedThreadStart processTaskThread = delegate { UseResource(l, -1, null); };

                    Thread deviceThread = new Thread(processTaskThread)
                    {
                        Name = String.Format("L{0}", i)
                    };

                    #endregion

                    deviceThread.Start();

                    threadsUsed.Add(deviceThread);
                }
                else if (Devices[i] is Servo)
                {
                    Servo s = (Devices[i] as Servo);

                    #region create thread

                    ParameterizedThreadStart processTaskThread = delegate { UseResource(s, -1, null); };

                    Thread deviceThread = new Thread(processTaskThread)
                    {
                        Name = String.Format("S{0}", i)
                    };

                    #endregion

                    deviceThread.Start();

                    threadsUsed.Add(deviceThread);
                }
            }

            #endregion

            #region create algorithm thread

            if (useMM)
            {
                ParameterizedThreadStart processTaskThreadForAlgorithm = delegate { UseResourceForAlgorithm(Devices, RunAlgorithm); };

                Thread algorithmThread = new Thread(processTaskThreadForAlgorithm)
                {
                    Name = "M"
                };

                algorithmThread.Start();

                threadsUsed.Add(algorithmThread);
            }

            #endregion

            #region send tags to Excel

            ExcelMediator.ExcelProcessForTagsPosition(WriteLog);

            #endregion
        }

        /// <summary>
        /// Logs used Devices and Mathematical Model Information
        /// </summary>
        private void LogUsedDevicesAndMMInformation()
        {
            string[] newArrayOfDevices = new string[Devices.Count];

            int counter = 0;
            int devicesConnectedCounter = 0;

            foreach (Device d in Devices)
            {
                if (!d.Connected)
                {
                    continue;
                }

                if (d is UHFReader)
                {
                    newArrayOfDevices[counter++] = "R" + counter;
                    devicesConnectedCounter++;
                }
                else if (d is LaserModule)
                {
                    newArrayOfDevices[counter++] = "L" + counter;
                    devicesConnectedCounter++;
                }
                else if (d is Servo)
                {
                    newArrayOfDevices[counter++] = "S" + counter;
                    devicesConnectedCounter++;
                }
            }

            WriteLog(
                String.Format("Started Reads process with {0} device{1} ({2}), and {3}applying the Mathematical Model",
                    devicesConnectedCounter,
                    (devicesConnectedCounter > 1) ? "s" : "",
                    (devicesConnectedCounter > 1) ? string.Join(", ", newArrayOfDevices) : newArrayOfDevices[0],
                    useMM ? "" : "not "
            ), 0);
        }

        /// <summary>
        /// Stops read process.
        /// </summary>
        public void StopReads()
        {
            WriteLog("Stopped Reads process", 0);

            onReads = false;

            readerCounter = 1;

            ExcelMediator.Running = false;

            usingLasers = false;
            usingServo = false;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Method that executes a device process inside a thread.
        /// </summary>
        /// <param name="device"></param>
        private static void UseResource(Device device, int readerCounter, Action<MetaTag>updateUIGridMetaTagsDel)
        {
            if (device is UHFReader)
            {
                #region UHFReader process

                while (onReads)
                {
                    try
                    {
                        readersMutex.WaitOne();

                        if (onReads)
                        {
                            UHFReader.DoInventory(readerCounter, (device as UHFReader), updateUIGridMetaTagsDel);
                        }
                    }
                    finally
                    {
                        if (useDeltaRead)
                        {
                            /// Use TDM delta read duration
                            Thread.Sleep(deltaRead);
                        }

                        readersMutex.ReleaseMutex();
                    }
                }

                #endregion
            }
            else if (device is LaserModule)
            {
                #region Laser process

                usingLasers = true;

                while (onReads)
                {
                    try
                    {
                        dwspcMutex.WaitOne();

                        if (onReads)
                        {
                            LaserModule.DoScanProcess(device as LaserModule);
                        }
                    }
                    finally
                    {
                        dwspcMutex.ReleaseMutex();
                    }
                }

                #endregion
            }
            else if (device is Servo)
            {
                #region Servo process

                usingServo = true;

                while (onReads)
                {
                    try
                    {
                        dwspcMutex.WaitOne();

                        if (onReads)
                        {
                            Servo.DoActionProcess(device as Servo);
                        }
                    }
                    finally
                    {
                        dwspcMutex.ReleaseMutex();
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// Method that executes an algorithm process inside a thread.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="RunAlgorithm"></param>
        private static void UseResourceForAlgorithm(List<Device> devices, Action RunAlgorithm)
        {
            while (onReads)
            {
                try
                {
                    dwspcMutex.WaitOne();

                    RunAlgorithm();
                }
                finally
                {
                    /// Algorithm is executed every 5 seconds
                    Thread.Sleep(5000);

                    dwspcMutex.ReleaseMutex();
                }
            }
        }

        #endregion

        #region Algorithm

        /// <summary>
        /// Method that generates/treats Tags(ID and position), and sends them to a MySQL Database.
        /// </summary>
        private void RunAlgorithm()
        {
            Position laserPosition = null;
            if (usingLasers)
            {
                laserPosition = LocalizationAlgorithm.GetPositionFromLasers(Devices);

                if (laserPosition == null)
                {
                    return;
                }
            }

            int servoAngle = int.MinValue;
            if (usingServo)
            {
                servoAngle = LocalizationAlgorithm.GetAngleFromServo(Devices);

                if (servoAngle == int.MinValue)
                {
                    return;
                }
            }

            List<TagRead> tagsReads = LocalizationAlgorithm.GetTagsReads(Devices, RemoveFromUIGridMetaTagsDel);
            
            List<Tag> tags = MathematicalModel.RunMathematicalModel(tagsReads);

            if (tags.Count == 0)
            {
                WriteLog("Mathematical Model applied: 0 tags obtained", 0);

                return;
            }

            tags = LocalizationAlgorithm.TagsPosteriorTreatment(tags, laserPosition, servoAngle, usingLasers, usingServo);

            UpdateUIGridTagsDel(tags);

            InsertTagsOnDB(tags);

            /// Sends a copy of tags obtained to Excel Mediator
            ExcelMediator.tagsObtained = tags;
        }

        #endregion
    }
}
