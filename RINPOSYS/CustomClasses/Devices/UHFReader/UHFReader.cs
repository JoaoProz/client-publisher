using RINPOSYS.CustomClasses.Devices.GenericDevice;
using RINPOSYS.CustomClasses.RFIDReads;
using RINPOSYS.CustomClasses.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UHF;

namespace RINPOSYS.CustomClasses.Devices.UHFReader
{
    /// <summary>
    /// Provides control on a UHFReader like connection/disconnection as well as inventory process, among others
    /// </summary>
    public class UHFReader : Device
    {
        #region ConnectionControls

        /// <summary>
        /// Necessary controls for Connect and Disconnect functions in UHFReader86.dll
        /// </summary>
        
        /// <summary>
        /// Number of COM port used
        /// </summary>
        public int PortNum { get; set; }

        /// <summary>
        /// Baudrate used
        /// </summary>
        public byte FBaud { get; set; }

        /// <summary>
        /// Pointed to the address of the reader
        /// </summary>
        public byte FComAdr { get; set; }

        /// <summary>
        /// Pointed to the communication handle
        /// </summary>
        public int FrmPortIndex { get; set; }

        #endregion

        /// <summary>
        /// Necessary controls for InventoryG2 function in UHFReader86.dll
        /// </summary>
        public UHFReaderInvParams InvParams { get; set; } = new UHFReaderInvParams();

        /// <summary>
        /// Util that provides Statistical information
        /// </summary>
        /// <remarks>
        /// Being used only on the generated Excel from reads
        /// </remarks>
        public UHFReaderInvCounter RIC { get; set; }

        /// <summary>
        /// Associated antenna to this Reader
        /// </summary>
        public Antenna Antenna { get; set; }

        /// <summary>
        /// List of transformed reads obtained from Reader with its antenna
        /// </summary>
        public ConcurrentDictionary<string, MetaTag> MetaTagsDictionary { get; set; }

        /// <summary>
        /// Flag the controls if UHFReader beeps everytime it gets a tag data
        /// </summary>
        public bool BeepOn { get; set; } = false;
       
        /// <summary>
        /// Value for UHFReader potency
        /// </summary>
        public byte PowerDbm { get; set; }

        /// <summary>
        /// Minimum frequency used by UHFReader
        /// </summary>
        /// <remarks>
        /// Use same value for Minimum and Maximum frequency for single frequency usage
        /// </remarks>
        public decimal MinFrequency { get; set; }

        /// <summary>
        /// Maximum frequency used by UHFReader
        /// </summary>
        /// <remarks>
        /// Use same value for Minimum and Maximum frequency for single frequency usage
        /// </remarks>
        public decimal MaxFrequency { get; set; }

        /// <summary>
        /// Shows device type and its port in a string format
        /// </summary>
        /// <remarks>
        /// Used only for logging
        /// </remarks>
        public override string Identifier { get => "UHFReader (" + PortStr + ") "; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="port"></param>
        /// <param name="antenna"></param>
        /// <param name="beep"></param>
        /// <param name="powerDbm"></param>
        /// <param name="dminfre"></param>
        /// <param name="dmaxfre"></param>
        /// <param name="WriteLog"></param>
        public UHFReader(string id, string port, Antenna antenna, bool beep, byte powerDbm, decimal dminfre, decimal dmaxfre, Action<string, int> WriteLog) : base(id, port, DeviceBaudRate.ReaderStr, WriteLog)
        {
            Antenna = antenna;

            FComAdr = 255;
            FrmPortIndex = 0;

            FBaud = ByteConversion.GetBaudRateIndexByte(base.BaudRateStr);

            if (port == "")
            {
                PortNum = -1;
            }
            else
            {
                PortNum = Int32.Parse(port.Substring(3, port.Length - 3));
            }

            BeepOn = beep;

            PowerDbm = powerDbm;

            MinFrequency = dminfre;
            MaxFrequency = dmaxfre;

            MetaTagsDictionary = new ConcurrentDictionary<string, MetaTag>();

            RIC = new UHFReaderInvCounter();
        }

        /// <summary>
        /// Connects to UHFReader
        /// </summary>
        /// <returns>
        /// true: Connection successful;
        /// false: Failed connection.
        /// </returns>
        public override bool Connect()
        {
            #region Do Connect

            byte fComAdr = FComAdr;
            int frmPortIndex = FrmPortIndex;

            int fCmdRet = RWDev.OpenComPort(
                Port: PortNum, 
                ComAddr: ref fComAdr, 
                Baud: FBaud, 
                PortHandle: ref frmPortIndex);

            FComAdr = fComAdr;
            FrmPortIndex = frmPortIndex;

            #endregion

            if (fCmdRet != 0)
            {
                string strErr = Identifier + "failed to connect: " + UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet);
                WriteLog(strErr, 1);
                return false;
            }

            Connected = true;

            string strLog = Identifier + "connected successfully";
            WriteLog(strLog, 0);

            #region Set beep

            byte b;
            if (BeepOn)
            {
                b = 1;
            }
            else
            {
                b = 0;
            }

            SetBeepState(b);

            #endregion

            #region Set Power

            SetPowerDbm();

            #endregion

            #region Set usable Frequency range

            SetRegion();

            #endregion

            return true;
        }

