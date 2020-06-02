using RINPOSYS.CustomClasses;
using RINPOSYS.CustomClasses.UI;
using RINPOSYS.CustomClasses.Algorithm;
using RINPOSYS.CustomClasses.RFIDReads;
using RINPOSYS.CustomClasses.ExcelInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RINPOSYS.CustomClasses.Utils;
using System.Diagnostics;
using RINPOSYS.CustomClasses.Devices.UHFReader;
using RINPOSYS.CustomClasses.Devices.LaserModule;
using RINPOSYS.CustomClasses.Devices.Servo;
using RINPOSYS.CustomClasses.Devices.GenericDevice;
using System.Threading;
using System.Globalization;
using RINPOSYS.CustomClasses.IOFiles;

namespace RINPOSYS
{
    /// <summary>
    /// Form used in application
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// List of devices found in config file Devices.txt
        /// </summary>
        private List<Device> devicesFound;

        /// <summary>
        /// List of devices connected in software
        /// </summary>
        private List<Device> devicesConnected;

        /// <summary>
        /// Binding list used as source by dataGridViewTagsList component 
        /// </summary>
        private BindingList<Tag> tagsBindingList;

        /// <summary>
        /// Manages all devices data interaction
        /// </summary>
        private DataController dc;

        /// <summary>
        /// Valitades only numbers in matched string
        /// </summary>
        private static Regex regexNumbers = new Regex(@"^[0-9]+[.,]?[0-9]*$");

        /// <summary>
        /// Stopwatch used when the objective is to have a timed read process
        /// </summary>
        private Stopwatch stopWatch;
        
        public Form1()
        {
            InitializeComponent();
        }

        #region Form control

        private void Form1_Load(object sender, EventArgs e)
        {
            DisabledForm();

            /// Used to workaround the replacing of '.' to ',' when converting strings into floating-point numbers
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            #region Vareables Initialization

            tagsBindingList = new BindingList<Tag>();
            dataGridViewTagsList.DataSource = tagsBindingList;

            devicesFound = new List<Device>();
            devicesConnected = new List<Device>();

            dc = new DataController(
                writeLog: WriteLog,
                updateUIGridMetaTagsDel: UpdateUIGridMetaTagsDel,
                removeFromUIGridMetaTagsDel: RemoveFromUIGridMetaTagsDel,
                clearUIGridMetaTagsDel: ClearUIGridMetaTagsDel,
                updateUIGridTagsDel: UpdateUIGridTagsDel);

            /// Loads all configuration files
            dc.LoadConfigFiles();

            /// Tests if MySQL connection is successful
            dc.TestMySQLConnection();

            //dc.ConnectAllDevices();
            //dc.StartReads(null);

            #endregion

            UpdateUI();

            WriteLog(String.Format("Using Mathematical Model Parameters: {0}", MathematicModelParameters.ParametersToString()), 0);

            WriteToWriteLogDevicesFound();
        }

        /// <summary>
        /// Closes Excel resources if any is being used, then closes form and application
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ExcelMediator.Close();

            base.OnFormClosed(e);

