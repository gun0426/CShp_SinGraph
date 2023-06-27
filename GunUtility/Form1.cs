using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

/**********************************************
*
*       Search Keyword
*
*  Chart/Chart_Sub_1/Chart_Sub_2
*  Timer
*  Debug
*  Compare
*  Roll
*********************************************/
namespace Chart_Project
{
    public partial class Form1 : Form
    {
        private delegate void Draw_Chart1Delegate(double[] buffer, int size);
        private delegate void DrawChart2Delegate(double[] buffer, int size);
        public const double AXIS_Y_MIN = Double.NaN;
        public const double AXIS_Y_MAX = Double.NaN;
        //     public const double FREQ = 100.0;
        public const double TICK = 100.0;
        public const int PERIOD_COUNT = 50;
        public const int ROW_N = 8;
        public const int COLUMN_N = 8;
        public const int BACK_COLOR_R = 0x20;
        public const int BACK_COLOR_G = 0x20;
        public const int BACK_COLOR_B = 0x20;
        public const int SAMPLE_N = 200;
        public const int DRAW_TICK = 100;
        public const int TEXT_FUNC_N = 8;
        //       public const double PI = 3.1415926535897931;
        double xIndx = 0;
        bool startToggle = false;
        CheckBox[,] checks = new CheckBox[8, 8];
        TextBox[] textFunc = new TextBox[TEXT_FUNC_N];
        Button[] btnColor = new Button[TEXT_FUNC_N];
        Button[] btnColorS = new Button[TEXT_FUNC_N];
        string[] textDisp = new string[TEXT_FUNC_N];
        int[] aAreaSel = new int[20];
        int nSeries = 0;
        int nArea = 0;
        Color[] sColor = new Color[20];
        bool bMinMaxInit = true;
        bool bMouseMoveReady = false;
        string strCmd = "";
        string strThis = "";
        int preIndex = 0;
        bool bChartVertical = false;
        int textFuncIndex = 0;
        bool bClick = false;

        public Form1()
        {
            InitializeComponent();

            //Graphics graphics = CreateGraphics();
            //Pen RefPen = new Pen(Color.Red, 3);

            chart1.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer1.BackColor = Color.FromArgb(BACK_COLOR_R + 20, BACK_COLOR_G + 20, BACK_COLOR_B + 20);
            splitContainer1.Panel1.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer1.Panel2.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer2.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer2.Panel1.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer2.Panel2.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer3.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer3.Panel1.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            splitContainer3.Panel2.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);

            splitContainer1.FixedPanel = FixedPanel.Panel1; // ###GUN           
            splitContainer2.FixedPanel = FixedPanel.Panel2;
            splitContainer3.FixedPanel = FixedPanel.Panel2;
            textBox_Cmd.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            textBox_Cmd.ForeColor = Color.FromArgb(BACK_COLOR_R+100, BACK_COLOR_G+100, BACK_COLOR_B+100);


            textBox_dispcount.Text = Convert.ToString(SAMPLE_N);
            textBox_MousePoint.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            textBox_MousePoint.ForeColor = Color.White;
            textBox_UserTitle.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            textBox_UserTitle.ForeColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B); //Color.White;
            textBox_UserTitle.Text = "";

            /* trackBar */
            //this.TopMost = true;
            //trackBar_DrawSpeed.BringToFront();
            trackBar_DrawSpeed.Minimum = 10;
            trackBar_DrawSpeed.Maximum = 1000;
            textBox_DrawTick.Text = "100";
            trackBar_DrawSpeed.Value = Convert.ToInt32(textBox_DrawTick.Text);
            /* Timer1 @Timer */
            timer1.Interval = Convert.ToInt32(textBox_DrawTick.Text);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Stop();
            /* Chart1 @Chart */
            textBox_resolution.Text = Convert.ToString(PERIOD_COUNT);
            textFunc[0] = textBox0;
            textFunc[1] = textBox1;
            textFunc[2] = textBox2;
            textFunc[3] = textBox3;
            textFunc[4] = textBox4;
            textFunc[5] = textBox5;
            textFunc[6] = textBox6;
            textFunc[7] = textBox7;
            textFunc[0].Text = "";
            textFunc[1].Text = "";
            textFunc[2].Text = "";
            textFunc[3].Text = "";
            textFunc[4].Text = "";
            textFunc[5].Text = "";
            textFunc[6].Text = "";
            textFunc[7].Text = "";

            textDisp[0] = textFunc[0].Text;
            textDisp[1] = textFunc[1].Text;
            textDisp[2] = textFunc[2].Text;
            textDisp[3] = textFunc[3].Text;
            textDisp[4] = textFunc[4].Text;
            textDisp[5] = textFunc[5].Text;
            textDisp[6] = textFunc[6].Text;
            textDisp[7] = textFunc[7].Text;
                        
            checks[0, 0] = checkBox1;
            checks[0, 1] = checkBox2;
            checks[0, 2] = checkBox3;
            checks[0, 3] = checkBox4;
            checks[0, 4] = checkBox5;
            checks[0, 5] = checkBox6;
            checks[0, 6] = checkBox7;
            checks[0, 7] = checkBox8;
            checks[1, 0] = checkBox9;
            checks[1, 1] = checkBox10;
            checks[1, 2] = checkBox11;
            checks[1, 3] = checkBox12;
            checks[1, 4] = checkBox13;
            checks[1, 5] = checkBox14;
            checks[1, 6] = checkBox15;
            checks[1, 7] = checkBox16;
            checks[2, 0] = checkBox17;
            checks[2, 1] = checkBox18;
            checks[2, 2] = checkBox19;
            checks[2, 3] = checkBox20;
            checks[2, 4] = checkBox21;
            checks[2, 5] = checkBox22;
            checks[2, 6] = checkBox23;
            checks[2, 7] = checkBox24;
            checks[3, 0] = checkBox25;
            checks[3, 1] = checkBox26;
            checks[3, 2] = checkBox27;
            checks[3, 3] = checkBox28;
            checks[3, 4] = checkBox29;
            checks[3, 5] = checkBox30;
            checks[3, 6] = checkBox31;
            checks[3, 7] = checkBox32;
            checks[4, 0] = checkBox33;
            checks[4, 1] = checkBox34;
            checks[4, 2] = checkBox35;
            checks[4, 3] = checkBox36;
            checks[4, 4] = checkBox37;
            checks[4, 5] = checkBox38;
            checks[4, 6] = checkBox39;
            checks[4, 7] = checkBox40;
            checks[5, 0] = checkBox41;
            checks[5, 1] = checkBox42;
            checks[5, 2] = checkBox43;
            checks[5, 3] = checkBox44;
            checks[5, 4] = checkBox45;
            checks[5, 5] = checkBox46;
            checks[5, 6] = checkBox47;
            checks[5, 7] = checkBox48;
            checks[6, 0] = checkBox49;
            checks[6, 1] = checkBox50;
            checks[6, 2] = checkBox51;
            checks[6, 3] = checkBox52;
            checks[6, 4] = checkBox53;
            checks[6, 5] = checkBox54;
            checks[6, 6] = checkBox55;
            checks[6, 7] = checkBox56;
            checks[7, 0] = checkBox57;
            checks[7, 1] = checkBox58;
            checks[7, 2] = checkBox59;
            checks[7, 3] = checkBox60;
            checks[7, 4] = checkBox61;
            checks[7, 5] = checkBox62;
            checks[7, 6] = checkBox63;
            checks[7, 7] = checkBox64;

