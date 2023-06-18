using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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
namespace GunUtility
{
    public partial class Form1 : Form
    {
        private delegate void DrawChart1Delegate(double[] buffer, int size);
        private delegate void DrawChart2Delegate(double[] buffer, int size);
        public const double AXIS_Y_MIN = Double.NaN;
        public const double AXIS_Y_MAX = Double.NaN;
        public const double FREQ = 100.0;
        public const double TICK = 100.0;
        public const int ROW_N = 5;
        public const int COLUMN_N = 8;
        public const int COLOR_R = 0x20;
        public const int COLOR_G = 0x20;
        public const int COLOR_B = 0x20;
        //       public const double PI = 3.1415926535897931;
        double chart1_x = 0;
        double chart2_x = 0;
        double chart3_x = 0;
        double chart4_x = 0;
        int t1 = 0;
        bool bS0 = false;
        int xIndx = 0;
        bool bTog = false;
        CheckBox[,] checks = new CheckBox[5, 8];
        TextBox[] texts = new TextBox[5];
        int[] aAreaSel = new int[20];
        int nSeries = 0;
        public Form1()
        {
            InitializeComponent();

            tabControl1.TabPages[0].UseVisualStyleBackColor = true;
            tabControl1.TabPages[1].UseVisualStyleBackColor = true;

            tabControl1.TabPages[0].BackColor = Color.FromArgb(COLOR_R+20, COLOR_G+50, COLOR_B+50);
            tabControl1.TabPages[1].BackColor = Color.FromArgb(COLOR_R+100, COLOR_G, COLOR_B);
            chart1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer1.Panel1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer1.Panel2.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);


