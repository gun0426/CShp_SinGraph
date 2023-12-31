﻿using System;
using System.Numerics;  // 참조 : 어셈블리
using MathNet.Numerics; // 참조 : NuGet
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ChartDirector;



using DSPLib;
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
        private delegate void Draw_Chart2Delegate(double[] buffer, int size);
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
        double xIndx = 0;
        bool startToggle = false;
        CheckBox[,] checks = new CheckBox[ROW_N, COLUMN_N];
        System.Windows.Forms.TextBox[] textFunc = new System.Windows.Forms.TextBox[TEXT_FUNC_N];
        Button[] btnColor = new Button[TEXT_FUNC_N];
        Button[] btnColorS = new Button[TEXT_FUNC_N];
        string[] textDisp = new string[TEXT_FUNC_N];
        int[] aAreaSel = new int[20];
        int nSeries = 0;
        int nArea = 0;
        Color[] sColor = new Color[20];
        bool bMinMaxInit_1 = true;
        bool bMinMaxInit_2 = true;
        bool bMouseMoveReady = false;
        int preIndex = 0;
        bool bChartVertical = false;
        bool bClick = false;
        string[] strMixXY = new string[2];
        bool bOverlap = true;
        bool bDocking = true;
        int checkIndex = 0;
        double[] preData = new double[ROW_N];

        List<Scatter> scallterList = new List<Scatter>();


        public Form1()
        {
            InitializeComponent();

            #region UI Color
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
            textBox_Cmd.ForeColor = Color.FromArgb(BACK_COLOR_R + 100, BACK_COLOR_G + 100, BACK_COLOR_B + 100);
            textBox_Mix.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            textBox_Mix.ForeColor = Color.FromArgb(BACK_COLOR_R + 100, BACK_COLOR_G + 100, BACK_COLOR_B + 100);
            textBox_Mix.Visible = false;
            textBox_dispcount.Text = Convert.ToString(SAMPLE_N);
            textBox_MousePoint.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            textBox_MousePoint.ForeColor = Color.White;
            textBox_UserTitle.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            textBox_UserTitle.ForeColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B); //Color.White;
            textBox_UserTitle.Text = "";


            chart3DControl.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            chart3DControl.BorderColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
            #endregion

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

            #region Control Array
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
            #endregion
            Init_Chart1();
            chart2.Visible = false;
            chart3DControl.Visible = false;
            strMixXY[0] = "cos";
            strMixXY[1] = "y";
            textBox_Mix.Visible = false;
            textBox_Mix.Text = "cos,y";
            textBox_Cmd.Focus();

            this.dataSourceComboBox.SelectedIndexChanged += dataSourceComboBox_SelectedIndexChanged;
            this.colorSchemeComboBox.SelectedIndexChanged += colorSchemeComboBox_SelectedIndexChanged;
            this.rasterTypeComboBox.SelectedIndexChanged += rasterTypeComboBox_SelectedIndexChanged;
            this.resetPositionButton.Click += resetPositionButton_Click;
            this.saveImageButton.Click += saveImageButton_Click;

            //this.chart3DControl.SetFunction
            //(
            //    rendererDelegate,
            //    new PointF(-120f, -80f),
            //    new PointF(120f, 80f),
            //    5d,
            //    NormalizeType.MaintainXYZ
            //);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dataSourceComboBox.SelectedIndex = 0;

            this.colorSchemeComboBox.Sorted = false;

            foreach (ColoeScheme schemaType in Enum.GetValues(typeof(ColoeScheme)))
            {
                this.colorSchemeComboBox.Items.Add(schemaType);
            }

            this.colorSchemeComboBox.SelectedIndex = (int)ColoeScheme.Rainbow1;

            this.rasterTypeComboBox.Sorted = false;

            foreach (RasterType rasterType in Enum.GetValues(typeof(RasterType)))
            {
                this.rasterTypeComboBox.Items.Add(rasterType);
            }

            this.rasterTypeComboBox.SelectedIndex = (int)RasterType.Label;

            this.chart3DControl.AssignTrackBars(this.rhoTrackBar, this.thetaTrackBar, this.phiTrackBar);
        }
        private void dataSourceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chart3DControl.AxisXLegend = null;
            this.chart3DControl.AxisYLegend = null;
            this.chart3DControl.AxisZLegend = null;

            switch (this.dataSourceComboBox.SelectedIndex)
            {
                case 0: SetFunction1(); break;
                case 1: SetFunction2(); break;
                case 2: SetSurfacePoints(); break;
                case 3: SetScatterPoints(false); break;
                case 4: SetScatterPoints(true); break;
                case 5: SetScatterPoints(); break;
            }

            this.informationLabel.Text = "포인트 수 : " + this.chart3DControl.PointCount;
        }
        private void colorSchemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color[] colorArray = ColorSchema.GetSchema((ColoeScheme)this.colorSchemeComboBox.SelectedIndex);

            this.chart3DControl.SetColorScheme(colorArray, 3);
        }
        private void rasterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chart3DControl.RasterType = (RasterType)this.rasterTypeComboBox.SelectedIndex;
        }
        private void resetPositionButton_Click(object sender, EventArgs e)
        {
            this.chart3DControl.SetCoefficients(1350, 70, 230);
        }
        private void saveImageButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "PNG 이미지 저장하기";
            saveFileDialog.Filter = "PNG 이미지|*.png";
            saveFileDialog.DefaultExt = ".png";

            if (DialogResult.Cancel == saveFileDialog.ShowDialog(this))
            {
                return;
            }

            Bitmap bitmap = this.chart3DControl.GetBitmap();

            try
            {
                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
            catch (Exception exception)
            {
                MessageBox.Show(this, exception.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetFunction1()
        {
            RendererDelegate rendererDelegate = delegate (double X, double Y)
            {
                double r = 0.15 * Math.Sqrt(X * X + Y * Y);

                if (r < 1e-10)
                {
                    return 120;
                }
                else
                {
                    return 120 * Math.Sin(r) / r;
                }
            };

            this.chart3DControl.SetFunction
            (
                rendererDelegate,
                new PointF(-120f, -80f),
                new PointF(120f, 80f),
                5d,
                NormalizeType.MaintainXYZ
            );
        }
        private void SetFunction2()
        {
            string formula = "12 * sin(x) * cos(y) / (sqrt(sqrt(x * x + y * y)) + 0.2)";

            try
            {
                RendererDelegate rendererDelegate = FunctionCompiler.Compile(formula);

                this.chart3DControl.SetFunction
                (
                    rendererDelegate,
                    new PointF(-10f, -10f),
                    new PointF(10f, 10f),
                    0.5d,
                    NormalizeType.MaintainXYZ
                );
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSurfacePoints()
        {
            int[,] valueArray = new int[,]
            {
                { 34767, 34210, 33718, 33096, 32342, 31851, 31228, 30867, 31457, 30867, 30266, 28934, 27984, 26492, 25167, 25167, 25167},
                { 34669, 34210, 33653, 33096, 32539, 32047, 31490, 30933, 31293, 30671, 29983, 28803, 27886, 26492, 25167, 25167, 25167},
                { 34603, 34144, 33718, 33227, 32768, 32342, 31719, 30999, 31228, 30333, 29622, 28606, 27886, 26492, 25167, 25167, 25167},
                { 34472, 34079, 33653, 33161, 32768, 32408, 31785, 31162, 30802, 30048, 29360, 28312, 27755, 26367, 25049, 25049, 25049},
                { 34210, 33784, 33423, 33161, 32801, 32408, 31785, 31097, 30474, 29622, 29000, 28115, 27623, 26367, 25049, 25049, 25049},
                { 33980, 33587, 33161, 32935, 32588, 32342, 31621, 30802, 29852, 29000, 28377, 27689, 27421, 26367, 25049, 25049, 25049},
                { 33522, 33227, 32702, 32615, 32452, 31851, 30933, 30179, 29295, 28358, 27984, 27132, 27301, 26367, 25049, 25049, 25049},
                { 32672, 32178, 31916, 31469, 31246, 30540, 29852, 29065, 28377, 27623, 27263, 26706, 26935, 26367, 25049, 25049, 25049},
                { 30769, 30423, 29917, 29231, 29392, 28705, 28075, 27726, 27263, 26691, 26417, 26182, 26575, 26575, 25246, 25246, 25246},
                { 27525, 27518, 26701, 27334, 27682, 27402, 26903, 26707, 26444, 25887, 25719, 25690, 26122, 26122, 26122, 26122, 26122},
                { 23475, 23888, 24478, 25330, 26212, 26199, 25701, 25664, 25740, 25013, 24904, 25068, 25374, 25374, 25374, 25374, 25374},
                { 20677, 21445, 22544, 23593, 24441, 24785, 24538, 24644, 24773, 24299, 24062, 24576, 24510, 24510, 24510, 24510, 24510},
                { 18743, 19792, 20808, 22086, 22805, 23167, 23486, 23366, 23757, 23411, 23691, 23822, 23822, 23822, 23822, 23822, 23822},
                { 17334, 18579, 19497, 20775, 21463, 21848, 22288, 22446, 22643, 22446, 22643, 22708, 23069, 23069, 23069, 23069, 23069},
                { 16155, 17236, 18350, 19399, 20251, 20677, 21016, 21332, 21660, 21791, 21889, 21955, 22217, 22217, 22217, 22217, 22217},
                { 14746, 15860, 17039, 17990, 18842, 19595, 20050, 20349, 20546, 20840, 20972, 20972, 21332, 21332, 21332, 21332, 21332},
                { 13337, 14516, 15729, 16679, 17564, 18514, 18907, 19169, 19399, 19661, 19792, 19594, 20152, 20152, 20152, 20152, 20152},
                { 12452, 13435, 14615, 15499, 16253, 17105, 17596, 17924, 18153, 18285, 18428, 18776, 19104, 19104, 19104, 19104, 19104},
                { 11469, 12354, 13533, 14287, 15008, 15925, 16187, 16482, 16690, 16976, 17105, 17302, 17531, 17531, 17531, 17531, 17531},
                { 10486, 11370, 12255, 13009, 13861, 14746, 15172, 15368, 15434, 15630, 15794, 15991, 16351, 16351, 16351, 16351, 16351},
                {  9684, 10387, 11141, 11796, 12546, 13337, 14029, 14320, 14549, 14811, 14939, 15434, 15794, 15794, 15794, 15794, 15794},
                {  9059,  9634, 10617, 11141, 11838, 12681, 13411, 13861, 14121, 14624, 14868, 15172, 15368, 15368, 15368, 15368, 15368}
            };

            Point3D[,] pointArray = new Point3D[valueArray.GetLength(0), valueArray.GetLength(1)];

            for (int x = 0; x < valueArray.GetLength(0); x++)
            {
                for (int y = 0; y < valueArray.GetLength(1); y++)
                {
                    pointArray[x, y] = new Point3D(x * 10, y * 500, valueArray[x, y]);
                }
            }

            this.chart3DControl.AxisXLegend = "MAP (kPa)";
            this.chart3DControl.AxisYLegend = "Engine Speed (rpm)";
            this.chart3DControl.AxisZLegend = "ADS";

            this.chart3DControl.SetSurfacePoints(pointArray, NormalizeType.Separate);
        }
        private void SetScatterPoints(bool drawLine)
        {
            List<Scatter> scallterList = new List<Scatter>();

            for (double p = -33d; p < 33d; p += 0.1d)
            {
                double x = Math.Sin(p) * p;
                double y = Math.Cos(p) * p;
                double z = p;

                //if (z > 0d)
                //{
                //    z /= 3d;
                //}

                scallterList.Add(new Scatter(x, y, z, null));
            }

            if (drawLine)
            {
                this.chart3DControl.SetScatterLines(scallterList.ToArray(), NormalizeType.Separate, 3f);
            }
            else
            {
                this.chart3DControl.SetScatterPoints(scallterList.ToArray(), NormalizeType.Separate);
            }
        }
        private void SetScatterPoints()
        {
            List<Scatter> scatterList = new List<Scatter>();

            double x = 0.0d;
            double z = 0.0d;

            for (double p = 0.0d; p <= Math.PI * 1.32d; p += 0.025d)
            {
                x = Math.Cos(p) * 1.5d - 1.5d;
                z = Math.Sin(p) * 3.0d + 6.0d;

                scatterList.Add(new Scatter(x, -x, z, Brushes.Red));
                scatterList.Add(new Scatter(-x, x, z, Brushes.Red));
            }

            double deltaX = x / 70d;
            double deltaZ = z / 70d;

            while (z >= 0.0d)
            {
                scatterList.Add(new Scatter(x, -x, z, Brushes.Red));
                scatterList.Add(new Scatter(-x, x, z, Brushes.Red));

                x -= deltaX;
                z -= deltaZ;
            }

            this.chart3DControl.SetScatterPoints(scatterList.ToArray(), NormalizeType.MaintainXYZ);
        }
        public static void Example8() //================[ Basic DFT + Signal & Noise + Log Magnitude ]================
        {
            // Same Input Signal as Example 1, except amplitude is 5 Vrms.
            double amplitude = 5.0; 
            double frequency = 20000;
            UInt32 length = 1000; double samplingRate = 100000;
            double[] inputSignal = DSP.Generate.ToneSampling(amplitude, frequency, samplingRate, length);

            // Add noise that is about 80 dBc from signal level
            // 80 dBc is about the level of noise from a 14 bit ADC
            // 1/10,000 down from full scale
            double[] inputNoise = DSP.Generate.NoiseRms(amplitude / 10000.0, length);

            // Add noise to the signal
            double[] compositeInput = DSP.Math.Add(inputSignal, inputNoise);

            // Use the BH92 type window - this is a very "Spectrum Analyzer" like window.
            // Apply window to the Input Data & calculate Scale Factor
            double[] wCoefs = DSP.Window.Coefficients(DSP.Window.Type.BH92, length);
            double wScaleFactor = DSP.Window.ScaleFactor.Signal(wCoefs);
            double[] wInputData = DSP.Math.Multiply(compositeInput, wCoefs);

            // Instantiate & Initialize a new DFT
            DSPLib.DFT dft = new DSPLib.DFT();
            dft.Initialize(length);

            // Call the DFT and get the scaled spectrum back
            Complex[] cSpectrum = dft.Execute(wInputData);

            // Convert the complex spectrum to note: Magnitude Format
            double[] lmSpectrum = DSP.ConvertComplex.ToMagnitude(cSpectrum);

            // Properly scale the spectrum for the added window
            lmSpectrum = DSP.Math.Multiply(lmSpectrum, wScaleFactor);

            // Convert from linear magnitude to log magnitude format
            double[] logMagSpectrum = DSP.ConvertMagnitude.ToMagnitudeDBV(lmSpectrum);

            // For plotting on an XY Scatter plot generate the X Axis frequency Span
            double[] freqSpan = dft.FrequencySpan(samplingRate);

            // At this point a XY Scatter plot can be generated from,
            // X axis => freqSpan
            // Y axis => logMagSpectrum

            // In this example - maximum amplitude of 13.974 dBV is at bin 200 (20,000 Hz)
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
            xIndx++;
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
                    Set_Series1(i, aAreaSel[i], 5, ChartDashStyle.Solid, sColor[i]);
                }
                xIndx = 0;
                bMinMaxInit_1 = true;

                Update_textBox();

                //strThis = "";
                //preIndex = 0;
                //textFuncIndex = 0;
            }
        }
        private void Set_Chart2()
        {
            chart2.ChartAreas.Clear();
            chart2.Series.Clear();
            scallterList.Clear();

            if (nSeries != 0)
            {
                Set_Area2(1);
                for (int i = 0; i < nSeries; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[0]);
                            break;
                        case 1:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[1]);
                            break;
                        case 2:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[2]);
                            break;
                        case 3:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[3]);
                            break;
                        case 4:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[4]);
                            break;
                        case 5:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[5]);
                            break;
                        case 6:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[6]);
                            break;
                        case 7:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[7]);
                            break;
                        default:
                            Set_Series2(i, aAreaSel[i], 5, ChartDashStyle.Dot, sColor[7]);
                            break;
                    }
                }
            }
            bMinMaxInit_2 = true;
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
                string strArea = "A";// "Chart Area ";
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
                chart1.ChartAreas[i].AxisY.Minimum = 0;
                chart1.ChartAreas[i].AxisY.Maximum = 0.0001;
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
        private void Set_Area2(int n_area)
        {
            for (int i = 0; i < n_area; i++)
            {
                string strArea = "B";// "Chart Area ";
                strArea += Convert.ToString(i);

                chart2.ChartAreas.Add(strArea);

                //chart1.ChartAreas[i].InnerPlotPosition = new System.Windows.Forms.DataVisualization.Charting.ElementPosition(2, -5, 80, 90);    // X, Y, W, H
                //chart1.ChartAreas[i].InnerPlotPosition = new System.Windows.Forms.DataVisualization.Charting.ElementPosition(2, 0, 100, 100);    // X, Y, W, H
                chart2.ChartAreas[i].AxisX.ScaleView.Zoomable = true;
                chart2.ChartAreas[i].AxisX.Interval = 0.5;
                chart2.ChartAreas[i].AxisY.Interval = 0;
                //chart1.ChartAreas[i].AxisX.IntervalOffset = -1;

                //chart1.ChartAreas[i].AxisX.Title = "PI(π)";
                chart2.ChartAreas[i].AxisY.Title = "Value" + Convert.ToString(i);
                chart2.ChartAreas[i].AxisX.TitleFont = new System.Drawing.Font("Consolas", 9, System.Drawing.FontStyle.Bold); // ###GUN              
                chart2.ChartAreas[i].AxisX.TitleForeColor = Color.White;
                chart2.ChartAreas[i].AxisY.TitleForeColor = Color.White;
                chart2.ChartAreas[i].AxisX.TitleAlignment = StringAlignment.Far; // ###GUN 가운데 -> 오른쪽 끝

                chart2.ChartAreas[i].AxisX.LabelStyle.Format = "0.0";  // "#.##"
                chart2.ChartAreas[i].AxisX.LabelStyle.Enabled = true;
                chart2.ChartAreas[i].AxisX.LabelStyle.Angle = 0;
                chart2.ChartAreas[i].AxisX.LabelStyle.IsEndLabelVisible = false;    // ###GUN!!!
                chart2.ChartAreas[i].AxisY.LabelStyle.Format = "0.00";  // ###GUN
                chart2.ChartAreas[i].AxisX.LabelStyle.ForeColor = Color.White;
                chart2.ChartAreas[i].AxisY.LabelStyle.ForeColor = Color.White;
                //chart1.ChartAreas[i].AxisX.LabelStyle.Font          = new System.Drawing.Font("Trebuchet MS", 15, System.Drawing.FontStyle.Bold);
                //chart1.ChartAreas[i].AxisY.LabelStyle.Font          = new System.Drawing.Font("Trebuchet MS", 15, System.Drawing.FontStyle.Bold);

                chart2.ChartAreas[i].AxisX.LineColor = Color.FromArgb(150, 150, 150);
                chart2.ChartAreas[i].AxisY.LineColor = Color.FromArgb(150, 150, 150);

                chart2.ChartAreas[i].AxisX.MajorGrid.Interval = 0;  // ###GUN 0: Auto
                chart2.ChartAreas[i].AxisY.MajorGrid.Interval = 0;
                //chart1.ChartAreas[i].AxisX.MajorGrid.Enabled = true;
                chart2.ChartAreas[i].AxisX.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart2.ChartAreas[i].AxisY.MajorGrid.LineColor = Color.FromArgb(100, 100, 100);
                chart2.ChartAreas[i].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart2.ChartAreas[i].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

                chart2.BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B); // ###GUN
                chart2.ChartAreas[i].BackColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);
                chart2.ChartAreas[i].BackSecondaryColor = Color.FromArgb(BACK_COLOR_R, BACK_COLOR_G, BACK_COLOR_B);

                chart2.ChartAreas[i].AxisX.MajorTickMark.LineColor = Color.FromArgb(100, 100, 100);    // ###GUN
                chart2.ChartAreas[i].AxisY.MajorTickMark.LineColor = Color.FromArgb(100, 100, 100);
                chart2.ChartAreas[i].AxisX.MinorTickMark.LineColor = Color.FromArgb(100, 100, 100);
                chart2.ChartAreas[i].AxisY.MinorTickMark.LineColor = Color.FromArgb(100, 100, 100);

                //chart1.ChartAreas[i].AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Auto;   // X축 이름 회전
                //chart1.ChartAreas[i].AxisX.IsReversed = true;   // ###GUN : 그래프 이동 방향 우에서 좌로
                //chart1.ChartAreas[i].AxisY.IsReversed = true;   // ###GUN : 그래프 이동 방향 위에서 아래로       
                //chart2.ChartAreas[i].AxisY.Minimum = 0.0;
                //chart2.ChartAreas[i].AxisY.Maximum = 0.0001;
                //chart1.ChartAreas[i].AxisX.Enabled = AxisEnabled.True;
                //chart1.ChartAreas[i].AxisY.Enabled = AxisEnabled.True;
                ////chart1.ChartAreas[i].AlignWithChartArea = strArea;
                ////chart1.ChartAreas[i].AlignmentStyle = AreaAlignmentStyles.Position;
                ////chart1.ChartAreas[i].AlignmentOrientation = AreaAlignmentOrientations.Vertical;

                //chart1.ChartAreas[i].CursorX.IsUserSelectionEnabled = true;
                //chart1.ChartAreas[i].CursorX.AutoScroll = true;
                //chart1.ChartAreas[i].CursorY.AutoScroll = true;
                /* Y축 Measure Line */
                chart2.ChartAreas[i].CursorX.LineColor = Color.Red;
                chart2.ChartAreas[i].CursorY.LineColor = Color.Red;
                chart2.ChartAreas[i].CursorX.LineDashStyle = ChartDashStyle.Dot;
                chart2.ChartAreas[i].CursorY.LineDashStyle = ChartDashStyle.Dot;
                chart2.ChartAreas[i].CursorX.Interval = 0;  // ###GUN
                chart2.ChartAreas[i].CursorY.Interval = 0;

                chart2.ChartAreas[i].AxisX.Title = "PI(π)";
            }
            //chart1.ChartAreas[n_area - 1].AxisX.Title = "PI(π)";

            // ###GUN En:4 x 1, Dis:2 x 2
            if (bChartVertical == true)
            {
                float currentHeight = 3;
                foreach (var itm in chart1.ChartAreas)
                {
                    itm.Position.Height = 97 / chart1.ChartAreas.Count; // Note: the valus are in percenteges and not absolute pixels
                    itm.Position.Y = currentHeight;
                    itm.Position.X = 5;
                    itm.Position.Width = 95;
                    currentHeight += 97 / chart1.ChartAreas.Count;
                }
            }
        }
        private void Set_Series1(int series_idx, int area_idx, int marker_size, ChartDashStyle dash, Color color)
        {
            string strSeries = "S"; // Series ";
            strSeries += Convert.ToString(series_idx);
            chart1.Series.Add(strSeries);
            string strArea = "A";   // "Chart Area ";
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
        private void Set_Series2(int series_idx, int area_idx, int marker_size, ChartDashStyle dash, Color color)
        {
            string strSeries = "S";  //eries ";
            strSeries += Convert.ToString(series_idx);
            chart2.Series.Add(strSeries);
            string strArea = "B";// "Chart Area ";
            strArea += Convert.ToString(0);
            chart2.Series[series_idx].ChartArea = strArea;
            chart2.Series[series_idx].ChartType = SeriesChartType.Line;
            chart2.Series[series_idx].XValueType = ChartValueType.Double;
            chart2.Series[series_idx].YValueType = ChartValueType.Double;
            chart2.Series[series_idx].MarkerSize = marker_size;
            chart2.Series[series_idx].MarkerStyle = MarkerStyle.Circle; //MarkerStyle.None; //MarkerStyle.Circle;   //MarkerStyle.None;    // ###GUN
            chart2.Series[series_idx].BorderWidth = 1;
            chart2.Series[series_idx].BorderDashStyle = dash;
            chart2.Series[series_idx].Color = color;
            chart2.Series[series_idx].IsVisibleInLegend = false;
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
                    //double difData;
                    //
                    //difData = yData - preData[i];
                    //preData[i] = yData;
                    //
                    //if (true)
                    //{
                    //    chart1.Series[i].Points.AddXY(xData, yData);
                    //}
                    //else
                    //{
                    //    chart1.Series[i].Points.AddXY(xData, difData);
                    //}

                    if (bMinMaxInit_1 == true)
                    {
                        chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum = 0.0;
                        chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum = 0.00001;
                    }
                    //double delta = chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum - chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum;
                    if (yData < chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum)
                    {
                        chart1.ChartAreas[aAreaSel[i]].AxisY.Minimum = yData;
                    }
                    if (yData > chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum)
                    {
                        chart1.ChartAreas[aAreaSel[i]].AxisY.Maximum = yData;
                    }

                    if (chart1.Series[i].Points.Count > Convert.ToInt32(textBox_dispcount.Text))
                    {
                        for (int j = 0; j < chart1.Series[i].Points.Count - Convert.ToInt32(textBox_dispcount.Text); j++)
                        {
                            chart1.Series[i].Points.RemoveAt(0);
                        }
                    }
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Minimum = chart1.Series[i].Points[0].XValue;
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Maximum = xData;
                    chart1.ChartAreas[aAreaSel[i]].AxisX.Interval = 0.5 * ((chart1.Series[i].Points.Count / 300)+1);
                }
                bMinMaxInit_1 = false;
                //xIndx++;
            }
        }
        private void Draw_Chart2(double[] buffer, int size)
        {
            if (chart1.InvokeRequired)
            {
                Draw_Chart2Delegate del = new Draw_Chart2Delegate(Draw_Chart2);
                chart2.Invoke(del, new object[] { buffer, size });
            }
            else
            {
                for (int i = 0; i < nSeries; i++)
                {
                    double yData = buffer[i];
                    double xData = 2 * xIndx / PERIOD_COUNT;  // (2*pi/PERIOD_COUNT) * xIndx

                    double[] mixXY = new double[2];
                    mixXY[0] = 1;
                    mixXY[1] = 1;
                    MatchCollection mcs;
                    bool xAxis = false;
                    for (int xy = 0; xy < 2; xy++)
                    {
                        mcs = Regex.Matches(strMixXY[xy], @"(y|x|sin|cos|tan|asin|acos|atan)");
                        for (int j = 0; j < mcs.Count; j++)
                        {
                            if (mcs[j].Value == "y")
                            {
                                mixXY[xy] *= yData;
                            }
                            else if (mcs[j].Value == "x")
                            {
                                mixXY[xy] *= xData;
                                xAxis = true;
                            }
                            else if (mcs[j].Value == "sin")
                            {
                                mixXY[xy] *= Math.Sin(xData * Math.PI);
                            }
                            else if (mcs[j].Value == "cos")
                            {
                                mixXY[xy] *= Math.Cos(xData * Math.PI);
                            }
                            else if (mcs[j].Value == "tan")
                            {
                                mixXY[xy] *= Math.Tan(xData * Math.PI);
                            }
                            else if (mcs[j].Value == "asin")    
                            {
                                mixXY[xy] *= Math.Asin(yData);
                            }
                            else if (mcs[j].Value == "acos")
                            {
                                mixXY[xy] *= Math.Acos(yData);              
                            }
                            else if (mcs[j].Value == "atan")                /* y = rsin(θ), x = rcos(θ), θ = atan(y/x) */
                            {
                                mixXY[xy] *= Math.Atan(yData / Math.Cos(xData * Math.PI));
                            }
                        }
                    }
                    chart2.Series[i].Points.AddXY(mixXY[0], mixXY[1]);

                    if (i == 0)
                    {
                        double x = mixXY[0];// Math.Sin(xIndx * 0.1);
                        double y = mixXY[1];// Math.Cos(xIndx * 0.1);
                        double z = xIndx;
                        
                        scallterList.Add(new Scatter(x, y, z, null));
                        this.chart3DControl.SetScatterLines(scallterList.ToArray(), NormalizeType.Separate, 3f);

                        //RendererDelegate rendererDelegate = delegate (double X, double Y)
                        //{
                        //    double r = 0.15 * Math.Sqrt(X * X + Y * Y);
                        //
                        //    if (r < 1e-10)
                        //    {
                        //        return 120;
                        //    }
                        //    else
                        //    {
                        //        return 120 * Math.Sin(r) / r;
                        //    }
                        //};
                    }

                    if (bMinMaxInit_2 == true)
                    {
                        chart2.ChartAreas[0].AxisY.Minimum = 0.0;
                        chart2.ChartAreas[0].AxisY.Maximum = 0.00001;
                    }
                    if (mixXY[1] < chart2.ChartAreas[0].AxisY.Minimum)
                    {
                        chart2.ChartAreas[0].AxisY.Minimum = mixXY[1];
                    }
                    if (mixXY[1] > chart2.ChartAreas[0].AxisY.Maximum)
                    {
                        chart2.ChartAreas[0].AxisY.Maximum = mixXY[1];
                    }
                    if (xAxis == true)
                    {
                        chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[i].Points[0].XValue;
                        chart2.ChartAreas[0].AxisX.Maximum = xData;
                        chart2.ChartAreas[0].AxisX.Interval = 0.5 * ((chart2.Series[i].Points.Count / 300) + 1);
                    }
                    
                    if (chart2.Series[i].Points.Count > Convert.ToInt32(textBox_resolution.Text))
                    {
                        for (int j = 0; j < chart2.Series[i].Points.Count - Convert.ToInt32(textBox_resolution.Text); j++)
                        {
                            chart2.Series[i].Points.RemoveAt(0);
                        }
                    }
                }
                bMinMaxInit_2 = false;
                //xIndx++;             
                
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

 //         MatchCollection mc = Regex.Matches(name, @"(Sin|Cos|Tan)\([^\(]+\){1}", RegexOptions.None, TimeSpan.FromSeconds(1));
            MatchCollection mc0 = Regex.Matches(name, @"(Sin|Cos|Tan)\([^\(]+\){2}");
            MatchCollection mc = Regex.Matches(name, @"(Sin|Cos|Tan)\([^\(]+\)");
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
                if (mc0.Count != 0)
                {
                    name = name.Remove(mc[mc.Count - j - 1].Index, mc[mc.Count - j - 1].Length - 1);
                }
                else
                {
                    name = name.Remove(mc[mc.Count - j - 1].Index, mc[mc.Count - j - 1].Length);
                }
                name = name.Insert(mc[mc.Count - j - 1].Index, Convert.ToString(dblSin));
            }
          
            Match mmm = Regex.Match(name, @"[^\d\.\+\-\*\/Ee\(\)]");
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
                            Draw_Chart2(item, nSeries);
                            xIndx++;
                            return;
                        }
                    }
                }
            }
 
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            checkIndex = 0;
            timer2.Stop();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            List<ChartArea> Areas = new List<ChartArea>();
            int numberOfAreas = 5;
            for (int k = 1; k <= numberOfAreas; k++)
            {
                var S1 = new System.Windows.Forms.DataVisualization.Charting.Series();  // MathNet.Numerics.Series 와 구분
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
                Set_Chart2();
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
            Set_Chart2();
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
                System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
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
                        //textFuncIndex = 0;
                        Set_Chart1();
                        Set_Chart2();
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
                            textFunc[tbIndex].Text = str.Substring(str.IndexOf(":") + 1);
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
                        Set_Chart2();
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
                        Set_Chart2();
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
                        mc = Regex.Match(str, @"\(\d+,\d+\)");  // (1,2)
                        if (mc.Success)
                        {
                            mcs = Regex.Matches(mc.Value, @"\d+");
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
                        }
                        mc = Regex.Match(str, @"-a\d*");            // -a
                        if (mc.Success)
                        {
                            mc = Regex.Match(str, @"-a\d+");        // -a4
                            if (mc.Success)
                            {
                                int n = Convert.ToInt32(mc.Value.Substring(2, mc.Value.Length - 2));
                                mc = Regex.Match(str, @"-d");       // distribute
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
                                            checks[i, j].Checked = false;
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
                        mc = Regex.Match(str, @"-d[ftblr]");                // docking
                        if (mc.Success)
                        {
                            if (mc.Value.Substring(2, 1) == "f")            // docking fill
                            {
                                chart2.Visible = false;
                                chart3DControl.Visible = false;
                                textBox_Mix.Visible = false;
                                chart1.Dock = DockStyle.Fill;
                            }
                            else if (mc.Value.Substring(2, 1) == "t")       // docking top
                            {
                                chart2.Visible = false;
                                chart3DControl.Visible = false;
                                textBox_Mix.Visible = false;
                                chart1.Dock = DockStyle.Top;
                            }
                            else if (mc.Value.Substring(2, 1) == "b")       // docking bottom
                            {
                                chart2.Visible = false;
                                chart3DControl.Visible = false;
                                textBox_Mix.Visible = false;
                                chart1.Dock = DockStyle.Bottom;
                            }
                            else if (mc.Value.Substring(2, 1) == "l")       // docking left
                            {
                                chart1.Dock = DockStyle.Left;
                                chart2.Width = chart1.Width;
                                chart2.Height = chart1.Height;
                                /////chart2.Visible = true;
                                chart3DControl.Width = chart1.Width;
                                chart3DControl.Height = chart1.Height;
                                chart3DControl.Visible = true;
                                textBox_Mix.Visible = true;
                            }
                            else if (mc.Value.Substring(2, 1) == "r")       // docking right
                            {
                                chart1.Dock = DockStyle.Right;
                                chart2.Width = chart1.Width;
                                chart2.Height = chart1.Height;
                                /////chart2.Visible = true;
                                chart3DControl.Visible = true;
                                textBox_Mix.Visible = true;
                            }
                        }
                        mc = Regex.Match(str, @"-v");                       // vertical
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
                            Set_Chart2();
                        }
                        mc = Regex.Match(str, @"-wm");                      // window miximized
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
                        //mc = Regex.Match(str, @"-p\(.+,.+\)$");             // chart2 shape
                        mc = Regex.Match(str, @"-p\((y|x|sin|cos|tan|asin|acos|atan|\*)+,(y|x|sin|cos|tan|asin|acos|atan|\*)+\)$");
                        if (mc.Success)
                        {
                            textBox_Mix.Text = mc.Value.Substring(mc.Value.IndexOf("("));
                            strMixXY[0] = mc.Value.Substring(mc.Value.IndexOf("(") + 1, (mc.Value.IndexOf(",") - 1) - mc.Value.IndexOf("("));
                            strMixXY[1] = mc.Value.Substring(mc.Value.IndexOf(",") + 1, (mc.Value.IndexOf(")") - 1) - mc.Value.IndexOf(","));
                            Set_Chart2();
                        }
                    }
                    else
                    {
                        /* sin, COS, pi -> Sin, Cos, PI */
                        //lastLine = Regex.Replace(lastLine, "sin", "sin", RegexOptions.IgnoreCase);
                        //lastLine = Regex.Replace(lastLine, "cos", "cos", RegexOptions.IgnoreCase);
                        //lastLine = Regex.Replace(lastLine, "tan", "tan", RegexOptions.IgnoreCase);
                        //if ((lastLine.IndexOf("sin") != -1) || (lastLine.IndexOf("cos") != -1) || (lastLine.IndexOf("tan") != -1))
                        //mc = Regex.Match(lastLine, @"[abdefghjklmpqruvwyz]");
                        //if (mc.Success) return;
                        //mc = Regex.Match(lastLine, @"(sn|cs|tn)");
                        //if (mc.Success) return;
                        mc = Regex.Match(lastLine, @"[^sincostanx0-9\.\+\-\*\/\(\)]+");
                        if (mc.Success)
                        {
                            Console.WriteLine("E1");
                            return;
                        }
                        mc = Regex.Match(lastLine, @"(s[^i\(]+|c[^o]+|t[^a]+|[^s]+i|[^c]+o|[^t]+a)");                       
                        //mc = Regex.Match(lastLine, @"(s[^i\(]+|c[^o]+|t[^a]+)");
                        if (mc.Success)
                        {
                            Console.WriteLine("E2");
                            return;
                        }
                        textFunc[COLUMN_N - 1].Text = textBox_Cmd.Text;
                        textFunc[COLUMN_N - 1].Text = textFunc[COLUMN_N - 1].Text.Replace("\r\n", "");
                        textFunc[COLUMN_N - 1].Text = textFunc[COLUMN_N - 1].Text.Replace(" ", "");

                        textDisp[COLUMN_N - 1] = textFunc[COLUMN_N - 1].Text;
                        //e.Handled = true;   // ###GUN 이것이 없으면 경고음 발생
                        if (textFunc[COLUMN_N - 1].Text.Length < preIndex)
                        {
                            preIndex = 0;
                            Console.WriteLine("preIndex error");
                        }
                        //strThis = textFunc[COLUMN_N - 1].Text.Substring(preIndex, textFunc[COLUMN_N - 1].Text.Length - preIndex);
                        //textFunc[textFuncIndex % (ROW_N - 1)].Text = strThis;
                        //textFuncIndex++;
                        //preIndex = textFunc[COLUMN_N - 1].Text.Length;
                        //Update_textBox();
                        //Console.WriteLine(strThis);
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Shift) == Keys.Shift && e.KeyCode == Keys.W)
            {
                if (WindowState == FormWindowState.Maximized)
                //if (bWindow == false)
                {
                    WindowState = FormWindowState.Normal;
                    //bWindow = true;
                    //ClientSize = new Size(1630, 700);
                }
                else
                {
                    WindowState = FormWindowState.Maximized;
                    //bWindow = false;
                    //ClientSize = new Size(1920, 1024);
                }
                if (bDocking == true)
                {
                    chart2.Visible = false;
                    textBox_Mix.Visible = false;
                    chart1.Dock = DockStyle.Fill;
                }
                else
                {
                    chart1.Dock = DockStyle.Left;
                    chart1.Width = splitContainer3.Panel1.Width / 2;
                    chart2.Width = splitContainer3.Panel1.Width / 2;
                    chart2.Height = chart1.Height;
                    /////chart2.Visible = true;
                    chart3DControl.Width = splitContainer3.Panel1.Width / 2;
                    chart3DControl.Height = chart1.Height;
                    chart3DControl.Visible = true;
                    textBox_Mix.Visible = true;
                }
                textBox_Cmd.Focus();
                e.SuppressKeyPress = true;
            }
            else if ((e.Modifiers & Keys.Shift) == Keys.Shift && e.KeyCode == Keys.O)
            {
                if (bOverlap == false)
                {
                    bOverlap = true;
                    for (int i = 0; i < ROW_N; i++)
                    {
                        for (int j = 0; j < COLUMN_N; j++)
                        {
                            if (checks[i, j].Checked == true)
                            {
                                checks[i, 0].Checked = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    bOverlap = false;
                    for (int i = 0; i < ROW_N; i++)
                    {
                        for (int j = 0; j < COLUMN_N; j++)
                        {
                            if (checks[i, j].Checked == true)
                            {
                                checks[i, i].Checked = true;
                                break;
                            }
                        }
                    }
                }
                textBox_Cmd.Focus();
                e.SuppressKeyPress = true;
            }
            else if ((e.Modifiers & Keys.Shift) == Keys.Shift && e.KeyCode == Keys.D)
            {
                if (bDocking == false)
                {
                    bDocking = true;
                    chart2.Visible = false;
                    chart3DControl.Visible = false;
                    textBox_Mix.Visible = false;
                    chart1.Dock = DockStyle.Fill;
                }
                else
                {
                    bDocking = false;
                    chart1.Dock = DockStyle.Left;
                    chart1.Width = splitContainer3.Panel1.Width / 2;
                    chart2.Width = splitContainer3.Panel1.Width / 2;
                    chart2.Height = chart1.Height;
                    /////chart2.Visible = true;
                    chart3DControl.Width = splitContainer3.Panel1.Width / 2;
                    chart3DControl.Height = chart1.Height;
                    chart3DControl.Visible = true;
                    textBox_Mix.Visible = true;
                }
                textBox_Cmd.Focus();    //this.ActiveControl = textBox_Cmd;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                textBox0.Text = "sin(x)";
                textBox1.Text = "cos(x)";
                textBox2.Text = "sin(2x)";
                textBox3.Text = "cos(2x)";
                textBox4.Text = "sin(3x)";
                textBox5.Text = "cos(3x)";
                textBox6.Text = "sin(4x)";
                textBox7.Text = "sin(x)+cos(x)+sin(2x)+cos(2x)+sin(3x)+cos(3x)+sin(4x)";
                Update_textBox();
                Set_Chart1();
                Set_Chart2();
                startToggle = false;
                button_Start_Click(sender, e);
                textBox_Cmd.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (checkIndex == 0)
                {
                    for (int row = 0; row < ROW_N; row++)
                    {
                        checks[row, 0].Checked = false;
                    }
                }
                checks[checkIndex++, 0].Checked = true;
                checkIndex %= 8;
                timer2.Stop();
                timer2.Interval = 1000;
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Start();
                textBox_Cmd.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (checkIndex == 0)
                {
                    for (int row = 0; row < ROW_N; row++)
                    {
                        for (int col = 0; col < COLUMN_N; col++)
                        {
                            checks[row, col].Checked = false;
                        }
                    }
                }
                checks[checkIndex, checkIndex].Checked = true;
                checkIndex++;
                checkIndex %= 8;
                timer2.Stop();
                timer2.Interval = 500;
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Start();
                textBox_Cmd.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F8)
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
                Set_Chart2();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (chart2.Visible == true)
                {
                    chart2.Visible = false;
                    chart3DControl.Visible = true;
                }
                else if (chart3DControl.Visible == true)
                {                   
                    chart3DControl.Visible = false;
                    chart2.Visible = true;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //UInt32 N = Convert.ToUInt32(txtN.Text);
            //UInt32 zeros = Convert.ToUInt32(txtZp.Text);
            //double samplingRateHz = Convert.ToDouble(txtFs.Text);
            //
            //txtPoints.Text = (N + zeros).ToString();
            //
            //string selectedWindowName = cmbWindow.SelectedValue.ToString();
            //DSPLib.DSP.Window.Type windowToApply = (DSPLib.DSP.Window.Type)Enum.Parse(typeof(DSPLib.DSP.Window.Type), selectedWindowName);
            //
            //// Update the output window
            //txtPoints.Text = (N + zeros).ToString();
            //
            //// Make time series data
            //double[] timeSeries = GenerateTimeSeriesData(N);
            //
            //// Apply window to the time series data
            //double[] wc = DSP.Window.Coefficients(windowToApply, N);
            //
            //double windowScaleFactor = DSP.Window.ScaleFactor.Signal(wc);
            //double[] windowedTimeSeries = DSP.Math.Multiply(timeSeries, wc);
            //
            ///////// Plot Time Series data
            ///////Plot fig1 = new Plot("Figure 1 - FFT Time Series Input", "Sample", "Volts");
            ///////fig1.PlotData(windowedTimeSeries);
            ///////fig1.Show();
            //
            //// Instantiate & Initialize the FFT class
            //DSPLib.FFT fft = new DSPLib.FFT();
            //fft.Initialize(N, zeros);
            //
            //// Start a Stopwatch
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //
            //// Perform a DFT
            //Complex[] cpxResult = fft.Execute(windowedTimeSeries);
            //
            //// Calculate the elapsed time
            //stopwatch.Stop();
            //txtTime.Text = Convert.ToString(stopwatch.ElapsedMilliseconds / 1.0);
            //
            //// Convert the complex result to a scalar magnitude 
            //double[] magResult = DSP.ConvertComplex.ToMagnitude(cpxResult);
            //magResult = DSP.Math.Multiply(magResult, windowScaleFactor);
            //
            ///////// Plot the DFT Magnitude
            ///////Plot fig2 = new Plot("Figure 2 - FFT Magnitude", "FFT Bin", "Mag (Vrms)");
            ///////fig2.PlotData(magResult);
            ///////fig2.Show();
            //
            //// Calculate the frequency span
            //double[] fSpan = fft.FrequencySpan(samplingRateHz);
            //
            //// Convert and Plot Log Magnitude
            //double[] mag = DSP.ConvertComplex.ToMagnitude(cpxResult);
            //mag = DSP.Math.Multiply(mag, windowScaleFactor);
            //double[] magLog = DSP.ConvertMagnitude.ToMagnitudeDBV(mag);
            ///////Plot fig3 = new Plot("Figure 3 - FFT Log Magnitude ", "Frequency (Hz)", "Mag (dBV)");
            ///////fig3.PlotData(fSpan, magLog);
            ///////fig3.Show();
        }

        private void textBox_resolution_TextChanged(object sender, EventArgs e)
        {

        }
    }
}