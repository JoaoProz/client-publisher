using System;
using UHF;

namespace RINPOSYS.CustomClasses.Devices.UHFReader
{
    /// <summary>
    /// Controls all parameters that are used on Inventory_G2 from RWDev
    /// </summary>
    public class UHFReaderInvParams
    {
        #region Fields

        /// <summary>
        /// Pointed to the address of the reader
        /// </summary>
        public byte FComAddress = 0xff;   //255

        #region Inventory control vareables

        /// <summary>
        /// Inventory max scan time .
        /// </summary>
        public byte Scantime { get; set; } = 0x0a;  //10

        /// <summary>
        /// Q value setting should be field label quantity.
        /// Ranges from 0 to 15.
        /// </summary>
        public byte QValue { get; set; } = 0x04;

        /// <summary>
        /// Session value:
        ///  0:S0;
        ///  1:S1;
        ///  2:S2;
        ///  3:S3.
        /// </summary>
        public byte Session { get; set; } = 0x00;

        /// <summary>
        /// 0: Flag value is A;
        /// 1：Flag value is B.
        /// </summary>
        public byte Target { get; set; } = 0x00;

        #endregion

        #region Mask Control

        /// <summary>
        /// It specifies the target memory when applying inventory mask:
        ///  1: EPC memory;
        ///  2: TID memory;
        ///  3: User memory. 
        /// </summary>
        public byte MaskMem { get; set; } = 0;

        /// <summary>
        /// Specifies the start bit address of the mask pattern data.
        /// Ranges from 0 to 16383.
        /// </summary>
        public byte[] MaskAdr { get; set; } = new byte[2];

        /// <summary>
        /// Specifies the bit length of the mask pattern data.
        /// Ranges from 0 to 255.
        /// </summary>
        public byte MaskLen { get; set; } = 0;

        /// <summary>
        /// Mask pattern data.
        /// The byte length of the MaskData is MaskLen/8.
        /// </summary>
        /// <remarks>
        /// If MaskLen is not 8bits integer times, the length of MaskData should be int[MaskLen/8]+1 with 0 patching in the low significant location.
        /// </remarks>
        public byte[] MaskData { get; set; } = new byte[100];

        /// <summary>
        /// Masking Flag:
        /// 0: disabled;
        /// 1: enabled.
        /// </summary>
        public byte MaskFlag { get; set; } = 0;

        #endregion 

        #region TID

        /// <summary>
        /// Specifies the start word address in TID memory when doing the TID-inventory. 
        /// </summary>
        public byte AdrTID { get; set; } = 0x00;

        /// <summary>
        /// Specifies the number of words when doing the TID-inventory.
        /// Ranges from 0 to 15. 
        /// </summary>
        public byte LenTID { get; set; } = 0x06;

        /// <summary>
        /// The flag of read EPC or TID:
        /// 1: read TID of tag;
        /// 0:read EPC of tag.
        /// </summary>
        public byte TIDFlag { get; set; } = 0x00;

        #endregion

        #region Antenna

        /// <summary>
        /// Bytes for Ant, 0x80, Other values are reserved.
        /// </summary>
        public byte InAnt { get; set; } = 0x80; //128

        /// <summary>
        /// Describes from which antenna the tag EPC is collected, this module is 0x01.
        /// </summary>
        public byte Ant = 0;

        #endregion

        /// <summary>
        /// Apply fast inventory? Not documented.
        /// 0: disabled;
        /// 1: enabled.
        /// </summary>
        public byte FastFlag { get; set; } = 0x01;

        /// <summary>
        /// Pointed to the array storing the inventory result.
        /// It is the EPC data of tag Reader read. 
        /// The unit of the array includes 1 byte EPCLen and N (the value of EPCLen) bytes EPC.
        /// It is the former high-word, low word in the EPC of each tag.
        /// It is the former high-byte, low byte in the each word.
        /// </summary>
        public byte[] EPC { get; set; } = new byte[50000];

        /// <summary>
        /// Pointed to the byte count of the EPC
        /// </summary>
        public int Totallen = 0;

        /// <summary>
        /// The number of tags detected.
        /// </summary>
        public int CardNum = 0;

        /// <summary>
        /// Counter for the number of inventory iterations that didnt retrieve any tag.
        /// </summary>
        public int AA_Times = 0;

        /// <summary>
        /// Flag that represents if the flag used should be changed.
        /// </summary>
        public bool ConvertTagFlagWhenFailedReads = true;

        /// <summary>
        /// Number of failed reads necessary before applying tag flag conversion.
        /// </summary>
        public int TargetTimesBeforeConversion = 2;

        #endregion

        /// <summary>
        /// Updates the parameters that are being used, at the moment, to affect the behaviour of the Inventory_G2
        /// </summary>
        /// <param name="scanTime"></param>
        /// <param name="qValue"></param>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <param name="read"></param>
        /// <param name="targetTimes"></param>
        public void UpdateParams(byte scanTime, byte qValue, byte session, byte target, bool read, int targetTimes)
        {
            //Console.WriteLine("UP|S:{0}|Q:{1}|F:{2}|AA:{3}", Session, QValue, Target, AA_Times);

            Scantime = scanTime;
            QValue = qValue;
            Session = session;
            Target = target;

            AA_Times = 0;

            ConvertTagFlagWhenFailedReads = read;
            TargetTimesBeforeConversion = targetTimes;
        }

        /// <summary>
        /// Executed before Inventory_G2. Changes reader's Target if conditions are met
        /// </summary>
        public void RefreshBeforeInv()
        {
            if (Session > 1
                && ConvertTagFlagWhenFailedReads
                && (AA_Times + 1 > TargetTimesBeforeConversion))
            {
                Target = Convert.ToByte(1 - Target);  //If the card has not been read twice(default value), the A / B status is switched.
            }
        }

        /// <summary>
        /// Executed after Inventory_G2.
        /// </summary>
        /// <returns>
        /// Returns true if any tag was found
        /// Returns false if not tags were found
        /// </returns>
        public bool RefreshAfterInv()
        {
            if (CardNum == 0)
            {
                if (Session > 1)
                {
                    AA_Times = AA_Times + 1;
                }
                return false;
            }
            AA_Times = 0;

            return true;
        }

        /// <summary>
        /// Calls Inventory_G2 with own parameters and the number of the port of the reader.
        /// </summary>
        /// <param name="portNum"></param>
        /// <returns>
        /// Returns fCmdRet that represents information about the process
        /// </returns>
        public int DoInventory(int portNum)
        {
            return RWDev.Inventory_G2(
                ComAdr: ref FComAddress,
                QValue: QValue,
                Session: Session,
                MaskMem: MaskMem,
                MaskAdr: MaskAdr,
                MaskLen: MaskLen,
                MaskData: MaskData,
                MaskFlag: MaskFlag,
                AdrTID: AdrTID,
                LenTID: LenTID,
                TIDFlag: TIDFlag,
                Target: Target,
                InAnt: InAnt,
                Scantime: Scantime,
                FastFlag: FastFlag,
                pEPCList: EPC,
                Ant: ref Ant,
                Totallen: ref Totallen,
                CardNum: ref CardNum,
                frmComPortindex: portNum);
        }
    }
}
