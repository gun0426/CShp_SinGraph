using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data;
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
        public const double PI = 3.1415926535897931;
        double chart1_x = 0;
        int t1 = 0;
        bool bS0 = false;
        public Form1()
        {
            InitializeComponent();
            /* Timer1 @Timer */
            timer1.Interval = (int)TICK;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Stop();
            /* Chart1 @Chart */
            /* Chart2 @Chart */
            textBox0.Text = "2 * sin(x + pi/4)";
            textBox1.Text = "2 * cos(x + pi/4)";
            textBox2.Text = "F0 + F1";
            textBox3.Text = "3 * sin(x + pi/6) + 2 * cos(x + pi/7)";
            textBox4.Text = "F3 * sin(x)";
            textBox5.Text = "F3 * cos(x)";
        }
        private void Chart1_Set()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            Chart1_Area(2);
            Chart1_Series(0, 0, 5, ChartDashStyle.Solid, Color.Red);
            Chart1_Series(1, 0, 5, ChartDashStyle.Solid, Color.Yellow);
            Chart1_Series(2, 0, 5, ChartDashStyle.Dash, Color.Cyan);
            Chart1_Series(3, 0, 5, ChartDashStyle.Dash, Color.Blue);
            Chart1_Series(4, 1, 5, ChartDashStyle.Dot, Color.Red);
            Chart1_Series(5, 1, 5, ChartDashStyle.Solid, Color.Yellow);
            Chart1_Series(6, 1, 5, ChartDashStyle.Dash, Color.Cyan);
            Chart1_Series(7, 1, 5, ChartDashStyle.Dash, Color.Blue);
            chart1_x = 0;
        }
        private void Chart1_Area(int count)
        {
            float yPos = 0;
            float xPos = 0;
            int quotient = count / 2;
            int remainder = count % 2;
            int nLine = quotient + remainder;
            for (int i = 0; i < count; i++)
            {
                string strArea = "Chart Area ";
                strArea += Convert.ToString(i);
                chart1.ChartAreas.Add(strArea);
                chart1.ChartAreas[i].BackColor = Color.FromArgb(0, 0, 0);
                chart1.ChartAreas[i].BackSecondaryColor = Color.FromArgb(0, 0, 0);
                chart1.ChartAreas[i].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas[i].CursorX.AutoScroll = true;
                chart1.ChartAreas[i].CursorY.AutoScroll = true;
                chart1.ChartAreas[i].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
                chart1.ChartAreas[i].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
                chart1.ChartAreas[i].AxisX.Interval = 10;
                chart1.ChartAreas[i].AxisX.MajorGrid.Interval = 0;
                chart1.ChartAreas[i].AxisX.MajorGrid.Enabled = true;
                chart1.ChartAreas[i].AxisX.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisX.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisX.LabelStyle.ForeColor = Color.FromArgb(255, 255, 255);
                chart1.ChartAreas[i].AxisY.Minimum = AXIS_Y_MIN;
                chart1.ChartAreas[i].AxisY.Maximum = AXIS_Y_MAX;
                chart1.ChartAreas[i].AxisY.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart1.ChartAreas[i].AxisY.LabelStyle.ForeColor = Color.FromArgb(255, 255, 255);
                chart1.ChartAreas[i].AlignWithChartArea = strArea;
                chart1.ChartAreas[i].AlignmentStyle = AreaAlignmentStyles.Position;
                chart1.ChartAreas[i].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;
            }
            chart1.Legends.Clear();
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = ".##";
            chart1.ChartAreas[0].Position.Height = 100;
            chart1.ChartAreas[0].Position.Width = 80;
            chart1.ChartAreas[0].Position.X = 0;
            chart1.ChartAreas[0].Position.Y = 0;
            chart1.ChartAreas[1].AxisX.LabelStyle.Format = ".##";
            chart1.ChartAreas[1].Position.Height = 100;
            chart1.ChartAreas[1].Position.Width = 20;
            chart1.ChartAreas[1].Position.X = 80;
            chart1.ChartAreas[1].Position.Y = 0;
            chart1.ChartAreas[1].AxisY.Enabled = AxisEnabled.False;
            chart1.ChartAreas[1].AxisX.Minimum = -2;
            chart1.ChartAreas[1].AxisX.Maximum = 2;
            chart1.ChartAreas[1].AxisY.Minimum = -2;
            chart1.ChartAreas[1].AxisY.Maximum = 2;
            chart1.BackColor = Color.FromArgb(0, 0, 0);
            chart1.BackSecondaryColor = Color.FromArgb(0, 0, 0);
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
            chart1.Series[series_idx].MarkerStyle = MarkerStyle.Circle;
            chart1.Series[series_idx].BorderWidth = 1;
            chart1.Series[series_idx].BorderDashStyle = dash;
            chart1.Series[series_idx].Color = color;
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
                /*
                 * CHART 1 : Area-0
                 */
                double Chart1_Y0 = buffer[0];
                chart1.Series[0].Points.AddXY(chart1_x, Chart1_Y0);
                if (chart1.ChartAreas[0].AxisY.Minimum > Chart1_Y0) chart1.ChartAreas[0].AxisY.Minimum = Chart1_Y0;
                if (chart1.ChartAreas[0].AxisY.Maximum < Chart1_Y0) chart1.ChartAreas[0].AxisY.Maximum = Chart1_Y0;
                double Chart1_Y1 = buffer[1];
                chart1.Series[1].Points.AddXY(chart1_x, Chart1_Y1);
                if (chart1.ChartAreas[0].AxisY.Minimum > Chart1_Y1) chart1.ChartAreas[0].AxisY.Minimum = Chart1_Y1;
                if (chart1.ChartAreas[0].AxisY.Maximum < Chart1_Y1) chart1.ChartAreas[0].AxisY.Maximum = Chart1_Y1;
                double Chart1_Y2 = buffer[2];
                chart1.Series[2].Points.AddXY(chart1_x, Chart1_Y2);
                if (chart1.ChartAreas[0].AxisY.Minimum > Chart1_Y2) chart1.ChartAreas[0].AxisY.Minimum = Chart1_Y2;
                if (chart1.ChartAreas[0].AxisY.Maximum < Chart1_Y2) chart1.ChartAreas[0].AxisY.Maximum = Chart1_Y2;
                double Chart1_Y3 = buffer[3];
                chart1.Series[3].Points.AddXY(chart1_x, Chart1_Y3);
                if (chart1.ChartAreas[0].AxisY.Minimum > Chart1_Y3) chart1.ChartAreas[0].AxisY.Minimum = Chart1_Y3;
                if (chart1.ChartAreas[0].AxisY.Maximum < Chart1_Y3) chart1.ChartAreas[0].AxisY.Maximum = Chart1_Y3;
                if (chart1.Series[0].Points.Count > 100)
                {
                    chart1.Series[0].Points.RemoveAt(0);
                    chart1.Series[1].Points.RemoveAt(0);
                    chart1.Series[2].Points.RemoveAt(0);
                    chart1.Series[3].Points.RemoveAt(0);
                }
                chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                chart1.ChartAreas[0].AxisX.Maximum = chart1_x;
                chart1_x++;
                /*
                 * CHART 1 : Area-1
                 */
                double Chart1_X0 = buffer[4];
                chart1.Series[4].Points.Clear();
                chart1.Series[4].Points.AddXY(0, 0);
                chart1.Series[4].Points.AddXY(Chart1_X0, Chart1_Y0);
                chart1.Series[4].Points.AddXY(-2, Chart1_Y0);
                double Chart1_X1 = buffer[5];
                chart1.Series[5].Points.Clear();
                chart1.Series[5].Points.AddXY(0, 0);
                chart1.Series[5].Points.AddXY(Chart1_X1, Chart1_Y1);
                chart1.Series[5].Points.AddXY(-2, Chart1_Y1);
                double Chart1_X2 = buffer[5];
                chart1.Series[6].Points.Clear();
                chart1.Series[6].Points.AddXY(0, 0);
                chart1.Series[6].Points.AddXY(Chart1_X2, Chart1_Y2);
                chart1.Series[6].Points.AddXY(-2, Chart1_Y2);
                chart1.ChartAreas[1].AxisY.Minimum = chart1.ChartAreas[0].AxisY.Minimum;
                chart1.ChartAreas[1].AxisY.Maximum = chart1.ChartAreas[0].AxisY.Maximum;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t1++;
            double Amp1 = 2;
            double[] dblData1 = new double[10];
            dblData1[0] = (double)t1;
            dblData1[1] = Amp1 * Math.Sin((2 * Math.PI / 30) * t1 + (Math.PI / 4));
            dblData1[1] = dblData1[0] * Math.Sin((2 * Math.PI / 30) * t1);
            dblData1[2] = dblData1[0] * Math.Cos((2 * Math.PI / 30) * t1);
            dblData1[3] = dblData1[1] + dblData1[2];
            dblData1[4] = Amp1 * Math.Cos((2 * Math.PI / 30) * t1 + (Math.PI / 4));
            dblData1[5] = dblData1[0] * Math.Cos((2 * Math.PI / 30) * t1);
            dblData1[6] = dblData1[1] * Math.Sin((2 * Math.PI / 30) * t1);
            dblData1[7] = dblData1[1] * Math.Cos((2 * Math.PI / 30) * t1);
            dblData1[0] = Math.Round(dblData1[0], 2);
            dblData1[1] = Math.Round(dblData1[1], 2);
            dblData1[2] = Math.Round(dblData1[2], 2);
            dblData1[3] = Math.Round(dblData1[3], 2);
            dblData1[4] = Math.Round(dblData1[4], 2);
            dblData1[5] = Math.Round(dblData1[5], 2);
            DrawChart1(dblData1, 6);
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                timer1.Start();
                button1.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                button1.Text = "Start";
            }
        }
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
        private void chart1_Click(object sender, EventArgs e)
        {
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
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
        private void checkBox_S0A0_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_S0A0.Checked == true)
            {
                chart1.ChartAreas.Add("ChartArea0");
            }
            else
            {
                chart1.ChartAreas.Remove(chart1.ChartAreas[chart1.ChartAreas.IndexOf("ChartArea0")]);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string input = "12 * Sin(5x + PI/4) + 10";
            string inputQ = input.Replace(" ", "");                                     /* 12*Sin(5x+PI/4)+10 */
            string pattern = @"[\*|\+|\-|\/]?(sin|cos|tan)(\d*[x|X]|\(\d*[x|X].*\))";
            Match m = Regex.Match(inputQ, pattern, RegexOptions.IgnoreCase);            /* *Sin(5x+PI/4) */
            string Form = inputQ.Replace(m.Value, "");                                  /* 12+10 */
            if (m.Success)
            {
                string Fx = m.Value;
                Fx = Fx.ToLower();                                                      /* *sin(5x+PI/4) */
                if ((Fx.Substring(0, 3) == "sin") || (Fx.Substring(0, 1) == "cos") || (Fx.Substring(0, 1) == "tan"))
                {
                    Form = Form.Insert(m.Index, "*");                                   /* 12*+10 */
                }
                else
                {
                    Form = Form.Insert(m.Index, Fx.Substring(0, 1));                    /* 12*+10 */
                    Fx = Fx.Substring(1, Fx.Length - 1);                                /* sin(5x+PI/4) */
                }
                string sinVal = Fx.Substring(Fx.IndexOf("(")+1, Fx.IndexOf(")") - Fx.IndexOf("(")-1);
                DataTable dt_1 = new DataTable();
                var sinIn = dt_1.Compute(sinVal, "");
                while (true) ;
            }
            else
            {
            }
            DataTable dt = new DataTable();
            var v = dt.Compute(Form, "");
            while (true) ;
        }
    }
}