        /// <summary>
        /// Disconnects UHFReader
        /// </summary>
        /// <returns>
        /// true: Disconnection successful
        /// false: Failed disconnection
        /// </returns>
        public override bool Disconnect()
        {
            int fCmdRet = RWDev.CloseSpecComPort(FrmPortIndex);

            if (fCmdRet != 0)
            {
                string strErr = Identifier + "failed to disconnect: " + UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet);
                WriteLog(strErr, 1);
                return false;
            }

            string strLog = Identifier + "disconnected successfully";
            WriteLog(strLog, 0);

            return true;
        }

        /// <summary>
        /// Get UHFReader beep information
        /// </summary>
        /// <returns>
        /// Beep state:
        /// true: Beep is ON;
        /// false: Beep is OFF or failed to retrieve beep information.
        /// </returns>
        public bool GetBeepState()
        {
            #region get Information

            byte[] VersionInfo = new byte[2];
            byte ReaderType = 0;
            byte TrType = 0;
            byte dmaxfre = 0;
            byte dminfre = 0;
            byte powerdBm = 0;
            byte ScanTime = 0;
            byte Ant = 0;
            byte BeepEn = 0;
            byte OutputRep = 0;
            byte CheckAnt = 0;

            byte fComAdrLocal = this.FComAdr;
            int frmPortIndex = this.FrmPortIndex;

            int fCmdRet = RWDev.GetReaderInformation(
                ComAdr: ref fComAdrLocal, 
                VersionInfo: VersionInfo, 
                ReaderType: ref ReaderType, 
                TrType: ref TrType, 
                dmaxfre: ref dmaxfre, 
                dminfre: ref dminfre, 
                powerdBm: ref powerdBm, 
                ScanTime: ref ScanTime, 
                Ant: ref Ant, 
                BeepEn: ref BeepEn, 
                OutputRep: ref OutputRep, 
                CheckAnt: ref CheckAnt, 
                FrmHandle: frmPortIndex);

            FComAdr = fComAdrLocal;
            FrmPortIndex = frmPortIndex;

            #endregion

            if (fCmdRet != 0)
            {
                string strLog = Identifier + "get Reader Beep Information failed: " + UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet);
                WriteLog(strLog, 1);
            }

