using System.Drawing;

namespace Chart_Project
{
    /// <summary>
    /// 스캐터
    /// </summary>
    public class Scatter
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 포인트 3D
        /// </summary>
        public Point3D Point3D;

        /// <summary>
        /// 포인트
        /// </summary>
        public PointF Point;

        /// <summary>
        /// 브러시
        /// </summary>
        public Brush Brush;

        /// <summary>
        /// 펜
        /// </summary>
        public Pen Pen;

        /// <summary>
        /// 팩터 Z
        /// </summary>
        public double FactorZ;

        /// <summary>
        /// 이전 스캐터
        /// </summary>
        public Scatter PreviousScatter;

        /// <summary>
        /// 결합 여부
        /// </summary>
        public bool Combine;

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 유효 여부
        /// </summary>
        private bool isValid;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Property
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 유효 여부 - IsValid

        /// <summary>
        /// 유효 여부
        /// </summary>
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - Scatter(x, y, z, brush)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <param name="brush">브러시</param>
        public Scatter(double x, double y, double z, Brush brush)
        {
            Point3D = new Point3D(x, y, z);
            Brush   = brush;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 포인트 2D 설정하기 - SetPoint2D(point2D)

        /// <summary>
        /// 포인트 2D 설정하기
        /// </summary>
        /// <param name="point2D">포인트 2D</param>
        public void SetPoint2D(Point2D point2D)
        {
            Point = point2D.Coordinate;

            this.isValid = point2D.IsValid;

            Point.X -= Chart3DControl.SCATTER_SIZE;
            Point.Y -= Chart3DControl.SCATTER_SIZE;
        }

        #endregion
    }
}