using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace Chart_Project
{
    /// <summary>
    /// 차트 3D 컨트롤
    /// </summary>
    public class Chart3DControl : UserControl
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        // 마우스 동작 및 트랙바에 대한 제한 및 기본값
        // 주의 : MIN, MAX 값을 변경하지 않는 것이 좋다.
        // 마우스 요소는 변경에 필요한 마우스 움직임의 양을 정의한다.
        // 화면에서 마우스를 약 1000픽셀 이동하면 최소에서 최대로 또는 그 반대로 이동한다.
        // 배열 값 : MIN, MAX, DEFAULT, MOUSE FACTOR

        /// <summary>
        /// 로 값 배열
        /// </summary>
        public static readonly double[] RHO_VALUE_ARRAY = new double[] { 300, 1800, 1350, 2 };

        /// <summary>
        /// 세타 값 배열
        /// </summary>
        public static readonly double[] THETA_VALUE_ARRAY = new double[] { 10, 170, 70, 0.25 };

        /// <summary>
        /// 파이 값 배열
        /// </summary>
        public static readonly double[] PHI_VALUE_ARRAY = new double[] { 0, 360, 230, 0.4 };

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Instance
        //////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 스캐터 크기
        /// </summary>
        public const int SCATTER_SIZE = 3;

        #endregion

        //////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 축 초과
        /// </summary>
        /// <remarks>축이 가장 높은 X, Y, Z 값보다 10% 더 길다.</remarks>
        private const double AXIS_EXCESS = 1.1;

        /// <summary>
        /// 수직 오프셋
        /// </summary>
        /// <remarks>이상한 이유로 그래프가 세로로 중앙에 있지 않는다.</remarks>
        private const int VERTICAL_OFFSET = -30;

        /// <summary>
        /// 래스터 타입
        /// </summary>
        private RasterType rasterType = RasterType.Off;

        /// <summary>
        /// 축 펜 배열
        /// </summary>
        private Pen[] axisPenArray = new Pen[3];

        /// <summary>
        /// 래스터 펜 배열
        /// </summary>
        private Pen[] rasterPenArray = new Pen[3];

        /// <summary>
        /// 변환
        /// </summary>
        private Transform transform = new Transform();

        /// <summary>
        /// 그리기 객체 리스트
        /// </summary>
        private List<DrawObject> drawObjectList = new List<DrawObject>();

        /// <summary>
        /// 마우스
        /// </summary>
        private Mouse mouse = new Mouse();

        /// <summary>
        /// 오프셋 포인트
        /// </summary>
        private Point offsetPoint = new Point();

        /// <summary>
        /// 축 레전드 문자열 배열
        /// </summary>
        private string[] axisLegendStringArray = new string[3];

        /// <summary>
        /// 축 브러시 배열
        /// </summary>
        private SolidBrush[] axisBrushArray = new SolidBrush[3];

        /// <summary>
        /// 다각선 펜
        /// </summary>
        private Pen polyLinePen;

        /// <summary>
        /// 테두리 펜
        /// </summary>
        private Pen borderPen;

        /// <summary>
        /// 상위 레전드 브러시
        /// </summary>
        private SolidBrush topLegendBrush;

        /// <summary>
        /// 색상 구성표 브러시 배열
        /// </summary>
        private SolidBrush[] colorSchemeBrusheArray;

        /// <summary>
        /// 색상 구성표 펜 배열
        /// </summary>
        private Pen[] colorSchemePenArray;

        /// <summary>
        /// 포인트 배열
        /// </summary>
        private Point3D[,] pointArray;

        /// <summary>
        /// 스캐터 배열
        /// </summary>
        private Scatter[] scatterArray;

        /// <summary>
        /// 범위
        /// </summary>
        private Range3D range;

        /// <summary>
        /// 사분면
        /// </summary>
        private Quadrant quadrant;

        /// <summary>
        /// 포인트 카운트
        /// </summary>
        private int pointCount;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Property
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 래스터 타입 - RasterType

        /// <summary>
        /// 래스터 타입
        /// </summary>
        public RasterType RasterType
        {
            set
            {
                if(this.rasterType != value)
                {
                    this.rasterType = value;

                    this.drawObjectList.Clear();

                    Invalidate();
                }
            }
            get
            {
                return this.rasterType;
            }
        }

        #endregion
        #region 다각형 선 색상 - PolygonLineColor

        /// <summary>
        /// 다각형 선 색상
        /// </summary>
        public Color PolygonLineColor
        {
            set
            {
                if(value.A == 0)
                {
                    this.polyLinePen = null;
                }
                else
                {
                    this.polyLinePen = new Pen(value);
                }

                Invalidate();
            }
            get
            {
                if(this.polyLinePen != null)
                {
                    return this.polyLinePen.Color;
                }
                else
                {
                    return Color.Empty;
                }
            }
        }

        #endregion
        #region 테두리 색상 - BorderColor

        /// <summary>
        /// 테두리 색상
        /// </summary>
        public Color BorderColor
        {
            set
            {
                if(value.A == 0)
                {
                    this.borderPen = null;
                }
                else
                {
                    this.borderPen = new Pen(value);
                }

                Invalidate();
            }
            get
            {
                if(this.borderPen != null)
                {
                    return this.borderPen.Color;
                }
                else
                {
                    return Color.Empty;
                }
            }
        }

        #endregion
        #region 상위 레전드 색상 - TopLegendColor

        /// <summary>
        /// 상위 레전드 색상
        /// </summary>
        public Color TopLegendColor
        {
            set
            {
                this.topLegendBrush = new SolidBrush(value);

                Invalidate();
            }
            get
            {
                if(this.topLegendBrush != null)
                {
                    return this.topLegendBrush.Color;
                }
                else
                {
                    return Color.Empty;
                }
            }
        }

        #endregion
        #region X축 레전드 - AxisXLegend

        /// <summary>
        /// X축 레전드
        /// </summary>
        public string AxisXLegend
        {
            set
            {
                this.axisLegendStringArray[(int)CoordinateType.X] = value;
                
                Invalidate();
            }
            get
            {
                return this.axisLegendStringArray[(int)CoordinateType.X];
            }
        }

        #endregion
        #region Y축 레전드 - AxisYLegend

        /// <summary>
        /// Y축 레전드
        /// </summary>
        public string AxisYLegend
        {
            set
            {
                this.axisLegendStringArray[(int)CoordinateType.Y] = value;
                
                Invalidate();
            }
            get
            {
                return this.axisLegendStringArray[(int)CoordinateType.Y];
            }
        }

        #endregion
        #region Z축 레전드 - AxisZLegend

        /// <summary>
        /// Z축 레전드
        /// </summary>
        public string AxisZLegend
        {
            set
            {
                this.axisLegendStringArray[(int)CoordinateType.Z] = value;
                
                Invalidate();
            }
            get
            {
                return this.axisLegendStringArray[(int)CoordinateType.Z];
            }
        }

        #endregion
        #region X축 색상 - AxisXColor

        /// <summary>
        /// X축 색상
        /// </summary>
        public Color AxisXColor
        {
            set
            {
                SetAxisColor(CoordinateType.X, value);
                
                Invalidate();
            }
            get
            {
                return this.axisPenArray[(int)CoordinateType.X].Color;
            }
        }

        #endregion
        #region Y축 색상 - AxisYColor

        /// <summary>
        /// Y축 색상
        /// </summary>
        public Color AxisYColor
        {
            set
            {
                SetAxisColor(CoordinateType.Y, value);
                
                Invalidate();
            }
            get
            {
                return this.axisPenArray[(int)CoordinateType.Y].Color;
            }
        }

        #endregion
        #region Z축 색상 - AxisZColor

        /// <summary>
        /// Z축 색상
        /// </summary>
        public Color AxisZColor
        {
            set
            {
                SetAxisColor(CoordinateType.Z, value);
                
                Invalidate();
            }
            get
            {
                return this.axisPenArray[(int)CoordinateType.Z].Color;
            }
        }

        #endregion
        #region 포인트 카운트 - PointCount

        /// <summary>
        /// 포인트 카운트
        /// </summary>
        [ReadOnly(true)]
        [Browsable(false)]
        public int PointCount
        {
            get
            {
                return this.pointCount;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - Chart3DControl()

        /// <summary>
        /// 생성자
        /// </summary>
        public Chart3DControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint,  true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = Color.White;

            SetAxisColor(CoordinateType.X, Color.DarkBlue );
            SetAxisColor(CoordinateType.Y, Color.DarkGreen);
            SetAxisColor(CoordinateType.Z, Color.DarkRed  );

            this.polyLinePen    = new Pen(Color.Black, 1);
            this.borderPen      = new Pen(Color.FromArgb(255,180,180,180), 1);
            this.topLegendBrush = new SolidBrush(Color.FromArgb(255,200,200,150));

            this.transform.SetCoeficients(this.mouse);
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public
        //////////////////////////////////////////////////////////////////////////////// Function

        #region 색상 구성표 설정하기 - SetColorScheme(colorArray, lineWidth)

        /// <summary>
        /// 색상 구성표 설정하기
        /// </summary>
        /// <param name="colorArray">색상 배열</param>
        /// <param name="lineWidth">선 너비</param>
        public void SetColorScheme(Color[] colorArray, float lineWidth)
        {
            this.colorSchemeBrusheArray = new SolidBrush[colorArray.Length];
            this.colorSchemePenArray    = new Pen       [colorArray.Length];

            for(int i = 0; i < this.colorSchemeBrusheArray.Length; i++)
            {
                this.colorSchemeBrusheArray[i] = new SolidBrush(colorArray[i]);
                this.colorSchemePenArray   [i] = new Pen(this.colorSchemeBrusheArray[i], lineWidth);
            }

            Invalidate();
        }

        #endregion
        #region 트랙바 할당하기 - AssignTrackBars(rhoTrackBar, thetaTrackBar, phiTrackBar)

        /// <summary>
        /// 트랙바 할당하기
        /// </summary>
        /// <param name="rhoTrackBar">로 트랙바</param>
        /// <param name="thetaTrackBar">세타 트랙바</param>
        /// <param name="phiTrackBar">파이 트랙바</param>
        public void AssignTrackBars(TrackBar rhoTrackBar, TrackBar thetaTrackBar, TrackBar phiTrackBar)
        {
            this.mouse.AssignTrackBar(MouseAction.Rho,   rhoTrackBar,   new EventHandler(trackBar_Scroll));
            this.mouse.AssignTrackBar(MouseAction.Theta, thetaTrackBar, new EventHandler(trackBar_Scroll));
            this.mouse.AssignTrackBar(MouseAction.Phi,   phiTrackBar,   new EventHandler(trackBar_Scroll));
        }

        #endregion
        #region 표면 포인트 설정하기 - SetSurfacePoints(pointArray, normalizeType)

        /// <summary>
        /// 표면 포인트 설정하기
        /// </summary>
        /// <param name="pointArray">포인트 배열</param>
        /// <param name="normalizeType">정규화 타입</param>
        public void SetSurfacePoints(Point3D[,] pointArray, NormalizeType normalizeType)
        {
            this.scatterArray = null;
            this.pointArray   = pointArray;
            this.pointCount   = pointArray.Length;
            this.range        = new Range3D(pointArray);

            if(this.pointCount < 4)
            {
                throw new Exception("Insufficient 3D points specified");
            }

            NormalizeRanges(normalizeType);

            this.mouse.OffsetPoint = Point.Empty;

            this.drawObjectList.Clear();

            Invalidate();
        }

        #endregion
        #region 함수 설정하기 - SetFunction(rendererDelegate, startPoint, endPoint, density, normalizeType)

        /// <summary>
        /// 함수 설정하기
        /// </summary>
        /// <param name="rendererDelegate">렌더러 대리자</param>
        /// <param name="startPoint">시작 포인트</param>
        /// <param name="endPoint">종료 포인트</param>
        /// <param name="density">밀도</param>
        /// <param name="normalizeType">정규화 타입</param>
        public void SetFunction(RendererDelegate rendererDelegate, PointF startPoint, PointF endPoint, double density, NormalizeType normalizeType)
        {
            int countX = (int)((endPoint.X - startPoint.X) / density + 1);
            int countY = (int)((endPoint.Y - startPoint.Y) / density + 1);

            Point3D[,] pointArray = new Point3D[countX, countY];

            for(int c = 0; c < countX; c++)
            {
                double x = startPoint.X + density * c;

                for(int r = 0; r < countY; r++)
                {
                    double Y = startPoint.Y + density * r;
                    double Z = rendererDelegate(x, Y);

                    pointArray[c, r] = new Point3D(x, Y, Z);
                }
            }

            SetSurfacePoints(pointArray, normalizeType);
        }

        #endregion
        #region 스캐터 포인트 설정하기 - SetScatterPoints(scatterArray, normalizeType)

        /// <summary>
        /// 스캐터 포인트 설정하기
        /// </summary>
        /// <param name="scatterArray">스캐터 배열</param>
        /// <param name="normalizeType">정규화 타입</param>
        public void SetScatterPoints(Scatter[] scatterArray, NormalizeType normalizeType)
        {
            this.pointArray   = null;
            this.scatterArray = scatterArray;
            this.pointCount   = scatterArray.Length;
            this.range        = new Range3D(scatterArray);

            NormalizeRanges(normalizeType);

            this.mouse.OffsetPoint = Point.Empty;

            this.drawObjectList.Clear();

            Invalidate();
        }

        #endregion
        #region 스캐터 라인 설정하기 - SetScatterLines(scatterArrary, normalizeType, lineWidth)

        /// <summary>
        /// 스캐터 라인 설정하기
        /// </summary>
        /// <param name="scatterArrary">스캐터 배열</param>
        /// <param name="normalizeType">정규화 타입</param>
        /// <param name="lineWidth">선 너비</param>
        public void SetScatterLines(Scatter[] scatterArrary, NormalizeType normalizeType, float lineWidth)
        {
            Scatter previousScatter = null;

            foreach(Scatter scatter in scatterArrary)
            {
                scatter.Combine         = true;
                scatter.PreviousScatter = previousScatter;

                if(scatter.Brush != null)
                {
                    scatter.Pen = new Pen(scatter.Brush, lineWidth);
                }

                previousScatter = scatter;
            }

            SetScatterPoints(scatterArrary, normalizeType);
        }

        #endregion
        #region 계수 설정하기 - SetCoefficients(rho, theta, phi)

        /// <summary>
        /// 계수 설정하기
        /// </summary>
        /// <param name="rho">로</param>
        /// <param name="theta">세타</param>
        /// <param name="phi">파이</param>
        public void SetCoefficients(double rho, double theta, double phi)
        {
            this.mouse.SetRho(rho);
            this.mouse.SetTheta(theta);
            this.mouse.SetPhi(phi);

            this.transform.SetCoeficients(this.mouse);

            this.drawObjectList.Clear();

            Invalidate();
        }

        #endregion
        #region 비트맵 구하기 - GetBitmap()

        /// <summary>
        /// 비트맵 구하기
        /// </summary>
        /// <returns>비트맵</returns>
        public Bitmap GetBitmap()
        {
            Bitmap bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);

            using(Graphics graphics = Graphics.FromImage(bitmap))
            {
                Draw(graphics);
            }

            return bitmap;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Protected
        //////////////////////////////////////////////////////////////////////////////// Function

        #region 크기 변경시 처리하기 - OnSizeChanged(e)

        /// <summary>
        /// 크기 변경시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            this.transform.SetSize(ClientSize);

            this.drawObjectList.Clear();

            Invalidate();
        }

        #endregion
        #region 배경 페인트시 처리하기 - OnPaintBackground(e)

        /// <summary>
        /// 배경 페인트시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        #endregion
        #region 페인트시 처리하기 - OnPaint(e)

        /// <summary>
        /// 페인트시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        #endregion
        #region 마우스 DOWN 처리하기 - OnMouseDown(e)

        /// <summary>
        /// 마우스 DOWN 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.mouse.LastPosition = e.Location;

            if(this.drawObjectList.Count == 0)
            {
                return;
            }
           
            switch(Control.ModifierKeys)
            {
                case Keys.None :

                    if(e.Button == MouseButtons.Left)
                    {
                        Cursor = Cursors.NoMoveVert;

                        this.mouse.MouseAction = MouseAction.Theta;
                    }

                    if(e.Button == MouseButtons.Right)
                    {
                        Cursor = Cursors.NoMoveHoriz;

                        this.mouse.MouseAction = MouseAction.Phi;
                    }

                    break;

                case Keys.Shift :

                    if(e.Button == MouseButtons.Left)
                    {
                        Cursor = Cursors.NoMove2D;

                        this.mouse.MouseAction = MouseAction.Move;
                    }

                    break;

                case Keys.Control :

                    if(e.Button == MouseButtons.Left)
                    {
                        Cursor = Cursors.SizeNS;

                        this.mouse.MouseAction = MouseAction.Rho;
                    }

                    break;
            }
        }

        #endregion
        #region 마우스 이동시 처리하기 - OnMouseMove(e)

        /// <summary>
        /// 마우스 이동시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int deltaX = e.X - this.mouse.LastPosition.X;
            int deltaY = e.Y - this.mouse.LastPosition.Y;

            this.mouse.LastPosition = e.Location;

            switch(this.mouse.MouseAction)
            {
                case MouseAction.Move :

                    this.mouse.OffsetPoint.X += deltaX;
                    this.mouse.OffsetPoint.Y += deltaY;

                    Invalidate();

                    break;

                case MouseAction.Rho   :
                case MouseAction.Theta :
                case MouseAction.Phi   :

                    this.mouse.ProcessMouseMove(deltaX, deltaY);

                    this.transform.SetCoeficients(this.mouse);

                    this.drawObjectList.Clear();

                    Invalidate();

                    break;
            }
        }

        #endregion
        #region 마우스 UP 처리하기 - OnMouseUp(e)

        /// <summary>
        /// 마우스 UP 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.mouse.MouseAction = MouseAction.None;

            Cursor = Cursors.Arrow;
        }

        #endregion
        #region 마우스 이탈시 처리하기 - OnMouseLeave(e)

        /// <summary>
        /// 마우스 이탈시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.mouse.MouseAction = MouseAction.None;

            Cursor = Cursors.Arrow;
        }

        #endregion
        #region 마우스 WHEEL 처리하기 - OnMouseWheel(e)

        /// <summary>
        /// 마우스 WHEEL 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if(this.mouse.ProcessMouseWheel(e.Delta))
            {
                this.transform.SetCoeficients(this.mouse);

                this.drawObjectList.Clear();

                Invalidate();
            }
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Private
        //////////////////////////////////////////////////////////////////////////////// Event

        #region 트랙바 스크롤시 처리하기 - trackBar_Scroll(sender, e)

        /// <summary>
        /// 트랙바 스크롤시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            this.mouse.ProcessTrackBarScroll();

            this.transform.SetCoeficients(this.mouse);

            this.drawObjectList.Clear();

            Invalidate();
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////// Function

        #region 범위 정규화하기 - NormalizeRanges(normalizeType)

        /// <summary>
        /// 범위 정규화하기
        /// </summary>
        /// <param name="normalizeType">정규화 타입</param>
        private void NormalizeRanges(NormalizeType normalizeType)
        {
            if(this.range.MaximumX == this.range.MinimumX)
            {
                this.range.MinimumX -= 1.0d;
                this.range.MaximumX += 1.0d;
            }

            if(this.range.MaximumY == this.range.MinimumY)
            {
                this.range.MinimumY -= 1.0d;
                this.range.MaximumY += 1.0d;
            }

            if(this.range.MaximumZ == this.range.MinimumZ)
            {
                this.range.MinimumZ -= 1.0d;
                this.range.MaximumZ += 1.0d;
            }

            double rangeX = this.range.MaximumX - this.range.MinimumX;
            double rangeY = this.range.MaximumY - this.range.MinimumY;

            double rangeZ;

            if(this.rasterType == RasterType.Off)
            {
                rangeZ = this.range.MaximumZ - this.range.MinimumZ;
            }
            else
            {
                rangeZ = Math.Max(0d, this.range.MaximumZ) - Math.Min(0d, this.range.MinimumZ);
            }

            switch(normalizeType)
            {
                case NormalizeType.MaintainXY :

                    double rangeXY = (rangeX + rangeY) / 2d;

                    rangeX = rangeXY;
                    rangeY = rangeXY;

                    break;

                case NormalizeType.MaintainXYZ :

                    double rangeXYZ = (rangeX + rangeY + rangeZ) / 3d;

                    rangeX = rangeXYZ;
                    rangeY = rangeXYZ;
                    rangeZ = rangeXYZ;

                    break;
            }

            this.transform.NormalizeX = 250.0d / rangeX;
            this.transform.NormalizeY = 250.0d / rangeY;
            this.transform.NormalizeZ = 250.0d / rangeZ;

            this.range.CenterPoint.X = (this.range.MaximumX + this.range.MinimumX) / 2.0d;
            this.range.CenterPoint.Y = (this.range.MaximumY + this.range.MinimumY) / 2.0d;

            if(this.rasterType == RasterType.Off)
            {
                this.range.CenterPoint.Z = (this.range.MaximumZ + this.range.MinimumZ) / 2.0d;
            }
            else
            {
                this.range.CenterPoint.Z = (Math.Max(0d, this.range.MaximumZ) + Math.Min(0d, this.range.MinimumZ)) / 2.0d;
            }
        }

        #endregion
        #region 좌표계 생성하기 - CreateCoordinateSystem(graphics)

        /// <summary>
        /// 좌표계 생성하기
        /// </summary>
        /// <param name="graphics">그래픽스</param>
        private void CreateCoordinateSystem(Graphics graphics)
        {
            this.offsetPoint = new Point(0, VERTICAL_OFFSET);

            if(this.rasterType == RasterType.Off)
            {
                return;
            }

            List<Line> lineList = new List<Line>();

            for(int a = 0; a < 3; a++)
            {
                Line axisLine  = new Line();

                axisLine.Pen = this.axisPenArray[a];

                switch((CoordinateType)a)
                {
                    case CoordinateType.X: // 청색

                        axisLine.Point3DArray[0].X = Math.Min(0.0d, this.range.MinimumX * AXIS_EXCESS);
                        axisLine.Point3DArray[1].X = Math.Max(0.0d, this.range.MaximumX * AXIS_EXCESS);

                        axisLine.Point3DArray[0].Y = Math.Min(0.0d, this.range.MinimumY * AXIS_EXCESS);
                        axisLine.Point3DArray[1].Y = Math.Min(0.0d, this.range.MinimumY * AXIS_EXCESS);

                        axisLine.MainCoordinateType = CoordinateType.X;
                        axisLine.SecondaryCoordinateType = CoordinateType.X;

                        break;

                    case CoordinateType.Y : // 녹색

                        axisLine.Point3DArray[0].Y = Math.Min(0.0d, this.range.MinimumY * AXIS_EXCESS);
                        axisLine.Point3DArray[1].Y = Math.Max(0.0d, this.range.MaximumY * AXIS_EXCESS);

                        axisLine.Point3DArray[0].X = Math.Min(0.0d, this.range.MinimumX * AXIS_EXCESS);
                        axisLine.Point3DArray[1].X = Math.Min(0.0d, this.range.MinimumX * AXIS_EXCESS);

                        axisLine.MainCoordinateType      = CoordinateType.Y;
                        axisLine.SecondaryCoordinateType = CoordinateType.Z;
                        break;

                    case CoordinateType.Z : // 적색

                        axisLine.Point3DArray[0].Z = Math.Min(0.0d, this.range.MinimumZ * AXIS_EXCESS);
                        axisLine.Point3DArray[1].Z = Math.Max(0.0d, this.range.MaximumZ * AXIS_EXCESS);

                        axisLine.Point3DArray[0].X = Math.Min(0.0d, this.range.MinimumX * AXIS_EXCESS);
                        axisLine.Point3DArray[1].X = Math.Min(0.0d, this.range.MinimumX * AXIS_EXCESS);
                        axisLine.Point3DArray[0].Y = Math.Min(0.0d, this.range.MinimumY * AXIS_EXCESS);
                        axisLine.Point3DArray[1].Y = Math.Min(0.0d, this.range.MinimumY * AXIS_EXCESS);

                        axisLine.MainCoordinateType      = CoordinateType.Z;
                        axisLine.SecondaryCoordinateType = CoordinateType.Z;

                        break;
                }

                axisLine.Point2DArray[0] = this.transform.Project(axisLine.Point3DArray[0], this.range.CenterPoint);
                axisLine.Point2DArray[1] = this.transform.Project(axisLine.Point3DArray[1], this.range.CenterPoint);

                axisLine.CalculateAngle();

                lineList.Add(axisLine);
            }

            this.quadrant = new Quadrant
            (
                this.mouse.Phi,
                lineList[(int)CoordinateType.X],
                lineList[(int)CoordinateType.Y],
                lineList[(int)CoordinateType.Z]
            );

            if(this.rasterType >= RasterType.Raster)
            {
                for(int a = 0; a < 3; a++)
                {
                    CoordinateType firstCoordinateType  = (CoordinateType)(a);
                    CoordinateType secondCoordinateType = (CoordinateType)((a + 1) % 3);

                    for(int d = 0; d < 2; d++)
                    {
                        Line firstAxisLine  = lineList[(int)firstCoordinateType ];
                        Line secondAxisLine = lineList[(int)secondCoordinateType];

                        double secondStart = secondAxisLine.Point3DArray[0].GetValue(secondCoordinateType);
                        double secondEnd   = secondAxisLine.Point3DArray[1].GetValue(secondCoordinateType);

                        double interval = CalculateInterval(secondEnd - secondStart);

                        for(int l = -11; l < 11; l++)
                        {
                            double offset = interval * l;

                            if(offset < secondStart || offset > secondEnd)
                            {
                                continue;
                            }
                                
                            Line rasterLine = new Line();

                            rasterLine.Pen                     = this.rasterPenArray[(int)secondCoordinateType];
                            rasterLine.MainCoordinateType      = firstCoordinateType;
                            rasterLine.SecondaryCoordinateType = secondCoordinateType;
                            rasterLine.Label                   = offset;
                            rasterLine.Point3DArray[0]         = firstAxisLine.Point3DArray[0].Clone();
                            rasterLine.Point3DArray[1]         = firstAxisLine.Point3DArray[1].Clone();

                            rasterLine.Point3DArray[0].SetValue(secondCoordinateType, offset);
                            rasterLine.Point3DArray[1].SetValue(secondCoordinateType, offset);

                            if
                            (
                                rasterLine.EqualsCoordinate(lineList[(int)CoordinateType.X]) ||
                                rasterLine.EqualsCoordinate(lineList[(int)CoordinateType.Y]) ||
                                rasterLine.EqualsCoordinate(lineList[(int)CoordinateType.Z])
                            )
                            {
                                continue;
                            }

                            if
                            (
                                (firstCoordinateType == CoordinateType.X && secondCoordinateType == CoordinateType.Z) ||
                                (firstCoordinateType == CoordinateType.Z && secondCoordinateType == CoordinateType.X)
                            )
                            {
                                rasterLine.Sort = this.quadrant.SortXZ;
                            }
                            else if
                            (
                                (firstCoordinateType == CoordinateType.Z && secondCoordinateType == CoordinateType.Y) ||
                                (firstCoordinateType == CoordinateType.Y && secondCoordinateType == CoordinateType.Z)
                            )
                            {
                                rasterLine.Sort = this.quadrant.SortYZ;
                            }
                            else
                            {
                                rasterLine.Sort = this.quadrant.SortXY;

                                Line axisZLine = lineList[(int)CoordinateType.Z];

                                rasterLine.Point3DArray[0].Z = axisZLine.Point3DArray[0].Z;
                                rasterLine.Point3DArray[1].Z = axisZLine.Point3DArray[0].Z;
                            }

                            lineList.Add(rasterLine);
                        }

                        CoordinateType temporaryCoordinateType = firstCoordinateType;

                        firstCoordinateType  = secondCoordinateType;
                        secondCoordinateType = temporaryCoordinateType;
                    }
                }
            }

            foreach(Line line in lineList)
            {
                line.Point2DArray[0] = this.transform.Project(line.Point3DArray[0], this.range.CenterPoint);
                line.Point2DArray[1] = this.transform.Project(line.Point3DArray[1], this.range.CenterPoint);

                AddDrawObject(new DrawObject(line, line.Sort));
            }

            if(this.rasterType == RasterType.Label)
            {
                int labelWidth = 0;

                foreach(Line line in lineList)
                {
                    if(line.MainCoordinateType == CoordinateType.Y && line.SecondaryCoordinateType == CoordinateType.Z)
                    {
                        string label = FormatLabel(line.Label);

                        SizeF size = graphics.MeasureString(label, Font);

                        labelWidth = Math.Max(labelWidth, (int)size.Width);
                    }
                }

                this.offsetPoint.X -= labelWidth / 2;
            }
        }

        #endregion
        #region 다각형 생성하기 - CreatePolygons()

        /// <summary>
        /// 다각형 생성하기
        /// </summary>
        private void CreatePolygons()
        {
            Point2D[,] pointArray = new Point2D[this.pointArray.GetLength(0), this.pointArray.GetLength(1)];

            for(int x = 0; x < this.pointArray.GetLength(0); x++)
            {
                for(int y = 0; y < this.pointArray.GetLength(1); y++)
                {
                    pointArray[x, y] = this.transform.Project(this.pointArray[x, y], this.range.CenterPoint);
                }
            }

            for(int x = 0; x < this.pointArray.GetLength(0) - 1; x++)
            {
                for(int y = 0; y < this.pointArray.GetLength(1) - 1; y++)
                {
                    Polygon polygon = new Polygon
                    (
                        pointArray[x    , y    ],
                        pointArray[x    , y + 1],
                        pointArray[x + 1, y + 1],
                        pointArray[x + 1, y    ]
                    );
                    
                    double z1 = this.pointArray[x    , y    ].Z;
                    double z2 = this.pointArray[x    , y + 1].Z;
                    double z3 = this.pointArray[x + 1, y + 1].Z;
                    double z4 = this.pointArray[x + 1, y    ].Z;

                    double zAverage = (z1 + z2 + z3 + z4) / 4.0d;

                    polygon.FactorZ = (zAverage - this.range.MinimumZ) / (this.range.MaximumZ - this.range.MinimumZ);

                    double sort = this.transform.ProjectXY(x + 1, y + 1);

                    AddDrawObject(new DrawObject(polygon, sort));
                }
            }
        }

        #endregion
        #region 스캐터 점 생성하기 - CreateScatterDots()

        /// <summary>
        /// 스캐터 점 생성하기
        /// </summary>
        private void CreateScatterDots()
        {
            foreach(Scatter scatter in this.scatterArray)
            {
                scatter.SetPoint2D(this.transform.Project(scatter.Point3D, this.range.CenterPoint));

                if(scatter.Brush == null)
                {
                    scatter.FactorZ = (scatter.Point3D.Z - this.range.MinimumZ) / (this.range.MaximumZ - this.range.MinimumZ);
                }

                double sort = this.transform.ProjectXY
                (
                    scatter.Point3D.X + 1.0d, 
                    scatter.Point3D.Y + 1.0d
                );

                AddDrawObject(new DrawObject(scatter, sort));
            }
        }

        #endregion
        #region 그리기 객체 추가하기 - AddDrawObject(drawObject)

        /// <summary>
        /// 그리기 객체 추가하기
        /// </summary>
        /// <param name="drawObject">그리기 객체</param>
        private void AddDrawObject(DrawObject drawObject)
        {
            int p;

            for(p = 0; p < this.drawObjectList.Count; p++)
            {
                if(this.drawObjectList[p].Sort > drawObject.Sort)
                {
                    break;
                }
            }

            this.drawObjectList.Insert(p, drawObject);
        }

        #endregion
        #region 색상 구성표 브러시 구하기 - GetColorSchemeBrush(factorZ)

        /// <summary>
        /// 색상 구성표 브러시 구하기
        /// </summary>
        /// <param name="factorZ">팩터 Z</param>
        /// <returns>색상 구성표 브러시</returns>
        private Brush GetColorSchemeBrush(double factorZ)
        {
            if(this.colorSchemeBrusheArray == null || double.IsNaN(factorZ))
            {
                return Brushes.Goldenrod;
            }

            factorZ = Math.Min(1.0d, factorZ);
            factorZ = Math.Max(0.0d, factorZ);

            int index = (int)(factorZ * (this.colorSchemeBrusheArray.Length - 1));

            return this.colorSchemeBrusheArray[index];
        }

        #endregion
        #region 색상 구성표 펜 구하기 - GetColorSchemePen(factorZ)

        /// <summary>
        /// 색상 구성표 펜 구하기
        /// </summary>
        /// <param name="factorZ">팩터 Z</param>
        /// <returns>색상 구성표 펜</returns>
        private Pen GetColorSchemePen(double factorZ)
        {
            if(this.colorSchemePenArray == null || double.IsNaN(factorZ))
            {
                return Pens.Goldenrod;
            }

            factorZ = Math.Min(1.0, factorZ);
            factorZ = Math.Max(0.0, factorZ);

            int index = (int)(factorZ * (this.colorSchemePenArray.Length - 1));

            return this.colorSchemePenArray[index];
        }

        #endregion
        #region 축 색상 설정하기 - SetAxisColor(coordinateType, color)

        /// <summary>
        /// 축 색상 설정하기
        /// </summary>
        /// <param name="coordinateType">좌표 타입</param>
        /// <param name="color">색상</param>
        private void SetAxisColor(CoordinateType coordinateType, Color color)
        {
            this.axisBrushArray[(int)coordinateType] = new SolidBrush(color);

            this.axisPenArray[(int)coordinateType] = new Pen(color, 3);

            this.rasterPenArray[(int)coordinateType] = new Pen(BrightenColor(color), 1);
        }

        #endregion
        #region 색상 밝게 만들기 - BrightenColor(color)

        /// <summary>
        /// 색상 밝게 만들기
        /// </summary>
        /// <param name="color">색상</param>
        /// <returns>색상</returns>
        private Color BrightenColor(Color color)
        {
            int red   = color.R + (255 - color.R) / 2;
            int green = color.G + (255 - color.G) / 2;
            int blue  = color.B + (255 - color.B) / 2;

            return Color.FromArgb(255, red, green, blue);
        }

        #endregion
        #region 간격 계산하기 - CalculateInterval(range)

        /// <summary>
        /// 간격 계산하기
        /// </summary>
        /// <param name="range">범위</param>
        /// <returns>간격</returns>
        private double CalculateInterval(double range)
        {
            double factor = Math.Pow(10.0d, Math.Floor(Math.Log10(range)));

            if(range / factor >= 5.0d)
            {
                return factor;
            }
            else if(range / (factor / 2.0d) >= 5.0d)
            {
                return factor / 2.0d;
            }
            else
            {
                return factor / 5.0d;
            }
        }

        #endregion
        #region 레이블 포맷 적용하기 - FormatLabel(label)

        /// <summary>
        /// 레이블 포맷 적용하기
        /// </summary>
        /// <param name="label">레이블</param>
        /// <returns>레이블</returns>
        /// <remarks>
        /// 123.000 --> "123"
        ///  15.700 --> "15.7"  
        ///   4.260 --> "4.26"
        ///   0.834 --> "0.834"
        /// </remarks>
        private string FormatLabel(double label)
        {
            return label.ToString("0.000", CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.');
        }

        #endregion
        #region 그리기 - Draw(graphics)

        /// <summary>
        /// 그리기
        /// </summary>
        /// <param name="graphics">그래픽스</param>
        private void Draw(Graphics graphics)
        {
            if(this.drawObjectList.Count == 0)
            {
                CreateCoordinateSystem(graphics);

                if(this.pointArray != null)
                {
                    CreatePolygons();
                }

                if(this.scatterArray != null)
                {
                    CreateScatterDots();
                }
            }

            graphics.Clear(BackColor);

            int x = 4;
            int y = ClientSize.Height - Font.Height - 4;

            for(int i = 2; i >= 0; i--)
            {
                if(string.IsNullOrEmpty(this.axisLegendStringArray[i]))
                {
                    continue;
                }

                string legend = string.Format("{0} : {1}", (CoordinateType)i, this.axisLegendStringArray[i]);

                graphics.DrawString(legend, Font, this.axisBrushArray[i], x,  y);

                y -= Font.Height;
            }

            if(this.topLegendBrush != null)
            {
                string[] legendArray = new string[]
                {
                    "Rotation  : ",
                    "Elevation : ",
                    "Distance  : "
                };
                
                string[] valueArray  = new string[]
                {
                    string.Format("{0:+#;-#;0}°", (int)this.mouse.Phi  ),
                    string.Format("{0:+#;-#;0}°", (int)this.mouse.Theta),
                    string.Format("{0}"          , (int)this.mouse.Rho  )
                };

                SizeF size = graphics.MeasureString(legendArray[1], Font);

                x = 4;
                y = 3;

                for(int i = 0; i < 3; i++)
                {
                    graphics.DrawString(legendArray[i], Font, this.topLegendBrush, x,  y);

                    graphics.DrawString(valueArray [i], Font, this.topLegendBrush, x + size.Width, y);

                    y += Font.Height;
                }
            }

            graphics.TranslateTransform
            (
                this.mouse.OffsetPoint.X + this.offsetPoint.X, 
                this.mouse.OffsetPoint.Y + this.offsetPoint.Y
            );

            SmoothingMode smoothingMode = SmoothingMode.Invalid;

            foreach(DrawObject drawObject in this.drawObjectList)
            {
                if(!drawObject.IsValid)
                {
                    continue;
                }

                if(drawObject.Polygon != null)
                {
                    if(smoothingMode != SmoothingMode.None)
                    {
                        smoothingMode = SmoothingMode.None;

                        graphics.SmoothingMode = SmoothingMode.None;
                    }

                    Polygon polygon = drawObject.Polygon;
                    Brush   brush   = GetColorSchemeBrush(polygon.FactorZ);

                    graphics.FillPolygon(brush, polygon.PointArray);

                    if(this.polyLinePen != null)
                    {
                        graphics.DrawPolygon(this.polyLinePen, polygon.PointArray);
                    }
                }
                else if(drawObject.Scatter != null)
                {
                    if(smoothingMode != SmoothingMode.AntiAlias)
                    {
                        smoothingMode = SmoothingMode.AntiAlias;

                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    }

                    Scatter scatter = drawObject.Scatter;

                    if(scatter.Combine)
                    {
                        if(scatter.PreviousScatter != null)
                        {
                            Pen pen = scatter.Pen;

                            if(pen == null)
                            {
                                pen = GetColorSchemePen(scatter.FactorZ);
                            }

                            graphics.DrawLine(pen, scatter.PreviousScatter.Point, scatter.Point);
                        }
                    }
                    else
                    {
                        Brush brush = scatter.Brush;

                        if(brush == null)
                        {
                            brush = GetColorSchemeBrush(scatter.FactorZ);
                        }

                        graphics.FillEllipse(brush, scatter.Point.X, scatter.Point.Y, SCATTER_SIZE * 2, SCATTER_SIZE * 2);
                    }
                }
                else
                {
                    if(smoothingMode != SmoothingMode.AntiAlias)
                    {
                        smoothingMode = SmoothingMode.AntiAlias;

                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    }

                    Line line = drawObject.Line;

                    graphics.DrawLine(line.Pen, line.Point2DArray[0].Coordinate, line.Point2DArray[1].Coordinate);

                    if(this.rasterType == RasterType.Label && this.quadrant.BottomView == false && this.quadrant.QuadrantValue == 3)
                    {
                        PointF position = line.Point2DArray[1].Coordinate;

                        StringFormat stringFormat = new StringFormat();

                        if(line.MainCoordinateType == CoordinateType.Y && line.SecondaryCoordinateType == CoordinateType.Z)
                        {
                            position.X += 5;
                            position.Y -= Font.Height / 2;
                        }
                        else if(line.MainCoordinateType == CoordinateType.Y && line.SecondaryCoordinateType == CoordinateType.X)
                        {
                            position.X += (float)this.transform.ProjectXY(5, -5);
                            position.Y += (float)this.transform.ProjectXY(-Font.Height / 2, 5);
                        }
                        else if(line.MainCoordinateType == CoordinateType.X && line.SecondaryCoordinateType == CoordinateType.Y)
                        {
                            position.X += (float)this.transform.ProjectXY(5, -5);
                            position.Y += (float)this.transform.ProjectXY(5, -Font.Height / 2);

                            stringFormat.Alignment = StringAlignment.Far;
                        }
                        else
                        {
                            continue;
                        }

                        string label = FormatLabel(line.Label);

                        Brush  brush = this.axisBrushArray[(int)line.SecondaryCoordinateType];

                        graphics.DrawString(label, Font, brush, position, stringFormat);
                    }
                }
            }

            if(this.borderPen != null)
            {
                graphics.ResetTransform();

                Rectangle borderRectangle = ClientRectangle;

                graphics.DrawRectangle
                (
                    this.borderPen,
                    borderRectangle.X,
                    borderRectangle.Y,
                    borderRectangle.Width - 1,
                    borderRectangle.Height - 1
                );
            }
        }

        #endregion
    }
}