            splitContainer2.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer2.Panel1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer2.Panel2.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer3.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer3.Panel1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer3.Panel2.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B); 
            splitContainer6.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer6.Panel1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
            splitContainer6.Panel2.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);



            /* Timer1 @Timer */
            timer1.Interval = (int)TICK;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Stop();
            /* Chart1 @Chart */
            /* Chart2 @Chart */
            textBox0.Text = "sin(x)";
            textBox1.Text = "cos(x)";
            textBox2.Text = "sin(x)+cos(x)";
            textBox3.Text = "sin(x)+sin(2x)+sin(3x)+sin(4x)+sin(5x)+sin(6x)+sin(7x)+sin(8x)+sin(9x)+sin(10x)";
            textBox4.Text = "";
            textBox_Samples.Text = "50";

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

            

            texts[0] = textBox0;
            texts[1] = textBox1;
            texts[2] = textBox2;
            texts[3] = textBox3;
            texts[4] = textBox4;

            Chart1_Init();

            
        }

        static int countSetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        private void Chart1_Init()
        {
            checks[0, 0].Checked = true;
            checks[1, 0].Checked = true;
            checks[2, 0].Checked = true;
            checks[3, 0].Checked = true;
            Chart1_Set();

            double[] item = new double[4];
            item[0] = 0;
            item[1] = 0;
            item[2] = 0;
            item[3] = 0;

            DrawChart1(item, nSeries);
        }
        private void Chart1_Set()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

            int row, column;
            int bArea = 0;           
            int nEmptyCol = 0;

            nSeries = 0;

            for (int i = 0; i < 20; i++)
            {
                aAreaSel[i] = 0;
            }
            for (row = 0; row < 5; row++)
            {
                nEmptyCol = 0;
                for (column = 0; column < 8; column++)
                {
                    nEmptyCol++;
                    for (int rowForEmpty = 0; rowForEmpty < 5; rowForEmpty++)
                    {
                        if (checks[rowForEmpty, column].Checked == true)
                        {
                            nEmptyCol--;
                            break;
                        }
                    }                    

                    if (checks[row, column].Checked == true)
                    {
                        aAreaSel[nSeries] = column - nEmptyCol;
                        nSeries++;
                        bArea |= (0x01 << column);
                        break;
                    }
                }
            }
            Chart1_setArea(bArea);

            for (int i = 0; i < nSeries; i++)
            {
                switch (i)
                {
                    case 0:
                        Chart1_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, Color.Red);
                        break;
                    case 1:
                        Chart1_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, Color.Green);
                        break;
                    case 2:
                        Chart1_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, Color.Blue);
                        break;
                    case 3:
                        Chart1_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, Color.Cyan);
                        break;
                    default:
                        Chart1_Series(i, aAreaSel[i], 5, ChartDashStyle.Solid, Color.Cyan);
                        break;
                }
            }
            chart1_x = 0;
        }

        private int indexSetBits(int bArea, int order)
        {
            int bitIndx = 0;
            int count = 0;

            while (bArea > 0)
            {
                if ((bArea & 1) == 1)
                {
                    if (count == order)
                    {
                        return bitIndx;
                    }
                    count++;
                }
                bArea >>= 1;
                bitIndx++;
            }

            return bitIndx;
        }

        private void Chart1_setArea(int bArea)
        {
            for (int i = 0; i < countSetBits(bArea); i++)
            {
                string strArea = "Chart Area ";
                strArea += Convert.ToString(i);
                chart1.BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B); ; // ###GUN
                chart1.ChartAreas.Add(strArea);
                chart1.ChartAreas[i].BackColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
                chart1.ChartAreas[i].BackSecondaryColor = Color.FromArgb(COLOR_R, COLOR_G, COLOR_B);
                chart1.ChartAreas[i].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[i].CursorX.AutoScroll = true;
                chart1.ChartAreas[i].CursorY.AutoScroll = true;
                chart1.ChartAreas[i].AxisX.LabelStyle.Format = "#.##";
                chart1.ChartAreas[i].AxisY.LabelStyle.Format = "0.00";  // ###GUN
                chart1.ChartAreas[i].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
                chart1.ChartAreas[i].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
                chart1.ChartAreas[i].AxisX.Interval = 10;
                chart1.ChartAreas[i].AxisX.MajorGrid.Interval = 0;
                chart1.ChartAreas[i].AxisX.MajorGrid.Enabled = true;
                chart1.ChartAreas[i].AxisX.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisX.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisX.LabelStyle.ForeColor = Color.White;
                chart1.ChartAreas[i].AxisY.Minimum = AXIS_Y_MIN;
                chart1.ChartAreas[i].AxisY.Maximum = AXIS_Y_MAX;
                chart1.ChartAreas[i].AxisY.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisY.LabelStyle.ForeColor = Color.White;
                chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.True;
                chart1.ChartAreas[i].AlignWithChartArea = strArea;
                chart1.ChartAreas[i].AlignmentStyle = AreaAlignmentStyles.Position;
                chart1.ChartAreas[i].AlignmentOrientation = AreaAlignmentOrientations.Vertical;


                //chart1.ChartAreas[i].Position.X = 0;
                //chart1.ChartAreas[i].Position.Width = 100;
                //chart1.ChartAreas[i].Position.Height = 100;
                //chart1.ChartAreas[i].Position.Y = 0;
            }

            // ###GUN
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
        private void Chart1_Series(int series_idx, int area_idx, int marker_size, ChartDashStyle dash, Color color)
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
            chart1.Series[series_idx].MarkerStyle = MarkerStyle.None;    // ###GUN
            chart1.Series[series_idx].BorderWidth = 1;
            chart1.Series[series_idx].BorderDashStyle = dash;
            chart1.Series[series_idx].Color = color;
            chart1.Series[series_idx].IsVisibleInLegend = false;
        }
        
        private void DrawChart1(double[] buffer, int size)
        {
            if (chart1.InvokeRequired)
            {
                DrawChart1Delegate del = new DrawChart1Delegate(DrawChart1);
                chart1.Invoke(del, new object[] { buffer, size });
            }
            else
            {
                for (int i = 0; i < nSeries; i++)
                { 
                    double data = buffer[i];
                    chart1.Series[i].Points.AddXY(chart1_x, data);
                    if (chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum > data) chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum = data;
                    if (chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum < data) chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum = data;
                    if (chart1.Series[i].Points.Count > 100)
                    {
                        chart1.Series[i].Points.RemoveAt(0);
                    }
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Minimum = chart1.Series[i].Points[0].XValue;
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Maximum = chart1_x;
                }
                chart1_x++;
            }
        }
        private double calcStrMath(string math)
        {
            string name = math;
            /* " " -> "" */
            name = name.Replace(" ", "");

            /* x^2 -> *x */
            name = name.Replace("^2", "*x");
            int i = 1;
            foreach (Match match in Regex.Matches(name, @"\d[x|\(]", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(1)))
            {
                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                name = name.Insert(match.Index + i++, "*");
            }

            /* sin, COS, pi -> Sin, Cos, PI */
            name = Regex.Replace(name, "sin", "Sin", RegexOptions.IgnoreCase);
            name = Regex.Replace(name, "cos", "Cos", RegexOptions.IgnoreCase);
            name = Regex.Replace(name, "pi", "PI", RegexOptions.IgnoreCase);

            /* 
             * x -> 2*PI*xIndx/samples (Sin함수)
             * x -> xIndx (일반다항식)
             */
            if ((name.IndexOf("Sin") != -1) || (name.IndexOf("Cos") != -1))
            {
                name = name.Replace("x", "2*PI*x/" + textBox_Samples.Text);
            }
            name = name.Replace("x", Convert.ToString(xIndx));

            xIndx++;

            /* 12Sin -> 12*Sin */
            i = 1;
            /*  MatchCollection mc = Regex.Matches(name, @"\d(Sin|Cos)", RegexOptions.None, TimeSpan.FromSeconds(1));
            foreach (Match match in mc) */
            foreach (Match match in Regex.Matches(name, @"\d(Sin|Cos)", RegexOptions.None, TimeSpan.FromSeconds(1)))
            {
                Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                name = name.Insert(match.Index + i++, "*");
            }

            MatchCollection mc = Regex.Matches(name, @"(Sin|Cos)\([^\(]+\)", RegexOptions.None, TimeSpan.FromSeconds(1));
            DataTable dt = new DataTable();
            for (int j = 0; j < mc.Count; j++)
            {
                string strIn = mc[mc.Count - j - 1].Value.Substring(mc[mc.Count - j - 1].Value.IndexOf("(") + 1, mc[mc.Count - j - 1].Value.IndexOf(")") - 1 - mc[mc.Count - j - 1].Value.IndexOf("("));
                strIn = strIn.Replace("PI", "3.1415926535897931");
                double dblIn = Convert.ToDouble(dt.Compute(strIn, ""));

                double dblSin = 0;
                if (mc[mc.Count - j - 1].Value.IndexOf("Sin") != -1)
                {
                    dblSin = Math.Sin(dblIn);
                }
                if (mc[mc.Count - j - 1].Value.IndexOf("Cos") != -1)
                {
                    dblSin = Math.Cos(dblIn);
                }
                //name = name.Replace(mc[mc.Count - j - 1].Value, "");
                name = name.Remove(mc[mc.Count - j - 1].Index, mc[mc.Count - j - 1].Length);

                

          
                name = name.Insert(mc[mc.Count - j - 1].Index, Convert.ToString(dblSin));
            }

            double Q = Convert.ToDouble(dt.Compute(name, ""));

            //Q = Math.Round(Q, 2);     // 소수세짜리 반올림 ###GUN
            //Q = Math.Ceiling(Q);      // 소수첫짜리 올림
            //Q = Math.Truncate(Q);     // 소수첫짜리 버림
            //Q = Math.Round(Q, 1);     // 소수둘째자리 반올림

            return Q;           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] item = new double[10];
            //item[0] = calcStrMath(textBox0.Text);
            //item[1] = calcStrMath(textBox1.Text);
            //item[2] = calcStrMath(textBox2.Text);
            //item[3] = calcStrMath(textBox3.Text);


            int indx = 0;

            for (int row = 0; row < ROW_N; row ++)
            {
                for (int column = 0; column < COLUMN_N; column ++)
                {
                    if (checks[row, column].Checked == true)
                    {
                        item[indx++] = calcStrMath(texts[row].Text);
                        if (indx == nSeries)
                        {
                            DrawChart1(item, nSeries);
                            return;
                        }
                    }
                }
            }

            DrawChart1(item, 4);
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chart1.Series.Count; i++)
            {
                chart1.Series[i].Points.Clear();
            }
            for (int i = 0; i < chart1.ChartAreas.Count; i++)
            {
                chart1.ChartAreas[i].AxisY.Minimum = AXIS_Y_MIN;
                chart1.ChartAreas[i].AxisY.Maximum = AXIS_Y_MAX;
            }
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Debug.WriteLine("Enter !");
                if (textBox1.Text.ToLower() == "sinx")
                {
                    Debug.WriteLine("sinx !");
                }
                if (textBox1.Text.ToLower() == "cosx")
                {
                    Debug.WriteLine("cosx !");
                }
                textBox1.Text = "";
            }
            return;
        }
//       private void button1_Click_1(object sender, EventArgs e)
//       {
//           if (button1.Text == "Start")
//           {
//               timer1.Start();
//               button1.Text = "Stop";
//           }
//           else
//           {
//               timer1.Stop();
//               button1.Text = "Start";
//           }
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

        private void button_F0_Click(object sender, EventArgs e)
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
        
        private void button5_Click(object sender, EventArgs e)
        {
            xIndx = 0;

            if (bTog == false)
            {
                Chart1_Set();
                splitContainer1.FixedPanel = FixedPanel.Panel1; // ###GUN
                splitContainer2.FixedPanel = FixedPanel.Panel2;

                timer1.Start();
                bTog = true;
            }
            else 
            {
                timer1.Stop();
                bTog = false;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            for (int i = 0; i <= ROW_N*COLUMN_N; i++)
            {
                if (cb.Name == "checkBox" + Convert.ToString(i+1))
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
        }
    }
}