            return (BeepEn == 1);
        }

        /// <summary>
        /// Updates beep state
        /// </summary>
        /// <param name="beep"></param>
        public void SetBeepState(byte beep)
        {
            #region Set Beep

            byte fComAdr = FComAdr;

            int fCmdRet = RWDev.SetBeepNotification(
                ComAdr: ref fComAdr, 
                BeepEn: beep, 
                frmComPortindex: FrmPortIndex);

            FComAdr = fComAdr;

            #endregion

            if (fCmdRet != 0)
            {
                string strErr = Identifier + "Set beep failed: " + UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet);
                WriteLog(strErr, 1);
                return;
            }
        }

        /// <summary>
        /// Updates UHFReader potency
        /// </summary>
        private void SetPowerDbm()
        {
            #region Set Power

            byte fComAdr = FComAdr;

            int fCmdRet = RWDev.SetRfPower(
                ComAdr: ref fComAdr, 
                powerDbm: PowerDbm, 
                frmComPortindex: FrmPortIndex);

            FComAdr = fComAdr;

            #endregion

            if (fCmdRet != 0)
            {
                string strErr = String.Format("Set power to {0} failed: " + UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet), PowerDbm);
                WriteLog(strErr, 1);
                return;
            }
        }

        private void SetRegion()
        {
            #region Set Region Frequency

            byte fComAdr = FComAdr;

            RegionFrequencyConverter.ConvertMinFrequencyToByte(MinFrequency, out byte dminfre);
            RegionFrequencyConverter.ConvertMaxFrequencyToByte(MaxFrequency, out byte dmaxfre);

            int fCmdRet = RWDev.SetRegion(
                ComAdr: ref fComAdr,
                dminfre: dminfre, 
                dmaxfre: dmaxfre, 
                frmComPortindex: FrmPortIndex);

            FComAdr = fComAdr;

            #endregion

            if (fCmdRet != 0)
            {
                string strErr = "Set Region failed: " + UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet);
                WriteLog(strErr, 1);
            }
        }


        /// <summary>
        /// Runs Inventory function in UHFReader86.dll and treats its data
        /// </summary>
        /// <param name="readerCounter"></param>
        /// <param name="reader"></param>
        /// <param name="updateMetaTagGrid"></param>
        public static void DoInventory(int readerCounter, UHFReader reader, Action<MetaTag> updateMetaTagGrid)
        {
            //WriteLog(String.Format("R{0}|S:{1}|Q:{2}|F:{3}|C:{4}|AA:{5}",
            //    readerCounter, 
            //    reader.InvParams.Session, 
            //    reader.InvParams.QValue, 
            //    reader.InvParams.Target, 
            //    reader.InvParams.ConvertTagFlagWhenFailedReads,
            //    reader.InvParams.AA_Times), 0);

            int EPClen;
            int m;
            string temps;
            string temp;
            temp = "";
            string sEPC;

            reader.InvParams.RefreshBeforeInv();
            
            int fCmdRet = reader.InvParams.DoInventory(reader.PortNum);
            
            if (fCmdRet > 0 && fCmdRet < 5)
            {
                if (fCmdRet == 4)
                {
                    WriteLog(UHFReaderLogMessages.GetReturnCodeDesc(fCmdRet), 1);
                }

                byte[] daw = new byte[reader.InvParams.Totallen];
                Array.Copy(reader.InvParams.EPC, daw, reader.InvParams.Totallen);
                temps = ByteConversion.ByteArrayToHexString(daw);

                m = 0;

                if ( !reader.InvParams.RefreshAfterInv() )
                {
                    WriteLog(String.Format("R{0} - Finished Inventory with {1} tags",
                    readerCounter,
                    reader.InvParams.CardNum), 0);

                    reader.RIC.UpdateWithoutTags();

                    return;
                }

                reader.RIC.UpdateWithTags(reader.InvParams.CardNum);

                List<string> epcsFound = new List<string>();

                for (int CardIndex = 0; CardIndex < reader.InvParams.CardNum; CardIndex++)
                {
                    EPClen = daw[m] + 1;

                    /// Obtained tag data from reader in string 
                    temp = temps.Substring(m * 2 + 2, EPClen * 2);

                    ///get RSSI value from string
                    int RSSI = Convert.ToInt32(temp.Substring(temp.Length - 2, 2), 16);

                    ///Get EPC value from string
                    sEPC = temp.Substring(0, temp.Length - 2);

                    epcsFound.Add(sEPC);

                    m = m + EPClen + 1;

                    if (sEPC.Length != (EPClen - 1) * 2)
                    {
                        return;
                    }
                    
                    //-------------

                    if (reader.MetaTagsDictionary.ContainsKey(sEPC))
                    {
                        // Needs another confirmation, because another thread could have deleted it meanwhile
                        if (reader.MetaTagsDictionary.ContainsKey(sEPC))
                        {
                            reader.MetaTagsDictionary[sEPC].AddRSSI(RSSI);
                        }

                        // Needs another confirmation, because another thread could have deleted it meanwhile
                        if (reader.MetaTagsDictionary.ContainsKey(sEPC))
                        {
                            updateMetaTagGrid(reader.MetaTagsDictionary[sEPC]);
                        }
                    }
                    else
                    {
                        MetaTag metaTag = new MetaTag(sEPC, reader.Antenna);
                        metaTag.AddRSSI(RSSI);

                        if (reader.MetaTagsDictionary.TryAdd(sEPC, metaTag))
                        {
                            updateMetaTagGrid(reader.MetaTagsDictionary[sEPC]);
                        }
                    }
                }

                WriteLog(
                    String.Format("R{0} - Finished Inventory with {1} tags:\n\t[\n\t\t{2}\n\t]",
                    readerCounter,
                    reader.InvParams.CardNum,
                    string.Join(",\n\t\t", epcsFound.ToArray())), 0);
            }
        }

        /// <summary>
        /// Resets parameters used for Reads Process
        /// </summary>
        public void Reset()
        {
            InvParams.AA_Times = 0;

            MetaTagsDictionary.Clear();

            RIC.Reset();
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns>
        /// Returns UHFReader with noticeable parameters
        /// </returns>
        public override string ToString()
        {
            return String.Format("Reader: {0} | BR: {1} | B: {2} | Ant.X: {3}m | Ant.Y: {4}m | Q: {5} | S: {6} | T: {7} | P: {8}dBm | F: [{9}-{10}]MHz", 
                PortStr,
                BaudRateStr, 
                BeepOn ? "ON" : "OFF", 
                Antenna.Position.X, 
                Antenna.Position.Y,
                InvParams.QValue,
                InvParams.Session,
                InvParams.Target,
                PowerDbm,
                MinFrequency,
                MaxFrequency
                );
        }
    }
}