            Environment.Exit(0);
        }

        #region Form UI Enabled/Disabled

        private void DisabledForm()
        {
            groupBoxSetup.Enabled = false;
            groupBoxReadsList.Enabled = false;
            groupBoxTagsList.Enabled = false;
        }
        private void EnabledForm()
        {
            groupBoxSetup.Enabled = true;
            groupBoxReadsList.Enabled = true;
            groupBoxTagsList.Enabled = true;
        }
        private void RefreshFormState()
        {
            if (devicesConnected.Count > 0)
            {
                EnabledForm();
            }
            else
            {
                DisabledForm();
            }
        }

        #endregion

        #endregion

        #region Delegates

        #region WriteLog

        private delegate void WriteLogUnSafe(string strLog, int nType);
        private void WriteLog(string strLog, int nType)
        {
            if (InvokeRequired)
            {
                WriteLogUnSafe InvokeWriteLog = new WriteLogUnSafe(WriteLog);
                Invoke(InvokeWriteLog, new object[] { strLog, nType });
            }
            else
            {
                if (nType == 0)
                {
                    richTextBoxLog.AppendText(strLog, Color.Indigo);
                }
                else
                {
                    richTextBoxLog.AppendText(strLog, Color.Red);
                }

                richTextBoxLog.Select(richTextBoxLog.TextLength, 0);
                richTextBoxLog.ScrollToCaret();

                if (dc != null)
                {
                    dc.WriteLogToFile(strLog);
                }
            }
        }
        private void ButtonRefreshLogs_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }

        #endregion

        #region UpdateMetaTagGrid
        
        private delegate void DelegateUpdateMetaTagGrid(MetaTag mt);

        private void UpdateUIGridMetaTagsDel(MetaTag mt)
        {
            DelegateUpdateMetaTagGrid del = new DelegateUpdateMetaTagGrid(UpdateMetaTagGrid);
            Invoke(del, mt);
        }

        private void UpdateMetaTagGrid(MetaTag mt)
        {
            if (!DataController.onReads)
            {
                return;
            }

            bool isonlistview = false;            
            for (int i = 0; i < dataGridViewMetaTagsList.RowCount; i++)
            {
                if ((dataGridViewMetaTagsList.Rows[i].Cells[3].Value != null)
                    && (mt.Antenna.ID == (int)dataGridViewMetaTagsList.Rows[i].Cells[1].Value)
                    && (mt.EPC == dataGridViewMetaTagsList.Rows[i].Cells[3].Value.ToString()))
                {
                    DataGridViewRow rows = dataGridViewMetaTagsList.Rows[i];

                    rows.Cells[2].Value = mt.TimeStampDateTime;
                    rows.Cells[4].Value = mt.RSSICounter;
                    rows.Cells[5].Value = mt.RSSI;
                    rows.Cells[6].Value = mt.RSSIAvg;

                    isonlistview = true;

                    break;
                }
            }
            if (!isonlistview)
            {
                object[] arr = new object[7];
                arr[0] = dataGridViewMetaTagsList.RowCount + 1;
                arr[1] = mt.Antenna.ID;
                arr[2] = mt.TimeStampDateTime;
                arr[3] = mt.EPC;
                arr[4] = mt.RSSICounter;
                arr[5] = mt.RSSI;
                arr[6] = mt.RSSIAvg;

                dataGridViewMetaTagsList.Rows.Insert(dataGridViewMetaTagsList.RowCount, arr);
            }
        }
        #endregion

        #region ClearMetaTagGrid

        private delegate void DelegateClearMetaTagGrid();

        private void ClearUIGridMetaTagsDel()
        {
            DelegateClearMetaTagGrid del = new DelegateClearMetaTagGrid(ClearMetaTagGrid);
            Invoke(del);
        }

        private void ClearMetaTagGrid()
        {
            dataGridViewMetaTagsList.Rows.Clear();
        }

        #endregion

        #region RemoveFromMetaTagGridDel

        private delegate void DelegateRemoveFromMetaTagGrid(MetaTag mt);

        private void RemoveFromUIGridMetaTagsDel(MetaTag mt)
        {
            DelegateRemoveFromMetaTagGrid del = new DelegateRemoveFromMetaTagGrid(RemoveFromMetaTagGrid);
            Invoke(del, mt);
        }

        private void RemoveFromMetaTagGrid(MetaTag mt)
        {
            for (int i = 0; i < dataGridViewMetaTagsList.RowCount; i++)
            {
                if (mt.EPC == dataGridViewMetaTagsList.Rows[i].Cells[2].Value.ToString())
                {
                    dataGridViewMetaTagsList.Rows.RemoveAt(i);

                    for (int j = i; j < dataGridViewMetaTagsList.RowCount; j++)
                    {
                        dataGridViewMetaTagsList.Rows[j].Cells[0].Value = j;
                    }

                    break;
                }
            }
        }

        #endregion

        #region UpdateTagGrid

        private delegate void DelegateUpdateTagGrid(List<Tag> t);

        private void UpdateUIGridTagsDel(List<Tag> t)
        {
            DelegateUpdateTagGrid del = new DelegateUpdateTagGrid(UpdateTagGrid);
            Invoke(del, t);
        }

        private void UpdateTagGrid(List<Tag> tags)
        {
            foreach (Tag tag in tags)
            {
                tagsBindingList.Add(tag);

                WriteLog(String.Format("New Tag obtained: {0} ({1:0}, {2:0})", tag.ID, tag.PositionX, tag.PositionY), 0);
            }

            dataGridViewTagsList.CurrentCell = dataGridViewTagsList.Rows[dataGridViewTagsList.RowCount - 1].Cells[0];
        }

        #endregion

        #endregion

        #region Devices UI control

        #region Connection/Disconnection UI control

        private void ButtonConnection_Click(object sender, EventArgs e)
        {
            Device device = devicesFound.Find(d => d.ID == ((Button)sender).Parent.Text);
            bool connect = (((Button)sender).Text == "Connect") ? true : false;

            if (connect)
            {
                if (!ValidateFieldsForConnect(device, (GroupBox)((Button)sender).Parent))
                {
                    return;
                }

                if (!ConnectDevice(device))
                {
                    return;
                }

                ((Button)sender).Text = "Disconnect";

                ((Button)sender).Parent.Controls.Find("comboBoxPort", false)[0].Enabled = false;
                ((Button)sender).Parent.Controls.Find("comboBoxBaudRate", false)[0].Enabled = false;

                if (device is UHFReader)
                {
                    ((Button)sender).Parent.Controls.Find("checkBoxBeep", false)[0].Enabled = true;

                    ((Button)sender).Parent.Controls.Find("textBoxAntX", false)[0].Enabled = false;
                    ((Button)sender).Parent.Controls.Find("textBoxAntY", false)[0].Enabled = false;

                    ((Button)sender).Parent.Controls.Find("comboBoxPower", false)[0].Enabled = false;
                }
                else if (device is LaserModule)
                {
                    ((Button)sender).Parent.Controls.Find("comboBoxDirection", false)[0].Enabled = false;
                }
            }
            else
            {
                if (!DisconnectDevice(device))
                {
                    return;
                }

                ((Button)sender).Text = "Connect";

                ((Button)sender).Parent.Controls.Find("comboBoxPort", false)[0].Enabled = true;
                ((Button)sender).Parent.Controls.Find("comboBoxBaudRate", false)[0].Enabled = true;

                if (device is UHFReader)
                {
                    ((Button)sender).Parent.Controls.Find("checkBoxBeep", false)[0].Enabled = false;
                    ((CheckBox)((Button)sender).Parent.Controls.Find("checkBoxBeep", false)[0]).Checked = false;

                    ((Button)sender).Parent.Controls.Find("textBoxAntX", false)[0].Enabled = true;
                    ((Button)sender).Parent.Controls.Find("textBoxAntY", false)[0].Enabled = true;

                    ((Button)sender).Parent.Controls.Find("comboBoxPower", false)[0].Enabled = true;
                }
                else if (device is LaserModule)
                {
                    ((Button)sender).Parent.Controls.Find("comboBoxDirection", false)[0].Enabled = true;
                }
            }

            RefreshFormState();
        }

        private bool ValidateFieldsForConnect(Device device, GroupBox groupBox)
        {
            string strLog;

            if (device.PortStr == "")
            {
                strLog = "Device Port isn't choosen!";
                WriteLog(strLog, 1);
                return false;
            }

            if (device is UHFReader)
            {
                TextBox textBoxAntX = (TextBox)groupBox.Controls.Find("textBoxAntX", false)[0];
                TextBox textBoxAntY = (TextBox)groupBox.Controls.Find("textBoxAntY", false)[0];

                if (textBoxAntX.Text == "")
                {
                    strLog = "Antenna x (m) is empty!";
                    WriteLog(strLog, 1);
                    return false;
                }

                if (textBoxAntY.Text == "")
                {
                    strLog = "Antenna y (m) is empty!";
                    WriteLog(strLog, 1);
                    return false;
                }

                textBoxAntX.Text = textBoxAntX.Text;

                if (!Double.TryParse(textBoxAntX.Text, out double aNumber))
                {
                    strLog = "Antenna x (m) value isn't a valid number!";
                    WriteLog(strLog, 1);
                    return false;
                }

                textBoxAntY.Text = textBoxAntY.Text;

                if (!Double.TryParse(textBoxAntY.Text, out aNumber))
                {
                    strLog = "Antenna y (m) value isn't a valid number!";
                    WriteLog(strLog, 1);
                    return false;
                }
            }
            else if (device is LaserModule)
            {
                ComboBox comboBoxDirection = (ComboBox)groupBox.Controls.Find("comboBoxDirection", false)[0];

                if (comboBoxDirection.SelectedIndex == -1)
                {
                    strLog = "Laser direction not set!";
                    WriteLog(strLog, 1);
                    return false;
                }
            }

            return true;
        }

        private bool DisconnectDevice(Device device)
        {
            if (device.Disconnect())
            {
                if (!devicesConnected.Remove(device))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ConnectDevice(Device device)
        {
            if (device is UHFReader)
            {
                if (device.Connect())
                {
                    devicesConnected.Add(device);

                    bool BeepEnabled = (device as UHFReader).BeepOn;

                    GroupBox GroupBoxDevice = (GroupBox)panelDevices.Controls.Find("GroupBoxDevice" + device.ID.Substring("device ".Length), false)[0];
                    CheckBox checkBoxBeep = ((CheckBox)GroupBoxDevice.Controls.Find("checkBoxBeep", false)[0]);

                    checkBoxBeep.Checked = BeepEnabled;

                    return true;
                }
            }
            else if (device is LaserModule)
            {
                if (device.Connect())
                {
                    devicesConnected.Add(device);

                    return true;
                }
            }
            else if (device is Servo)
            {
                if (device.Connect())
                {
                    devicesConnected.Add(device);

                    return true;
                }
            }

            return false;
        }

        #endregion

        #region UHFReader UI control

        private void CheckBoxBeep_Click(object sender, EventArgs e)
        {
            UHFReader reader = (UHFReader)devicesConnected.Find(d => d.ID == ((CheckBox)sender).Parent.Text);

            byte beep = 0;
            if (((CheckBox)sender).Checked)
            {
                beep = 1;
            }

            reader.SetBeepState(beep);
        }

        private void ComboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device device = devicesFound.Find(d => d.ID == ((ComboBox)sender).Parent.Text);
            device.BaudRateStr = (string)((ComboBox)sender).SelectedItem;

            if (device is UHFReader)
            {
                ((UHFReader)device).FBaud = ByteConversion.GetBaudRateIndexByte(device.BaudRateStr);
            }
        }

        private void ComboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device device = devicesFound.Find(d => d.ID == ((ComboBox)sender).Parent.Text);

            device.PortStr = (string)((ComboBox)sender).SelectedItem;

            if (device is UHFReader)
            {
                (device as UHFReader).PortNum = Int32.Parse(device.PortStr.Substring(3, device.PortStr.Length - 3));
            }
        }

        private void ComboBoxPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device device = devicesFound.Find(d => d.ID == ((ComboBox)sender).Parent.Text);

            if (device is UHFReader)
            {
                (device as UHFReader).PowerDbm = Convert.ToByte(((ComboBox)sender).SelectedItem);
            }
        }

        #endregion

        #region Laser UI control

        private void ButtonGetLaserStatus_Click(object sender, EventArgs e)
        {
            Device device = devicesFound.Find(d => d.ID == ((Button)sender).Parent.Text);
            string s = ((LaserModule)device).GetLaserStatus();
            ((Button)sender).Parent.Controls.Find("textBoxLaserStatus", false)[0].Text = s;
        }

        private void ComboBoxDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device device = devicesFound.Find(d => d.ID == ((ComboBox)sender).Parent.Text);
            ((LaserModule)device).Direction = (LaserDirection)((ComboBox)sender).SelectedIndex;
        }

        private void ButtonLaserOnOff_Click(object sender, EventArgs e)
        {
            LaserModule laser = (LaserModule)devicesFound.Find(d => d.ID == ((Button)sender).Parent.Text);

            if (((Button)sender).Text == "L (OFF)")
            {
                laser.TurnLaser(true);
                ((Button)sender).Text = "L (ON)";
            }
            else
            {
                laser.TurnLaser(false);
                ((Button)sender).Text = "L (OFF)";
            }
        }

        #endregion

        private void GenerateUIForDevices(ref Panel panelDevices, List<Device> devices)
        {
            for (int i = 0; i < devices.Count; i++)
            {
                int deviceNumber = i + 1;

                GroupBox Gb = new GroupBox
                {
                    Name = "GroupBoxDevice" + deviceNumber,
                    Text = devices[i].ID,
                    Location = new Point(0, 89 * i),
                    Size = new Size(800, 83)
                };

                #region generate controls for groupbox

                Label LabelType = new Label
                {
                    Name = "labelType",
                    Text = "Type:",
                    Location = new Point(6, 22),
                    Size = new Size(34, 13)
                };

                Label LabelPort = new Label
                {
                    Name = "labelPort",
                    Text = "Port:",
                    Location = new Point(6, 50),
                    Size = new Size(29, 13)
                };

                Label LabelBaudRate = new Label
                {
                    Name = "labelBaudRate",
                    Text = "Baud rate:",
                    Location = new Point(105, 22),
                    Size = new Size(56, 13)
                };

                string deviceType = devices[i] is UHFReader ? "Reader" : devices[i] is LaserModule ? "Laser" : "Servo";
                TextBox textBoxType = new TextBox
                {
                    Name = "textBoxType",
                    Text = deviceType,
                    Location = new Point(41, 19),
                    Size = new Size(60, 21),
                    ReadOnly = true
                };

                ComboBox ComboBoxPort = new ComboBox
                {
                    Name = "comboBoxPort",
                    Location = new Point(41, 47),
                    Size = new Size(60, 21),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                ComboBoxPort.Items.AddRange(UICollections.DevicePorts);
                ComboBoxPort.SelectedItem = devices[i].PortStr;
                ComboBoxPort.SelectedIndexChanged += new EventHandler(ComboBoxPort_SelectedIndexChanged);

                ComboBox ComboBoxBaudRate = new ComboBox
                {
                    Name = "comboBoxBaudRate",
                    Location = new Point(167, 19),
                    Size = new Size(77, 21),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Enabled = false
                };
                ComboBoxBaudRate.Items.AddRange(UICollections.DeviceBaudRates);
                ComboBoxBaudRate.SelectedItem = devices[i].BaudRateStr;
                ComboBoxBaudRate.SelectedIndexChanged += new EventHandler(ComboBoxBaudRate_SelectedIndexChanged);

                Button ButtonConnection = new Button
                {
                    Name = "buttonConnection",
                    Text = "Connect",
                    Location = new Point(108, 46),
                    Size = new Size(78, 24)
                };
                ButtonConnection.Click += new EventHandler(ButtonConnection_Click);

                //------

                Gb.Controls.Add(LabelType);
                Gb.Controls.Add(LabelPort);
                Gb.Controls.Add(LabelBaudRate);

                Gb.Controls.Add(textBoxType);

                Gb.Controls.Add(ComboBoxPort);
                Gb.Controls.Add(ComboBoxBaudRate);

                Gb.Controls.Add(ButtonConnection);

                #endregion

                if (devices[i] is UHFReader)
                {
                    #region generate UHFReader especific controls

                    Label LabelAntX = new Label
                    {
                        Name = "labelAntX",
                        Text = "Antenna x (m):",
                        Location = new Point(276, 22),
                        Size = new Size(83, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    Label LabelAntY = new Label
                    {
                        Name = "labelAntY",
                        Text = "Antenna y (m):",
                        Location = new Point(276, 48),
                        Size = new Size(83, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    Label LabelFrequencyMin = new Label
                    {
                        Name = "labelFreqMin",
                        Text = "Freq. min. (MHz):",
                        Location = new Point(480, 22),
                        Size = new Size(100, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    Label LabelFrequencyMax = new Label
                    {
                        Name = "labelFreqMax",
                        Text = "Freq. Max. (MHz):",
                        Location = new Point(480, 50),
                        Size = new Size(100, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    Label LabelPower = new Label
                    {
                        Name = "labelPower",
                        Text = "Power (dBm):",
                        Location = new Point(680, 50),
                        Size = new Size(70, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    TextBox TextBoxAntX = new TextBox
                    {
                        Name = "textBoxAntX",
                        Location = new Point(365, 19),
                        Size = new Size(77, 20),
                        Text = (devices[i] as UHFReader).Antenna.Position.X.ToString(),
                        ReadOnly = true
                    };

                    TextBox TextBoxAntY = new TextBox
                    {
                        Name = "textBoxAntY",
                        Location = new Point(365, 45),
                        Size = new Size(77, 20),
                        Text = (devices[i] as UHFReader).Antenna.Position.Y.ToString(),
                        ReadOnly = true
                    };

                    CheckBox CheckBoxBeep = new CheckBox
                    {
                        Name = "checkBoxBeep",
                        Text = "Beep",
                        Location = new Point(193, 51),
                        Size = new Size(51, 17)
                    };
                    CheckBoxBeep.Click += new EventHandler(CheckBoxBeep_Click);
                    CheckBoxBeep.Enabled = false;

                    ComboBox ComboBoxFrequencyMin = new ComboBox
                    {
                        Name = "comboBoxFrequencyMin",
                        Location = new Point(580, 19),
                        Size = new Size(55, 21),
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Enabled = false
                    };
                    ComboBoxFrequencyMin.Items.AddRange(RegionFrequencyConverter.GetFrequencies());
                    ComboBoxFrequencyMin.SelectedItem = Convert.ToString((devices[i] as UHFReader).MinFrequency);

                    ComboBox ComboBoxFrequencyMax = new ComboBox
                    {
                        Name = "comboBoxFrequencyMax",
                        Location = new Point(580, 47),
                        Size = new Size(55, 21),
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        Enabled = false
                    };
                    ComboBoxFrequencyMax.Items.AddRange(RegionFrequencyConverter.GetFrequencies());
                    ComboBoxFrequencyMax.SelectedItem = Convert.ToString((devices[i] as UHFReader).MaxFrequency);

                    ComboBox ComboBoxPower = new ComboBox
                    {
                        Name = "comboBoxPower",
                        Location = new Point(750, 47),
                        Size = new Size(40, 21),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    ComboBoxPower.Items.AddRange(UICollections.DevicePower);
                    ComboBoxPower.SelectedItem = Convert.ToString((devices[i] as UHFReader).PowerDbm);
                    ComboBoxPower.SelectedIndexChanged += new EventHandler(ComboBoxPower_SelectedIndexChanged);

                    Gb.Controls.Add(LabelAntX);
                    Gb.Controls.Add(LabelAntY);
                    Gb.Controls.Add(LabelPower);
                    Gb.Controls.Add(TextBoxAntX);
                    Gb.Controls.Add(TextBoxAntY);
                    Gb.Controls.Add(CheckBoxBeep);
                    Gb.Controls.Add(ComboBoxPower);

                    Gb.Controls.Add(LabelFrequencyMin);
                    Gb.Controls.Add(LabelFrequencyMax);
                    Gb.Controls.Add(ComboBoxFrequencyMin);
                    Gb.Controls.Add(ComboBoxFrequencyMax);

                    #endregion
                }
                else if (devices[i] is LaserModule)
                {
                    #region generate LaserModule especific controls

                    Label LabelDirection = new Label
                    {
                        Name = "labelDirection",
                        Text = "Direction:",
                        Location = new Point(276, 22),
                        Size = new Size(83, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    ComboBox ComboBoxDirection = new ComboBox
                    {
                        Name = "comboBoxDirection",
                        Location = new Point(365, 19),
                        Size = new Size(77, 20),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    ComboBoxDirection.Items.AddRange(UICollections.LaserDirection);
                    ComboBoxDirection.SelectedIndex = (int)(devices[i] as LaserModule).Direction;
                    ComboBoxDirection.SelectedIndexChanged += new EventHandler(ComboBoxDirection_SelectedIndexChanged);

                    Button ButtonGetLaserStatus = new Button
                    {
                        Name = "buttonGetLaserStatus",
                        Text = "Status",
                        Location = new Point(276, 46),
                        Size = new Size(78, 24)
                    };
                    ButtonGetLaserStatus.Click += new EventHandler(ButtonGetLaserStatus_Click);

                    TextBox TextBoxLaserStatus = new TextBox
                    {
                        Name = "textBoxLaserStatus",
                        Location = new Point(365, 48),
                        Size = new Size(77, 20),
                        ReadOnly = true
                    };

                    Button ButtonLaserOnOff = new Button
                    {
                        Name = "buttonLaserOnOff",
                        Text = "L (OFF)",
                        Location = new Point(195, 46),
                        Size = new Size(50, 24)
                    };
                    ButtonLaserOnOff.Click += new EventHandler(ButtonLaserOnOff_Click);

                    Label LabelOffset = new Label
                    {
                        Name = "labelOffset",
                        Text = "Offset (m):",
                        Location = new Point(497, 22),
                        Size = new Size(83, 13),
                        TextAlign = ContentAlignment.MiddleRight
                    };

                    TextBox TextBoxLaserOffset = new TextBox
                    {
                        Name = "textBoxLaserOffset",
                        Location = new Point(580, 20),
                        Size = new Size(77, 20),
                        ReadOnly = true
                    };
                    TextBoxLaserOffset.Text = Convert.ToString((devices[i] as LaserModule).Offset);

                    Gb.Controls.Add(LabelDirection);
                    Gb.Controls.Add(LabelOffset);
                    Gb.Controls.Add(ComboBoxDirection);
                    Gb.Controls.Add(ButtonGetLaserStatus);
                    Gb.Controls.Add(TextBoxLaserStatus);
                    Gb.Controls.Add(TextBoxLaserOffset);

                    Gb.Controls.Add(ButtonLaserOnOff);

                    #endregion
                }
                else if (devices[i] is Servo)
                {
                    //TODO
                }

                panelDevices.Controls.Add(Gb);

            }
        }

        #endregion

        #region Start/Stop Reads process control

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            bool start = (((Button)sender).Text == "Start") ? true : false;

            if (start)
            {

                if (checkBoxDuration.Checked)
                {
                    stopWatch = new Stopwatch();
                    stopWatch.Start();

                    timerReads.Enabled = true;

                    if (!int.TryParse(textBoxDuration.Text, out int millis))
                    {
                        return;
                    }
                    else
                    {
                        timerDuration.Interval = millis;
                        timerDuration.Enabled = true;
                    }
                }

                tagsBindingList.Clear();
                
                dc.StartReads(devicesConnected);

                ((Button)sender).BackColor = Color.BlueViolet;
                ((Button)sender).Text = "Stop";
            }
            else
            {
                dc.StopReads();
                
                ((Button)sender).BackColor = Color.Transparent;
                ((Button)sender).Text = "Start";

                if (stopWatch != null)
                {
                    stopWatch.Stop();
                    stopWatch = null;
                }

                timerReads.Enabled = false;
                timerDuration.Enabled = false;
            }
        }

        #endregion

        #region Logging methods

        private void WriteToWriteLogDevicesFound()
        {
            if (devicesFound.Count > 0)
            {
                WriteLog("Devices found...", 0);
                foreach (Device d in devicesFound)
                {
                    WriteLog(String.Format("\t{0}", d.ToString()), 0);
                }
            }
            else
            {
                WriteLog("No Devices found", 1);
            }
        }

        #endregion

        #region Update UI Methods

        private void UpdateUI()
        {
            UpdateUIDevices();
            UpdateUIMMParams();
            UpdateUINotes();
            UpdateUIMySQL();
            UpdateUIEPCDatasets();
        }

        private void UpdateUIDevices()
        {
            devicesFound.Clear();
            devicesConnected.Clear();
            panelDevices.Controls.Clear();

            RefreshFormState();

            devicesFound = dc.Devices;

            GenerateUIForDevices(ref panelDevices, devicesFound);

            //-----------

            int readerCounter = 1;
            foreach (Device d in devicesFound)
            {
                if (d is UHFReader)
                {
                    if (readerCounter == 1)
                    {
                        cbR1Q.SelectedIndex = (d as UHFReader).InvParams.QValue;
                        cbR1Session.SelectedIndex = (d as UHFReader).InvParams.Session;
                        cbR1Target.SelectedIndex = (d as UHFReader).InvParams.Target;
                    }
                    else
                    {
                        cbR2Q.SelectedIndex = (d as UHFReader).InvParams.QValue;
                        cbR2Session.SelectedIndex = (d as UHFReader).InvParams.Session;
                        cbR2Target.SelectedIndex = (d as UHFReader).InvParams.Target;
                    }

                    readerCounter++;
                }
            }

            for (int i = 0x03; i <= 0xff; i++)
            {
                cbR1Scantime.Items.Add(Convert.ToString(i) + "*100ms");
                cbR2Scantime.Items.Add(Convert.ToString(i) + "*100ms");

            }
            cbR1Scantime.SelectedIndex = 7;
            cbR2Scantime.SelectedIndex = 7;
        }

        private void UpdateUIMMParams()
        {
            textBoxLMax.Clear();
            textBoxRssiMin.Clear();
            textBoxRssiMax.Clear();
            textBoxXAmp.Clear();

            textBoxLMax.Text = MathematicModelParameters.LMax.ToString();
            textBoxRssiMin.Text = MathematicModelParameters.RssiMin.ToString();
            textBoxRssiMax.Text = MathematicModelParameters.RssiMax.ToString();
            textBoxXAmp.Text = MathematicModelParameters.XAmp.ToString();
        }

        private void UpdateUINotes()
        {
            richTextBoxNotes.Clear();

            richTextBoxNotes.Text = dc.notes;
        }

        private void UpdateUIMySQL()
        {
            textBoxServer.Clear();
            textBoxPort.Clear();
            textBoxDatabase.Clear();
            textBoxUser.Clear();
            textBoxPassword.Clear();
            textBoxTable.Clear();

            textBoxServer.Text = dc.mySQLMediator.Server;
            textBoxPort.Text = dc.mySQLMediator.Port;
            textBoxDatabase.Text = dc.mySQLMediator.Database;
            textBoxUser.Text = dc.mySQLMediator.User;
            textBoxPassword.Text = dc.mySQLMediator.Password;
            textBoxTable.Text = dc.mySQLMediator.Table;
        }

        private void UpdateUIEPCDatasets()
        {
            comboBoxEPCDatasets.Items.Clear();

            comboBoxEPCDatasets.Items.AddRange(EPCsComparer.GetDatasetsLabels());

            comboBoxEPCDatasets.SelectedItem = EPCsComparer.SelectedDataset;
        }

        #endregion

        #region MetaTag's rssiQueue's size control

        private void TextBoxQueueSize_Leave(object sender, EventArgs e)
        {
            FixedSizedQueue<int>.Size = Convert.ToInt32(textBoxQueueSize.Text);
        }

        #endregion

        #region MMP params UI control

        private void GroupBoxMMParametersCustomChanged(object sender, EventArgs e)
        {
            //return if form load hasn't finished
            if (textBoxLMax.Text == "" 
                || textBoxRssiMin.Text == ""
                || textBoxRssiMax.Text == ""
                || textBoxXAmp.Text == "")
            {
                return;
            }

            //return if not a number
            if (!regexNumbers.Match(textBoxLMax.Text).Success 
                || !regexNumbers.Match(textBoxRssiMin.Text).Success
                || !regexNumbers.Match(textBoxRssiMax.Text).Success
                || !regexNumbers.Match(textBoxXAmp.Text).Success)
            {
                return;
            }
            
            MathematicModelParameters.UpdateParams(
                lMax: Convert.ToDouble(textBoxLMax.Text),
                rssiMin: Convert.ToDouble(textBoxRssiMin.Text),
                rssiMax: Convert.ToDouble(textBoxRssiMax.Text),
                xAmp: Convert.ToDouble(textBoxXAmp.Text)
            );
        }

        private void CheckBoxUseMM_CheckedChanged(object sender, EventArgs e)
        {
            DataController.useMM = checkBoxUseMM.Checked;
        }

        #endregion

        #region Readers Inv Params UI control

        #region R1 Inv Params UI control

        private void GroupBoxR1InvParamsCustomChanged(object sender, EventArgs e)
        {
            //return if form load hasn't finished
            if (cbR1Q.SelectedIndex < 0
                || cbR1Session.SelectedIndex < 0
                || cbR1Target.SelectedIndex < 0
                || cbR1Scantime.SelectedIndex < 0
                || textBoxR1NTimes.Text == "" || !regexNumbers.Match(textBoxR1NTimes.Text).Success)
            {
                return;
            }

            byte Qvalue = Convert.ToByte(cbR1Q.SelectedIndex);
            byte Session = Convert.ToByte(cbR1Session.SelectedIndex);
            byte Target = Convert.ToByte(cbR1Target.SelectedIndex);

            byte ScanTime = Convert.ToByte(cbR1Scantime.SelectedIndex + 3);

            bool withReads = checkBoxR1ReadFlag.Checked;
            int targettimes = Convert.ToInt32(textBoxR1NTimes.Text);

            foreach (Device d in dc.Devices)
            {
                if (d is UHFReader)
                {
                    (d as UHFReader).InvParams.UpdateParams(ScanTime, Qvalue, Session, Target, withReads, targettimes);

                    break;
                }
            }
        }

        #endregion

        #region R2 Inv Params UI control

        private void GroupBoxR2InvParamsCustomChanged(object sender, EventArgs e)
        {
            /// return if form load hasn't finished
            if (cbR2Q.SelectedIndex < 0
                || cbR2Session.SelectedIndex < 0
                || cbR2Target.SelectedIndex < 0
                || cbR2Scantime.SelectedIndex < 0
                || textBoxR2NTimes.Text == "" || !regexNumbers.Match(textBoxR2NTimes.Text).Success)
            {
                return;
            }

            byte Qvalue = Convert.ToByte(cbR2Q.SelectedIndex);
            byte Session = Convert.ToByte(cbR2Session.SelectedIndex);
            byte Target = Convert.ToByte(cbR2Target.SelectedIndex);

            byte ScanTime = Convert.ToByte(cbR2Scantime.SelectedIndex + 3);

            bool withReads = checkBoxR2ReadFlag.Checked;
            int targettimes = Convert.ToInt32(textBoxR2NTimes.Text);

            int counterDevices = 0;
            foreach (Device d in dc.Devices)
            {
                if (d is UHFReader)
                {
                    counterDevices++;

                    if (counterDevices > 1)
                    {
                        (d as UHFReader).InvParams.UpdateParams(ScanTime, Qvalue, Session, Target, withReads, targettimes);

                        break;
                    }
                }
            }
        }

        #endregion

        private void TextBoxRxNTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion        

        #region Angle transformation Tests control

        private void ButtonTestAngleConsole_Click(object sender, EventArgs e)
        {
            Position initP = new Position(Convert.ToDecimal(3), Convert.ToDecimal(3));
            Position finalP;
            //double delta = 0.5;

            Console.WriteLine("TEST Apply Angle");

            Console.WriteLine("test: {0}", Math.Cos(180));
            Console.WriteLine("test: {0}", Math.Cos(Math.PI));

            Console.WriteLine("IPos\tAngle\tFPos");
            //for(int angle = -180; angle <= 180; angle += 10)
            for (int angle = -180; angle <= 180; angle += 45)
            {
                finalP = LocalizationAlgorithm.ApplyAngleTransformation(angle, new Position(initP.X, initP.Y), out double D, out double alpha);

                Console.WriteLine("{0}\t{1}   \t{2}", initP, angle, finalP);
            }

            Console.WriteLine("TEST Apply Angle-----");
        }

        private void ButtonTestAngle_Click(object sender, EventArgs e)
        {
            decimal xi = Convert.ToDecimal(textBoxTestAngleInitPosX.Text);
            decimal yi = Convert.ToDecimal(textBoxTestAngleInitPosY.Text);

            Position initPos = new Position(xi, yi);

            int angle = Convert.ToInt32(textBoxTestAngleTheta.Text);

            Position finalP = LocalizationAlgorithm.ApplyAngleTransformation(
                angle: angle, 
                position: new Position(initPos.X, initPos.Y), 
                D: out double D, 
                alpha: out double alpha);

            textBoxTestAngleD.Text = Math.Round(D, 2).ToString();
            textBoxTestAngleAlpha.Text = Math.Round(alpha, 2).ToString();
            textBoxTestAngleFinalPosX.Text = finalP.X.ToString();
            textBoxTestAngleFinalPosY.Text = finalP.Y.ToString();
        }

        #endregion

        #region Excel UI Control

        private void CheckBoxUseExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxExcelUseExcel.Checked)
            {
                ExcelMediator.ExcelPrep();
            }
            else
            {
                ExcelMediator.Close();
            }
        }
        
        private void CheckBoxExcelUpdateRSSIs_CheckedChanged(object sender, EventArgs e)
        {
            ExcelMediator.updateRSSIs = checkBoxExcelUpdateRSSIs.Checked;
        }

        private void CheckBoxExcelUpdateTags_CheckedChanged(object sender, EventArgs e)
        {
            ExcelMediator.updateTags = checkBoxExcelUpdateTags.Checked;
        }

        private void ButtonExcelGenerateFromData_Click(object sender, EventArgs e)
        {
            int readerCounter = 1;
            UHFReader R1 = null;
            UHFReader R2 = null;
            
            foreach (Device d in dc.Devices)
            {
                if (d is UHFReader)
                {
                    if (readerCounter == 1)
                    {
                        R1 = (d as UHFReader);
                    }
                    else
                    {
                        R2 = (d as UHFReader);
                    }

                    readerCounter++;
                }
            }

            string readsDuration = "";
            if (stopWatch != null)
            {
                readsDuration = String.Format("{0:#}", stopWatch.Elapsed.TotalMilliseconds);
            }

            ExcelMediator.GenerateFileFromData(R1, R2, readsDuration);
        }

        #endregion

        #region Timers control

        private void TimerReads_Tick(object sender, EventArgs e)
        {
            textBoxTime.Text = String.Format("{0:#}", stopWatch.Elapsed.TotalMilliseconds);
        }

        private void TimerDuration_Tick(object sender, EventArgs e)
        {
            timerDuration.Enabled = false;

            buttonStart.PerformClick();
        }

        #endregion

        #region Epcs used/EPC found comparison control

        private void ButtonRunCompare_Click(object sender, EventArgs e)
        {
            string s = richTextBoxInsertTags.Text;

            string[] array = s.Split('\n');
            List<string> list = new List<string>(array);

            EPCsComparer.GetEpcsNotInList(list, out List<string> newList);

            string news = string.Join("\n", newList.ToArray());

            news += String.Format("\n{0}", newList.Count);

            richTextBoxGetTags.Text = news;
        }

        private void ButtonCompareClearList_Click(object sender, EventArgs e)
        {
            richTextBoxInsertTags.Clear();
        }

        private void ComboBoxEPCDatasets_SelectedIndexChanged(object sender, EventArgs e)
        {
            EPCsComparer.ChangeSelectedDataSet(comboBoxEPCDatasets.SelectedItem.ToString());
        }

        #endregion

        #region Config files control

        private void ButtonOpenDeviceManager_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void ButtonOpenMMParametersConfigFile_Click(object sender, EventArgs e)
        {
            dc.OpenConfigFile(ConfigFileType.MMParameters);
        }

        private void ButtonOpenConfigDevicesFile_Click(object sender, EventArgs e)
        {
            dc.OpenConfigFile(ConfigFileType.Devices);
        }

        private void ButtonOpenConfigNotesFile_Click(object sender, EventArgs e)
        {
            dc.OpenConfigFile(ConfigFileType.Notes);
        }

        private void ButtonOpenConfigMySQLFile_Click(object sender, EventArgs e)
        {
            dc.OpenConfigFile(ConfigFileType.MySQL);
        }

        private void ButtonOpenConfigEPCDatasetsFile_Click(object sender, EventArgs e)
        {
            dc.OpenConfigFile(ConfigFileType.EPCDatasets);
        }

        private void ButtonOpenLogFile_Click(object sender, EventArgs e)
        {
            dc.OpenConfigFile(ConfigFileType.Log);
        }

        private void ButtonUseParametersConfigFile_Click(object sender, EventArgs e)
        {
            WriteLog("Loading Mathematical Parameters configuration file...", 0);

            dc.LoadMMParametersConfigFile();
            UpdateUIMMParams();

            WriteLog(String.Format("Using Mathematical Model Parameters: {0}", MathematicModelParameters.ParametersToString()), 0);
        }

        private void ButtonUseConfigDevicesFile_Click(object sender, EventArgs e)
        {
            WriteLog("Loading Devices configuration file...", 0);

            dc.LoadDevicesConfigFile();
            UpdateUIDevices();

            WriteToWriteLogDevicesFound();
        }

        private void ButtonUseNotesConfigFile_Click(object sender, EventArgs e)
        {
            WriteLog("Loading Notes configuration file...", 0);

            dc.LoadNotesFromFile();
            UpdateUINotes();
        }

        private void ButtonUseMySQLConfigFile_Click(object sender, EventArgs e)
        {
            WriteLog("Loading MySQL configuration file...", 0);

            dc.LoadMySQLConfigFile();
            UpdateUIMySQL();

            dc.TestMySQLConnection();
        }

        private void ButtonUseEPCDatasetsConfigFile_Click(object sender, EventArgs e)
        {
            WriteLog("Loading EPC datasets configuration file...", 0);

            dc.LoadEPCDatasetsConfigFile();
            UpdateUIEPCDatasets();
        }

        private void ButtonResetAllConfigFiles_Click(object sender, EventArgs e)
        {
            dc.ResetConfigFiles();
        }

        #endregion

        #region TDM delta reads control

        private void CheckBoxUseDeltaRead_CheckedChanged(object sender, EventArgs e)
        {
            DataController.useDeltaRead = checkBoxUseDeltaRead.Checked;
        }

        private void TextBoxDeltaRead_Leave(object sender, EventArgs e)
        {
            DataController.deltaRead = Convert.ToInt32(textBoxDeltaRead.Text);
        }

        #endregion
    }
}
