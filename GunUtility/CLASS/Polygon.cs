using System.Drawing;

namespace Chart_Project
{
    /// <summary>
    /// 다각형
    /// </summary>
    public class Polygon
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 포인트 배열
        /// </summary>
        public PointF[] PointArray;

        /// <summary>
        /// 팩터 Z
        /// </summary>
        public double FactorZ;

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

        #region 생성자 - Polygon(pointArray)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="pointArray">포인트 배열</param>
        public Polygon(params Point2D[] pointArray)
        {
            this.isValid = true;

            PointArray = new PointF[pointArray.Length];

            for(int i = 0; i < pointArray.Length; i++)
            {
                if(pointArray[i].IsValid)
                {
                    PointArray[i] = pointArray[i].Coordinate;
                }
                else
                {
                    this.isValid = false;
                }
            }
        }

        #endregion
    }
}