            btnColor[0] = button_Color0;
            btnColor[1] = button_Color1;
            btnColor[2] = button_Color2;
            btnColor[3] = button_Color3;
            btnColor[4] = button_Color4;
            btnColor[5] = button_Color5;
            btnColor[6] = button_Color6;
            btnColor[7] = button_Color7;

            btnColorS[0] = button_ColorS0;
            btnColorS[1] = button_ColorS1;
            btnColorS[2] = button_ColorS2;
            btnColorS[3] = button_ColorS3;
            btnColorS[4] = button_ColorS4;
            btnColorS[5] = button_ColorS5;
            btnColorS[6] = button_ColorS6;
            btnColorS[7] = button_ColorS7;

            Init_Chart1();
        }

        private void Init_Chart1()
        {
            button_ColorS0.BackColor = button_Color0.BackColor;
            button_ColorS1.BackColor = button_Color1.BackColor;
            button_ColorS2.BackColor = button_Color2.BackColor;
            button_ColorS3.BackColor = button_Color3.BackColor;
            button_ColorS4.BackColor = button_Color4.BackColor;
            button_ColorS5.BackColor = button_Color5.BackColor;
            button_ColorS6.BackColor = button_Color6.BackColor;
            button_ColorS7.BackColor = button_Color7.BackColor;

            sColor[0] = button_Color0.BackColor;
            sColor[1] = button_Color1.BackColor;
            sColor[2] = button_Color2.BackColor;
            sColor[3] = button_Color3.BackColor;
            sColor[4] = button_Color4.BackColor;
            sColor[5] = button_Color5.BackColor;
            sColor[6] = button_Color6.BackColor;
            sColor[7] = button_Color7.BackColor;

            checks[0, 0].Checked = true;
            checks[1, 0].Checked = true;
            checks[2, 0].Checked = true;
            checks[3, 0].Checked = true;
            checks[4, 0].Checked = true;
            checks[5, 0].Checked = true;
            checks[6, 0].Checked = true;
            checks[7, 0].Checked = true;
            Set_Chart1();

            double[] item = new double[8];
            item[0] = -3;
            item[1] = -2;
            item[2] = -1;
            item[3] = 0;
            item[4] = 1;
            item[5] = 2;
            item[6] = 3;
            item[7] = 4;

            Draw_Chart1(item, nSeries);
            Draw_Chart1(item, nSeries);  // ###GUN : 최소 두개의 데이타
        }
        private void Set_Chart1()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

            int row, column;
            int vArea = 0;
            int nEmptyCol = 0;

            nSeries = 0;
            for (int i = 0; i < 20; i++)
            {
                aAreaSel[i] = 0;
            }
            for (row = 0; row < ROW_N; row++) // 하나의 행에서 하나의 열에서만 체크 가능 -> #1
            {
                nEmptyCol = 0;
                for (column = 0; column < COLUMN_N; column++)   // 열중에서 선택된 하나(break)가 있다면
                {
                    nEmptyCol++;
                    for (int rowForEmpty = 0; rowForEmpty < ROW_N; rowForEmpty++) // 하나의 열에서 하나도 체크되지 않은 열이 있다면 -> #2
                    {
                        if (checks[rowForEmpty, column].Checked == true)
                        {
                            nEmptyCol--;
                            break;
                        }
                    }

                    if (checks[row, column].Checked == true)
                    {
                        aAreaSel[nSeries] = column - nEmptyCol; // from #2 Area Index에서 제외
                        sColor[nSeries] = btnColor[row].BackColor;
                        nSeries++;
                        vArea |= (0x01 << column);
                        break;  // from #1
                    }
                }
            }

            nArea = Count_SetBit(vArea);
            if (nSeries != 0)
            {
                Set_Area(nArea);

                for (int i = 0; i < nSeries; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[0]);
                            break;
                        case 1:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[1]);
                            break;
                        case 2:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[2]);
                            break;
                        case 3:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[3]);
                            break;
                        case 4:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[4]);
                            break;
                        case 5:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[5]);
                            break;
                        case 6:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[6]);
                            break;
                        case 7:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[7]);
                            break;
                        default:
                            Set_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[7]);
                            break;
                    }
                }
                xIndx = 0;
                bMinMaxInit = true;

                Update_textBox();

                strThis = "";
                //preIndex = 0;
                //textFuncIndex = 0;
            }
        }


        static int Count_SetBit(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        private int Get_SetBit_Index(int vArea, int order)
        {
            int bitIndx = 0;
            int count = 0;

            while (vArea > 0)
            {
                if ((vArea & 1) == 1)
                {
                    if (count == order)
                    {
                        return bitIndx;
                    }
                    count++;
                }
                vArea >>= 1;
                bitIndx++;
            }

            return bitIndx;
        }

        private void Set_Area(int n_area)
        {
            for (int i = 0; i < n_area; i++)
            {
                string strArea = "Chart Area ";
                strArea += Convert.ToString(i);

                chart1.ChartAreas.Add(strArea);

                //chart1.ChartAreas[i].InnerPlotPosition = new System.Windows.Forms.DataVisualization.Charting.ElementPosition(2, -5, 80, 90);    // X, Y, W, H
                //chart1.ChartAreas[i].InnerPlotPosition = new System.Windows.Forms.DataVisualization.Charting.ElementPosition(2, 0, 100, 100);    // X, Y, W, H
                chart1.ChartAreas[i].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas[i].AxisX.Interval = 0.5;
                chart1.ChartAreas[i].AxisY.Interval = 0;
                //chart1.ChartAreas[i].AxisX.IntervalOffset = -1;

                //chart1.ChartAreas[i].AxisX.Title = "PI(π)";
                chart1.ChartAreas[i].AxisY.Title = "Value" + Convert.ToString(i);
                chart1.ChartAreas[i].AxisX.TitleFont = new System.Drawing.Font("Consolas", 9, System.Drawing.FontStyle.Bold); // ###GUN              
                chart1.ChartAreas[i].AxisX.TitleForeColor = Color.White;
                chart1.ChartAreas[i].AxisY.TitleForeColor = Color.White;
                chart1.ChartAreas[i].AxisX.TitleAlignment = StringAlignment.Far; // ###GUN 가운데 -> 오른쪽 끝

                chart1.ChartAreas[i].AxisX.LabelStyle.Format = "0.0";  // "#.##"
                chart1.ChartAreas[i].AxisX.LabelStyle.Enabled = true;
                chart1.ChartAreas[i].AxisX.LabelStyle.Angle = 0;
                chart1.ChartAreas[i].AxisX.LabelStyle.IsEndLabelVisible = false;    // ###GUN!!!
                chart1.ChartAreas[i].AxisY.LabelStyle.Format = "0.00";  // ###GUN
                chart1.ChartAreas[i].AxisX.LabelStyle.ForeColor = Color.White;
                chart1.ChartAreas[i].AxisY.LabelStyle.ForeColor = Color.White;
                //chart1.ChartAreas[i].AxisX.LabelStyle.Font          = new System.Drawing.Font("Trebuchet MS", 15, System.Drawing.FontStyle.Bold);
                //chart1.ChartAreas[i].AxisY.LabelStyle.Font          = new System.Drawing.Font("Trebuchet MS", 15, System.Drawing.FontStyle.Bold);

                chart1.ChartAreas[i].AxisX.LineColor = Color.FromArgb(150, 150, 150);
                chart1.ChartAreas[i].AxisY.LineColor = Color.FromArgb(150, 150, 150);

                chart1.ChartAreas[i].AxisX.MajorGrid.Interval = 0;  // ###GUN 0: Auto
                chart1.ChartAreas[i].AxisY.MajorGrid.Interval = 0;
                //chart1.ChartAreas[i].AxisX.MajorGrid.Enabled = true;
                chart1.ChartAreas[i].AxisX.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas[i].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

                chart1.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B); // ###GUN
                chart1.ChartAreas[i].BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
                chart1.ChartAreas[i].BackSecondaryColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);

                chart1.ChartAreas[i].AxisX.MajorTickMark.LineColor = Color.FromArgb(100, 100, 100);    // ###GUN
                chart1.ChartAreas[i].AxisY.MajorTickMark.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisX.MinorTickMark.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisY.MinorTickMark.LineColor = Color.FromArgb(100, 100, 100);

                //chart1.ChartAreas[i].AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Auto;   // X축 이름 회전
                //chart1.ChartAreas[i].AxisX.IsReversed = true;   // ###GUN : 그래프 이동 방향 우에서 좌로
                //chart1.ChartAreas[i].AxisY.IsReversed = true;   // ###GUN : 그래프 이동 방향 위에서 아래로       
                //chart1.ChartAreas[i].AxisY.Minimum = AXIS_Y_MIN;
                //chart1.ChartAreas[i].AxisY.Maximum = AXIS_Y_MAX;
                //chart1.ChartAreas[i].AxisX.Enabled = AxisEnabled.True;
                //chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.True;
                ////chart1.ChartAreas[i].AlignWithChartArea = strArea;
                ////chart1.ChartAreas[i].AlignmentStyle = AreaAlignmentStyles.Position;
                ////chart1.ChartAreas[i].AlignmentOrientation = AreaAlignmentOrientations.Vertical;

                //chart1.ChartAreas[i].CursorX.IsUserSelectionEnabled = true;
                //chart1.ChartAreas[i].CursorX.AutoScroll = true;
                //chart1.ChartAreas[i].CursorY.AutoScroll = true;
                chart1.ChartAreas[i].CursorX.LineColor = Color.Red;
                chart1.ChartAreas[i].CursorY.LineColor = Color.Red;
                chart1.ChartAreas[i].CursorX.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas[i].CursorY.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas[i].CursorX.Interval = 0;  // ###GUN
                chart1.ChartAreas[i].CursorY.Interval = 0;

                chart1.ChartAreas[i].AxisX.Title = "PI(π)";
            }
            //chart1.ChartAreas[n_area - 1].AxisX.Title = "PI(π)";

            // ###GUN En:4 x 1, Dis:2 x 2
            if (bChartVertical == true)
            {
                float currentHeight = 0;
                foreach (var itm in chart1.ChartAreas)
                {
                    itm.Position.Height = 100 / chart1.ChartAreas.Count; // Note: the valus are in percenteges and not absolute pixels
                    itm.Position.Y = currentHeight;
                    itm.Position.X = 5;
                    itm.Position.Width = 95;
                    currentHeight += 100 / chart1.ChartAreas.Count;
                }
            }
        }



        private void Set_Series(int series_idx, int area_idx, int marker_size, ChartDashStyle dash, Color color)
        {
            string strSeries = "Series ";
            strSeries += Convert.ToString(series_idx);
            chart1.Series.Add(strSeries);
            string strArea = "Chart Area ";
            strArea += Convert.ToString(area_idx);
            chart1.Series[series_idx].ChartArea = strArea;
            chart1.Series[series_idx].ChartType = SeriesChartType.Line;
            chart1.Series[series_idx].XValueType = ChartValueType.Double;
            chart1.Series[series_idx].YValueType = ChartValueType.Double;
            chart1.Series[series_idx].MarkerSize = marker_size;
            chart1.Series[series_idx].MarkerStyle = MarkerStyle.None; //MarkerStyle.Circle;    //MarkerStyle.None;    // ###GUN
            chart1.Series[series_idx].BorderWidth = 1;
            chart1.Series[series_idx].BorderDashStyle = dash;
            chart1.Series[series_idx].Color = color;
            chart1.Series[series_idx].IsVisibleInLegend = false;
        }

        private void Draw_Chart1(double[] buffer, int size)
        {
            if (chart1.InvokeRequired)
            {
                Draw_Chart1Delegate del = new Draw_Chart1Delegate(Draw_Chart1);
                chart1.Invoke(del, new object[] { buffer, size });
            }
            else
            {
                for (int i = 0; i < nSeries; i++)
                {
                    double yData = buffer[i];
                    double xData = 2 * xIndx / PERIOD_COUNT;  // (2*pi/PERIOD_COUNT) * xIndx
                    chart1.Series[i].Points.AddXY(xData, yData);

                    if (bMinMaxInit == true)
                    {
                        chart1.ChartAreas[aAreaSel[i]].AxisX.Minimum = 0.0;
                        chart1.ChartAreas[aAreaSel[i]].AxisX.Maximum = 0.00001;
                    }
                    //double delta = chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum - chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum;
                    if (yData < chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum)
                    {
                        chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum = yData;// - delta * 0.2;
                    }
                    if (yData > chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum)
                    {
                        chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum = yData;// + delta * 1.2
                    }

                    if (chart1.Series[i].Points.Count > Convert.ToInt32(textBox_dispcount.Text))
                    {
                        for (int j = 0; j < chart1.Series[i].Points.Count - Convert.ToInt32(textBox_dispcount.Text); j++)
                            chart1.Series[i].Points.RemoveAt(0);
                    }
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Minimum = chart1.Series[i].Points[0].XValue;
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Maximum = xData;
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Interval = 0.5 * ((chart1.Series[i].Points.Count / 300)+1);
                }
                bMinMaxInit = false;
                xIndx++;
            }
        }

        /* 
         * 3sin(2x+pi/4) + x^2 + 10x+ 2 
         * -> 3*Sin(2*x+PI/4)+x*x+10*x+2
         * 
         * 
         */
        private double Calc_StrMath(string math)
        {
            string name = math;


            //Match mcChar = Regex.Match(name, @"[^sincostanx]");

            if (name == "")
            {
                return 0;
            }
            /* " " -> "" */
            name = name.Replace(" ", "");

            /* x^2 -> x * x */
            name = name.Replace("^2", "*x");   
            int i = 1;
            /* 10x -> 10 * x */
            foreach (Match match in Regex.Matches(name, @"\d[x|\(]", RegexOptions.IgnoreCase))//, TimeSpan.FromSeconds(1)))
            {
                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                name = name.Insert(match.Index + i++, "*");
            }

            /* sin, COS, pi -> Sin, Cos, PI */
            name = Regex.Replace(name, "sin", "Sin", RegexOptions.IgnoreCase);
            name = Regex.Replace(name, "cos", "Cos", RegexOptions.IgnoreCase);
            name = Regex.Replace(name, "tan", "Tan", RegexOptions.IgnoreCase);
            name = Regex.Replace(name, "pi", "PI", RegexOptions.IgnoreCase);

            /* 
             * x -> 2*PI*xIndx/samples (Sin함수)
             * x -> xIndx (일반다항식)
             */
            if ((name.IndexOf("Sin") != -1) || (name.IndexOf("Cos") != -1) || (name.IndexOf("Tan") != -1))
            {
                name = name.Replace("x", "2*PI*x/" + textBox_resolution.Text);
            }
            name = name.Replace("x", Convert.ToString(xIndx));

            /* 12Sin -> 12*Sin */
            i = 1;
            /*  MatchCollection mc = Regex.Matches(name, @"\d(Sin|Cos)", RegexOptions.None, TimeSpan.FromSeconds(1));
            foreach (Match match in mc) */
            foreach (Match match in Regex.Matches(name, @"\d(Sin|Cos|Tan)", RegexOptions.None, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                name = name.Insert(match.Index + i++, "*");
            }

            MatchCollection mc = Regex.Matches(name, @"(Sin|Cos|Tan)\([^\(]+\)", RegexOptions.None, TimeSpan.FromSeconds(1));
            DataTable dt = new DataTable();
            string strIn;
            double dblIn;
            double dblSin;
            for (int j = 0; j < mc.Count; j++)
            {
                 strIn = mc[mc.Count - j - 1].Value.Substring(mc[mc.Count - j - 1].Value.IndexOf("(") + 1, mc[mc.Count - j - 1].Value.IndexOf(")") - 1 - mc[mc.Count - j - 1].Value.IndexOf("("));
                strIn = strIn.Replace("PI", "3.1415926535897931");
                
                 dblIn = Convert.ToDouble(dt.Compute(strIn, ""));

                 dblSin = 0;
                if (mc[mc.Count - j - 1].Value.IndexOf("Sin") != -1)
                {
                    dblSin = Math.Sin(dblIn);
                }
                if (mc[mc.Count - j - 1].Value.IndexOf("Cos") != -1)
                {
                    dblSin = Math.Cos(dblIn);
                }
                if (mc[mc.Count - j - 1].Value.IndexOf("Tan") != -1)
                {
                    dblSin = Math.Tan(dblIn);
                }
                //name = name.Replace(mc[mc.Count - j - 1].Value, "");
                name = name.Remove(mc[mc.Count - j - 1].Index, mc[mc.Count - j - 1].Length);
                name = name.Insert(mc[mc.Count - j - 1].Index, Convert.ToString(dblSin));
            }
          
            Match mmm = Regex.Match(name, @"[^\d\.\+\-\*\/Ee]");
            if (mmm.Value == "")
            {
                name = name.TrimEnd('+', '-', '*', '/');   // 0.1234+ -> 0.1234
                double Q = Convert.ToDouble(dt.Compute(name, ""));
                //Q = Math.Round(Q, 2);     // 소수세짜리 반올림 ###GUN
                //Q = Math.Ceiling(Q);      // 소수첫짜리 올림
                //Q = Math.Truncate(Q);     // 소수첫짜리 버림
                //Q = Math.Round(Q, 1);     // 소수둘째자리 반올림

                return Q;
            }
            else
            {
                Console.WriteLine("Calc 0");
                return 0;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] item = new double[10];

            int indx = 0;

            for (int row = 0; row < ROW_N; row++)
            {
                for (int column = 0; column < COLUMN_N; column++)
                {
                    if (checks[row, column].Checked == true)
                    {
                        item[indx++] = Calc_StrMath(textDisp[row]);
                        if (indx == nSeries)
                        {
bMouseMoveReady = true;
                            Draw_Chart1(item, nSeries);
                            return;
                        }
                    }
                }
            }
 
        }

 //       private void keyDown(object sender, KeyEventArgs e)
 //       {
 //           if (e.KeyCode == Keys.Enter)
 //           {
 //               Debug.WriteLine("Enter !");
 //               if (textBox1.Text.ToLower() == "sinx")
 //               {
 //                   Debug.WriteLine("sinx !");
 //               }
 //               if (textBox1.Text.ToLower() == "cosx")
 //               {
 //                   Debug.WriteLine("cosx !");
 //               }
 //               textBox1.Text = "";
 //           }
 //           return;
 //       }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ChartArea> Areas = new List<ChartArea>();
            int numberOfAreas = 5;
            for (int k = 1; k <= numberOfAreas; k++)
            {
                var S1 = new Series();
                chart1.Series.Add(S1);
                S1.Name = k.ToString();
                for (int j = 0; j < 100; j += 10) S1.Points.AddXY(j, j / 10);
                S1.Color = Color.Transparent;
                Areas.Add(new ChartArea(k.ToString()));
                chart1.ChartAreas.Add(Areas[k - 1]);
                S1.ChartArea = k.ToString();
                chart1.ChartAreas[k - 1].AlignWithChartArea = chart1.ChartAreas[k - 1].Name;
                chart1.ChartAreas[k - 1].AlignmentStyle = AreaAlignmentStyles.AxesView;
                chart1.ChartAreas[k - 1].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
            }
            float currentHeight = 0;
            foreach (var itm in Areas)
            {
                itm.Position.Height = 100 / numberOfAreas;
                itm.Position.Y = currentHeight;
                itm.Position.X = 5;
                itm.Position.Width = 50;
                currentHeight += 100 / numberOfAreas;
            }
        }

        private void button_RegEx_Click(object sender, EventArgs e)
        {
            string targetStr = "7,873,330원(문자열 추출 테스트)";
            string tempStr = Regex.Replace(targetStr, @"\D", "");
            int rsInt = int.Parse(tempStr);
            string input = "cos(x+pi/2)";
            string pattern = @"\d*\**(sin|cos|tan)\(\d*x\+pi\/*\d*\)\+*\d*";
            string result = Regex.Match(input, pattern).Value;
            Regex regex = new Regex(@"\/([a-zA-Z]+)\s([a-zA-Z0-9]+)");
            GroupCollection groups = regex.Match("/command content123").Groups;
            int groupCount = groups.Count;
            string strExample = "<12> GameObject [23]  ";
            string pattern1 = @"[\s\[\{\(\<]+" + @"([0-9]+)" + @"[\s\]\}\)\>]+";
            string replacement = @"($1)";
            string result1 = Regex.Replace(strExample, pattern1, replacement);
            string strExample1 = "<12> GameObject [23]  ";
            string pattern2 = @"([\s\[\{\(\<]+)" + @"([0-9]+)" + @"([\s\]\}\)\>]+)";
            string replacement2 = @"$1X$3";
            string result3 = Regex.Replace(strExample1, pattern2, replacement2);
            while (true) ;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            xIndx = 0;

            if (startToggle == false)
            {
                Set_Chart1();
                timer1.Interval = Convert.ToInt32(textBox_DrawTick.Text);
                timer1.Start();
                button_Start.Text = "Stop";
                startToggle = true;
                bMouseMoveReady = true;
            }
            else
            {
                timer1.Stop();
                button_Start.Text = "Start";
                startToggle = false;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            for (int i = 0; i <= ROW_N * COLUMN_N; i++)
            {
                if (cb.Name == "checkBox" + Convert.ToString(i + 1))
                {
                    if (cb.Checked == true)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (j != i % 8)
                                checks[i / 8, j].Checked = false;
                        }
                    }
                }
            }
            Set_Chart1();
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
bMouseMoveReady = false;
                for (int i = 0; i < TEXT_FUNC_N; i++)
                {
                    if (btn.Name == "button_Color" + Convert.ToString(i))
                    {
                        btnColor[i].BackColor = colorDialog1.Color;
                        btnColorS[i].BackColor = colorDialog1.Color;
                        chart1.Series[i].Color = colorDialog1.Color;
                    }
                }
                //Set_Chart1();
            }
        }

        private void button_ColorS_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
