using RINPOSYS.CustomClasses.RFIDReads;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using RINPOSYS.CustomClasses.Utils;
using System.Linq;
using RINPOSYS.CustomClasses.Devices.UHFReader;

using Excel = Microsoft.Office.Interop.Excel;

namespace RINPOSYS.CustomClasses.ExcelInterop
{
    /// <summary>
    /// Manages Excel interactions
    /// </summary>
    public class ExcelMediator
    {
        /// <summary>
        /// Represents the entire Microsoft Excel application
        /// </summary>
        private static Excel.Application oXL;

        /// <summary>
        /// Represents a Microsoft Excel workbook
        /// </summary>
        private static Excel._Workbook oWB;

        /// <summary>
        /// Represents a cell, a row, a column, a selection of cells containing one or more contiguous blocks of cells
        /// </summary>
        private static Excel.Range oRng;

        /// <summary>
        /// Represents a worksheet that contains charts
        /// </summary>
        private static Excel._Worksheet oSheetCharts;

        /// <summary>
        /// Represents a worksheet that RSSI data of MetaTags
        /// </summary>
        private static Excel._Worksheet oSheetDataRSSIs;

        /// <summary>
        /// Represents a worksheet that Position data of Tags
        /// </summary>
        private static Excel._Worksheet oSheetDataTags;

        /// <summary>
        /// Represents a worksheet that contains a filtered tag flag
        /// </summary>
        private static Excel._Worksheet oSheetTagFlags;

        /// <summary>
        /// Represents an embedded chart of RSSIs on worksheet oSheetCharts
        /// </summary>
        private static Excel.ChartObject oChartRSSIs;

        /// <summary>
        /// Represents an embedded chart of Tags Position on worksheet oSheetCharts
        /// </summary>
        private static Excel.ChartObject oChartTags;

        /// <summary>
        /// Maximum number of lines for a tag value 
        /// </summary>
        /// <remarks>
        /// When number of lines == MaxTagsQueueSize, applies FIFO behaviour
        /// </remarks>
        private static readonly int MaxTagsQueueSize = 20;

        /// <summary>
        /// Mutex used for synchronization of each Excel process.
        /// </summary>
        private static Mutex mutexForExcel = new Mutex();

        /// <summary>
        /// Flag that represents if Excel thread processes are executing
        /// </summary>
        public static bool Running = false;

        /// <summary>
        /// Flag that represents if Tags chart has gotten any value
        /// </summary>
        /// <remarks>
        /// Starts at false, then changes to true when a tag value is obtained.
        /// Used only for better visualization experience.
        /// </remarks>
        private static bool ChartTagsHasValues = false;

        /// <summary>
        /// Flag that represents if Excel Application is being used
        /// </summary>
        private static bool UsingExcel = false;

        /// <summary>
        /// List of EPCs
        /// </summary>
        private static List<string> epcsList = new List<string>();

        /// <summary>
        /// Dictionary of R1 EPCs and their counter
        /// </summary>
        private static Dictionary<string, int> R1EPCsDic = new Dictionary<string, int>();

        /// <summary>
        /// Dictionary of R1 EPCs and their counter
        /// </summary>
        private static Dictionary<string, int> R2EPCsDic = new Dictionary<string, int>();

        /// <summary>
        /// Dictionary of tags IDs and their counter
        /// </summary>
        private static Dictionary<string, int> tagsDic = new Dictionary<string, int>();

        /// <summary>
        /// List of obtained tags
        /// </summary>
        public static List<Tag> tagsObtained = new List<Tag>();

        /// <summary>
        /// Static tag that is used as filter
        /// </summary>
        /// <remarks>
        /// Was used for tests
        /// </remarks>
        public static string tagFilter = "E20000193103011415807500";

        /// <summary>
        /// Flag that represents if Excel process that updates RSSIs values should be used
        /// </summary>
        public static bool updateRSSIs = false;

        /// <summary>
        /// Flag that represents if Excel process that updates Tags values should be used
        /// </summary>
        public static bool updateTags = false;

