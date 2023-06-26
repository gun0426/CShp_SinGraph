using System;

namespace Chart_Project
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStriptextBox0 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStriptextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.initToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.check11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispcount100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fsinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartdfv1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar_DrawSpeed = new System.Windows.Forms.TrackBar();
            this.textBox_DrawTick = new System.Windows.Forms.TextBox();
            this.textBox_dispcount = new System.Windows.Forms.TextBox();
            this.button_Color7 = new System.Windows.Forms.Button();
            this.button_Color6 = new System.Windows.Forms.Button();
            this.button_Color5 = new System.Windows.Forms.Button();
            this.button_Color4 = new System.Windows.Forms.Button();
            this.button_Color3 = new System.Windows.Forms.Button();
            this.button_Color2 = new System.Windows.Forms.Button();
            this.button_Color1 = new System.Windows.Forms.Button();
            this.button_ColorS7 = new System.Windows.Forms.Button();
            this.button_ColorS6 = new System.Windows.Forms.Button();
            this.button_ColorS5 = new System.Windows.Forms.Button();
            this.button_ColorS4 = new System.Windows.Forms.Button();
            this.button_ColorS3 = new System.Windows.Forms.Button();
            this.button_ColorS2 = new System.Windows.Forms.Button();
            this.button_ColorS1 = new System.Windows.Forms.Button();
            this.button_ColorS0 = new System.Windows.Forms.Button();
            this.button_Color0 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.checkBox40 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.checkBox48 = new System.Windows.Forms.CheckBox();
            this.checkBox47 = new System.Windows.Forms.CheckBox();
            this.checkBox46 = new System.Windows.Forms.CheckBox();
            this.checkBox45 = new System.Windows.Forms.CheckBox();
            this.checkBox44 = new System.Windows.Forms.CheckBox();
            this.checkBox43 = new System.Windows.Forms.CheckBox();
            this.checkBox42 = new System.Windows.Forms.CheckBox();
            this.checkBox64 = new System.Windows.Forms.CheckBox();
            this.checkBox63 = new System.Windows.Forms.CheckBox();
            this.checkBox62 = new System.Windows.Forms.CheckBox();
            this.checkBox61 = new System.Windows.Forms.CheckBox();
            this.checkBox60 = new System.Windows.Forms.CheckBox();
            this.checkBox59 = new System.Windows.Forms.CheckBox();
            this.checkBox58 = new System.Windows.Forms.CheckBox();
            this.checkBox57 = new System.Windows.Forms.CheckBox();
            this.checkBox56 = new System.Windows.Forms.CheckBox();
            this.checkBox55 = new System.Windows.Forms.CheckBox();
            this.checkBox54 = new System.Windows.Forms.CheckBox();
            this.checkBox53 = new System.Windows.Forms.CheckBox();
            this.checkBox52 = new System.Windows.Forms.CheckBox();
            this.checkBox51 = new System.Windows.Forms.CheckBox();
            this.checkBox50 = new System.Windows.Forms.CheckBox();
            this.checkBox49 = new System.Windows.Forms.CheckBox();
            this.checkBox41 = new System.Windows.Forms.CheckBox();
            this.checkBox33 = new System.Windows.Forms.CheckBox();
            this.checkBox32 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.textBox_resolution = new System.Windows.Forms.TextBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox39 = new System.Windows.Forms.CheckBox();
            this.checkBox34 = new System.Windows.Forms.CheckBox();
            this.checkBox31 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.checkBox38 = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.checkBox35 = new System.Windows.Forms.CheckBox();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox36 = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.checkBox37 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBox_MousePoint = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textBox_Cmd = new System.Windows.Forms.TextBox();
            this.button_RegEx = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.textBox_UserTitle = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_DrawSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1398, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.toolStripSeparator1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriptextBox0,
            this.toolStripSeparator2});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStriptextBox0
            // 
            this.toolStriptextBox0.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.toolStriptextBox0.Name = "toolStriptextBox0";
            this.toolStriptextBox0.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox2});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 23);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriptextBox1});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem4.Text = "toolStripMenuItem4";
            // 
            // toolStriptextBox1
            // 
            this.toolStriptextBox1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.toolStriptextBox1.Name = "toolStriptextBox1";
            this.toolStriptextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem5.Text = "toolStripMenuItem5";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(127, 22);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.startToolStripMenuItem,
            this.check11ToolStripMenuItem,
            this.checkAllToolStripMenuItem,
            this.dispcount100ToolStripMenuItem,
            this.sinxToolStripMenuItem,
            this.fsinsToolStripMenuItem,
            this.chartdfv1ToolStripMenuItem});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(76, 22);
            this.toolStripMenuItem7.Text = "Command";
            // 
            // initToolStripMenuItem
            // 
            this.initToolStripMenuItem.Name = "initToolStripMenuItem";
            this.initToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.initToolStripMenuItem.Text = "init";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "clear";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startToolStripMenuItem.Text = "start";
            // 
            // check11ToolStripMenuItem
            // 
            this.check11ToolStripMenuItem.Name = "check11ToolStripMenuItem";
            this.check11ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.check11ToolStripMenuItem.Text = "check(1,1)";
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkAllToolStripMenuItem.Text = "check -a -d";
            // 
            // dispcount100ToolStripMenuItem
            // 
            this.dispcount100ToolStripMenuItem.Name = "dispcount100ToolStripMenuItem";
            this.dispcount100ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dispcount100ToolStripMenuItem.Text = "disp -c -r -t";
            // 
            // sinxToolStripMenuItem
            // 
            this.sinxToolStripMenuItem.Name = "sinxToolStripMenuItem";
            this.sinxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sinxToolStripMenuItem.Text = "sin(x)";
            // 
            // fsinsToolStripMenuItem
            // 
            this.fsinsToolStripMenuItem.Name = "fsinsToolStripMenuItem";
            this.fsinsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fsinsToolStripMenuItem.Text = "fsin(s)";
            // 
            // chartdfv1ToolStripMenuItem
            // 
            this.chartdfv1ToolStripMenuItem.Name = "chartdfv1ToolStripMenuItem";
            this.chartdfv1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.chartdfv1ToolStripMenuItem.Text = "chart -df -v1 -wm";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.Color.White;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.trackBar_DrawSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_DrawTick);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_dispcount);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color7);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color6);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color5);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color4);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color3);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color2);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color1);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS7);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS6);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS5);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS4);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS3);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS2);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS1);
            this.splitContainer1.Panel1.Controls.Add(this.button_ColorS0);
            this.splitContainer1.Panel1.Controls.Add(this.button_Color0);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox25);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox10);
            this.splitContainer1.Panel1.Controls.Add(this.button_Start);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox40);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox4);
            this.splitContainer1.Panel1.Controls.Add(this.textBox0);
            this.splitContainer1.Panel1.Controls.Add(this.label23);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox17);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label30);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox48);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox47);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox46);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox45);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox44);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox43);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox42);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox64);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox63);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox62);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox61);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox60);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox59);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox58);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox57);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox56);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox55);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox54);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox53);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox52);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox51);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox50);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox49);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox41);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox33);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox32);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox3);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox18);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox24);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox9);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox11);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox16);
            this.splitContainer1.Panel1.Controls.Add(this.textBox3);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox7);
            this.splitContainer1.Panel1.Controls.Add(this.textBox6);
            this.splitContainer1.Panel1.Controls.Add(this.textBox5);
            this.splitContainer1.Panel1.Controls.Add(this.textBox4);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox26);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_resolution);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox8);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox12);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox39);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox34);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox31);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox19);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox23);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox20);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox15);
            this.splitContainer1.Panel1.Controls.Add(this.label28);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox27);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox7);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox28);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox38);
            this.splitContainer1.Panel1.Controls.Add(this.label27);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox35);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox30);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox36);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox22);
            this.splitContainer1.Panel1.Controls.Add(this.label26);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox5);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox14);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox13);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox6);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox21);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox37);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox29);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1398, 584);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(122, 431);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // trackBar_DrawSpeed
            // 
            this.trackBar_DrawSpeed.Location = new System.Drawing.Point(13, 550);
            this.trackBar_DrawSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar_DrawSpeed.Maximum = 1000;
            this.trackBar_DrawSpeed.Minimum = 10;
            this.trackBar_DrawSpeed.Name = "trackBar_DrawSpeed";
            this.trackBar_DrawSpeed.Size = new System.Drawing.Size(125, 45);
            this.trackBar_DrawSpeed.TabIndex = 17;
            this.trackBar_DrawSpeed.TickFrequency = 10;
            this.trackBar_DrawSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_DrawSpeed.Value = 10;
            this.trackBar_DrawSpeed.Visible = false;
            this.trackBar_DrawSpeed.Scroll += new System.EventHandler(this.trackBar_DrawSpeed_Scroll);
            // 
            // textBox_DrawTick
            // 
            this.textBox_DrawTick.Location = new System.Drawing.Point(141, 552);
            this.textBox_DrawTick.Name = "textBox_DrawTick";
            this.textBox_DrawTick.Size = new System.Drawing.Size(28, 21);
            this.textBox_DrawTick.TabIndex = 16;
            this.textBox_DrawTick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_DrawTick.Visible = false;
            this.textBox_DrawTick.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DrawTick_KeyPress);
            // 
            // textBox_dispcount
            // 
            this.textBox_dispcount.Location = new System.Drawing.Point(82, 505);
            this.textBox_dispcount.Name = "textBox_dispcount";
            this.textBox_dispcount.Size = new System.Drawing.Size(28, 21);
            this.textBox_dispcount.TabIndex = 16;
            this.textBox_dispcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox_dispcount.Visible = false;
            // 
            // button_Color7
            // 
            this.button_Color7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button_Color7.Location = new System.Drawing.Point(157, 377);
            this.button_Color7.Name = "button_Color7";
            this.button_Color7.Size = new System.Drawing.Size(16, 17);
            this.button_Color7.TabIndex = 15;
            this.button_Color7.UseVisualStyleBackColor = false;
            this.button_Color7.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_Color6
            // 
            this.button_Color6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Color6.Location = new System.Drawing.Point(157, 354);
            this.button_Color6.Name = "button_Color6";
            this.button_Color6.Size = new System.Drawing.Size(16, 17);
            this.button_Color6.TabIndex = 15;
            this.button_Color6.UseVisualStyleBackColor = false;
            this.button_Color6.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_Color5
            // 
            this.button_Color5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button_Color5.Location = new System.Drawing.Point(157, 331);
            this.button_Color5.Name = "button_Color5";
            this.button_Color5.Size = new System.Drawing.Size(16, 17);
            this.button_Color5.TabIndex = 15;
            this.button_Color5.UseVisualStyleBackColor = false;
            this.button_Color5.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_Color4
            // 
            this.button_Color4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_Color4.Location = new System.Drawing.Point(157, 308);
            this.button_Color4.Name = "button_Color4";
            this.button_Color4.Size = new System.Drawing.Size(16, 17);
            this.button_Color4.TabIndex = 15;
            this.button_Color4.UseVisualStyleBackColor = false;
            this.button_Color4.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_Color3
            // 
            this.button_Color3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button_Color3.Location = new System.Drawing.Point(157, 285);
            this.button_Color3.Name = "button_Color3";
            this.button_Color3.Size = new System.Drawing.Size(16, 17);
            this.button_Color3.TabIndex = 14;
            this.button_Color3.UseVisualStyleBackColor = false;
            this.button_Color3.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_Color2
            // 
            this.button_Color2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button_Color2.Location = new System.Drawing.Point(157, 262);
            this.button_Color2.Name = "button_Color2";
            this.button_Color2.Size = new System.Drawing.Size(16, 17);
            this.button_Color2.TabIndex = 14;
            this.button_Color2.UseVisualStyleBackColor = false;
            this.button_Color2.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_Color1
            // 
            this.button_Color1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_Color1.Location = new System.Drawing.Point(157, 239);
            this.button_Color1.Name = "button_Color1";
            this.button_Color1.Size = new System.Drawing.Size(16, 17);
            this.button_Color1.TabIndex = 14;
            this.button_Color1.UseVisualStyleBackColor = false;
            this.button_Color1.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // button_ColorS7
            // 
            this.button_ColorS7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS7.Location = new System.Drawing.Point(157, 152);
            this.button_ColorS7.Name = "button_ColorS7";
            this.button_ColorS7.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS7.TabIndex = 14;
            this.button_ColorS7.UseVisualStyleBackColor = false;
            this.button_ColorS7.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS6
            // 
            this.button_ColorS6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS6.Location = new System.Drawing.Point(157, 135);
            this.button_ColorS6.Name = "button_ColorS6";
            this.button_ColorS6.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS6.TabIndex = 14;
            this.button_ColorS6.UseVisualStyleBackColor = false;
            this.button_ColorS6.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS5
            // 
            this.button_ColorS5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS5.Location = new System.Drawing.Point(157, 118);
            this.button_ColorS5.Name = "button_ColorS5";
            this.button_ColorS5.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS5.TabIndex = 14;
            this.button_ColorS5.UseVisualStyleBackColor = false;
            this.button_ColorS5.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS4
            // 
            this.button_ColorS4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS4.Location = new System.Drawing.Point(157, 101);
            this.button_ColorS4.Name = "button_ColorS4";
            this.button_ColorS4.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS4.TabIndex = 14;
            this.button_ColorS4.UseVisualStyleBackColor = false;
            this.button_ColorS4.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS3
            // 
            this.button_ColorS3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS3.Location = new System.Drawing.Point(157, 84);
            this.button_ColorS3.Name = "button_ColorS3";
            this.button_ColorS3.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS3.TabIndex = 14;
            this.button_ColorS3.UseVisualStyleBackColor = false;
            this.button_ColorS3.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS2
            // 
            this.button_ColorS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS2.Location = new System.Drawing.Point(157, 67);
            this.button_ColorS2.Name = "button_ColorS2";
            this.button_ColorS2.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS2.TabIndex = 14;
            this.button_ColorS2.UseVisualStyleBackColor = false;
            this.button_ColorS2.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS1
            // 
            this.button_ColorS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS1.Location = new System.Drawing.Point(157, 50);
            this.button_ColorS1.Name = "button_ColorS1";
            this.button_ColorS1.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS1.TabIndex = 14;
            this.button_ColorS1.UseVisualStyleBackColor = false;
            this.button_ColorS1.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_ColorS0
            // 
            this.button_ColorS0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_ColorS0.Location = new System.Drawing.Point(157, 33);
            this.button_ColorS0.Name = "button_ColorS0";
            this.button_ColorS0.Size = new System.Drawing.Size(16, 17);
            this.button_ColorS0.TabIndex = 14;
            this.button_ColorS0.UseVisualStyleBackColor = false;
            this.button_ColorS0.Click += new System.EventHandler(this.button_ColorS_Click);
            // 
            // button_Color0
            // 
            this.button_Color0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button_Color0.Location = new System.Drawing.Point(157, 216);
            this.button_Color0.Name = "button_Color0";
            this.button_Color0.Size = new System.Drawing.Size(16, 17);
            this.button_Color0.TabIndex = 14;
            this.button_Color0.UseVisualStyleBackColor = false;
            this.button_Color0.Click += new System.EventHandler(this.button_Color_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(20, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox25
            // 
            this.checkBox25.AutoSize = true;
            this.checkBox25.Location = new System.Drawing.Point(20, 86);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(15, 14);
            this.checkBox25.TabIndex = 13;
            this.checkBox25.UseVisualStyleBackColor = true;
            this.checkBox25.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(37, 52);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(15, 14);
            this.checkBox10.TabIndex = 13;
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // button_Start
            // 
            this.button_Start.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_Start.Location = new System.Drawing.Point(115, 496);
            this.button_Start.Margin = new System.Windows.Forms.Padding(0);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(58, 30);
            this.button_Start.TabIndex = 11;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Visible = false;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // checkBox40
            // 
            this.checkBox40.AutoSize = true;
            this.checkBox40.Location = new System.Drawing.Point(139, 103);
            this.checkBox40.Name = "checkBox40";
            this.checkBox40.Size = new System.Drawing.Size(15, 14);
            this.checkBox40.TabIndex = 13;
            this.checkBox40.UseVisualStyleBackColor = true;
            this.checkBox40.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(71, 35);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBox0
            // 
            this.textBox0.Location = new System.Drawing.Point(20, 213);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(133, 21);
            this.textBox0.TabIndex = 10;
            this.textBox0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(73, 191);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 12);
            this.label23.TabIndex = 9;
            this.label23.Text = "sin( 2πx /";
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(20, 69);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(15, 14);
            this.checkBox17.TabIndex = 13;
            this.checkBox17.UseVisualStyleBackColor = true;
            this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = ")";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(19, 191);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(55, 12);
            this.label30.TabIndex = 9;
            this.label30.Text = "sin(x) →";
            // 
            // checkBox48
            // 
            this.checkBox48.AutoSize = true;
            this.checkBox48.Location = new System.Drawing.Point(139, 120);
            this.checkBox48.Name = "checkBox48";
            this.checkBox48.Size = new System.Drawing.Size(15, 14);
            this.checkBox48.TabIndex = 13;
            this.checkBox48.UseVisualStyleBackColor = true;
            this.checkBox48.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox47
            // 
            this.checkBox47.AutoSize = true;
            this.checkBox47.Location = new System.Drawing.Point(122, 120);
            this.checkBox47.Name = "checkBox47";
            this.checkBox47.Size = new System.Drawing.Size(15, 14);
            this.checkBox47.TabIndex = 13;
            this.checkBox47.UseVisualStyleBackColor = true;
            this.checkBox47.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox46
            // 
            this.checkBox46.AutoSize = true;
            this.checkBox46.Location = new System.Drawing.Point(105, 120);
            this.checkBox46.Name = "checkBox46";
            this.checkBox46.Size = new System.Drawing.Size(15, 14);
            this.checkBox46.TabIndex = 13;
            this.checkBox46.UseVisualStyleBackColor = true;
            this.checkBox46.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox45
            // 
            this.checkBox45.AutoSize = true;
            this.checkBox45.Location = new System.Drawing.Point(88, 120);
            this.checkBox45.Name = "checkBox45";
            this.checkBox45.Size = new System.Drawing.Size(15, 14);
            this.checkBox45.TabIndex = 13;
            this.checkBox45.UseVisualStyleBackColor = true;
            this.checkBox45.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox44
            // 
            this.checkBox44.AutoSize = true;
            this.checkBox44.Location = new System.Drawing.Point(71, 120);
            this.checkBox44.Name = "checkBox44";
            this.checkBox44.Size = new System.Drawing.Size(15, 14);
            this.checkBox44.TabIndex = 13;
            this.checkBox44.UseVisualStyleBackColor = true;
            this.checkBox44.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox43
            // 
            this.checkBox43.AutoSize = true;
            this.checkBox43.Location = new System.Drawing.Point(54, 120);
            this.checkBox43.Name = "checkBox43";
            this.checkBox43.Size = new System.Drawing.Size(15, 14);
            this.checkBox43.TabIndex = 13;
            this.checkBox43.UseVisualStyleBackColor = true;
            this.checkBox43.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox42
            // 
            this.checkBox42.AutoSize = true;
            this.checkBox42.Location = new System.Drawing.Point(37, 120);
            this.checkBox42.Name = "checkBox42";
            this.checkBox42.Size = new System.Drawing.Size(15, 14);
            this.checkBox42.TabIndex = 13;
            this.checkBox42.UseVisualStyleBackColor = true;
            this.checkBox42.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox64
            // 
            this.checkBox64.AutoSize = true;
            this.checkBox64.Location = new System.Drawing.Point(139, 154);
            this.checkBox64.Name = "checkBox64";
            this.checkBox64.Size = new System.Drawing.Size(15, 14);
            this.checkBox64.TabIndex = 13;
            this.checkBox64.UseVisualStyleBackColor = true;
            this.checkBox64.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox63
            // 
            this.checkBox63.AutoSize = true;
            this.checkBox63.Location = new System.Drawing.Point(122, 154);
            this.checkBox63.Name = "checkBox63";
            this.checkBox63.Size = new System.Drawing.Size(15, 14);
            this.checkBox63.TabIndex = 13;
            this.checkBox63.UseVisualStyleBackColor = true;
            this.checkBox63.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox62
            // 
            this.checkBox62.AutoSize = true;
            this.checkBox62.Location = new System.Drawing.Point(105, 154);
            this.checkBox62.Name = "checkBox62";
            this.checkBox62.Size = new System.Drawing.Size(15, 14);
            this.checkBox62.TabIndex = 13;
            this.checkBox62.UseVisualStyleBackColor = true;
            this.checkBox62.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox61
            // 
            this.checkBox61.AutoSize = true;
            this.checkBox61.Location = new System.Drawing.Point(88, 154);
            this.checkBox61.Name = "checkBox61";
            this.checkBox61.Size = new System.Drawing.Size(15, 14);
            this.checkBox61.TabIndex = 13;
            this.checkBox61.UseVisualStyleBackColor = true;
            this.checkBox61.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox60
            // 
            this.checkBox60.AutoSize = true;
            this.checkBox60.Location = new System.Drawing.Point(71, 154);
            this.checkBox60.Name = "checkBox60";
            this.checkBox60.Size = new System.Drawing.Size(15, 14);
            this.checkBox60.TabIndex = 13;
            this.checkBox60.UseVisualStyleBackColor = true;
            this.checkBox60.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox59
            // 
            this.checkBox59.AutoSize = true;
            this.checkBox59.Location = new System.Drawing.Point(54, 154);
            this.checkBox59.Name = "checkBox59";
            this.checkBox59.Size = new System.Drawing.Size(15, 14);
            this.checkBox59.TabIndex = 13;
            this.checkBox59.UseVisualStyleBackColor = true;
            this.checkBox59.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox58
            // 
            this.checkBox58.AutoSize = true;
            this.checkBox58.Location = new System.Drawing.Point(37, 154);
            this.checkBox58.Name = "checkBox58";
            this.checkBox58.Size = new System.Drawing.Size(15, 14);
            this.checkBox58.TabIndex = 13;
            this.checkBox58.UseVisualStyleBackColor = true;
            this.checkBox58.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox57
            // 
            this.checkBox57.AutoSize = true;
            this.checkBox57.Location = new System.Drawing.Point(20, 154);
            this.checkBox57.Name = "checkBox57";
            this.checkBox57.Size = new System.Drawing.Size(15, 14);
            this.checkBox57.TabIndex = 13;
            this.checkBox57.UseVisualStyleBackColor = true;
            this.checkBox57.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox56
            // 
            this.checkBox56.AutoSize = true;
            this.checkBox56.Location = new System.Drawing.Point(139, 137);
            this.checkBox56.Name = "checkBox56";
            this.checkBox56.Size = new System.Drawing.Size(15, 14);
            this.checkBox56.TabIndex = 13;
            this.checkBox56.UseVisualStyleBackColor = true;
            this.checkBox56.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox55
            // 
            this.checkBox55.AutoSize = true;
            this.checkBox55.Location = new System.Drawing.Point(122, 137);
            this.checkBox55.Name = "checkBox55";
            this.checkBox55.Size = new System.Drawing.Size(15, 14);
            this.checkBox55.TabIndex = 13;
            this.checkBox55.UseVisualStyleBackColor = true;
            this.checkBox55.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox54
            // 
            this.checkBox54.AutoSize = true;
            this.checkBox54.Location = new System.Drawing.Point(105, 137);
            this.checkBox54.Name = "checkBox54";
            this.checkBox54.Size = new System.Drawing.Size(15, 14);
            this.checkBox54.TabIndex = 13;
            this.checkBox54.UseVisualStyleBackColor = true;
            this.checkBox54.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox53
            // 
            this.checkBox53.AutoSize = true;
            this.checkBox53.Location = new System.Drawing.Point(88, 137);
            this.checkBox53.Name = "checkBox53";
            this.checkBox53.Size = new System.Drawing.Size(15, 14);
            this.checkBox53.TabIndex = 13;
            this.checkBox53.UseVisualStyleBackColor = true;
            this.checkBox53.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox52
            // 
            this.checkBox52.AutoSize = true;
            this.checkBox52.Location = new System.Drawing.Point(71, 137);
            this.checkBox52.Name = "checkBox52";
            this.checkBox52.Size = new System.Drawing.Size(15, 14);
            this.checkBox52.TabIndex = 13;
            this.checkBox52.UseVisualStyleBackColor = true;
            this.checkBox52.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox51
            // 
            this.checkBox51.AutoSize = true;
            this.checkBox51.Location = new System.Drawing.Point(54, 137);
            this.checkBox51.Name = "checkBox51";
            this.checkBox51.Size = new System.Drawing.Size(15, 14);
            this.checkBox51.TabIndex = 13;
            this.checkBox51.UseVisualStyleBackColor = true;
            this.checkBox51.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox50
            // 
            this.checkBox50.AutoSize = true;
            this.checkBox50.Location = new System.Drawing.Point(37, 137);
            this.checkBox50.Name = "checkBox50";
            this.checkBox50.Size = new System.Drawing.Size(15, 14);
            this.checkBox50.TabIndex = 13;
            this.checkBox50.UseVisualStyleBackColor = true;
            this.checkBox50.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox49
            // 
            this.checkBox49.AutoSize = true;
            this.checkBox49.Location = new System.Drawing.Point(20, 137);
            this.checkBox49.Name = "checkBox49";
            this.checkBox49.Size = new System.Drawing.Size(15, 14);
            this.checkBox49.TabIndex = 13;
            this.checkBox49.UseVisualStyleBackColor = true;
            this.checkBox49.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox41
            // 
            this.checkBox41.AutoSize = true;
            this.checkBox41.Location = new System.Drawing.Point(20, 120);
            this.checkBox41.Name = "checkBox41";
            this.checkBox41.Size = new System.Drawing.Size(15, 14);
            this.checkBox41.TabIndex = 13;
            this.checkBox41.UseVisualStyleBackColor = true;
            this.checkBox41.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox33
            // 
            this.checkBox33.AutoSize = true;
            this.checkBox33.Location = new System.Drawing.Point(20, 103);
            this.checkBox33.Name = "checkBox33";
            this.checkBox33.Size = new System.Drawing.Size(15, 14);
            this.checkBox33.TabIndex = 13;
            this.checkBox33.UseVisualStyleBackColor = true;
            this.checkBox33.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox32
            // 
            this.checkBox32.AutoSize = true;
            this.checkBox32.Location = new System.Drawing.Point(139, 86);
            this.checkBox32.Name = "checkBox32";
            this.checkBox32.Size = new System.Drawing.Size(15, 14);
            this.checkBox32.TabIndex = 13;
            this.checkBox32.UseVisualStyleBackColor = true;
            this.checkBox32.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(54, 35);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(37, 69);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(15, 14);
            this.checkBox18.TabIndex = 13;
            this.checkBox18.UseVisualStyleBackColor = true;
            this.checkBox18.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox24
            // 
            this.checkBox24.AutoSize = true;
            this.checkBox24.Location = new System.Drawing.Point(139, 69);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(15, 14);
            this.checkBox24.TabIndex = 13;
            this.checkBox24.UseVisualStyleBackColor = true;
            this.checkBox24.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(20, 52);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(15, 14);
            this.checkBox9.TabIndex = 13;
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 236);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(54, 52);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(15, 14);
            this.checkBox11.TabIndex = 13;
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(20, 259);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 21);
            this.textBox2.TabIndex = 10;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(139, 52);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(15, 14);
            this.checkBox16.TabIndex = 13;
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(20, 282);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(133, 21);
            this.textBox3.TabIndex = 10;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(37, 35);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(20, 374);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(133, 21);
            this.textBox7.TabIndex = 10;
            this.textBox7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(20, 351);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(133, 21);
            this.textBox6.TabIndex = 10;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(20, 328);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(133, 21);
            this.textBox5.TabIndex = 10;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(20, 305);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(133, 21);
            this.textBox4.TabIndex = 10;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBox26
            // 
            this.checkBox26.AutoSize = true;
            this.checkBox26.Location = new System.Drawing.Point(37, 86);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(15, 14);
            this.checkBox26.TabIndex = 13;
            this.checkBox26.UseVisualStyleBackColor = true;
            this.checkBox26.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBox_resolution
            // 
            this.textBox_resolution.Location = new System.Drawing.Point(141, 188);
            this.textBox_resolution.Name = "textBox_resolution";
            this.textBox_resolution.Size = new System.Drawing.Size(28, 21);
            this.textBox_resolution.TabIndex = 12;
            this.textBox_resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.ForeColor = System.Drawing.Color.White;
            this.checkBox8.Location = new System.Drawing.Point(139, 35);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(71, 52);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(15, 14);
            this.checkBox12.TabIndex = 13;
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox39
            // 
            this.checkBox39.AutoSize = true;
            this.checkBox39.Location = new System.Drawing.Point(122, 103);
            this.checkBox39.Name = "checkBox39";
            this.checkBox39.Size = new System.Drawing.Size(15, 14);
            this.checkBox39.TabIndex = 13;
            this.checkBox39.UseVisualStyleBackColor = true;
            this.checkBox39.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox34
            // 
            this.checkBox34.AutoSize = true;
            this.checkBox34.Location = new System.Drawing.Point(37, 103);
            this.checkBox34.Name = "checkBox34";
            this.checkBox34.Size = new System.Drawing.Size(15, 14);
            this.checkBox34.TabIndex = 13;
            this.checkBox34.UseVisualStyleBackColor = true;
            this.checkBox34.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox31
            // 
            this.checkBox31.AutoSize = true;
            this.checkBox31.Location = new System.Drawing.Point(122, 86);
            this.checkBox31.Name = "checkBox31";
            this.checkBox31.Size = new System.Drawing.Size(15, 14);
            this.checkBox31.TabIndex = 13;
            this.checkBox31.UseVisualStyleBackColor = true;
            this.checkBox31.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(54, 69);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(15, 14);
            this.checkBox19.TabIndex = 13;
            this.checkBox19.UseVisualStyleBackColor = true;
            this.checkBox19.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(122, 69);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(15, 14);
            this.checkBox23.TabIndex = 13;
            this.checkBox23.UseVisualStyleBackColor = true;
            this.checkBox23.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox20
            // 
            this.checkBox20.AutoSize = true;
            this.checkBox20.Location = new System.Drawing.Point(71, 69);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(15, 14);
            this.checkBox20.TabIndex = 13;
            this.checkBox20.UseVisualStyleBackColor = true;
            this.checkBox20.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(122, 52);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(15, 14);
            this.checkBox15.TabIndex = 13;
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(141, 15);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(11, 12);
            this.label28.TabIndex = 9;
            this.label28.Text = "7";
            // 
            // checkBox27
            // 
            this.checkBox27.AutoSize = true;
            this.checkBox27.Location = new System.Drawing.Point(54, 86);
            this.checkBox27.Name = "checkBox27";
            this.checkBox27.Size = new System.Drawing.Size(15, 14);
            this.checkBox27.TabIndex = 13;
            this.checkBox27.UseVisualStyleBackColor = true;
            this.checkBox27.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(122, 35);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 13;
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(90, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "4";
            // 
            // checkBox28
            // 
            this.checkBox28.AutoSize = true;
            this.checkBox28.Location = new System.Drawing.Point(71, 86);
            this.checkBox28.Name = "checkBox28";
            this.checkBox28.Size = new System.Drawing.Size(15, 14);
            this.checkBox28.TabIndex = 13;
            this.checkBox28.UseVisualStyleBackColor = true;
            this.checkBox28.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox38
            // 
            this.checkBox38.AutoSize = true;
            this.checkBox38.Location = new System.Drawing.Point(105, 103);
            this.checkBox38.Name = "checkBox38";
            this.checkBox38.Size = new System.Drawing.Size(15, 14);
            this.checkBox38.TabIndex = 13;
            this.checkBox38.UseVisualStyleBackColor = true;
            this.checkBox38.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(124, 15);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(11, 12);
            this.label27.TabIndex = 9;
            this.label27.Text = "6";
            // 
            // checkBox35
            // 
            this.checkBox35.AutoSize = true;
            this.checkBox35.Location = new System.Drawing.Point(54, 103);
            this.checkBox35.Name = "checkBox35";
            this.checkBox35.Size = new System.Drawing.Size(15, 14);
            this.checkBox35.TabIndex = 13;
            this.checkBox35.UseVisualStyleBackColor = true;
            this.checkBox35.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox30
            // 
            this.checkBox30.AutoSize = true;
            this.checkBox30.Location = new System.Drawing.Point(105, 86);
            this.checkBox30.Name = "checkBox30";
            this.checkBox30.Size = new System.Drawing.Size(15, 14);
            this.checkBox30.TabIndex = 13;
            this.checkBox30.UseVisualStyleBackColor = true;
            this.checkBox30.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(73, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 9;
            this.label16.Text = "3";
            // 
            // checkBox36
            // 
            this.checkBox36.AutoSize = true;
            this.checkBox36.Location = new System.Drawing.Point(71, 103);
            this.checkBox36.Name = "checkBox36";
            this.checkBox36.Size = new System.Drawing.Size(15, 14);
            this.checkBox36.TabIndex = 13;
            this.checkBox36.UseVisualStyleBackColor = true;
            this.checkBox36.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(105, 69);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(15, 14);
            this.checkBox22.TabIndex = 13;
            this.checkBox22.UseVisualStyleBackColor = true;
            this.checkBox22.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(107, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 12);
            this.label26.TabIndex = 9;
            this.label26.Text = "5";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(88, 35);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 13;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Location = new System.Drawing.Point(105, 52);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(15, 14);
            this.checkBox14.TabIndex = 13;
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(56, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 9;
            this.label15.Text = "2";
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(88, 52);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(15, 14);
            this.checkBox13.TabIndex = 13;
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(105, 35);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 13;
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "1";
            // 
            // checkBox21
            // 
            this.checkBox21.AutoSize = true;
            this.checkBox21.Location = new System.Drawing.Point(88, 69);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(15, 14);
            this.checkBox21.TabIndex = 13;
            this.checkBox21.UseVisualStyleBackColor = true;
            this.checkBox21.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox37
            // 
            this.checkBox37.AutoSize = true;
            this.checkBox37.Location = new System.Drawing.Point(88, 103);
            this.checkBox37.Name = "checkBox37";
            this.checkBox37.Size = new System.Drawing.Size(15, 14);
            this.checkBox37.TabIndex = 13;
            this.checkBox37.UseVisualStyleBackColor = true;
            this.checkBox37.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "dispcount";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "tick(ms)";
            this.label2.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "A0";
            // 
            // checkBox29
            // 
            this.checkBox29.AutoSize = true;
            this.checkBox29.Location = new System.Drawing.Point(88, 86);
            this.checkBox29.Name = "checkBox29";
            this.checkBox29.Size = new System.Drawing.Size(15, 14);
            this.checkBox29.TabIndex = 13;
            this.checkBox29.UseVisualStyleBackColor = true;
            this.checkBox29.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button_RegEx);
            this.splitContainer2.Size = new System.Drawing.Size(1207, 584);
            this.splitContainer2.SplitterDistance = 1058;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textBox_UserTitle);
            this.splitContainer3.Panel1.Controls.Add(this.textBox_MousePoint);
            this.splitContainer3.Panel1.Controls.Add(this.chart1);
            this.splitContainer3.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer3.Panel2.Controls.Add(this.textBox_Cmd);
            this.splitContainer3.Size = new System.Drawing.Size(1058, 584);
            this.splitContainer3.SplitterDistance = 555;
            this.splitContainer3.TabIndex = 2;
            // 
            // textBox_MousePoint
            // 
            this.textBox_MousePoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_MousePoint.Location = new System.Drawing.Point(4, 4);
            this.textBox_MousePoint.Name = "textBox_MousePoint";
            this.textBox_MousePoint.Size = new System.Drawing.Size(32, 14);
            this.textBox_MousePoint.TabIndex = 18;
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(3, 0);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(1055, 555);
            this.chart1.TabIndex = 19;
            this.chart1.Text = "chart1";
            title7.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title7.Name = "Title1";
            this.chart1.Titles.Add(title7);
            this.chart1.SizeChanged += new System.EventHandler(this.chart1_SizeChanged);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 555);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // textBox_Cmd
            // 
            this.textBox_Cmd.BackColor = System.Drawing.Color.White;
            this.textBox_Cmd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Cmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Cmd.Location = new System.Drawing.Point(0, 0);
            this.textBox_Cmd.Multiline = true;
            this.textBox_Cmd.Name = "textBox_Cmd";
            this.textBox_Cmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Cmd.Size = new System.Drawing.Size(1058, 25);
            this.textBox_Cmd.TabIndex = 0;
            this.textBox_Cmd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Cmd_KeyPress);
            // 
            // button_RegEx
            // 
            this.button_RegEx.ForeColor = System.Drawing.Color.Black;
            this.button_RegEx.Location = new System.Drawing.Point(76, 383);
            this.button_RegEx.Name = "button_RegEx";
            this.button_RegEx.Size = new System.Drawing.Size(57, 22);
            this.button_RegEx.TabIndex = 11;
            this.button_RegEx.Text = "RegEx";
            this.button_RegEx.UseVisualStyleBackColor = true;
            this.button_RegEx.Click += new System.EventHandler(this.button_RegEx_Click);
            // 
            // textBox_UserTitle
            // 
            this.textBox_UserTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_UserTitle.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UserTitle.Location = new System.Drawing.Point(374, 16);
            this.textBox_UserTitle.Name = "textBox_UserTitle";
            this.textBox_UserTitle.ReadOnly = true;
            this.textBox_UserTitle.Size = new System.Drawing.Size(10, 13);
            this.textBox_UserTitle.TabIndex = 2;
            this.textBox_UserTitle.Text = "T";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1398, 608);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Sine Function";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_DrawSpeed)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void clearToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripTextBox toolStriptextBox0;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripTextBox toolStriptextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox checkBox40;
        private System.Windows.Forms.CheckBox checkBox32;
        private System.Windows.Forms.CheckBox checkBox24;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox39;
        private System.Windows.Forms.CheckBox checkBox31;
        private System.Windows.Forms.CheckBox checkBox23;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox38;
        private System.Windows.Forms.CheckBox checkBox30;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox37;
        private System.Windows.Forms.CheckBox checkBox29;
        private System.Windows.Forms.CheckBox checkBox21;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox36;
        private System.Windows.Forms.CheckBox checkBox35;
        private System.Windows.Forms.CheckBox checkBox28;
        private System.Windows.Forms.CheckBox checkBox27;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox34;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox26;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox33;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox25;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_RegEx;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_resolution;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox textBox_Cmd;
        private System.Windows.Forms.Button button_Color3;
        private System.Windows.Forms.Button button_Color2;
        private System.Windows.Forms.Button button_Color1;
        private System.Windows.Forms.Button button_Color0;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_Color4;
        private System.Windows.Forms.Button button_ColorS3;
        private System.Windows.Forms.Button button_ColorS2;
        private System.Windows.Forms.Button button_ColorS1;
        private System.Windows.Forms.Button button_ColorS0;
        private System.Windows.Forms.Button button_ColorS4;
        private System.Windows.Forms.TextBox textBox_dispcount;
        private System.Windows.Forms.TrackBar trackBar_DrawSpeed;
        private System.Windows.Forms.TextBox textBox_DrawTick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_MousePoint;
        private System.Windows.Forms.Button button_Color7;
        private System.Windows.Forms.Button button_Color6;
        private System.Windows.Forms.Button button_Color5;
        private System.Windows.Forms.Button button_ColorS7;
        private System.Windows.Forms.Button button_ColorS6;
        private System.Windows.Forms.Button button_ColorS5;
        private System.Windows.Forms.CheckBox checkBox48;
        private System.Windows.Forms.CheckBox checkBox47;
        private System.Windows.Forms.CheckBox checkBox46;
        private System.Windows.Forms.CheckBox checkBox45;
        private System.Windows.Forms.CheckBox checkBox44;
        private System.Windows.Forms.CheckBox checkBox43;
        private System.Windows.Forms.CheckBox checkBox42;
        private System.Windows.Forms.CheckBox checkBox64;
        private System.Windows.Forms.CheckBox checkBox63;
        private System.Windows.Forms.CheckBox checkBox62;
        private System.Windows.Forms.CheckBox checkBox61;
        private System.Windows.Forms.CheckBox checkBox60;
        private System.Windows.Forms.CheckBox checkBox59;
        private System.Windows.Forms.CheckBox checkBox58;
        private System.Windows.Forms.CheckBox checkBox57;
        private System.Windows.Forms.CheckBox checkBox56;
        private System.Windows.Forms.CheckBox checkBox55;
        private System.Windows.Forms.CheckBox checkBox54;
        private System.Windows.Forms.CheckBox checkBox53;
        private System.Windows.Forms.CheckBox checkBox52;
        private System.Windows.Forms.CheckBox checkBox51;
        private System.Windows.Forms.CheckBox checkBox50;
        private System.Windows.Forms.CheckBox checkBox49;
        private System.Windows.Forms.CheckBox checkBox41;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem initToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem check11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispcount100ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fsinsToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem chartdfv1ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_UserTitle;
    }
}