bMouseMoveReady = false;
                for (int i = 0; i < TEXT_FUNC_N; i++)
                {
                    if (btn.Name == "button_ColorS" + Convert.ToString(i))
                    {
                        btnColor[i].BackColor = colorDialog1.Color;
                        btnColorS[i].BackColor = colorDialog1.Color;
                        chart1.Series[i].Color = colorDialog1.Color;
                    }
                }
                //Set_Chart1();
            }
        }

        private void textBox_DrawTick_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링             
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리             
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                timer1.Interval = Convert.ToInt32(textBox_DrawTick.Text);
                trackBar_DrawSpeed.Value = Convert.ToInt32(textBox_DrawTick.Text);
            }
        }

        private void trackBar_DrawSpeed_Scroll(object sender, EventArgs e)
        {
            textBox_DrawTick.Text = Convert.ToString(trackBar_DrawSpeed.Value);
            timer1.Interval = Convert.ToInt32(textBox_DrawTick.Text);
        }


        /*
         *  The InnerPlotPosition property 
         *      defines the rectangle within a chart area element that is used for plotting data; it excludes tick marks, axis labels, and so forth.
         *  ChartArea.Position property 
         *      defines the position of a ChartArea object within the Chart, and includes tick marks, axis labels, and so forth.
         *  Axis.PixelPositionToValue()  
         *      해당 윈도우 기준의 '절대적 pixel 값'을 axis 값으로 변환한다. 
         *  Axis.ValueToPosition()
         *      axis 값을 '상대값 (0 ~ 100%)'으로 변환한다. 
         *  ElementPosition : 상대좌표(0, 0) ~ (100, 100) 사이값을 가짐.
         *      ChartAreas[0].Position.X
         *      ChartAreas[0].InnerPlotPosition.X;
                ChartAreas[0].InnerPlotPosition.Width;
        */
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (bMouseMoveReady == true)
            {
                for (int i = 0; i < chart1.ChartAreas.Count; i++)
                {
                    Point mousePoint = new Point(e.X, e.Y);
                    //chart1.ChartAreas[i].CursorX.SetCursorPixelPosition(mousePoint, false);
                    chart1.ChartAreas[i].CursorY.SetCursorPixelPosition(mousePoint, true);   // ###true: cursor가 Area를 벗어나면 Boundary 선에 위치함. 
                    double x = chart1.ChartAreas[i].AxisX.PixelPositionToValue(e.X);
                    double y = chart1.ChartAreas[i].AxisY.PixelPositionToValue(e.Y);
                    x = Math.Round(x, 1); /* 반올림 */
                    y = Math.Round(y, 2); /* 반올림 */

                    if ((y <= chart1.ChartAreas[i].AxisY.Maximum) && (y >= chart1.ChartAreas[i].AxisY.Minimum) &&
                        (x <= chart1.ChartAreas[i].AxisX.Maximum) && (x >= chart1.ChartAreas[i].AxisX.Minimum)
                        )
                    {
                        textBox_MousePoint.Location = new Point(e.X + 20, e.Y + 5);
                        string str = "";
                        //str = Convert.ToString(x);
                        //str += "/";
                        str += Convert.ToString(y);
                        textBox_MousePoint.Text = str;
                    }
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TextBox tb = (TextBox)sender;
                for (int i = 0; i < TEXT_FUNC_N; i++)
                {
                    if (tb.Name == "textBox" + Convert.ToString(i))
                    {                 
                        textDisp[i] = textFunc[i].Text;
                    }
                }
                e.Handled = true;   // ###GUN 이것이 없으면 경고음 발생
            }
        }

        private void Update_textBox()
        {
            for (int i = 0; i < ROW_N; i++)
            {
                textDisp[i] = textFunc[i].Text;
            }          
        }
        
        private void textBox_Cmd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox_Cmd.Lines.Length > 0)
                {
                    e.Handled = true;
                    string lastLine = textBox_Cmd.Lines[textBox_Cmd.Lines.Length - 1];
                    lastLine = lastLine.ToLower();
                    //lastLine = lastLine.Replace("-", "");
                    lastLine = lastLine.Replace(" ", "");
                    //if (lastLine.Equals("Clear", StringComparison.OrdinalIgnoreCase))
                    Match mc;
                    MatchCollection mcs;
                    if (lastLine.IndexOf("init") != -1)
                    {
                        textFunc[0].Text = "";
                        textFunc[1].Text = "";
                        textFunc[2].Text = "";
                        textFunc[3].Text = "";
                        textFunc[4].Text = "";
                        textFunc[5].Text = "";
                        textFunc[6].Text = "";
                        textFunc[7].Text = "";
                        textBox_Cmd.Text = "";
                        textFuncIndex = 0;                       
                        Set_Chart1();
                    }
                    else if (lastLine.IndexOf("tb") != -1) // textbox number
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("tb"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        string str = lastLine.Substring(lastLine.IndexOf("tb"), lastLine.Length - lastLine.IndexOf("tb"));
                        mc = Regex.Match(str, @"\d+\:");            // dock
                        if (mc.Success)
                        {
                            int tbIndex = Convert.ToInt32(mc.Value.Substring(0, mc.Value.Length - 1));
                            textFunc[tbIndex].Text = str.Substring(str.IndexOf(":")+1);
                            Update_textBox();
                        }
                    }
                    else if (lastLine.IndexOf("exam") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("exam"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        string str = lastLine.Substring(lastLine.IndexOf("exam"), lastLine.Length - lastLine.IndexOf("exam"));
                        textBox0.Text = "sin(x)";
                        textBox1.Text = "cos(x)";
                        textBox2.Text = "sin(2x)";
                        textBox3.Text = "cos(2x)";
                        textBox4.Text = "sin(3x)";
                        textBox5.Text = "cos(3x)";
                        textBox6.Text = "sin(4x)";
                        textBox7.Text = "sin(x)+cos(x)+sin(2x)+cos(2x)+sin(3x)+cos(3x)+sin(4x)";
                        Set_Chart1();
                        startToggle = false;
                        button_Start_Click(sender, e);
                    }
                    else if (lastLine.IndexOf("cp") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("cp"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        string str = lastLine.Substring(lastLine.IndexOf("cp"), lastLine.Length - lastLine.IndexOf("cp"));
                        mcs = Regex.Matches(str, @"\d+");
                        if (mcs.Count == 1)
                        {
                            textFunc[Convert.ToInt32(mcs[0].Value)].Text = textFunc[7].Text;
                            Update_textBox();
                        }
                        if (mcs.Count == 2)
                        {
                            textFunc[Convert.ToInt32(mcs[1].Value)].Text = textFunc[Convert.ToInt32(mcs[0].Value)].Text;
                            Update_textBox();
                        }
                    }
                    else if (lastLine.IndexOf("fsin") != -1)
                    {
                        /*
                         * 이번 입력 전 문장(fsin 전까지) 백업 (수식만 입력 상태 유지를 위해)
                         * 이번 입력 전 문장 끝에 입력이 가능하돍 cursor 마지막으로 이동 (수식만 입력 상태 유지를 위해)
                         * 이번 입력 문장만 저장
                         */
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("fsin"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        /*
                         * 이번 입력 문장만 저장
                         * 이번 입력 문장 분석([sct], -c:count, -i:interval, -m 2:1 :sin-sin-cos mix
                         */
                        string strThis = lastLine.Substring(lastLine.IndexOf("fsin"), lastLine.Length - lastLine.IndexOf("fsin"));
                        string what = "";
                        int count = 1;
                        int intv = 1;
                        int nMix1 = 1;
                        int nMix2 = 0;

                        mc = Regex.Match(strThis, @"\([sct]\)");    // sin/cos/tan
                        if (mc.Success)
                        {
                            what = mc.Value.Substring(1, 1);
                        }
                        mc = Regex.Match(strThis, @"-c\d+");        // count
                        if (mc.Success)
                        {
                            count = Convert.ToInt32(mc.Value.Substring(2, mc.Value.Length - 2));
                        }
                        mc = Regex.Match(strThis, @"-i\d+");        // interval
                        if (mc.Success)
                        {
                            intv = Convert.ToInt32(mc.Value.Substring(2, mc.Value.Length - 2));
                        }
                        mc = Regex.Match(strThis, @"-m\d+");        // mixed
                        if (mc.Success)
                        {
                            nMix1 = Convert.ToInt32(mc.Value.Substring(2, mc.Value.Length - 2));
                        }
                        mc = Regex.Match(strThis, @":\d+");
                        if (mc.Success)
                        {
                            nMix2 = Convert.ToInt32(mc.Value.Substring(1, mc.Value.Length - 1));
                        }
                        Console.WriteLine("count:{0}, intv:{1}, nMix1:{2}, nMix2:{3}", count, intv, nMix1, nMix2);                       

                        string strRepeat = "";
                        if ((nMix1 != 0) && (nMix2 != 0))
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i % (nMix1 + nMix2) < nMix1)
                                {
                                    if (what == "s")
                                    {
                                        strRepeat += "sin(";
                                    }
                                    if (what == "c")
                                    {
                                        strRepeat += "cos(";
                                    }
                                }
                                else
                                {
                                    if (what == "s")
                                    {
                                        strRepeat += "cos(";
                                    }
                                    if (what == "c")
                                    {
                                        strRepeat += "sin(";
                                    }
                                }
                                if (intv != 0)
                                {
                                    strRepeat += Convert.ToString(intv * i);
                                }
                                strRepeat += "x)+";
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (what == "s")
                                {
                                    strRepeat += "sin(";
                                }
                                else if (what == "c")
                                {
                                    strRepeat += "cos(";
                                }
                                else if (what == "t")
                                {
                                    strRepeat += "tan(";
                                }
                                if (intv != 0)
                                {
                                    strRepeat += Convert.ToString(intv * i);
                                }
                                strRepeat += "x)+";
                            }
                        }
                        strRepeat = strRepeat.Remove(strRepeat.Length - 1, 1);
                        textBox_Cmd.Text = strRepeat;
                        textFunc[COLUMN_N - 1].Text = textBox_Cmd.Text;
                        Update_textBox();
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                    }
                    else if (lastLine.IndexOf("clear") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("clear"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        Set_Chart1();
                        //chart1.Series[0].Points.Clear();
                    }
                    else if (lastLine.IndexOf("start") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("start"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        button_Start_Click(sender, e);
                    }
                    else if (lastLine.IndexOf("stop") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("stop"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        button_Start_Click(sender, e);
                    }
                    else if (lastLine.IndexOf("check") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("check"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        string str = lastLine.Substring(lastLine.IndexOf("check"), lastLine.Length - lastLine.IndexOf("check"));

                        mcs = Regex.Matches(str, @"\(\d+,\d+\)");  // (1,2)
                        if (mcs.Count == 2)
                        {
                            if (checks[Convert.ToInt32(mcs[0].Value), Convert.ToInt32(mcs[1].Value)].Checked == true)
                            {
                                checks[Convert.ToInt32(mcs[0].Value), Convert.ToInt32(mcs[1].Value)].Checked = false;
                            }
                            else
                            {
                                checks[Convert.ToInt32(mcs[0].Value), Convert.ToInt32(mcs[1].Value)].Checked = true;
                            }
                        }
                        mc = Regex.Match(str, @"-a\d*");            // -a
                        if (mc.Success)
                        {
                            mc = Regex.Match(str, @"-a\d+");        // -a4
                            if (mc.Success)
                            {
                                int n = Convert.ToInt32(mc.Value.Substring(2, mc.Value.Length - 2));
                                mc = Regex.Match(str, @"-d");       // distrbute
                                if (mc.Success)
                                {
                                    for (int i = 0; i < n; i++)
                                    {
                                        checks[i, i].Checked = true;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < n; i++)
                                    {
                                        checks[i, 0].Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                mc = Regex.Match(str, @"-d");  
                                if (mc.Success)
                                {
                                    for (int i = 0; i < ROW_N; i++)
                                    {
                                        checks[i, i].Checked = true;
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < ROW_N; i++)
                                    {
                                        checks[i, 0].Checked = true;
                                    }
                                }
                            }
                        }
                        mc = Regex.Match(str, @"-u.*");        
                        if (mc.Success)
                        {
                            mc = Regex.Match(str, @"-u\d+");  // 개별적으로 uncheck
                            if (mc.Success)
                            {
                                mcs = Regex.Matches(str, @"\d+");
                                if (mcs.Count != 0)
                                {
                                    for (int i = 0; i < mcs.Count; i++)
                                    {
                                        for (int j = 0; j < COLUMN_N; j++)
                                        {
                                            if (Convert.ToInt32(mcs[i].Value) < ROW_N)
                                            {
                                                checks[Convert.ToInt32(mcs[i].Value), j].Checked = false;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                mc = Regex.Match(str, @"-u[hl]\d+");
                                if (mc.Success)
                                {
                                    mc = Regex.Match(str, @"-uh\d+");
                                    if (mc.Success)
                                    {
                                        int n = Convert.ToInt32(str.Substring(mc.Index + 3));
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < COLUMN_N; j++)
                                            {
                                                checks[i, j].Checked = false;
                                            }
                                        }
                                    }
                                    mc = Regex.Match(str, @"-ul\d+");
                                    if (mc.Success)
                                    {
                                        int n = Convert.ToInt32(str.Substring(mc.Index + 3));
                                        for (int i = 0; i < n; i++)
                                        {
                                            for (int j = 0; j < COLUMN_N; j++)
                                            {
                                                checks[ROW_N - 1 - i, j].Checked = false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < ROW_N; i++)
                                    {
                                        for (int j = 0; j < COLUMN_N; j++)
                                        {
                                            checks[ROW_N - 1 + i, j].Checked = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (lastLine.IndexOf("disp") != -1)
                    {
                        textBox_Cmd.Text = textBox_Cmd.Text.Substring(0, lastLine.IndexOf("disp"));
                        textBox_Cmd.SelectionStart = textBox_Cmd.Text.Length;
                        string str = lastLine.Substring(lastLine.IndexOf("disp"), lastLine.Length - lastLine.IndexOf("disp"));
                        
                        mc = Regex.Match(str, @"-c\d+");
                        if (mc.Success)
                        {
                            textBox_dispcount.Text = mc.Value.Substring(2, mc.Value.Length - 2);
                        }
                        mc = Regex.Match(str, @"-r\d+");
                        if (mc.Success)
                        {
                            textBox_resolution.Text = mc.Value.Substring(2, mc.Value.Length - 2);
                        }
                        mc = Regex.Match(str, @"-t\d+");
                        if (mc.Success)
                        {
                            textBox_DrawTick.Text = mc.Value.Substring(2, mc.Value.Length - 2);
                            trackBar_DrawSpeed.Value = Convert.ToInt32(textBox_DrawTick.Text);
                            timer1.Interval = Convert.ToInt32(textBox_DrawTick.Text);
                        }
                        mc = Regex.Match(str, @"-d[ftblr]");            // dock
                        if (mc.Success)
                        {
                            if (mc.Value.Substring(2, 1) == "f")         // fill
                            {
                                chart1.Dock = DockStyle.Fill;
                            }
                            else if (mc.Value.Substring(2, 1) == "t")   // top
                            {
                                chart1.Dock = DockStyle.Top;
                            }
                            else if (mc.Value.Substring(2, 1) == "b")   // bottom
                            {
                                chart1.Dock = DockStyle.Bottom;
                            }
                            else if (mc.Value.Substring(2, 1) == "l")   // left
                            {
                                chart1.Dock = DockStyle.Left;
                            }
                            else if (mc.Value.Substring(2, 1) == "r")   // right
                            {
                                chart1.Dock = DockStyle.Right;
                            }
                        }
                        mc = Regex.Match(str, @"-v");                   // vertical
                        if (mc.Success)
                        {
                            if (bChartVertical == true)
                            {
                                bChartVertical = false;
                            }
                            else
                            {
                                bChartVertical = true;
                            }
                            Set_Chart1();
                        }
                        mc = Regex.Match(str, @"-wm");                // vertical
                        if (mc.Success)
                        {
                            if (WindowState == FormWindowState.Maximized)
                            {
                                WindowState = FormWindowState.Normal;
                            }
                            else
                            {
                                WindowState = FormWindowState.Maximized;
                            }
                        }
                    }   
                    else
                    {
                        /* sin, COS, pi -> Sin, Cos, PI */
                        //lastLine = Regex.Replace(lastLine, "sin", "sin", RegexOptions.IgnoreCase);
                        //lastLine = Regex.Replace(lastLine, "cos", "cos", RegexOptions.IgnoreCase);
                        //lastLine = Regex.Replace(lastLine, "tan", "tan", RegexOptions.IgnoreCase);
                        //if ((lastLine.IndexOf("sin") != -1) || (lastLine.IndexOf("cos") != -1) || (lastLine.IndexOf("tan") != -1))
                        {         
                            textFunc[COLUMN_N-1].Text = textBox_Cmd.Text;
                            textFunc[COLUMN_N-1].Text = textFunc[COLUMN_N - 1].Text.Replace("\r\n", "");
                            textFunc[COLUMN_N-1].Text = textFunc[COLUMN_N - 1].Text.Replace(" ", "");

                            textDisp[COLUMN_N-1] = textFunc[COLUMN_N - 1].Text;
                            //e.Handled = true;   // ###GUN 이것이 없으면 경고음 발생
                            if (textFunc[COLUMN_N - 1].Text.Length < preIndex)
                            {
                                preIndex = 0;
                                Console.WriteLine("preIndex error");
                            }
                            strThis = textFunc[COLUMN_N - 1].Text.Substring(preIndex, textFunc[COLUMN_N - 1].Text.Length - preIndex);
                            textFunc[textFuncIndex % (ROW_N-1)].Text = strThis;
                            textFuncIndex++;
                            preIndex = textFunc[COLUMN_N - 1].Text.Length;
                            Update_textBox();
                            Console.WriteLine(strThis);
                        }
                    }
                }
                else
                {
                    textFunc[COLUMN_N - 1].Text = textBox_Cmd.Text;
                    textFunc[COLUMN_N-1].Text = textFunc[COLUMN_N-1].Text.Replace("\r\n", "");
                    textDisp[COLUMN_N-1] = textFunc[COLUMN_N-1].Text;
                }
            }
            if (e.KeyChar == Convert.ToChar(Keys.Back))
            {
                //preIndex--;
                Console.WriteLine("back");
            }
        }
        private void chart1_Click(object sender, EventArgs e)
        {
            if (bClick == false)
            {
                bClick = true;
                timer1.Stop();
            }
            else
            {
                bClick = false;
                timer1.Start();
            }
        }

        private void chart1_SizeChanged(object sender, EventArgs e)
        {
            int textWidth = textBox_UserTitle.Width;
            int chartWidth = chart1.Width;
            //textBox_UserTitle.Location = new Point(chart1.Location.X + (chartWidth / 2) - (textWidth / 2), chart1.Location.Y+20);
            textBox_UserTitle.Location = new Point(chart1.Location.X, chart1.Location.Y);
        }
    }
}