        /// <summary>
        /// Initializes Excel vareables
        /// </summary>
        public static void ExcelPrep()
        {
            UsingExcel = true;

            R1EPCsDic.Clear();
            R2EPCsDic.Clear();

            #region config Excel application and workbook

            oXL = new Excel.Application
            {
                Visible = true,
                WindowState = Excel.XlWindowState.xlMaximized
            };

            oWB = oXL.Workbooks.Add(Missing.Value);

            #endregion

            try
            {
                #region config sheets

                oSheetDataRSSIs = (Excel._Worksheet)oWB.ActiveSheet;
                oSheetDataRSSIs.Name = "Rssis Data";
                oSheetDataRSSIs.get_Range("A1:Z1").Font.Bold = true;

                oSheetDataTags = (Excel._Worksheet)oWB.Sheets.Add(Type.Missing, oSheetDataRSSIs, Type.Missing, Type.Missing);
                oSheetDataTags.Name = "Tags Data";
                oSheetDataTags.get_Range("A1:Z2").Font.Bold = true;
                oSheetDataTags.get_Range("A1:Z2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                oSheetCharts = (Excel._Worksheet)oWB.Sheets.Add(Type.Missing, oSheetDataTags, Type.Missing, Type.Missing);
                oSheetCharts.Name = "Charts";

                oSheetTagFlags = (Excel._Worksheet)oWB.Sheets.Add(Type.Missing, oSheetCharts, Type.Missing, Type.Missing);
                oSheetTagFlags.Name = "Flags";
                oSheetTagFlags.Cells[1, 1] = "A";
                oSheetTagFlags.Cells[1, 2] = "B";

                // Selects sheet if needed
                //oSheetDataTags.Activate();

                #endregion

                #region config charts

                Excel.ChartObjects xlCharts = oSheetCharts.ChartObjects(Type.Missing);

                #region config RSSI chart

                oRng = oSheetCharts.get_Range("B2:K36");
                oChartRSSIs = xlCharts.Add(oRng.Left, oRng.Top, oRng.Width, oRng.Height);

                oChartRSSIs.Chart.ChartWizard(
                    Gallery: Excel.XlChartType.xlLine,
                    Format: 4,
                    PlotBy: Excel.XlRowCol.xlColumns,
                    CategoryLabels: false,
                    SeriesLabels: 5,
                    HasLegend: true,
                    Title: "RSSIs",
                    CategoryTitle: "Values_Range",
                    ValueTitle: "RSSI"
                );
                oChartRSSIs.Chart.SetSourceData(oSheetCharts.get_Range("A1:A2"));

                #region RSSIs chart axis

                Excel.Axis axis = oChartRSSIs.Chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                axis.MinimumScaleIsAuto = false;
                axis.MaximumScaleIsAuto = false;
                axis.MajorUnit = 1;
                axis.MinimumScale = 170;
                axis.MaximumScale = 220;

                #endregion

                #endregion

                #region config Tags chart

                oRng = oSheetCharts.get_Range("M2:U36");
                oChartTags = xlCharts.Add(oRng.Left, oRng.Top, oRng.Width, oRng.Height);

                oChartTags.Chart.ChartWizard(
                    Gallery: Excel.XlChartType.xlXYScatter,
                    Format: 3,
                    CategoryLabels: true,
                    SeriesLabels: 5,
                    HasLegend: true,
                    Title: "Tags Location",
                    CategoryTitle: "X",
                    ValueTitle: "Y"
                );
                oChartTags.Chart.ChartType = Excel.XlChartType.xlXYScatter;
                oChartTags.Chart.SetSourceData(oSheetCharts.get_Range("A1:A2"));

                #region Tags chart axis

                axis = oChartTags.Chart.Axes(Excel.XlAxisType.xlValue, Excel.XlAxisGroup.xlPrimary);
                axis.MinimumScaleIsAuto = false;
                axis.MaximumScaleIsAuto = false;
                axis.MajorUnit = 1;
                axis.MinimumScale = 0;
                axis.MaximumScale = 10;

                axis = oChartTags.Chart.Axes(Excel.XlAxisType.xlCategory, Excel.XlAxisGroup.xlPrimary);
                axis.MinimumScaleIsAuto = false;
                axis.MaximumScaleIsAuto = false;
                axis.MajorUnit = 1;
                axis.MinimumScale = -4;
                axis.MaximumScale = 4;

                #endregion

                #endregion
                
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Closes Excel Application and clears Excel Objects used
        /// </summary>
        public static void Close()
        {
            UsingExcel = false;

            if (oXL != null)
            {
                Marshal.ReleaseComObject(oChartRSSIs);
                Marshal.ReleaseComObject(oChartTags);
                Marshal.ReleaseComObject(oSheetCharts);
                Marshal.ReleaseComObject(oSheetDataRSSIs);
                Marshal.ReleaseComObject(oSheetDataTags);
                Marshal.ReleaseComObject(oRng);

                if (oWB != null)
                {
                    oWB.Close(false, null, null); // closes workbook
                }

                Marshal.ReleaseComObject(oWB);
                oWB = null;

                oXL.Quit();  // exit excel application

                Marshal.ReleaseComObject(oXL);
                oXL = null;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// Creates thread for RSSIs process if conditions are met
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="readerCounter"></param>
        public static void ExcelProcessForRSSIs(UHFReader reader, int readerCounter)
        {
            if (!UsingExcel && !updateRSSIs)
            {
                return;
            }

            Running = true;

            #region create Thread for RSSIs

            ParameterizedThreadStart processTaskThread = delegate { UseResourceForRSSIs(reader, readerCounter); };

            Thread newThread = new Thread(processTaskThread);

            #endregion

            newThread.Start();
        }

        /// <summary>
        /// Creates thread for Tags process if conditions are met
        /// </summary>
        /// <param name="writeLog"></param>
        public static void ExcelProcessForTagsPosition(Action<string, int> writeLog)
        {
            if (!UsingExcel && updateTags)
            {
                return;
            }

            Running = true;

            #region Create thread for Tags

            ParameterizedThreadStart processTaskThread = delegate { UseResourceForTagsPosition(writeLog); };

            Thread newThread = new Thread(processTaskThread);

            #endregion

            newThread.Start();
        }

        /// <summary>
        /// RSSIs process used inside a thread
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="readerCounter"></param>
        private static void UseResourceForRSSIs(UHFReader reader, int readerCounter)
        {
            while (Running && updateRSSIs)
            {
                try
                {
                    mutexForExcel.WaitOne();

                    if (reader.MetaTagsDictionary.Count > 0)
                    {
                        DoExcelInsertRSSIs(reader.MetaTagsDictionary, readerCounter);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                finally
                {
                    Thread.Sleep(200);

                    mutexForExcel.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// Tags process used inside a thread
        /// </summary>
        /// <param name="writeLog"></param>
        private static void UseResourceForTagsPosition(Action<string, int> writeLog)
        {
            while (Running && updateTags)
            {
                try
                {
                    mutexForExcel.WaitOne();
                    
                    DoExcelInsertTags(writeLog);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                finally
                {
                    Thread.Sleep(200);

                    mutexForExcel.ReleaseMutex();
                }
            }
        }

        /// <summary>
        /// Inserts RSSIs in Excel worksheet oSheetDataRSSIs
        /// </summary>
        /// <param name="metaTagsDic"></param>
        /// <param name="readerCounter"></param>
        private static void DoExcelInsertRSSIs(ConcurrentDictionary<string, MetaTag> metaTagsDic, int readerCounter)
        {
            foreach (string epc in metaTagsDic.Keys)
            {
                MetaTag metaTag = metaTagsDic[epc];

                /// Ignores RSSI average if metaTag's rssiQueue isn't full
                if (metaTag.RSSIAvg == -1)
                {
                    continue;
                }

                if (readerCounter == 1)
                {
                    /// R1 obtained RSSIs

                    UpdateRSSIs(readerCounter, R1EPCsDic, metaTag);
                }
                else
                {
                    /// R2 obtained RSSIs
                    
                    UpdateRSSIs(readerCounter, R2EPCsDic, metaTag);
                }
            }
        }

        /// <summary>
        /// Updates RSSIs in Excel using data from the corresponding UHFReader
        /// </summary>
        /// <param name="readerCounter"></param>
        /// <param name="readerEPCsDic"></param>
        /// <param name="metaTag"></param>
        private static void UpdateRSSIs(int readerCounter, Dictionary<string,int> readerEPCsDic, MetaTag metaTag)
        {
            if (!epcsList.Contains(metaTag.EPC))
            {
                /// EPC not in list

                /// Adds EPC to rssisList
                epcsList.Add(metaTag.EPC);

                /// Adds EPC to readerRssisDic
                readerEPCsDic.Add(metaTag.EPC, 1);

                /// Get index of EPC in rssisDic
                int index = epcsList.Count() - 1;

                index *= 2;

                #region Paint Excel borders

                Excel.Range newRng = oSheetDataRSSIs.Range[String.Format("{0}1:{1}1", GetExcelLetters(index), GetExcelLetters(index + 1)), Type.Missing];
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;

                newRng = oSheetDataRSSIs.Range[String.Format("{0}1:{1}{2}", GetExcelLetters(index), GetExcelLetters(index + 1), FixedSizedQueue<int>.Size + 1), Type.Missing];
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;

                #endregion

                /// Increment index based on reader number, so that data from different UHFReader's don't override for different UHFReader
                index += (readerCounter - 1);

                /// Update EPC header
                oSheetDataRSSIs.Cells[1, index + 1] = String.Format("R{0}-{1}", readerCounter, metaTag.EPC.Substring(metaTag.EPC.Length - 4));

                /// Update RSSI for EPC
                oSheetDataRSSIs.Cells[1 + readerEPCsDic[metaTag.EPC]++, index + 1] = metaTag.RSSIAvg;

                /// Get range of values
                newRng = oSheetDataRSSIs.get_Range(String.Format("A1:{0}1;A2:{0}{1}", GetExcelLetters(index), FixedSizedQueue<int>.Size + 2));

                /// Tell oChartRSSIs to utilize especified range
                oChartRSSIs.Chart.SetSourceData(newRng, Excel.XlRowCol.xlColumns);
            }
            else
            {
                /// EPC exists in list

                /// Get index of EPC in rssisDic
                int index = epcsList.IndexOf(metaTag.EPC);

                /// Increment index based on reader number, so that data from different UHFReader's don't override for different UHFReader
                index = 2 * index + (readerCounter - 1);

                if (!readerEPCsDic.ContainsKey(metaTag.EPC))
                {
                    /// Adds EPC to readerRssisDic
                    readerEPCsDic.Add(metaTag.EPC, 1);

                    /// Update EPC header
                    oSheetDataRSSIs.Cells[1, index + 1] = String.Format("R{0}-{1}", readerCounter, metaTag.EPC.Substring(metaTag.EPC.Length - 4));
                }

                if (readerEPCsDic[metaTag.EPC] > FixedSizedQueue<int>.Size)
                {
                    /// Get column letter for index
                    string letter = GetExcelLetters(index);

                    /// Get last valid Excel row to use
                    int lastPosition = FixedSizedQueue<int>.Size + 1;

                    Excel.Range sourceRng = oSheetDataRSSIs.get_Range(String.Format("{0}3:{0}{1}", letter, lastPosition + 1));
                    Excel.Range targetRng = oSheetDataRSSIs.get_Range(String.Format("{0}2:{0}{1}", letter, lastPosition));

                    /// Copy source range data to target range data
                    targetRng.Value = sourceRng.Value;

                    /// Update RSSI for EPC
                    oSheetDataRSSIs.Cells[readerEPCsDic[metaTag.EPC], index + 1] = metaTag.RSSIAvg;
                }
                else
                {
                    /// Update RSSI for EPC
                    oSheetDataRSSIs.Cells[1 + readerEPCsDic[metaTag.EPC]++, index + 1] = metaTag.RSSIAvg;
                }
            }
        }

        /// <summary>
        /// Inserts Tags in Excel worksheet oSheetDataTags
        /// </summary>
        /// <param name="writeLog"></param>
        private static void DoExcelInsertTags(Action<string, int> writeLog)
        {
            if (tagsObtained.Count == 0)
            {
                return;
            }

            foreach (Tag tag in tagsObtained)
            {
                if (!tagsDic.ContainsKey(tag.ID))
                {
                    /// tag id not in list

                    /// Adds ID to tagsDic
                    tagsDic.Add(tag.ID, 1);

                    /// Get index of ID in tagsDic
                    int index = tagsDic.Count - 1;

                    /// Get column letter for tag's position x
                    string firstLetter = GetExcelLetters(index * 2);

                    /// Get column letter for tag's position y
                    string secondLetter = GetExcelLetters(index * 2 + 1);

                    oSheetDataTags.get_Range(String.Format("{0}1:{1}1", firstLetter, secondLetter)).Merge();

                    /// Insert last 4 digits of Tag ID
                    oSheetDataTags.get_Range(String.Format("{0}1", firstLetter)).Value = tag.ID.Substring(tag.ID.Length - 4);

                    /// Insert tag's position x header
                    oSheetDataTags.get_Range(String.Format("{0}2", firstLetter)).Value = "x";

                    /// Insert tag's position y header
                    oSheetDataTags.get_Range(String.Format("{0}2", secondLetter)).Value = "y";

                    /// Update tag's position x
                    oSheetDataTags.get_Range(String.Format("{0}{1}", firstLetter, 2 + tagsDic[tag.ID])).Value = tag.PositionX / 1000;

                    /// Update tag's position y
                    oSheetDataTags.get_Range(String.Format("{0}{1}", secondLetter, 2 + tagsDic[tag.ID])).Value = tag.PositionY / 1000;

                    #region Paint Excel borders

                    Excel.Range newRng = oSheetDataTags.get_Range(String.Format("{0}1:{1}2", firstLetter, secondLetter));
                    newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;

                    newRng = oSheetDataTags.get_Range(String.Format("{0}1:{1}{2}", firstLetter, secondLetter, 2 + MaxTagsQueueSize));
                    newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                    newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;

                    #endregion

                    #region treat Series data

                    Excel.Series oSeries;

                    if (!ChartTagsHasValues)
                    {
                        /// First entry

                        /// Use the first Series, that was created but is empty
                        oSeries = oChartTags.Chart.SeriesCollection(1);

                        ChartTagsHasValues = true;
                    }
                    else
                    {
                        /// After first entry

                        /// Create a new Series
                        oSeries = ((Excel.SeriesCollection)oChartTags.Chart.SeriesCollection()).NewSeries();
                    }

                    /// Update Series name
                    oSeries.Name = tag.ID;

                    /// Update Series's marker's size
                    oSeries.MarkerSize = 5;

                    /// Tell Series that the Tag's position x is associated with the Series X Values
                    oSeries.XValues = oSheetDataTags.get_Range(String.Format("{0}3:{0}52", firstLetter));

                    /// Tell Series that the Tag's position y is associated with the Series Values
                    oSeries.Values = oSheetDataTags.get_Range(String.Format("{0}3:{0}52", secondLetter));

                    #endregion
                }
                else
                {
                    /// tag id exists in list

                    /// Increment counter of ID of tagsDic
                    tagsDic[tag.ID]++;

                    /// Get index of ID in tagsDic
                    int index = tagsDic.Keys.ToList().IndexOf(tag.ID);

                    /// Get column letter for tag's position x
                    string firstLetter = GetExcelLetters(index * 2);

                    /// Get column letter for tag's position y
                    string secondLetter = GetExcelLetters(index * 2 + 1);

                    if (tagsDic[tag.ID] > MaxTagsQueueSize)
                    {
                        /// Get last valid Excel row to use
                        int lastPosition = 2 + MaxTagsQueueSize;
                        
                        Excel.Range sourceRng = oSheetDataTags.get_Range(String.Format("{0}4:{1}{2}", firstLetter, secondLetter, lastPosition + 1));
                        Excel.Range targetRng = oSheetDataTags.get_Range(String.Format("{0}3:{1}{2}", firstLetter, secondLetter, lastPosition));

                        /// Copy source range data to target range data
                        targetRng.Value = sourceRng.Value;
                        
                        /// Update tag's position x
                        oSheetDataTags.get_Range(String.Format("{0}{1}", firstLetter, lastPosition + 1)).Value = tag.PositionX / 1000;

                        /// Update tag's position y
                        oSheetDataTags.get_Range(String.Format("{0}{1}", secondLetter, lastPosition + 1)).Value = tag.PositionY / 1000;
                    }
                    else
                    {
                        /// Update tag's position x
                        oSheetDataTags.get_Range(String.Format("{0}{1}", firstLetter, 2 + tagsDic[tag.ID])).Value = tag.PositionX / 1000;

                        /// Update tag's position y
                        oSheetDataTags.get_Range(String.Format("{0}{1}", secondLetter, 2 + tagsDic[tag.ID])).Value = tag.PositionY / 1000;
                    }
                }
            }

            /// Clear tagsObtained List
            tagsObtained.Clear();
        }
        
        /// <summary>
        /// Gets the column letters from transformed number given
        /// </summary>
        /// <param name="number"></param>
        /// <returns>
        /// Returns column letter associated with number
        /// </returns>
        private static string GetExcelLetters(int number)
        {
            char letter = ' ';
            int counter = 0;
            char newLetter = 'A';
            int newCounter = 1;
            string str = "";

            /// Stops at AZZ
            if (number > 1377)
            {
                return null;
            }

            str = "";

            #region 3rd letter

            if (number > 701)
            {
                if (number % 1378 == 0)
                {
                    newLetter = (char)(newCounter + 65);
                    newCounter++;

                    if (newCounter > 25)
                    {
                        newCounter = 0;
                    }
                }

                str += newLetter;
            }

            #endregion

            #region 2nd letter

            if (number > 25)
            {
                if (number % 26 == 0)
                {
                    letter = (char)(counter + 65);
                    counter++;

                    if (counter > 25)
                    {
                        counter = 0;
                    }
                }

                str += letter;
            }

            #endregion

            #region 1st letter

            int b = number % 26;
            int a = b + 65;

            str += (char)a;

            #endregion

            return str;
        }
        
        /// <summary>
        /// Create and open an Excel application with data of metatags found in both readers
        /// </summary>
        /// <param name="R1"></param>
        /// <param name="R2"></param>
        /// <param name="readsDuration"></param>
        public static void GenerateFileFromData(UHFReader R1, UHFReader R2, string readsDuration)
        {
            #region generate Excel file

            #region config Excel application and workbook

            Excel.Application newoXL = new Excel.Application
            {
                Visible = true,
                WindowState = Excel.XlWindowState.xlMaximized,
                DisplayAlerts = true
            };

            Excel._Workbook newoWB = newoXL.Workbooks.Add(Missing.Value);

            #endregion

            #region config sheet

            Excel._Worksheet oSheetData = (Excel._Worksheet)newoWB.ActiveSheet;

            oSheetData.Name = "Tag lists from readers";

            oSheetData.get_Range("A1:N1").Font.Bold = true;

            #endregion

            #endregion

            #region insert data on sheet

            int columnStartR1 = 2;
            FillExcelWithReaderInfo(R1, oSheetData, columnStartR1, 1);

            int columnStartR2 = 8;
            FillExcelWithReaderInfo(R2, oSheetData, columnStartR2, 2);

            FillExcelWithReadersTotals(R1, R2, oSheetData, readsDuration);

            #endregion

            #region Sheet format

            Excel.Range er = oSheetData.get_Range("A1:E1");
            er.Merge();
            er.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            er = oSheetData.get_Range("G1:K1");
            er.Merge();
            er.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            
            oSheetData.get_Range("A1:N2").Columns.EntireColumn.AutoFit();

            #endregion

            //obs: if there is a need to save the file automatically
            //#region close and save file 

            //Marshal.ReleaseComObject(oSheetData);

            //newoWB.Close(false, null, null); // closes workbook, promping save file to user

            //Marshal.ReleaseComObject(newoWB);

            //newoXL.Quit();  // exit excel application
            //Marshal.ReleaseComObject(newoXL);
            //newoXL = null;

            //#endregion
        }

        /// <summary>
        /// Fills Excel with list os metatags of reader and other useful information about the reads process
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="oSheetData"></param>
        /// <param name="columnStart"></param>
        /// <param name="readerNum"></param>
        private static void FillExcelWithReaderInfo(UHFReader reader, Excel._Worksheet oSheetData, int columnStart, int readerNum)
        {
            if (reader == null)
            {
                return;
            }

            if (readerNum == 1)
            {
                /// format Reader 1 cells

                Excel.Range newRng = oSheetData.get_Range(String.Format("A1:E{0}", reader.MetaTagsDictionary.Count + 21));

                newRng.Interior.Color = Excel.XlRgbColor.rgbOrange;

                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            else
            {
                /// format Reader 2 cells

                Excel.Range newRng = oSheetData.get_Range(String.Format("G1:K{0}", reader.MetaTagsDictionary.Count + 21));

                newRng.Interior.Color = Excel.XlRgbColor.rgbOrchid;

                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
            }

            #region Initialize local vareables

            /// UHFReader Inventory counter
            UHFReaderInvCounter ric = reader.RIC;

            /// UHFReader Inventory parameters
            UHFReaderInvParams rip = reader.InvParams;

            /// List with MetaTags
            List<MetaTag> lmt = new List<MetaTag>();

            /// Dictionary that represents the line number on Excel for the EPC of this Reader
            /// Key => EPC
            /// Value => counter
            Dictionary<string, int> dic = new Dictionary<string, int>();

            /// Represents line number on Excel
            int counter = 1;

            #endregion

            foreach (string epc in reader.MetaTagsDictionary.Keys)
            {
                /// Add MetaTag
                lmt.Add(reader.MetaTagsDictionary[epc]);

                /// Add EPC with line number on Excel
                dic.Add(epc, counter++);
            }

            lmt.Sort();

            /// Reader line number on Excel
            int rcL = 1;

            oSheetData.Cells[rcL++, columnStart - 1] = String.Format("R{0}", readerNum);

            oSheetData.Cells[rcL++, columnStart] = String.Format("Frequency min: {0} MHz", reader.MinFrequency);
            oSheetData.Cells[rcL++, columnStart] = String.Format("Frequency Max: {0} MHz", reader.MaxFrequency);
            oSheetData.Cells[rcL++, columnStart] = String.Format("Power: {0} dBm", reader.PowerDbm);

            rcL++;

            oSheetData.Cells[rcL++, columnStart] = String.Format("Q: {0}", rip.QValue);
            oSheetData.Cells[rcL++, columnStart] = String.Format("S: {0}", rip.Session);
            oSheetData.Cells[rcL++, columnStart] = String.Format("T: {0}", rip.Target);
            oSheetData.Cells[rcL++, columnStart] = String.Format("Commute: {0}", rip.ConvertTagFlagWhenFailedReads);

            rcL++;

            oSheetData.Cells[rcL++, columnStart] = String.Format("Invs (no Tags): {0}", ric.invsWithoutTags);
            oSheetData.Cells[rcL++, columnStart] = String.Format("Invs (with Tags): {0}", ric.invsWithTags);

            /// Total number of Inventaries that were gotten by Reader
            int totalInvsReader = ric.invsWithoutTags + ric.invsWithTags;

            oSheetData.Cells[rcL++, columnStart] = String.Format("Invs (Total): {0} => {1:0.00}%/{2:0.00}%",
                totalInvsReader,
                (double)ric.invsWithTags / totalInvsReader * 100,
                (double)ric.invsWithoutTags / totalInvsReader * 100);

            rcL++;

            oSheetData.Cells[rcL++, columnStart] = String.Format("Nº tags: {0}", ric.numTagsFound);
            oSheetData.Cells[rcL++, columnStart] = String.Format("MIN tags: {0}", ric.numTagsFoundMin);
            oSheetData.Cells[rcL++, columnStart] = String.Format("AVG tags: {0:0.00}", ric.GetTagsAvg());
            oSheetData.Cells[rcL++, columnStart] = String.Format("MAX tags: {0}", ric.numTagsFoundMax);

            rcL++;

            oSheetData.Cells[rcL, columnStart - 1] = "#";
            oSheetData.Cells[rcL, columnStart] = "EPC";
            oSheetData.Cells[rcL, columnStart + 1] = "Times";
            oSheetData.Cells[rcL, columnStart + 2] = "RSSI";
            oSheetData.Cells[rcL, columnStart + 3] = "RSSI_AVG";
            oSheetData.get_Range(String.Format("A{0}:N{0}", rcL)).Columns.EntireColumn.AutoFit();
            oSheetData.get_Range(String.Format("A{0}:N{0}", rcL)).Font.Bold = true;

            rcL++;

            /// The summation of the times that each MetaTag was read
            int sumTimes = 0;

            foreach (MetaTag mt in lmt)
            {
                oSheetData.Cells[rcL, columnStart - 1] = dic[mt.EPC];
                oSheetData.Cells[rcL, columnStart] = mt.EPC;
                oSheetData.Cells[rcL, columnStart + 1] = mt.RSSICounter;
                oSheetData.Cells[rcL, columnStart + 2] = mt.RSSI;
                oSheetData.Cells[rcL, columnStart + 3] = mt.RSSIAvg;

                sumTimes += mt.RSSICounter;

                rcL++;
            }
            oSheetData.Cells[rcL, columnStart - 1] = lmt.Count;
            oSheetData.Cells[rcL, columnStart + 1] = sumTimes;

            //-------------

            rcL += 2;

            /// newList gets all EPCs that are on dataset, but not in the lmt
            EPCsComparer.GetEpcsNotInList(lmt, out List<string> newList);

            /// EPC line number on Excel
            int newCounter = 1;

            /// Put Dataset label on Excel
            oSheetData.Cells[rcL++, columnStart] = newList[0];

            /// Remove Dataset Label
            newList.RemoveAt(0);

            foreach (string s in newList)
            {
                oSheetData.Cells[rcL, columnStart - 1] = newCounter++;
                oSheetData.Cells[rcL++, columnStart] = s;
            }
        }

        /// <summary>
        /// Fills Excel with useful information about the reads process
        /// </summary>
        /// <param name="R1"></param>
        /// <param name="R2"></param>
        /// <param name="oSheetData"></param>
        /// <param name="readsDuration"></param>
        private static void FillExcelWithReadersTotals(UHFReader R1, UHFReader R2, Excel._Worksheet oSheetData, string readsDuration)
        {
            if (R1 != null && R2 != null)
            {
                #region Format Cells

                Excel.Range newRng = oSheetData.get_Range(String.Format("M1:M{0}", 18));

                newRng.Interior.Color = Excel.XlRgbColor.rgbOlive;

                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
                newRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;

                #endregion

                /// UHFReader Inventory counter for Reader 1
                UHFReaderInvCounter ric1 = R1.RIC;

                /// UHFReader Inventory counter for Reader 2
                UHFReaderInvCounter ric2 = R2.RIC;

                /// Line number on Excel
                int lineStart = 1;

                /// Column number on Excel
                int column = 13;

                oSheetData.Cells[lineStart++, column] = String.Format("Reads Duration (ms): {0}", readsDuration);

                lineStart = 11;

                oSheetData.Cells[lineStart++, column] = String.Format("Total Invs (no Tags): {0}", ric1.invsWithoutTags + ric2.invsWithoutTags);
                oSheetData.Cells[lineStart++, column] = String.Format("Total Invs (with Tags): {0}", ric1.invsWithTags + ric2.invsWithTags);

                ///Total number of Inventaries that were gotten both Reader 1 and Reader 2
                int totalInvs = ric1.invsWithoutTags + ric1.invsWithTags + ric2.invsWithoutTags + ric2.invsWithTags;

                oSheetData.Cells[lineStart++, column] = String.Format("Total Invs (Total): {0} => {1:0.00}%/{2:0.00}%",
                    totalInvs,
                    ((double)ric1.invsWithTags + ric2.invsWithTags) / totalInvs * 100,
                    ((double)ric1.invsWithoutTags + ric2.invsWithoutTags) / totalInvs * 100);

                lineStart++;

                oSheetData.Cells[lineStart++, column] = String.Format("Total Nº tags: {0}", ric2.numTagsFound + ric2.numTagsFound);
                oSheetData.Cells[lineStart++, column] = String.Format("Total MIN tags: {0}", Math.Min(ric1.numTagsFoundMin, ric2.numTagsFoundMin));
                oSheetData.Cells[lineStart++, column] = String.Format("Total AVG tags: {0:0.00}", (ric1.GetTagsAvg() + ric2.GetTagsAvg()) / 2);
                oSheetData.Cells[lineStart++, column] = String.Format("Total MAX tags: {0}", Math.Max(ric1.numTagsFoundMax, ric2.numTagsFoundMax));
            }
        }
    }
}
