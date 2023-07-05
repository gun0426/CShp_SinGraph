using System;
using System.Drawing;

namespace Chart_Project
{
    /// <summary>
    /// 포인트 2D
    /// </summary>
    public class Point2D
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// X
        /// </summary>
        public double X;

        /// <summary>
        /// Y
        /// </summary>
        public double Y;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Property
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 좌표 - Coordinate

        /// <summary>
        /// 좌표
        /// </summary>
        public PointF Coordinate
        {
            get
            {
                return new PointF((float)X, (float)Y);
            }
        }

        #endregion
        #region 유효 여부 - IsValid

        /// <summary>
        /// 유효 여부
        /// </summary>
        public bool IsValid
        {
            get
            {
                return (!double.IsNaN(X) && Math.Abs(X) < 9999.9d && !double.IsNaN(Y) && Math.Abs(Y) < 9999.9d);
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 문자열 구하기 - ToString()

        /// <summary>
        /// 문자열 구하기
        /// </summary>
        /// <returns>문자열</returns>
        public override string ToString()
        {
            return string.Format("{0:0.00}, {1:0.00}", X, Y);
        }

        #endregion
    }
}