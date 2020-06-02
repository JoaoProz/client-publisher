namespace RINPOSYS
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up all resources in use.
        /// </summary>
        /// <param name="disposing"> True if the managed resource should be released; otherwise, false. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region InitializeComponents

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefreshLogs = new System.Windows.Forms.Button();
            this.Maintab = new System.Windows.Forms.TabControl();
            this.Command = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOpenDeviceManager = new System.Windows.Forms.Button();
            this.buttonOpenConfigDevicesFile = new System.Windows.Forms.Button();
            this.buttonUseConfigDevicesFile = new System.Windows.Forms.Button();
            this.panelDevices = new System.Windows.Forms.Panel();
            this.MathematicModel = new System.Windows.Forms.TabPage();
            this.groupBoxMMParameters = new System.Windows.Forms.GroupBox();
            this.buttonUseParametersConfigFile = new System.Windows.Forms.Button();
            this.buttonOpenParametersConfigFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxXAmp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRssiMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxRssiMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLMax = new System.Windows.Forms.TextBox();
            this.RFIDReads = new System.Windows.Forms.TabPage();
            this.groupBoxSetup = new System.Windows.Forms.GroupBox();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.checkBoxDuration = new System.Windows.Forms.CheckBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.checkBoxUseMM = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxR2 = new System.Windows.Forms.GroupBox();
            this.textBoxR2NTimes = new System.Windows.Forms.TextBox();
            this.cbR2Scantime = new System.Windows.Forms.ComboBox();
            this.checkBoxR2ReadFlag = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbR2Q = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbR2Session = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbR2Target = new System.Windows.Forms.ComboBox();
            this.groupBoxR1 = new System.Windows.Forms.GroupBox();
            this.textBoxR1NTimes = new System.Windows.Forms.TextBox();
            this.checkBoxR1ReadFlag = new System.Windows.Forms.CheckBox();
            this.cbR1Scantime = new System.Windows.Forms.ComboBox();
            this.cbR1Q = new System.Windows.Forms.ComboBox();
            this.cbR1Target = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbR1Session = new System.Windows.Forms.ComboBox();
            this.groupBoxReadsList = new System.Windows.Forms.GroupBox();
            this.dataGridViewMetaTagsList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AntID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagsList = new System.Windows.Forms.TabPage();
            this.groupBoxTagsList = new System.Windows.Forms.GroupBox();
            this.dataGridViewTagsList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R1RSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R2RSSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.buttonOpenNotesConfigFile = new System.Windows.Forms.Button();
            this.buttonUseNotesConfigFile = new System.Windows.Forms.Button();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.tabMySQL = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.buttonOpenMySQLConfigFile = new System.Windows.Forms.Button();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.buttonUseMySQLConfigFile = new System.Windows.Forms.Button();
            this.tabEPCsCompare = new System.Windows.Forms.TabPage();
            this.buttonUseEPCCompareConfigFile = new System.Windows.Forms.Button();
            this.buttonOpenEPCCompareConfigFile = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBoxEPCDatasets = new System.Windows.Forms.ComboBox();
            this.buttonCompareClearList = new System.Windows.Forms.Button();
            this.buttonRunCompare = new System.Windows.Forms.Button();
            this.richTextBoxGetTags = new System.Windows.Forms.RichTextBox();
            this.richTextBoxInsertTags = new System.Windows.Forms.RichTextBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseDeltaRead = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxDeltaRead = new System.Windows.Forms.TextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.buttonResetAllConfigFiles = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonTestAngle = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxTestAngleAntDistance = new System.Windows.Forms.TextBox();
            this.textBoxTestAngleTheta = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxTestAngleFinalPosY = new System.Windows.Forms.TextBox();
            this.textBoxTestAngleFinalPosX = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonTestAngleX = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBoxTestAngleAlpha = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxTestAngleD = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxTestAngleInitPosY = new System.Windows.Forms.TextBox();
            this.textBoxTestAngleInitPosX = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonExcelGenerateFromData = new System.Windows.Forms.Button();
            this.checkBoxExcelUpdateTags = new System.Windows.Forms.CheckBox();
            this.checkBoxExcelUpdateRSSIs = new System.Windows.Forms.CheckBox();
            this.checkBoxExcelUseExcel = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxQueueSize = new System.Windows.Forms.TextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label68 = new System.Windows.Forms.Label();
            this.ctctsend = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.bttcpsend = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.remotePort = new System.Windows.Forms.TextBox();
            this.bttcpconnect = new System.Windows.Forms.Button();
            this.bttcpdisconnect = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label62 = new System.Windows.Forms.Label();
            this.stcpport = new System.Windows.Forms.TextBox();
            this.btListen = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.listtcp = new System.Windows.Forms.ListBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.btGotoAT = new System.Windows.Forms.Button();
            this.btExitAT = new System.Windows.Forms.Button();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.fifoCB = new System.Windows.Forms.ComboBox();
            this.flowCB = new System.Windows.Forms.ComboBox();
            this.baudrateCB = new System.Windows.Forms.ComboBox();
            this.databitCB = new System.Windows.Forms.ComboBox();
            this.parityCB = new System.Windows.Forms.ComboBox();
            this.stopbitCB = new System.Windows.Forms.ComboBox();
            this.protocolCB = new System.Windows.Forms.ComboBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.btSetSerialPort = new System.Windows.Forms.Button();
            this.btGetSeriaPort = new System.Windows.Forms.Button();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.panel_TCP = new System.Windows.Forms.Panel();
            this.tcpActiveCB = new System.Windows.Forms.ComboBox();
            this.tcpLocalPortNUD = new System.Windows.Forms.NumericUpDown();
            this.tcpRemotePortNUD = new System.Windows.Forms.NumericUpDown();
            this.tcpRomteHostTB = new System.Windows.Forms.TextBox();
            this.workasCB = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.btSetCnt = new System.Windows.Forms.Button();
            this.btGetCnt = new System.Windows.Forms.Button();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.panel_StaticIp = new System.Windows.Forms.Panel();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.subnetTB = new System.Windows.Forms.TextBox();
            this.gatewayTB = new System.Windows.Forms.TextBox();
            this.pDNSTB = new System.Windows.Forms.TextBox();
            this.altDNSTB = new System.Windows.Forms.TextBox();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.macTB = new System.Windows.Forms.TextBox();
            this.label110 = new System.Windows.Forms.Label();
            this.btSetNet = new System.Windows.Forms.Button();
            this.btGetNet = new System.Windows.Forms.Button();
            this.btLoadDefault = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telnetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeviceListView = new System.Windows.Forms.ListView();
            this.deviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceMac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btInventory6B = new System.Windows.Forms.Button();
            this.rb_single = new System.Windows.Forms.RadioButton();
            this.rb_mutiple = new System.Windows.Forms.RadioButton();
            this.ListView_ID_6B = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label29 = new System.Windows.Forms.Label();
            this.text_6BUID = new System.Windows.Forms.TextBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.text_R6BAddr = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.text_R6BLen = new System.Windows.Forms.TextBox();
            this.btRead6B = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.text_R6B = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.text_W6BAddr = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.text_W6BLen = new System.Windows.Forms.TextBox();
            this.btWrite6B = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.text_W6B = new System.Windows.Forms.TextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.text_lock6b = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.text_checkaddr = new System.Windows.Forms.TextBox();
            this.btLock6B = new System.Windows.Forms.Button();
            this.btCheckLock6B = new System.Windows.Forms.Button();
            this.text_Statu6B = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timerReads = new System.Windows.Forms.Timer(this.components);
            this.timerDuration = new System.Windows.Forms.Timer(this.components);
            this.buttonOpenLogFile = new System.Windows.Forms.Button();
            this.Maintab.SuspendLayout();
            this.Command.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MathematicModel.SuspendLayout();
            this.groupBoxMMParameters.SuspendLayout();
            this.RFIDReads.SuspendLayout();
            this.groupBoxSetup.SuspendLayout();
            this.groupBoxR2.SuspendLayout();
            this.groupBoxR1.SuspendLayout();
            this.groupBoxReadsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetaTagsList)).BeginInit();
            this.TagsList.SuspendLayout();
            this.groupBoxTagsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagsList)).BeginInit();
            this.tabNotes.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabMySQL.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabEPCsCompare.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpLocalPortNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcpRemotePortNUD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operation records:";
            // 
            // buttonRefreshLogs
            // 
            this.buttonRefreshLogs.Location = new System.Drawing.Point(115, 454);
            this.buttonRefreshLogs.Name = "buttonRefreshLogs";
            this.buttonRefreshLogs.Size = new System.Drawing.Size(100, 25);
            this.buttonRefreshLogs.TabIndex = 5;
            this.buttonRefreshLogs.Text = "Refresh";
            this.buttonRefreshLogs.UseVisualStyleBackColor = true;
            this.buttonRefreshLogs.Click += new System.EventHandler(this.ButtonRefreshLogs_Click);
            // 
            // Maintab
            // 
            this.Maintab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Maintab.Controls.Add(this.Command);
            this.Maintab.Controls.Add(this.MathematicModel);
            this.Maintab.Controls.Add(this.RFIDReads);
            this.Maintab.Controls.Add(this.TagsList);
            this.Maintab.Controls.Add(this.tabNotes);
            this.Maintab.Controls.Add(this.tabMySQL);
            this.Maintab.Controls.Add(this.tabEPCsCompare);
            this.Maintab.Controls.Add(this.tabDebug);
            this.Maintab.ItemSize = new System.Drawing.Size(72, 30);
            this.Maintab.Location = new System.Drawing.Point(0, 0);
            this.Maintab.MinimumSize = new System.Drawing.Size(696, 448);
            this.Maintab.Multiline = true;
            this.Maintab.Name = "Maintab";
            this.Maintab.SelectedIndex = 0;
            this.Maintab.Size = new System.Drawing.Size(862, 448);
            this.Maintab.TabIndex = 3;
            // 
            // Command
            // 
            this.Command.Controls.Add(this.groupBox1);
            this.Command.Location = new System.Drawing.Point(4, 34);
            this.Command.Name = "Command";
            this.Command.Size = new System.Drawing.Size(854, 410);
            this.Command.TabIndex = 6;
            this.Command.Text = "Connection";
            this.Command.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonOpenDeviceManager);
            this.groupBox1.Controls.Add(this.buttonOpenConfigDevicesFile);
            this.groupBox1.Controls.Add(this.buttonUseConfigDevicesFile);
            this.groupBox1.Controls.Add(this.panelDevices);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 324);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Readers Config";
            // 
            // buttonOpenDeviceManager
            // 
            this.buttonOpenDeviceManager.Location = new System.Drawing.Point(9, 19);
            this.buttonOpenDeviceManager.Name = "buttonOpenDeviceManager";
            this.buttonOpenDeviceManager.Size = new System.Drawing.Size(124, 25);
            this.buttonOpenDeviceManager.TabIndex = 76;
            this.buttonOpenDeviceManager.Text = "Open Device Manager";
            this.buttonOpenDeviceManager.UseVisualStyleBackColor = true;
            this.buttonOpenDeviceManager.Click += new System.EventHandler(this.ButtonOpenDeviceManager_Click);
            // 
            // buttonOpenConfigDevicesFile
            // 
            this.buttonOpenConfigDevicesFile.Location = new System.Drawing.Point(139, 19);
            this.buttonOpenConfigDevicesFile.Name = "buttonOpenConfigDevicesFile";
            this.buttonOpenConfigDevicesFile.Size = new System.Drawing.Size(96, 25);
            this.buttonOpenConfigDevicesFile.TabIndex = 75;
            this.buttonOpenConfigDevicesFile.Text = "Open Config. File";
            this.buttonOpenConfigDevicesFile.UseVisualStyleBackColor = true;
            this.buttonOpenConfigDevicesFile.Click += new System.EventHandler(this.ButtonOpenConfigDevicesFile_Click);
            // 
            // buttonUseConfigDevicesFile
            // 
            this.buttonUseConfigDevicesFile.Location = new System.Drawing.Point(241, 19);
            this.buttonUseConfigDevicesFile.Name = "buttonUseConfigDevicesFile";
            this.buttonUseConfigDevicesFile.Size = new System.Drawing.Size(90, 25);
            this.buttonUseConfigDevicesFile.TabIndex = 74;
            this.buttonUseConfigDevicesFile.Text = "Use Config. File";
            this.buttonUseConfigDevicesFile.UseVisualStyleBackColor = true;
            this.buttonUseConfigDevicesFile.Click += new System.EventHandler(this.ButtonUseConfigDevicesFile_Click);
            // 
            // panelDevices
            // 
            this.panelDevices.AutoScroll = true;
            this.panelDevices.Location = new System.Drawing.Point(9, 50);
            this.panelDevices.Name = "panelDevices";
            this.panelDevices.Size = new System.Drawing.Size(828, 268);
            this.panelDevices.TabIndex = 73;
            // 
            // MathematicModel
            // 
            this.MathematicModel.Controls.Add(this.groupBoxMMParameters);
            this.MathematicModel.Location = new System.Drawing.Point(4, 34);
            this.MathematicModel.Name = "MathematicModel";
            this.MathematicModel.Size = new System.Drawing.Size(854, 410);
            this.MathematicModel.TabIndex = 5;
            this.MathematicModel.Text = "Mathematic Model";
            this.MathematicModel.UseVisualStyleBackColor = true;
            // 
            // groupBoxMMParameters
            // 
            this.groupBoxMMParameters.Controls.Add(this.buttonUseParametersConfigFile);
            this.groupBoxMMParameters.Controls.Add(this.buttonOpenParametersConfigFile);
            this.groupBoxMMParameters.Controls.Add(this.label9);
            this.groupBoxMMParameters.Controls.Add(this.textBoxXAmp);
            this.groupBoxMMParameters.Controls.Add(this.label8);
            this.groupBoxMMParameters.Controls.Add(this.textBoxRssiMax);
            this.groupBoxMMParameters.Controls.Add(this.label7);
            this.groupBoxMMParameters.Controls.Add(this.textBoxRssiMin);
            this.groupBoxMMParameters.Controls.Add(this.label6);
            this.groupBoxMMParameters.Controls.Add(this.textBoxLMax);
            this.groupBoxMMParameters.Location = new System.Drawing.Point(8, 3);
            this.groupBoxMMParameters.Name = "groupBoxMMParameters";
            this.groupBoxMMParameters.Size = new System.Drawing.Size(295, 127);
            this.groupBoxMMParameters.TabIndex = 61;
            this.groupBoxMMParameters.TabStop = false;
            this.groupBoxMMParameters.Text = "Parameters";
            // 
            // buttonUseParametersConfigFile
            // 
            this.buttonUseParametersConfigFile.Location = new System.Drawing.Point(9, 50);
            this.buttonUseParametersConfigFile.Name = "buttonUseParametersConfigFile";
            this.buttonUseParametersConfigFile.Size = new System.Drawing.Size(96, 25);
            this.buttonUseParametersConfigFile.TabIndex = 76;
            this.buttonUseParametersConfigFile.Text = "Use Config. File";
            this.buttonUseParametersConfigFile.UseVisualStyleBackColor = true;
            this.buttonUseParametersConfigFile.Click += new System.EventHandler(this.ButtonUseParametersConfigFile_Click);
            // 
            // buttonOpenParametersConfigFile
            // 
            this.buttonOpenParametersConfigFile.Location = new System.Drawing.Point(9, 19);
            this.buttonOpenParametersConfigFile.Name = "buttonOpenParametersConfigFile";
            this.buttonOpenParametersConfigFile.Size = new System.Drawing.Size(96, 25);
            this.buttonOpenParametersConfigFile.TabIndex = 71;
            this.buttonOpenParametersConfigFile.Text = "Open Config. File";
            this.buttonOpenParametersConfigFile.UseVisualStyleBackColor = true;
            this.buttonOpenParametersConfigFile.Click += new System.EventHandler(this.ButtonOpenMMParametersConfigFile_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(145, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Antenna type value:";
            // 
            // textBoxXAmp
            // 
            this.textBoxXAmp.Location = new System.Drawing.Point(249, 97);
            this.textBoxXAmp.MaxLength = 256;
            this.textBoxXAmp.Name = "textBoxXAmp";
            this.textBoxXAmp.Size = new System.Drawing.Size(40, 20);
            this.textBoxXAmp.TabIndex = 74;
            this.textBoxXAmp.TextChanged += new System.EventHandler(this.GroupBoxMMParametersCustomChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "RSSI Max:";
            // 
            // textBoxRssiMax
            // 
            this.textBoxRssiMax.Location = new System.Drawing.Point(249, 71);
            this.textBoxRssiMax.MaxLength = 256;
            this.textBoxRssiMax.Name = "textBoxRssiMax";
            this.textBoxRssiMax.Size = new System.Drawing.Size(40, 20);
            this.textBoxRssiMax.TabIndex = 72;
            this.textBoxRssiMax.TextChanged += new System.EventHandler(this.GroupBoxMMParametersCustomChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "RSSI Min:";
            // 
            // textBoxRssiMin
            // 
            this.textBoxRssiMin.Location = new System.Drawing.Point(249, 45);
            this.textBoxRssiMin.MaxLength = 256;
            this.textBoxRssiMin.Name = "textBoxRssiMin";
            this.textBoxRssiMin.Size = new System.Drawing.Size(40, 20);
            this.textBoxRssiMin.TabIndex = 70;
            this.textBoxRssiMin.TextChanged += new System.EventHandler(this.GroupBoxMMParametersCustomChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "L Max:";
            // 
            // textBoxLMax
            // 
            this.textBoxLMax.Location = new System.Drawing.Point(249, 19);
            this.textBoxLMax.MaxLength = 256;
            this.textBoxLMax.Name = "textBoxLMax";
            this.textBoxLMax.Size = new System.Drawing.Size(40, 20);
            this.textBoxLMax.TabIndex = 68;
            this.textBoxLMax.TextChanged += new System.EventHandler(this.GroupBoxMMParametersCustomChanged);
            // 
            // RFIDReads
            // 
            this.RFIDReads.Controls.Add(this.groupBoxSetup);
            this.RFIDReads.Controls.Add(this.groupBoxReadsList);
            this.RFIDReads.Location = new System.Drawing.Point(4, 34);
            this.RFIDReads.Name = "RFIDReads";
            this.RFIDReads.Size = new System.Drawing.Size(854, 410);
            this.RFIDReads.TabIndex = 8;
            this.RFIDReads.Text = "RFIDReads";
            this.RFIDReads.UseVisualStyleBackColor = true;
            // 
            // groupBoxSetup
            // 
            this.groupBoxSetup.Controls.Add(this.textBoxDuration);
            this.groupBoxSetup.Controls.Add(this.checkBoxDuration);
            this.groupBoxSetup.Controls.Add(this.textBoxTime);
            this.groupBoxSetup.Controls.Add(this.label31);
            this.groupBoxSetup.Controls.Add(this.checkBoxUseMM);
            this.groupBoxSetup.Controls.Add(this.buttonStart);
            this.groupBoxSetup.Controls.Add(this.groupBoxR2);
            this.groupBoxSetup.Controls.Add(this.groupBoxR1);
            this.groupBoxSetup.Location = new System.Drawing.Point(8, 3);
            this.groupBoxSetup.Name = "groupBoxSetup";
            this.groupBoxSetup.Size = new System.Drawing.Size(677, 141);
            this.groupBoxSetup.TabIndex = 72;
            this.groupBoxSetup.TabStop = false;
            this.groupBoxSetup.Text = "Setup";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(221, 109);
            this.textBoxDuration.MaxLength = 256;
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(78, 20);
            this.textBoxDuration.TabIndex = 89;
            this.textBoxDuration.Text = "10000";
            // 
            // checkBoxDuration
            // 
            this.checkBoxDuration.AutoSize = true;
            this.checkBoxDuration.Location = new System.Drawing.Point(144, 111);
            this.checkBoxDuration.Name = "checkBoxDuration";
            this.checkBoxDuration.Size = new System.Drawing.Size(71, 17);
            this.checkBoxDuration.TabIndex = 88;
            this.checkBoxDuration.Text = "Use Time";
            this.checkBoxDuration.UseVisualStyleBackColor = true;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.Location = new System.Drawing.Point(471, 91);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(197, 44);
            this.textBoxTime.TabIndex = 87;
            this.textBoxTime.Text = "0";
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(305, 94);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(171, 37);
            this.label31.TabIndex = 86;
            this.label31.Text = "Time (ms):";
            // 
            // checkBoxUseMM
            // 
            this.checkBoxUseMM.AutoSize = true;
            this.checkBoxUseMM.Location = new System.Drawing.Point(15, 59);
            this.checkBoxUseMM.Name = "checkBoxUseMM";
            this.checkBoxUseMM.Size = new System.Drawing.Size(66, 17);
            this.checkBoxUseMM.TabIndex = 85;
            this.checkBoxUseMM.Text = "Use MM";
            this.checkBoxUseMM.UseVisualStyleBackColor = true;
            this.checkBoxUseMM.CheckedChanged += new System.EventHandler(this.CheckBoxUseMM_CheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.ForeColor = System.Drawing.Color.DarkBlue;
            this.buttonStart.Location = new System.Drawing.Point(6, 16);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(88, 34);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // groupBoxR2
            // 
            this.groupBoxR2.Controls.Add(this.textBoxR2NTimes);
            this.groupBoxR2.Controls.Add(this.cbR2Scantime);
            this.groupBoxR2.Controls.Add(this.checkBoxR2ReadFlag);
            this.groupBoxR2.Controls.Add(this.label13);
            this.groupBoxR2.Controls.Add(this.cbR2Q);
            this.groupBoxR2.Controls.Add(this.label14);
            this.groupBoxR2.Controls.Add(this.label10);
            this.groupBoxR2.Controls.Add(this.cbR2Session);
            this.groupBoxR2.Controls.Add(this.label4);
            this.groupBoxR2.Controls.Add(this.cbR2Target);
            this.groupBoxR2.Location = new System.Drawing.Point(405, 12);
            this.groupBoxR2.Name = "groupBoxR2";
            this.groupBoxR2.Size = new System.Drawing.Size(263, 73);
            this.groupBoxR2.TabIndex = 74;
            this.groupBoxR2.TabStop = false;
            this.groupBoxR2.Text = "Reader 2";
            // 
            // textBoxR2NTimes
            // 
            this.textBoxR2NTimes.ForeColor = System.Drawing.Color.Black;
            this.textBoxR2NTimes.Location = new System.Drawing.Point(213, 17);
            this.textBoxR2NTimes.MaxLength = 4;
            this.textBoxR2NTimes.Name = "textBoxR2NTimes";
            this.textBoxR2NTimes.Size = new System.Drawing.Size(43, 20);
            this.textBoxR2NTimes.TabIndex = 78;
            this.textBoxR2NTimes.Text = "2";
            this.textBoxR2NTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR2NTimes.TextChanged += new System.EventHandler(this.GroupBoxR2InvParamsCustomChanged);
            this.textBoxR2NTimes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRxNTimes_KeyPress);
            // 
            // cbR2Scantime
            // 
            this.cbR2Scantime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR2Scantime.FormattingEnabled = true;
            this.cbR2Scantime.Location = new System.Drawing.Point(179, 45);
            this.cbR2Scantime.Name = "cbR2Scantime";
            this.cbR2Scantime.Size = new System.Drawing.Size(77, 21);
            this.cbR2Scantime.TabIndex = 78;
            this.cbR2Scantime.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR2InvParamsCustomChanged);
            // 
            // checkBoxR2ReadFlag
            // 
            this.checkBoxR2ReadFlag.AutoSize = true;
            this.checkBoxR2ReadFlag.Checked = true;
            this.checkBoxR2ReadFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxR2ReadFlag.Location = new System.Drawing.Point(164, 20);
            this.checkBoxR2ReadFlag.Name = "checkBoxR2ReadFlag";
            this.checkBoxR2ReadFlag.Size = new System.Drawing.Size(52, 17);
            this.checkBoxR2ReadFlag.TabIndex = 77;
            this.checkBoxR2ReadFlag.Text = "Read";
            this.checkBoxR2ReadFlag.UseVisualStyleBackColor = true;
            this.checkBoxR2ReadFlag.CheckedChanged += new System.EventHandler(this.GroupBoxR2InvParamsCustomChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(97, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 77;
            this.label13.Text = "Max-ScanTime:";
            // 
            // cbR2Q
            // 
            this.cbR2Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR2Q.FormattingEnabled = true;
            this.cbR2Q.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbR2Q.Location = new System.Drawing.Point(121, 17);
            this.cbR2Q.Name = "cbR2Q";
            this.cbR2Q.Size = new System.Drawing.Size(37, 21);
            this.cbR2Q.TabIndex = 80;
            this.cbR2Q.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR2InvParamsCustomChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(97, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 79;
            this.label14.Text = "Q:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "Session:";
            // 
            // cbR2Session
            // 
            this.cbR2Session.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR2Session.FormattingEnabled = true;
            this.cbR2Session.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cbR2Session.Location = new System.Drawing.Point(59, 17);
            this.cbR2Session.Name = "cbR2Session";
            this.cbR2Session.Size = new System.Drawing.Size(32, 21);
            this.cbR2Session.TabIndex = 79;
            this.cbR2Session.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR2InvParamsCustomChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Target:";
            // 
            // cbR2Target
            // 
            this.cbR2Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR2Target.FormattingEnabled = true;
            this.cbR2Target.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbR2Target.Location = new System.Drawing.Point(59, 45);
            this.cbR2Target.Name = "cbR2Target";
            this.cbR2Target.Size = new System.Drawing.Size(32, 21);
            this.cbR2Target.TabIndex = 77;
            this.cbR2Target.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR2InvParamsCustomChanged);
            // 
            // groupBoxR1
            // 
            this.groupBoxR1.Controls.Add(this.textBoxR1NTimes);
            this.groupBoxR1.Controls.Add(this.checkBoxR1ReadFlag);
            this.groupBoxR1.Controls.Add(this.cbR1Scantime);
            this.groupBoxR1.Controls.Add(this.cbR1Q);
            this.groupBoxR1.Controls.Add(this.cbR1Target);
            this.groupBoxR1.Controls.Add(this.label39);
            this.groupBoxR1.Controls.Add(this.label11);
            this.groupBoxR1.Controls.Add(this.label3);
            this.groupBoxR1.Controls.Add(this.label5);
            this.groupBoxR1.Controls.Add(this.cbR1Session);
            this.groupBoxR1.Location = new System.Drawing.Point(136, 12);
            this.groupBoxR1.Name = "groupBoxR1";
            this.groupBoxR1.Size = new System.Drawing.Size(263, 73);
            this.groupBoxR1.TabIndex = 73;
            this.groupBoxR1.TabStop = false;
            this.groupBoxR1.Text = "Reader 1";
            // 
            // textBoxR1NTimes
            // 
            this.textBoxR1NTimes.ForeColor = System.Drawing.Color.Black;
            this.textBoxR1NTimes.Location = new System.Drawing.Point(213, 17);
            this.textBoxR1NTimes.MaxLength = 4;
            this.textBoxR1NTimes.Name = "textBoxR1NTimes";
            this.textBoxR1NTimes.Size = new System.Drawing.Size(43, 20);
            this.textBoxR1NTimes.TabIndex = 43;
            this.textBoxR1NTimes.Text = "2";
            this.textBoxR1NTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxR1NTimes.TextChanged += new System.EventHandler(this.GroupBoxR1InvParamsCustomChanged);
            this.textBoxR1NTimes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRxNTimes_KeyPress);
            // 
            // checkBoxR1ReadFlag
            // 
            this.checkBoxR1ReadFlag.AutoSize = true;
            this.checkBoxR1ReadFlag.Checked = true;
            this.checkBoxR1ReadFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxR1ReadFlag.Location = new System.Drawing.Point(164, 20);
            this.checkBoxR1ReadFlag.Name = "checkBoxR1ReadFlag";
            this.checkBoxR1ReadFlag.Size = new System.Drawing.Size(52, 17);
            this.checkBoxR1ReadFlag.TabIndex = 42;
            this.checkBoxR1ReadFlag.Text = "Read";
            this.checkBoxR1ReadFlag.UseVisualStyleBackColor = true;
            this.checkBoxR1ReadFlag.CheckedChanged += new System.EventHandler(this.GroupBoxR1InvParamsCustomChanged);
            // 
            // cbR1Scantime
            // 
            this.cbR1Scantime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR1Scantime.FormattingEnabled = true;
            this.cbR1Scantime.Location = new System.Drawing.Point(179, 45);
            this.cbR1Scantime.Name = "cbR1Scantime";
            this.cbR1Scantime.Size = new System.Drawing.Size(77, 21);
            this.cbR1Scantime.TabIndex = 74;
            this.cbR1Scantime.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR1InvParamsCustomChanged);
            // 
            // cbR1Q
            // 
            this.cbR1Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR1Q.FormattingEnabled = true;
            this.cbR1Q.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbR1Q.Location = new System.Drawing.Point(121, 17);
            this.cbR1Q.Name = "cbR1Q";
            this.cbR1Q.Size = new System.Drawing.Size(37, 21);
            this.cbR1Q.TabIndex = 76;
            this.cbR1Q.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR1InvParamsCustomChanged);
            // 
            // cbR1Target
            // 
            this.cbR1Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR1Target.FormattingEnabled = true;
            this.cbR1Target.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbR1Target.Location = new System.Drawing.Point(59, 45);
            this.cbR1Target.Name = "cbR1Target";
            this.cbR1Target.Size = new System.Drawing.Size(32, 21);
            this.cbR1Target.TabIndex = 75;
            this.cbR1Target.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR1InvParamsCustomChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(97, 49);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(81, 13);
            this.label39.TabIndex = 73;
            this.label39.Text = "Max-ScanTime:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 75;
            this.label11.Text = "Q:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 75;
            this.label3.Text = "Target:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Session:";
            // 
            // cbR1Session
            // 
            this.cbR1Session.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbR1Session.FormattingEnabled = true;
            this.cbR1Session.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cbR1Session.Location = new System.Drawing.Point(59, 17);
            this.cbR1Session.Name = "cbR1Session";
            this.cbR1Session.Size = new System.Drawing.Size(32, 21);
            this.cbR1Session.TabIndex = 76;
            this.cbR1Session.SelectedIndexChanged += new System.EventHandler(this.GroupBoxR1InvParamsCustomChanged);
            // 
            // groupBoxReadsList
            // 
            this.groupBoxReadsList.Controls.Add(this.dataGridViewMetaTagsList);
            this.groupBoxReadsList.Location = new System.Drawing.Point(8, 150);
            this.groupBoxReadsList.Name = "groupBoxReadsList";
            this.groupBoxReadsList.Size = new System.Drawing.Size(677, 257);
            this.groupBoxReadsList.TabIndex = 66;
            this.groupBoxReadsList.TabStop = false;
            this.groupBoxReadsList.Text = "Reads list";
            // 
            // dataGridViewMetaTagsList
            // 
            this.dataGridViewMetaTagsList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridViewMetaTagsList.AllowUserToAddRows = false;
            this.dataGridViewMetaTagsList.AllowUserToDeleteRows = false;
            this.dataGridViewMetaTagsList.AllowUserToOrderColumns = true;
            this.dataGridViewMetaTagsList.AllowUserToResizeColumns = false;
            this.dataGridViewMetaTagsList.AllowUserToResizeRows = false;
            this.dataGridViewMetaTagsList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewMetaTagsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewMetaTagsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMetaTagsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.AntID,
            this.Column1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9});
            this.dataGridViewMetaTagsList.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewMetaTagsList.MultiSelect = false;
            this.dataGridViewMetaTagsList.Name = "dataGridViewMetaTagsList";
            this.dataGridViewMetaTagsList.ReadOnly = true;
            this.dataGridViewMetaTagsList.RowHeadersVisible = false;
            this.dataGridViewMetaTagsList.RowTemplate.Height = 23;
            this.dataGridViewMetaTagsList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMetaTagsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewMetaTagsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMetaTagsList.Size = new System.Drawing.Size(662, 232);
            this.dataGridViewMetaTagsList.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "GridIndex";
            this.dataGridViewTextBoxColumn4.HeaderText = "#";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 45;
            // 
            // AntID
            // 
            this.AntID.DataPropertyName = "AntennaID";
            this.AntID.HeaderText = "Ant #";
            this.AntID.Name = "AntID";
            this.AntID.ReadOnly = true;
            this.AntID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AntID.Width = 45;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TimeStampDateTime";
            dataGridViewCellStyle1.Format = "G";
            dataGridViewCellStyle1.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "TimeStamp";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "EPC";
            this.dataGridViewTextBoxColumn5.HeaderText = "EPC";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "RSSICounter";
            this.dataGridViewTextBoxColumn6.HeaderText = "Times";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 45;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "RSSI";
            this.dataGridViewTextBoxColumn7.HeaderText = "RSSI";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "RSSIAvg";
            this.dataGridViewTextBoxColumn9.HeaderText = "RSSI (avg)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 90;
            // 
            // TagsList
            // 
            this.TagsList.Controls.Add(this.groupBoxTagsList);
            this.TagsList.Location = new System.Drawing.Point(4, 34);
            this.TagsList.Name = "TagsList";
            this.TagsList.Size = new System.Drawing.Size(854, 410);
            this.TagsList.TabIndex = 9;
            this.TagsList.Text = "Tags List";
            this.TagsList.UseVisualStyleBackColor = true;
            // 
            // groupBoxTagsList
            // 
            this.groupBoxTagsList.Controls.Add(this.dataGridViewTagsList);
            this.groupBoxTagsList.Location = new System.Drawing.Point(8, 3);
            this.groupBoxTagsList.Name = "groupBoxTagsList";
            this.groupBoxTagsList.Size = new System.Drawing.Size(743, 398);
            this.groupBoxTagsList.TabIndex = 68;
            this.groupBoxTagsList.TabStop = false;
            this.groupBoxTagsList.Text = "Tags list";
            // 
            // dataGridViewTagsList
            // 
            this.dataGridViewTagsList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridViewTagsList.AllowUserToAddRows = false;
            this.dataGridViewTagsList.AllowUserToDeleteRows = false;
            this.dataGridViewTagsList.AllowUserToResizeColumns = false;
            this.dataGridViewTagsList.AllowUserToResizeRows = false;
            this.dataGridViewTagsList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewTagsList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewTagsList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewTagsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTagsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.R1RSSI,
            this.R2RSSI});
            this.dataGridViewTagsList.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewTagsList.MultiSelect = false;
            this.dataGridViewTagsList.Name = "dataGridViewTagsList";
            this.dataGridViewTagsList.ReadOnly = true;
            this.dataGridViewTagsList.RowHeadersVisible = false;
            this.dataGridViewTagsList.RowTemplate.Height = 23;
            this.dataGridViewTagsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTagsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTagsList.Size = new System.Drawing.Size(731, 373);
            this.dataGridViewTagsList.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TimeStampDateTime";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn11.HeaderText = "TimeStamp";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 150;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn12.HeaderText = "ID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "PositionX";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn16.HeaderText = "x (mm)";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 90;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "PositionY";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn17.HeaderText = "y (mm)";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 90;
            // 
            // R1RSSI
            // 
            this.R1RSSI.DataPropertyName = "R1RSSI";
            this.R1RSSI.HeaderText = "RSSI (R1)";
            this.R1RSSI.Name = "R1RSSI";
            this.R1RSSI.ReadOnly = true;
            // 
            // R2RSSI
            // 
            this.R2RSSI.DataPropertyName = "R2RSSI";
            this.R2RSSI.HeaderText = "RSSI (R2)";
            this.R2RSSI.Name = "R2RSSI";
            this.R2RSSI.ReadOnly = true;
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.groupBox10);
            this.tabNotes.Location = new System.Drawing.Point(4, 34);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Size = new System.Drawing.Size(854, 410);
            this.tabNotes.TabIndex = 11;
            this.tabNotes.Text = "Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.buttonOpenNotesConfigFile);
            this.groupBox10.Controls.Add(this.buttonUseNotesConfigFile);
            this.groupBox10.Controls.Add(this.richTextBoxNotes);
            this.groupBox10.Location = new System.Drawing.Point(8, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(843, 404);
            this.groupBox10.TabIndex = 73;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Notes";
            // 
            // buttonOpenNotesConfigFile
            // 
            this.buttonOpenNotesConfigFile.Location = new System.Drawing.Point(9, 19);
            this.buttonOpenNotesConfigFile.Name = "buttonOpenNotesConfigFile";
            this.buttonOpenNotesConfigFile.Size = new System.Drawing.Size(97, 25);
            this.buttonOpenNotesConfigFile.TabIndex = 73;
            this.buttonOpenNotesConfigFile.Text = "Open Config. File";
            this.buttonOpenNotesConfigFile.UseVisualStyleBackColor = true;
            this.buttonOpenNotesConfigFile.Click += new System.EventHandler(this.ButtonOpenConfigNotesFile_Click);
            // 
            // buttonUseNotesConfigFile
            // 
            this.buttonUseNotesConfigFile.Location = new System.Drawing.Point(112, 19);
            this.buttonUseNotesConfigFile.Name = "buttonUseNotesConfigFile";
            this.buttonUseNotesConfigFile.Size = new System.Drawing.Size(91, 25);
            this.buttonUseNotesConfigFile.TabIndex = 72;
            this.buttonUseNotesConfigFile.Text = "Use Config. File";
            this.buttonUseNotesConfigFile.UseVisualStyleBackColor = true;
            this.buttonUseNotesConfigFile.Click += new System.EventHandler(this.ButtonUseNotesConfigFile_Click);
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Location = new System.Drawing.Point(9, 50);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.ReadOnly = true;
            this.richTextBoxNotes.Size = new System.Drawing.Size(828, 348);
            this.richTextBoxNotes.TabIndex = 0;
            this.richTextBoxNotes.Text = "";
            // 
            // tabMySQL
            // 
            this.tabMySQL.Controls.Add(this.groupBox11);
            this.tabMySQL.Location = new System.Drawing.Point(4, 34);
            this.tabMySQL.Name = "tabMySQL";
            this.tabMySQL.Size = new System.Drawing.Size(854, 410);
            this.tabMySQL.TabIndex = 12;
            this.tabMySQL.Text = "MySQL";
            this.tabMySQL.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.buttonOpenMySQLConfigFile);
            this.groupBox11.Controls.Add(this.textBoxTable);
            this.groupBox11.Controls.Add(this.textBoxDatabase);
            this.groupBox11.Controls.Add(this.textBoxPassword);
            this.groupBox11.Controls.Add(this.textBoxUser);
            this.groupBox11.Controls.Add(this.textBoxServer);
            this.groupBox11.Controls.Add(this.textBoxPort);
            this.groupBox11.Controls.Add(this.label28);
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.label25);
            this.groupBox11.Controls.Add(this.label24);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Controls.Add(this.buttonUseMySQLConfigFile);
            this.groupBox11.Location = new System.Drawing.Point(8, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(214, 212);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Parameters";
            // 
            // buttonOpenMySQLConfigFile
            // 
            this.buttonOpenMySQLConfigFile.Location = new System.Drawing.Point(6, 19);
            this.buttonOpenMySQLConfigFile.Name = "buttonOpenMySQLConfigFile";
            this.buttonOpenMySQLConfigFile.Size = new System.Drawing.Size(96, 25);
            this.buttonOpenMySQLConfigFile.TabIndex = 86;
            this.buttonOpenMySQLConfigFile.Text = "Open Config. File";
            this.buttonOpenMySQLConfigFile.UseVisualStyleBackColor = true;
            this.buttonOpenMySQLConfigFile.Click += new System.EventHandler(this.ButtonOpenConfigMySQLFile_Click);
            // 
            // textBoxTable
            // 
            this.textBoxTable.Location = new System.Drawing.Point(103, 180);
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.Size = new System.Drawing.Size(100, 20);
            this.textBoxTable.TabIndex = 85;
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Location = new System.Drawing.Point(103, 102);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(100, 20);
            this.textBoxDatabase.TabIndex = 84;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(103, 154);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 83;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(103, 128);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(100, 20);
            this.textBoxUser.TabIndex = 82;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(103, 50);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(100, 20);
            this.textBoxServer.TabIndex = 81;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(103, 76);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxPort.TabIndex = 80;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(60, 183);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(37, 13);
            this.label28.TabIndex = 79;
            this.label28.Text = "Table:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(68, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 13);
            this.label27.TabIndex = 78;
            this.label27.Text = "Port:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(65, 131);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 13);
            this.label26.TabIndex = 77;
            this.label26.Text = "User:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(41, 157);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 13);
            this.label25.TabIndex = 76;
            this.label25.Text = "Password:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(41, 105);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 13);
            this.label24.TabIndex = 75;
            this.label24.Text = "Database:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(56, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 13);
            this.label23.TabIndex = 74;
            this.label23.Text = "Server:";
            // 
            // buttonUseMySQLConfigFile
            // 
            this.buttonUseMySQLConfigFile.Location = new System.Drawing.Point(108, 19);
            this.buttonUseMySQLConfigFile.Name = "buttonUseMySQLConfigFile";
            this.buttonUseMySQLConfigFile.Size = new System.Drawing.Size(95, 25);
            this.buttonUseMySQLConfigFile.TabIndex = 73;
            this.buttonUseMySQLConfigFile.Text = "Use Config. File";
            this.buttonUseMySQLConfigFile.UseVisualStyleBackColor = true;
            this.buttonUseMySQLConfigFile.Click += new System.EventHandler(this.ButtonUseMySQLConfigFile_Click);
            // 
            // tabEPCsCompare
            // 
            this.tabEPCsCompare.Controls.Add(this.buttonUseEPCCompareConfigFile);
            this.tabEPCsCompare.Controls.Add(this.buttonOpenEPCCompareConfigFile);
            this.tabEPCsCompare.Controls.Add(this.label22);
            this.tabEPCsCompare.Controls.Add(this.comboBoxEPCDatasets);
            this.tabEPCsCompare.Controls.Add(this.buttonCompareClearList);
            this.tabEPCsCompare.Controls.Add(this.buttonRunCompare);
            this.tabEPCsCompare.Controls.Add(this.richTextBoxGetTags);
            this.tabEPCsCompare.Controls.Add(this.richTextBoxInsertTags);
            this.tabEPCsCompare.Location = new System.Drawing.Point(4, 34);
            this.tabEPCsCompare.Name = "tabEPCsCompare";
            this.tabEPCsCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabEPCsCompare.Size = new System.Drawing.Size(854, 410);
            this.tabEPCsCompare.TabIndex = 13;
            this.tabEPCsCompare.Text = "EPCLists compare";
            this.tabEPCsCompare.UseVisualStyleBackColor = true;
            // 
            // buttonUseEPCCompareConfigFile
            // 
            this.buttonUseEPCCompareConfigFile.Location = new System.Drawing.Point(257, 52);
            this.buttonUseEPCCompareConfigFile.Name = "buttonUseEPCCompareConfigFile";
            this.buttonUseEPCCompareConfigFile.Size = new System.Drawing.Size(179, 39);
            this.buttonUseEPCCompareConfigFile.TabIndex = 80;
            this.buttonUseEPCCompareConfigFile.Text = "Use Config. File";
            this.buttonUseEPCCompareConfigFile.UseVisualStyleBackColor = true;
            this.buttonUseEPCCompareConfigFile.Click += new System.EventHandler(this.ButtonUseEPCDatasetsConfigFile_Click);
            // 
            // buttonOpenEPCCompareConfigFile
            // 
            this.buttonOpenEPCCompareConfigFile.Location = new System.Drawing.Point(257, 7);
            this.buttonOpenEPCCompareConfigFile.Name = "buttonOpenEPCCompareConfigFile";
            this.buttonOpenEPCCompareConfigFile.Size = new System.Drawing.Size(179, 39);
            this.buttonOpenEPCCompareConfigFile.TabIndex = 79;
            this.buttonOpenEPCCompareConfigFile.Text = "Open Config. File";
            this.buttonOpenEPCCompareConfigFile.UseVisualStyleBackColor = true;
            this.buttonOpenEPCCompareConfigFile.Click += new System.EventHandler(this.ButtonOpenConfigEPCDatasetsFile_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(254, 140);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 13);
            this.label22.TabIndex = 78;
            this.label22.Text = "Selected DataSet:";
            // 
            // comboBoxEPCDatasets
            // 
            this.comboBoxEPCDatasets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEPCDatasets.FormattingEnabled = true;
            this.comboBoxEPCDatasets.Location = new System.Drawing.Point(354, 137);
            this.comboBoxEPCDatasets.Name = "comboBoxEPCDatasets";
            this.comboBoxEPCDatasets.Size = new System.Drawing.Size(82, 21);
            this.comboBoxEPCDatasets.TabIndex = 77;
            this.comboBoxEPCDatasets.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEPCDatasets_SelectedIndexChanged);
            // 
            // buttonCompareClearList
            // 
            this.buttonCompareClearList.Location = new System.Drawing.Point(257, 164);
            this.buttonCompareClearList.Name = "buttonCompareClearList";
            this.buttonCompareClearList.Size = new System.Drawing.Size(179, 39);
            this.buttonCompareClearList.TabIndex = 3;
            this.buttonCompareClearList.Text = "Clear List";
            this.buttonCompareClearList.UseVisualStyleBackColor = true;
            this.buttonCompareClearList.Click += new System.EventHandler(this.ButtonCompareClearList_Click);
            // 
            // buttonRunCompare
            // 
            this.buttonRunCompare.Location = new System.Drawing.Point(257, 209);
            this.buttonRunCompare.Name = "buttonRunCompare";
            this.buttonRunCompare.Size = new System.Drawing.Size(179, 39);
            this.buttonRunCompare.TabIndex = 2;
            this.buttonRunCompare.Text = "Run Compare";
            this.buttonRunCompare.UseVisualStyleBackColor = true;
            this.buttonRunCompare.Click += new System.EventHandler(this.ButtonRunCompare_Click);
            // 
            // richTextBoxGetTags
            // 
            this.richTextBoxGetTags.Location = new System.Drawing.Point(442, 6);
            this.richTextBoxGetTags.Name = "richTextBoxGetTags";
            this.richTextBoxGetTags.Size = new System.Drawing.Size(240, 397);
            this.richTextBoxGetTags.TabIndex = 1;
            this.richTextBoxGetTags.Text = "";
            // 
            // richTextBoxInsertTags
            // 
            this.richTextBoxInsertTags.Location = new System.Drawing.Point(11, 7);
            this.richTextBoxInsertTags.Name = "richTextBoxInsertTags";
            this.richTextBoxInsertTags.Size = new System.Drawing.Size(240, 397);
            this.richTextBoxInsertTags.TabIndex = 0;
            this.richTextBoxInsertTags.Text = "";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.groupBox13);
            this.tabDebug.Controls.Add(this.groupBox12);
            this.tabDebug.Controls.Add(this.groupBox4);
            this.tabDebug.Controls.Add(this.groupBox2);
            this.tabDebug.Controls.Add(this.groupBox3);
            this.tabDebug.Location = new System.Drawing.Point(4, 34);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(854, 410);
            this.tabDebug.TabIndex = 10;
            this.tabDebug.Text = "Debug tests";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.checkBoxUseDeltaRead);
            this.groupBox13.Controls.Add(this.label32);
            this.groupBox13.Controls.Add(this.textBoxDeltaRead);
            this.groupBox13.Location = new System.Drawing.Point(317, 269);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(177, 73);
            this.groupBox13.TabIndex = 90;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "TDM";
            // 
            // checkBoxUseDeltaRead
            // 
            this.checkBoxUseDeltaRead.AutoSize = true;
            this.checkBoxUseDeltaRead.Location = new System.Drawing.Point(9, 19);
            this.checkBoxUseDeltaRead.Name = "checkBoxUseDeltaRead";
            this.checkBoxUseDeltaRead.Size = new System.Drawing.Size(95, 17);
            this.checkBoxUseDeltaRead.TabIndex = 89;
            this.checkBoxUseDeltaRead.Text = "Use delta read";
            this.checkBoxUseDeltaRead.UseVisualStyleBackColor = true;
            this.checkBoxUseDeltaRead.CheckedChanged += new System.EventHandler(this.CheckBoxUseDeltaRead_CheckedChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 45);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 13);
            this.label32.TabIndex = 85;
            this.label32.Text = "Delta read:";
            // 
            // textBoxDeltaRead
            // 
            this.textBoxDeltaRead.Location = new System.Drawing.Point(71, 42);
            this.textBoxDeltaRead.MaxLength = 256;
            this.textBoxDeltaRead.Name = "textBoxDeltaRead";
            this.textBoxDeltaRead.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeltaRead.TabIndex = 84;
            this.textBoxDeltaRead.Text = "0";
            this.textBoxDeltaRead.Leave += new System.EventHandler(this.TextBoxDeltaRead_Leave);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.buttonResetAllConfigFiles);
            this.groupBox12.Location = new System.Drawing.Point(454, 213);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(159, 50);
            this.groupBox12.TabIndex = 86;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "ConfigFilesDebug";
            // 
            // buttonResetAllConfigFiles
            // 
            this.buttonResetAllConfigFiles.Location = new System.Drawing.Point(6, 19);
            this.buttonResetAllConfigFiles.Name = "buttonResetAllConfigFiles";
            this.buttonResetAllConfigFiles.Size = new System.Drawing.Size(146, 23);
            this.buttonResetAllConfigFiles.TabIndex = 89;
            this.buttonResetAllConfigFiles.Text = "Reset to Defaults";
            this.buttonResetAllConfigFiles.UseVisualStyleBackColor = true;
            this.buttonResetAllConfigFiles.Click += new System.EventHandler(this.ButtonResetAllConfigFiles_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonTestAngle);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.buttonTestAngleX);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(317, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 203);
            this.groupBox4.TabIndex = 85;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TestAngleTransformation";
            // 
            // buttonTestAngle
            // 
            this.buttonTestAngle.Location = new System.Drawing.Point(6, 112);
            this.buttonTestAngle.Name = "buttonTestAngle";
            this.buttonTestAngle.Size = new System.Drawing.Size(85, 33);
            this.buttonTestAngle.TabIndex = 91;
            this.buttonTestAngle.Text = "Test Angle";
            this.buttonTestAngle.UseVisualStyleBackColor = true;
            this.buttonTestAngle.Click += new System.EventHandler(this.ButtonTestAngle_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.textBoxTestAngleAntDistance);
            this.groupBox7.Controls.Add(this.textBoxTestAngleTheta);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Location = new System.Drawing.Point(97, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(140, 70);
            this.groupBox7.TabIndex = 90;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Params";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(64, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "θ: ";
            // 
            // textBoxTestAngleAntDistance
            // 
            this.textBoxTestAngleAntDistance.Location = new System.Drawing.Point(89, 43);
            this.textBoxTestAngleAntDistance.Name = "textBoxTestAngleAntDistance";
            this.textBoxTestAngleAntDistance.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleAntDistance.TabIndex = 89;
            this.textBoxTestAngleAntDistance.Text = "0,5";
            // 
            // textBoxTestAngleTheta
            // 
            this.textBoxTestAngleTheta.Location = new System.Drawing.Point(89, 17);
            this.textBoxTestAngleTheta.Name = "textBoxTestAngleTheta";
            this.textBoxTestAngleTheta.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleTheta.TabIndex = 5;
            this.textBoxTestAngleTheta.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 88;
            this.label19.Text = "ant. distance: ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxTestAngleFinalPosY);
            this.groupBox6.Controls.Add(this.textBoxTestAngleFinalPosX);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(204, 95);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(85, 70);
            this.groupBox6.TabIndex = 87;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Final Position";
            // 
            // textBoxTestAngleFinalPosY
            // 
            this.textBoxTestAngleFinalPosY.Location = new System.Drawing.Point(30, 43);
            this.textBoxTestAngleFinalPosY.Name = "textBoxTestAngleFinalPosY";
            this.textBoxTestAngleFinalPosY.ReadOnly = true;
            this.textBoxTestAngleFinalPosY.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleFinalPosY.TabIndex = 3;
            // 
            // textBoxTestAngleFinalPosX
            // 
            this.textBoxTestAngleFinalPosX.Location = new System.Drawing.Point(30, 17);
            this.textBoxTestAngleFinalPosX.Name = "textBoxTestAngleFinalPosX";
            this.textBoxTestAngleFinalPosX.ReadOnly = true;
            this.textBoxTestAngleFinalPosX.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleFinalPosX.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "y: ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "x: ";
            // 
            // buttonTestAngleX
            // 
            this.buttonTestAngleX.Location = new System.Drawing.Point(6, 171);
            this.buttonTestAngleX.Name = "buttonTestAngleX";
            this.buttonTestAngleX.Size = new System.Drawing.Size(115, 23);
            this.buttonTestAngleX.TabIndex = 77;
            this.buttonTestAngleX.Text = "Test Angle (Console)";
            this.buttonTestAngleX.UseVisualStyleBackColor = true;
            this.buttonTestAngleX.Click += new System.EventHandler(this.ButtonTestAngleConsole_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBoxTestAngleAlpha);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.textBoxTestAngleD);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Location = new System.Drawing.Point(97, 95);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(101, 70);
            this.groupBox8.TabIndex = 88;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Values";
            // 
            // textBoxTestAngleAlpha
            // 
            this.textBoxTestAngleAlpha.Location = new System.Drawing.Point(51, 43);
            this.textBoxTestAngleAlpha.Name = "textBoxTestAngleAlpha";
            this.textBoxTestAngleAlpha.ReadOnly = true;
            this.textBoxTestAngleAlpha.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleAlpha.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "alpha: ";
            // 
            // textBoxTestAngleD
            // 
            this.textBoxTestAngleD.Location = new System.Drawing.Point(51, 17);
            this.textBoxTestAngleD.Name = "textBoxTestAngleD";
            this.textBoxTestAngleD.ReadOnly = true;
            this.textBoxTestAngleD.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleD.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(24, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "D: ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxTestAngleInitPosY);
            this.groupBox5.Controls.Add(this.textBoxTestAngleInitPosX);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(85, 70);
            this.groupBox5.TabIndex = 86;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Initial Position";
            // 
            // textBoxTestAngleInitPosY
            // 
            this.textBoxTestAngleInitPosY.Location = new System.Drawing.Point(30, 43);
            this.textBoxTestAngleInitPosY.Name = "textBoxTestAngleInitPosY";
            this.textBoxTestAngleInitPosY.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleInitPosY.TabIndex = 3;
            this.textBoxTestAngleInitPosY.Text = "1,42";
            // 
            // textBoxTestAngleInitPosX
            // 
            this.textBoxTestAngleInitPosX.Location = new System.Drawing.Point(30, 17);
            this.textBoxTestAngleInitPosX.Name = "textBoxTestAngleInitPosX";
            this.textBoxTestAngleInitPosX.Size = new System.Drawing.Size(42, 20);
            this.textBoxTestAngleInitPosX.TabIndex = 2;
            this.textBoxTestAngleInitPosX.Text = "1,42";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(18, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "y: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "x: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonExcelGenerateFromData);
            this.groupBox2.Controls.Add(this.checkBoxExcelUpdateTags);
            this.groupBox2.Controls.Add(this.checkBoxExcelUpdateRSSIs);
            this.groupBox2.Controls.Add(this.checkBoxExcelUseExcel);
            this.groupBox2.Location = new System.Drawing.Point(8, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 89);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Excel";
            // 
            // buttonExcelGenerateFromData
            // 
            this.buttonExcelGenerateFromData.Location = new System.Drawing.Point(148, 16);
            this.buttonExcelGenerateFromData.Name = "buttonExcelGenerateFromData";
            this.buttonExcelGenerateFromData.Size = new System.Drawing.Size(141, 23);
            this.buttonExcelGenerateFromData.TabIndex = 89;
            this.buttonExcelGenerateFromData.Text = "Generate Excel from Data";
            this.buttonExcelGenerateFromData.UseVisualStyleBackColor = true;
            this.buttonExcelGenerateFromData.Click += new System.EventHandler(this.ButtonExcelGenerateFromData_Click);
            // 
            // checkBoxExcelUpdateTags
            // 
            this.checkBoxExcelUpdateTags.AutoSize = true;
            this.checkBoxExcelUpdateTags.Location = new System.Drawing.Point(6, 64);
            this.checkBoxExcelUpdateTags.Name = "checkBoxExcelUpdateTags";
            this.checkBoxExcelUpdateTags.Size = new System.Drawing.Size(88, 17);
            this.checkBoxExcelUpdateTags.TabIndex = 85;
            this.checkBoxExcelUpdateTags.Text = "Update Tags";
            this.checkBoxExcelUpdateTags.UseVisualStyleBackColor = true;
            this.checkBoxExcelUpdateTags.CheckedChanged += new System.EventHandler(this.CheckBoxExcelUpdateTags_CheckedChanged);
            // 
            // checkBoxExcelUpdateRSSIs
            // 
            this.checkBoxExcelUpdateRSSIs.AutoSize = true;
            this.checkBoxExcelUpdateRSSIs.Location = new System.Drawing.Point(6, 42);
            this.checkBoxExcelUpdateRSSIs.Name = "checkBoxExcelUpdateRSSIs";
            this.checkBoxExcelUpdateRSSIs.Size = new System.Drawing.Size(94, 17);
            this.checkBoxExcelUpdateRSSIs.TabIndex = 84;
            this.checkBoxExcelUpdateRSSIs.Text = "Update RSSIs";
            this.checkBoxExcelUpdateRSSIs.UseVisualStyleBackColor = true;
            this.checkBoxExcelUpdateRSSIs.CheckedChanged += new System.EventHandler(this.CheckBoxExcelUpdateRSSIs_CheckedChanged);
            // 
            // checkBoxExcelUseExcel
            // 
            this.checkBoxExcelUseExcel.AutoSize = true;
            this.checkBoxExcelUseExcel.Location = new System.Drawing.Point(6, 20);
            this.checkBoxExcelUseExcel.Name = "checkBoxExcelUseExcel";
            this.checkBoxExcelUseExcel.Size = new System.Drawing.Size(74, 17);
            this.checkBoxExcelUseExcel.TabIndex = 83;
            this.checkBoxExcelUseExcel.Text = "Use Excel";
            this.checkBoxExcelUseExcel.UseVisualStyleBackColor = true;
            this.checkBoxExcelUseExcel.CheckedChanged += new System.EventHandler(this.CheckBoxUseExcel_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxQueueSize);
            this.groupBox3.Location = new System.Drawing.Point(317, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 51);
            this.groupBox3.TabIndex = 82;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TestRadiationDiagram";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Queue Size:";
            // 
            // textBoxQueueSize
            // 
            this.textBoxQueueSize.Location = new System.Drawing.Point(77, 22);
            this.textBoxQueueSize.MaxLength = 256;
            this.textBoxQueueSize.Name = "textBoxQueueSize";
            this.textBoxQueueSize.Size = new System.Drawing.Size(40, 20);
            this.textBoxQueueSize.TabIndex = 82;
            this.textBoxQueueSize.Text = "50";
            this.textBoxQueueSize.Leave += new System.EventHandler(this.TextBoxQueueSize_Leave);
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(4, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1064, 606);
            this.tabPage9.TabIndex = 3;
            this.tabPage9.Text = "   TCP Client   ";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(226, 218);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(99, 13);
            this.label68.TabIndex = 11;
            // 
            // ctctsend
            // 
            this.ctctsend.Location = new System.Drawing.Point(224, 116);
            this.ctctsend.Multiline = true;
            this.ctctsend.Name = "ctctsend";
            this.ctctsend.Size = new System.Drawing.Size(617, 93);
            this.ctctsend.TabIndex = 12;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(226, 93);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(84, 13);
            this.label69.TabIndex = 13;
            // 
            // bttcpsend
            // 
            this.bttcpsend.Location = new System.Drawing.Point(0, 0);
            this.bttcpsend.Name = "bttcpsend";
            this.bttcpsend.Size = new System.Drawing.Size(75, 23);
            this.bttcpsend.TabIndex = 0;
            // 
            // groupBox26
            // 
            this.groupBox26.Location = new System.Drawing.Point(224, 7);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(617, 68);
            this.groupBox26.TabIndex = 15;
            this.groupBox26.TabStop = false;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(14, 33);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(54, 13);
            this.label70.TabIndex = 0;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(227, 33);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(29, 13);
            this.label71.TabIndex = 23;
            // 
            // remotePort
            // 
            this.remotePort.Location = new System.Drawing.Point(268, 27);
            this.remotePort.Name = "remotePort";
            this.remotePort.Size = new System.Drawing.Size(94, 20);
            this.remotePort.TabIndex = 24;
            // 
            // bttcpconnect
            // 
            this.bttcpconnect.Location = new System.Drawing.Point(0, 0);
            this.bttcpconnect.Name = "bttcpconnect";
            this.bttcpconnect.Size = new System.Drawing.Size(75, 23);
            this.bttcpconnect.TabIndex = 0;
            // 
            // bttcpdisconnect
            // 
            this.bttcpdisconnect.Location = new System.Drawing.Point(0, 0);
            this.bttcpdisconnect.Name = "bttcpdisconnect";
            this.bttcpdisconnect.Size = new System.Drawing.Size(75, 23);
            this.bttcpdisconnect.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1064, 606);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "   TCP Server   ";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.Location = new System.Drawing.Point(224, 10);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(301, 115);
            this.groupBox24.TabIndex = 4;
            this.groupBox24.TabStop = false;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(17, 35);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(53, 13);
            this.label62.TabIndex = 0;
            // 
            // stcpport
            // 
            this.stcpport.Location = new System.Drawing.Point(93, 27);
            this.stcpport.Name = "stcpport";
            this.stcpport.Size = new System.Drawing.Size(187, 20);
            this.stcpport.TabIndex = 1;
            // 
            // btListen
            // 
            this.btListen.Location = new System.Drawing.Point(0, 0);
            this.btListen.Name = "btListen";
            this.btListen.Size = new System.Drawing.Size(75, 23);
            this.btListen.TabIndex = 0;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(0, 0);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 0;
            // 
            // groupBox25
            // 
            this.groupBox25.Location = new System.Drawing.Point(534, 10);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(307, 115);
            this.groupBox25.TabIndex = 5;
            this.groupBox25.TabStop = false;
            // 
            // listtcp
            // 
            this.listtcp.FormattingEnabled = true;
            this.listtcp.Location = new System.Drawing.Point(8, 22);
            this.listtcp.Name = "listtcp";
            this.listtcp.Size = new System.Drawing.Size(287, 82);
            this.listtcp.TabIndex = 0;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(226, 139);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(99, 13);
            this.label63.TabIndex = 7;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1064, 606);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "    Serialport Config    ";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(-2, -9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1069, 611);
            this.panel6.TabIndex = 0;
            // 
            // groupBox47
            // 
            this.groupBox47.Location = new System.Drawing.Point(754, 376);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(110, 92);
            this.groupBox47.TabIndex = 66;
            this.groupBox47.TabStop = false;
            // 
            // btGotoAT
            // 
            this.btGotoAT.Location = new System.Drawing.Point(0, 0);
            this.btGotoAT.Name = "btGotoAT";
            this.btGotoAT.Size = new System.Drawing.Size(75, 23);
            this.btGotoAT.TabIndex = 0;
            // 
            // btExitAT
            // 
            this.btExitAT.Location = new System.Drawing.Point(0, 0);
            this.btExitAT.Name = "btExitAT";
            this.btExitAT.Size = new System.Drawing.Size(75, 23);
            this.btExitAT.TabIndex = 0;
            // 
            // groupBox49
            // 
            this.groupBox49.Location = new System.Drawing.Point(191, 26);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(554, 128);
            this.groupBox49.TabIndex = 67;
            this.groupBox49.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(18, 22);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(415, 92);
            this.panel7.TabIndex = 113;
            // 
            // fifoCB
            // 
            this.fifoCB.AccessibleName = "SerialFIFO";
            this.fifoCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fifoCB.FormattingEnabled = true;
            this.fifoCB.Items.AddRange(new object[] {
            "14",
            "8",
            "4"});
            this.fifoCB.Location = new System.Drawing.Point(221, 11);
            this.fifoCB.Name = "fifoCB";
            this.fifoCB.Size = new System.Drawing.Size(45, 21);
            this.fifoCB.TabIndex = 43;
            // 
            // flowCB
            // 
            this.flowCB.AccessibleName = "FlowControl";
            this.flowCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowCB.FormattingEnabled = true;
            this.flowCB.Items.AddRange(new object[] {
            "None",
            "Software",
            "Hardware"});
            this.flowCB.Location = new System.Drawing.Point(311, 39);
            this.flowCB.Name = "flowCB";
            this.flowCB.Size = new System.Drawing.Size(88, 21);
            this.flowCB.TabIndex = 44;
            // 
            // baudrateCB
            // 
            this.baudrateCB.AccessibleName = "BaudRate";
            this.baudrateCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudrateCB.FormattingEnabled = true;
            this.baudrateCB.Items.AddRange(new object[] {
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.baudrateCB.Location = new System.Drawing.Point(92, 38);
            this.baudrateCB.Name = "baudrateCB";
            this.baudrateCB.Size = new System.Drawing.Size(98, 21);
            this.baudrateCB.TabIndex = 45;
            // 
            // databitCB
            // 
            this.databitCB.AccessibleName = "DataBits";
            this.databitCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databitCB.FormattingEnabled = true;
            this.databitCB.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.databitCB.Location = new System.Drawing.Point(354, 11);
            this.databitCB.Name = "databitCB";
            this.databitCB.Size = new System.Drawing.Size(45, 21);
            this.databitCB.TabIndex = 46;
            // 
            // parityCB
            // 
            this.parityCB.AccessibleName = "SerialParity";
            this.parityCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parityCB.FormattingEnabled = true;
            this.parityCB.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN",
            "MARK",
            "SPACE"});
            this.parityCB.Location = new System.Drawing.Point(92, 66);
            this.parityCB.Name = "parityCB";
            this.parityCB.Size = new System.Drawing.Size(88, 21);
            this.parityCB.TabIndex = 47;
            // 
            // stopbitCB
            // 
            this.stopbitCB.AccessibleName = "StopBits";
            this.stopbitCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stopbitCB.FormattingEnabled = true;
            this.stopbitCB.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopbitCB.Location = new System.Drawing.Point(311, 66);
            this.stopbitCB.Name = "stopbitCB";
            this.stopbitCB.Size = new System.Drawing.Size(45, 21);
            this.stopbitCB.TabIndex = 48;
            // 
            // protocolCB
            // 
            this.protocolCB.AccessibleName = "SerialProtocol";
            this.protocolCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protocolCB.FormattingEnabled = true;
            this.protocolCB.Items.AddRange(new object[] {
            "RS232",
            "RS422",
            "RS485"});
            this.protocolCB.Location = new System.Drawing.Point(92, 11);
            this.protocolCB.Name = "protocolCB";
            this.protocolCB.Size = new System.Drawing.Size(64, 21);
            this.protocolCB.TabIndex = 83;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(15, 14);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(46, 13);
            this.label78.TabIndex = 107;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(186, 14);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(30, 13);
            this.label77.TabIndex = 108;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(15, 42);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(58, 13);
            this.label76.TabIndex = 107;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(15, 69);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(33, 13);
            this.label75.TabIndex = 109;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(221, 42);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(65, 13);
            this.label74.TabIndex = 110;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(221, 69);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(49, 13);
            this.label73.TabIndex = 111;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(281, 14);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(50, 13);
            this.label72.TabIndex = 112;
            // 
            // btSetSerialPort
            // 
            this.btSetSerialPort.Location = new System.Drawing.Point(0, 0);
            this.btSetSerialPort.Name = "btSetSerialPort";
            this.btSetSerialPort.Size = new System.Drawing.Size(75, 23);
            this.btSetSerialPort.TabIndex = 0;
            // 
            // btGetSeriaPort
            // 
            this.btGetSeriaPort.Location = new System.Drawing.Point(0, 0);
            this.btGetSeriaPort.Name = "btGetSeriaPort";
            this.btGetSeriaPort.Size = new System.Drawing.Size(75, 23);
            this.btGetSeriaPort.TabIndex = 0;
            // 
            // groupBox50
            // 
            this.groupBox50.Location = new System.Drawing.Point(191, 168);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(554, 164);
            this.groupBox50.TabIndex = 68;
            this.groupBox50.TabStop = false;
            // 
            // panel_TCP
            // 
            this.panel_TCP.Location = new System.Drawing.Point(12, 22);
            this.panel_TCP.Name = "panel_TCP";
            this.panel_TCP.Size = new System.Drawing.Size(421, 127);
            this.panel_TCP.TabIndex = 113;
            // 
            // tcpActiveCB
            // 
            this.tcpActiveCB.AccessibleName = "ConnActive";
            this.tcpActiveCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tcpActiveCB.FormattingEnabled = true;
            this.tcpActiveCB.Items.AddRange(new object[] {
            "None",
            "WithAnyCharacter",
            "WithStartCharacter",
            "AutoStart"});
            this.tcpActiveCB.Location = new System.Drawing.Point(292, 8);
            this.tcpActiveCB.Name = "tcpActiveCB";
            this.tcpActiveCB.Size = new System.Drawing.Size(107, 21);
            this.tcpActiveCB.TabIndex = 93;
            // 
            // tcpLocalPortNUD
            // 
            this.tcpLocalPortNUD.AccessibleName = "ConnLocalPort";
            this.tcpLocalPortNUD.Location = new System.Drawing.Point(111, 93);
            this.tcpLocalPortNUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tcpLocalPortNUD.Name = "tcpLocalPortNUD";
            this.tcpLocalPortNUD.Size = new System.Drawing.Size(60, 20);
            this.tcpLocalPortNUD.TabIndex = 95;
            this.tcpLocalPortNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tcpRemotePortNUD
            // 
            this.tcpRemotePortNUD.AccessibleName = "ConnRemotePort";
            this.tcpRemotePortNUD.Location = new System.Drawing.Point(111, 64);
            this.tcpRemotePortNUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.tcpRemotePortNUD.Name = "tcpRemotePortNUD";
            this.tcpRemotePortNUD.Size = new System.Drawing.Size(60, 20);
            this.tcpRemotePortNUD.TabIndex = 96;
            this.tcpRemotePortNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tcpRomteHostTB
            // 
            this.tcpRomteHostTB.AccessibleName = "ConnRemoteHost";
            this.tcpRomteHostTB.Location = new System.Drawing.Point(79, 35);
            this.tcpRomteHostTB.Name = "tcpRomteHostTB";
            this.tcpRomteHostTB.Size = new System.Drawing.Size(92, 20);
            this.tcpRomteHostTB.TabIndex = 98;
            // 
            // workasCB
            // 
            this.workasCB.AccessibleName = "ConnWorkMode";
            this.workasCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workasCB.FormattingEnabled = true;
            this.workasCB.Items.AddRange(new object[] {
            "Server",
            "Client"});
            this.workasCB.Location = new System.Drawing.Point(79, 10);
            this.workasCB.Name = "workasCB";
            this.workasCB.Size = new System.Drawing.Size(92, 21);
            this.workasCB.TabIndex = 106;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(203, 13);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(80, 13);
            this.label93.TabIndex = 107;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(3, 13);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(60, 13);
            this.label90.TabIndex = 116;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(3, 39);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(69, 13);
            this.label89.TabIndex = 117;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(3, 70);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(66, 13);
            this.label88.TabIndex = 118;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(3, 101);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(55, 13);
            this.label87.TabIndex = 119;
            // 
            // btSetCnt
            // 
            this.btSetCnt.Location = new System.Drawing.Point(0, 0);
            this.btSetCnt.Name = "btSetCnt";
            this.btSetCnt.Size = new System.Drawing.Size(75, 23);
            this.btSetCnt.TabIndex = 0;
            // 
            // btGetCnt
            // 
            this.btGetCnt.Location = new System.Drawing.Point(0, 0);
            this.btGetCnt.Name = "btGetCnt";
            this.btGetCnt.Size = new System.Drawing.Size(75, 23);
            this.btGetCnt.TabIndex = 0;
            // 
            // groupBox51
            // 
            this.groupBox51.Location = new System.Drawing.Point(191, 345);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(554, 221);
            this.groupBox51.TabIndex = 69;
            this.groupBox51.TabStop = false;
            // 
            // panel_StaticIp
            // 
            this.panel_StaticIp.Location = new System.Drawing.Point(12, 22);
            this.panel_StaticIp.Name = "panel_StaticIp";
            this.panel_StaticIp.Size = new System.Drawing.Size(179, 187);
            this.panel_StaticIp.TabIndex = 56;
            // 
            // ipTB
            // 
            this.ipTB.AccessibleName = "IpAddress";
            this.ipTB.Location = new System.Drawing.Point(79, 3);
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(97, 20);
            this.ipTB.TabIndex = 39;
            // 
            // subnetTB
            // 
            this.subnetTB.AccessibleName = "Subnet";
            this.subnetTB.Location = new System.Drawing.Point(79, 33);
            this.subnetTB.Name = "subnetTB";
            this.subnetTB.Size = new System.Drawing.Size(97, 20);
            this.subnetTB.TabIndex = 40;
            // 
            // gatewayTB
            // 
            this.gatewayTB.AccessibleName = "Gateway";
            this.gatewayTB.Location = new System.Drawing.Point(79, 62);
            this.gatewayTB.Name = "gatewayTB";
            this.gatewayTB.Size = new System.Drawing.Size(97, 20);
            this.gatewayTB.TabIndex = 41;
            // 
            // pDNSTB
            // 
            this.pDNSTB.AccessibleName = "PreferredDNS";
            this.pDNSTB.Location = new System.Drawing.Point(79, 109);
            this.pDNSTB.Name = "pDNSTB";
            this.pDNSTB.Size = new System.Drawing.Size(97, 20);
            this.pDNSTB.TabIndex = 42;
            // 
            // altDNSTB
            // 
            this.altDNSTB.AccessibleName = "AlternateDNS";
            this.altDNSTB.Location = new System.Drawing.Point(79, 155);
            this.altDNSTB.Name = "altDNSTB";
            this.altDNSTB.Size = new System.Drawing.Size(97, 20);
            this.altDNSTB.TabIndex = 43;
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(3, 7);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(58, 13);
            this.label105.TabIndex = 46;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(3, 36);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(41, 13);
            this.label106.TabIndex = 47;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(3, 65);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(49, 13);
            this.label107.TabIndex = 48;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(3, 93);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(110, 13);
            this.label108.TabIndex = 49;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(3, 139);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(109, 13);
            this.label109.TabIndex = 50;
            // 
            // macTB
            // 
            this.macTB.AccessibleName = "MacAddress";
            this.macTB.Location = new System.Drawing.Point(224, 46);
            this.macTB.Name = "macTB";
            this.macTB.ReadOnly = true;
            this.macTB.Size = new System.Drawing.Size(176, 20);
            this.macTB.TabIndex = 58;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(222, 28);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(69, 13);
            this.label110.TabIndex = 61;
            // 
            // btSetNet
            // 
            this.btSetNet.Location = new System.Drawing.Point(0, 0);
            this.btSetNet.Name = "btSetNet";
            this.btSetNet.Size = new System.Drawing.Size(75, 23);
            this.btSetNet.TabIndex = 0;
            // 
            // btGetNet
            // 
            this.btGetNet.Location = new System.Drawing.Point(0, 0);
            this.btGetNet.Name = "btGetNet";
            this.btGetNet.Size = new System.Drawing.Size(75, 23);
            this.btGetNet.TabIndex = 0;
            // 
            // btLoadDefault
            // 
            this.btLoadDefault.Location = new System.Drawing.Point(0, 0);
            this.btLoadDefault.Name = "btLoadDefault";
            this.btLoadDefault.Size = new System.Drawing.Size(75, 23);
            this.btLoadDefault.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(0, 0);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1064, 606);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "    TCP config        ";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(72, 20);
            this.toolStripMenuItem1.Text = "&Operation";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(107, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(42, 20);
            this.toolStripMenuItem2.Text = "&Tool";
            // 
            // iEToolStripMenuItem
            // 
            this.iEToolStripMenuItem.Name = "iEToolStripMenuItem";
            this.iEToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // telnetToolStripMenuItem
            // 
            this.telnetToolStripMenuItem.Name = "telnetToolStripMenuItem";
            this.telnetToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languageToolStripMenuItem.Text = "&Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.englishToolStripMenuItem.Text = "&English";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // DeviceListView
            // 
            this.DeviceListView.Location = new System.Drawing.Point(0, 0);
            this.DeviceListView.Name = "DeviceListView";
            this.DeviceListView.Size = new System.Drawing.Size(121, 97);
            this.DeviceListView.TabIndex = 0;
            this.DeviceListView.UseCompatibleStateImageBehavior = false;
            // 
            // deviceName
            // 
            this.deviceName.DisplayIndex = 0;
            this.deviceName.Text = "Device name";
            this.deviceName.Width = 220;
            // 
            // deviceIP
            // 
            this.deviceIP.DisplayIndex = 1;
            this.deviceIP.Text = "Device IP";
            this.deviceIP.Width = 280;
            // 
            // deviceMac
            // 
            this.deviceMac.DisplayIndex = 2;
            this.deviceMac.Text = "Device Mac";
            this.deviceMac.Width = 245;
            // 
            // groupBox19
            // 
            this.groupBox19.Location = new System.Drawing.Point(10, 5);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(524, 77);
            this.groupBox19.TabIndex = 16;
            this.groupBox19.TabStop = false;
            // 
            // btInventory6B
            // 
            this.btInventory6B.Location = new System.Drawing.Point(0, 0);
            this.btInventory6B.Name = "btInventory6B";
            this.btInventory6B.Size = new System.Drawing.Size(75, 23);
            this.btInventory6B.TabIndex = 0;
            // 
            // rb_single
            // 
            this.rb_single.AutoSize = true;
            this.rb_single.Checked = true;
            this.rb_single.Location = new System.Drawing.Point(246, 38);
            this.rb_single.Name = "rb_single";
            this.rb_single.Size = new System.Drawing.Size(54, 17);
            this.rb_single.TabIndex = 1;
            this.rb_single.TabStop = true;
            this.rb_single.Text = "Single";
            this.rb_single.UseVisualStyleBackColor = true;
            // 
            // rb_mutiple
            // 
            this.rb_mutiple.AutoSize = true;
            this.rb_mutiple.Location = new System.Drawing.Point(377, 38);
            this.rb_mutiple.Name = "rb_mutiple";
            this.rb_mutiple.Size = new System.Drawing.Size(59, 17);
            this.rb_mutiple.TabIndex = 2;
            this.rb_mutiple.Text = "Mutiple";
            this.rb_mutiple.UseVisualStyleBackColor = true;
            // 
            // ListView_ID_6B
            // 
            this.ListView_ID_6B.Location = new System.Drawing.Point(0, 0);
            this.ListView_ID_6B.Name = "ListView_ID_6B";
            this.ListView_ID_6B.Size = new System.Drawing.Size(121, 97);
            this.ListView_ID_6B.TabIndex = 0;
            this.ListView_ID_6B.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 0;
            this.columnHeader5.Text = "NO";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 1;
            this.columnHeader6.Text = "ID";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 230;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 2;
            this.columnHeader7.Text = "ANT(4,3,2,1)";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 3;
            this.columnHeader2.Text = "Times";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 4;
            this.columnHeader3.Text = "RSSI";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(561, 48);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(111, 13);
            this.label29.TabIndex = 18;
            // 
            // text_6BUID
            // 
            this.text_6BUID.Location = new System.Drawing.Point(685, 42);
            this.text_6BUID.Name = "text_6BUID";
            this.text_6BUID.ReadOnly = true;
            this.text_6BUID.Size = new System.Drawing.Size(214, 20);
            this.text_6BUID.TabIndex = 19;
            // 
            // groupBox22
            // 
            this.groupBox22.Location = new System.Drawing.Point(563, 76);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(495, 440);
            this.groupBox22.TabIndex = 20;
            this.groupBox22.TabStop = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(106, 13);
            this.label30.TabIndex = 5;
            // 
            // text_R6BAddr
            // 
            this.text_R6BAddr.Location = new System.Drawing.Point(0, 0);
            this.text_R6BAddr.Name = "text_R6BAddr";
            this.text_R6BAddr.Size = new System.Drawing.Size(100, 20);
            this.text_R6BAddr.TabIndex = 0;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(189, 31);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(93, 13);
            this.label35.TabIndex = 7;
            // 
            // text_R6BLen
            // 
            this.text_R6BLen.Location = new System.Drawing.Point(0, 0);
            this.text_R6BLen.Name = "text_R6BLen";
            this.text_R6BLen.Size = new System.Drawing.Size(100, 20);
            this.text_R6BLen.TabIndex = 0;
            // 
            // btRead6B
            // 
            this.btRead6B.Location = new System.Drawing.Point(0, 0);
            this.btRead6B.Name = "btRead6B";
            this.btRead6B.Size = new System.Drawing.Size(75, 23);
            this.btRead6B.TabIndex = 0;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(18, 67);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(94, 13);
            this.label36.TabIndex = 10;
            // 
            // text_R6B
            // 
            this.text_R6B.Location = new System.Drawing.Point(122, 67);
            this.text_R6B.Multiline = true;
            this.text_R6B.Name = "text_R6B";
            this.text_R6B.ReadOnly = true;
            this.text_R6B.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_R6B.Size = new System.Drawing.Size(359, 150);
            this.text_R6B.TabIndex = 11;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(11, 245);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(106, 13);
            this.label50.TabIndex = 12;
            // 
            // text_W6BAddr
            // 
            this.text_W6BAddr.Location = new System.Drawing.Point(0, 0);
            this.text_W6BAddr.Name = "text_W6BAddr";
            this.text_W6BAddr.Size = new System.Drawing.Size(100, 20);
            this.text_W6BAddr.TabIndex = 0;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(185, 245);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(92, 13);
            this.label49.TabIndex = 14;
            // 
            // text_W6BLen
            // 
            this.text_W6BLen.Location = new System.Drawing.Point(0, 0);
            this.text_W6BLen.Name = "text_W6BLen";
            this.text_W6BLen.Size = new System.Drawing.Size(100, 20);
            this.text_W6BLen.TabIndex = 0;
            // 
            // btWrite6B
            // 
            this.btWrite6B.Location = new System.Drawing.Point(0, 0);
            this.btWrite6B.Name = "btWrite6B";
            this.btWrite6B.Size = new System.Drawing.Size(75, 23);
            this.btWrite6B.TabIndex = 0;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(18, 278);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(93, 13);
            this.label48.TabIndex = 17;
            // 
            // text_W6B
            // 
            this.text_W6B.Location = new System.Drawing.Point(0, 0);
            this.text_W6B.Name = "text_W6B";
            this.text_W6B.Size = new System.Drawing.Size(100, 20);
            this.text_W6B.TabIndex = 0;
            // 
            // groupBox23
            // 
            this.groupBox23.Location = new System.Drawing.Point(561, 517);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(495, 124);
            this.groupBox23.TabIndex = 21;
            this.groupBox23.TabStop = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(71, 35);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(99, 13);
            this.label51.TabIndex = 0;
            // 
            // text_lock6b
            // 
            this.text_lock6b.Location = new System.Drawing.Point(0, 0);
            this.text_lock6b.Name = "text_lock6b";
            this.text_lock6b.Size = new System.Drawing.Size(100, 20);
            this.text_lock6b.TabIndex = 0;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(47, 85);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(129, 13);
            this.label52.TabIndex = 15;
            // 
            // text_checkaddr
            // 
            this.text_checkaddr.Location = new System.Drawing.Point(0, 0);
            this.text_checkaddr.Name = "text_checkaddr";
            this.text_checkaddr.Size = new System.Drawing.Size(100, 20);
            this.text_checkaddr.TabIndex = 0;
            // 
            // btLock6B
            // 
            this.btLock6B.Location = new System.Drawing.Point(0, 0);
            this.btLock6B.Name = "btLock6B";
            this.btLock6B.Size = new System.Drawing.Size(75, 23);
            this.btLock6B.TabIndex = 0;
            // 
            // btCheckLock6B
            // 
            this.btCheckLock6B.Location = new System.Drawing.Point(0, 0);
            this.btCheckLock6B.Name = "btCheckLock6B";
            this.btCheckLock6B.Size = new System.Drawing.Size(75, 23);
            this.btCheckLock6B.TabIndex = 0;
            // 
            // text_Statu6B
            // 
            this.text_Statu6B.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_Statu6B.ForeColor = System.Drawing.Color.Red;
            this.text_Statu6B.Location = new System.Drawing.Point(252, 81);
            this.text_Statu6B.MaxLength = 2;
            this.text_Statu6B.Name = "text_Statu6B";
            this.text_Statu6B.ReadOnly = true;
            this.text_Statu6B.Size = new System.Drawing.Size(111, 20);
            this.text_Statu6B.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLog.MinimumSize = new System.Drawing.Size(696, 200);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(884, 202);
            this.richTextBoxLog.TabIndex = 6;
            this.richTextBoxLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxLog);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 485);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 202);
            this.panel1.TabIndex = 7;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 482);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(884, 3);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // timerReads
            // 
            this.timerReads.Tick += new System.EventHandler(this.TimerReads_Tick);
            // 
            // timerDuration
            // 
            this.timerDuration.Tick += new System.EventHandler(this.TimerDuration_Tick);
            // 
            // buttonOpenLogFile
            // 
            this.buttonOpenLogFile.Location = new System.Drawing.Point(221, 454);
            this.buttonOpenLogFile.Name = "buttonOpenLogFile";
            this.buttonOpenLogFile.Size = new System.Drawing.Size(96, 25);
            this.buttonOpenLogFile.TabIndex = 77;
            this.buttonOpenLogFile.Text = "Open Log File";
            this.buttonOpenLogFile.UseVisualStyleBackColor = true;
            this.buttonOpenLogFile.Click += new System.EventHandler(this.ButtonOpenLogFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(884, 687);
            this.Controls.Add(this.buttonOpenLogFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.buttonRefreshLogs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Maintab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RINPOSYS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Maintab.ResumeLayout(false);
            this.Command.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.MathematicModel.ResumeLayout(false);
            this.groupBoxMMParameters.ResumeLayout(false);
            this.groupBoxMMParameters.PerformLayout();
            this.RFIDReads.ResumeLayout(false);
            this.groupBoxSetup.ResumeLayout(false);
            this.groupBoxSetup.PerformLayout();
            this.groupBoxR2.ResumeLayout(false);
            this.groupBoxR2.PerformLayout();
            this.groupBoxR1.ResumeLayout(false);
            this.groupBoxR1.PerformLayout();
            this.groupBoxReadsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMetaTagsList)).EndInit();
            this.TagsList.ResumeLayout(false);
            this.groupBoxTagsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTagsList)).EndInit();
            this.tabNotes.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.tabMySQL.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabEPCsCompare.ResumeLayout(false);
            this.tabEPCsCompare.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcpLocalPortNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcpRemotePortNUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRefreshLogs;
        private System.Windows.Forms.TabControl Maintab;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox ctctsend;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button bttcpsend;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox remotePort;
        private System.Windows.Forms.Button bttcpconnect;
        private System.Windows.Forms.Button bttcpdisconnect;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox stcpport;
        private System.Windows.Forms.Button btListen;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.ListBox listtcp;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox47;
        private System.Windows.Forms.Button btGotoAT;
        private System.Windows.Forms.Button btExitAT;
        private System.Windows.Forms.GroupBox groupBox49;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox fifoCB;
        private System.Windows.Forms.ComboBox flowCB;
        private System.Windows.Forms.ComboBox baudrateCB;
        private System.Windows.Forms.ComboBox databitCB;
        private System.Windows.Forms.ComboBox parityCB;
        private System.Windows.Forms.ComboBox stopbitCB;
        private System.Windows.Forms.ComboBox protocolCB;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btSetSerialPort;
        private System.Windows.Forms.Button btGetSeriaPort;
        private System.Windows.Forms.GroupBox groupBox50;
        private System.Windows.Forms.Panel panel_TCP;
        private System.Windows.Forms.ComboBox tcpActiveCB;
        private System.Windows.Forms.NumericUpDown tcpLocalPortNUD;
        private System.Windows.Forms.NumericUpDown tcpRemotePortNUD;
        private System.Windows.Forms.TextBox tcpRomteHostTB;
        private System.Windows.Forms.ComboBox workasCB;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Button btSetCnt;
        private System.Windows.Forms.Button btGetCnt;
        private System.Windows.Forms.GroupBox groupBox51;
        private System.Windows.Forms.Panel panel_StaticIp;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.TextBox subnetTB;
        private System.Windows.Forms.TextBox gatewayTB;
        private System.Windows.Forms.TextBox pDNSTB;
        private System.Windows.Forms.TextBox altDNSTB;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.TextBox macTB;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Button btSetNet;
        private System.Windows.Forms.Button btGetNet;
        private System.Windows.Forms.Button btLoadDefault;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem iEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem telnetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListView DeviceListView;
        private System.Windows.Forms.ColumnHeader deviceName;
        private System.Windows.Forms.ColumnHeader deviceIP;
        private System.Windows.Forms.ColumnHeader deviceMac;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btInventory6B;
        private System.Windows.Forms.RadioButton rb_single;
        private System.Windows.Forms.RadioButton rb_mutiple;
        private System.Windows.Forms.ListView ListView_ID_6B;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox text_6BUID;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox text_R6BAddr;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox text_R6BLen;
        private System.Windows.Forms.Button btRead6B;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox text_R6B;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox text_W6BAddr;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox text_W6BLen;
        private System.Windows.Forms.Button btWrite6B;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox text_W6B;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox text_lock6b;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox text_checkaddr;
        private System.Windows.Forms.Button btLock6B;
        private System.Windows.Forms.Button btCheckLock6B;
        private System.Windows.Forms.TextBox text_Statu6B;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage MathematicModel;
        private System.Windows.Forms.GroupBox groupBoxMMParameters;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLMax;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRssiMin;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxXAmp;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxRssiMax;
        private System.Windows.Forms.Button buttonOpenParametersConfigFile;
        private System.Windows.Forms.TabPage Command;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage RFIDReads;
        private System.Windows.Forms.GroupBox groupBoxReadsList;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxSetup;
        private System.Windows.Forms.Panel panelDevices;
        private System.Windows.Forms.Button buttonUseConfigDevicesFile;
        private System.Windows.Forms.TabPage TagsList;
        private System.Windows.Forms.GroupBox groupBoxTagsList;
        private System.Windows.Forms.DataGridView dataGridViewTagsList;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button buttonTestAngleX;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxQueueSize;
        private System.Windows.Forms.ComboBox cbR1Scantime;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cbR2Target;
        private System.Windows.Forms.ComboBox cbR1Target;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxR2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbR2Session;
        private System.Windows.Forms.GroupBox groupBoxR1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbR1Session;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxExcelUseExcel;
        private System.Windows.Forms.ComboBox cbR1Q;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxR1NTimes;
        private System.Windows.Forms.CheckBox checkBoxR1ReadFlag;
        private System.Windows.Forms.TextBox textBoxR2NTimes;
        private System.Windows.Forms.ComboBox cbR2Scantime;
        private System.Windows.Forms.CheckBox checkBoxR2ReadFlag;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbR2Q;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxTestAngleInitPosY;
        private System.Windows.Forms.TextBox textBoxTestAngleInitPosX;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBoxTestAngleFinalPosY;
        private System.Windows.Forms.TextBox textBoxTestAngleFinalPosX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxTestAngleAntDistance;
        private System.Windows.Forms.TextBox textBoxTestAngleTheta;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBoxTestAngleAlpha;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxTestAngleD;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button buttonTestAngle;
        private System.Windows.Forms.DataGridView dataGridViewMetaTagsList;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button buttonUseNotesConfigFile;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.TabPage tabMySQL;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox textBoxTable;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button buttonUseMySQLConfigFile;
        private System.Windows.Forms.CheckBox checkBoxUseMM;
        private System.Windows.Forms.CheckBox checkBoxExcelUpdateRSSIs;
        private System.Windows.Forms.CheckBox checkBoxExcelUpdateTags;
        private System.Windows.Forms.Button buttonExcelGenerateFromData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Timer timerReads;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.CheckBox checkBoxDuration;
        private System.Windows.Forms.Timer timerDuration;
        private System.Windows.Forms.TabPage tabEPCsCompare;
        private System.Windows.Forms.Button buttonRunCompare;
        private System.Windows.Forms.RichTextBox richTextBoxGetTags;
        private System.Windows.Forms.RichTextBox richTextBoxInsertTags;
        private System.Windows.Forms.Button buttonCompareClearList;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button buttonResetAllConfigFiles;
        private System.Windows.Forms.GroupBox groupBox13;
        internal System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxDeltaRead;
        private System.Windows.Forms.CheckBox checkBoxUseDeltaRead;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxEPCDatasets;
        private System.Windows.Forms.Button buttonOpenEPCCompareConfigFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn AntID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn R1RSSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn R2RSSI;
        private System.Windows.Forms.Button buttonOpenConfigDevicesFile;
        private System.Windows.Forms.Button buttonOpenDeviceManager;
        private System.Windows.Forms.Button buttonUseParametersConfigFile;
        private System.Windows.Forms.Button buttonOpenNotesConfigFile;
        private System.Windows.Forms.Button buttonOpenMySQLConfigFile;
        private System.Windows.Forms.Button buttonUseEPCCompareConfigFile;
        private System.Windows.Forms.Button buttonOpenLogFile;
    }
}

