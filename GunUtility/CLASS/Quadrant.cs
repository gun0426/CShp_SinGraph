using System;

namespace Chart_Project
{
    /// <summary>
    /// 사분면
    /// </summary>
    public class Quadrant
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// XY 정렬
        /// </summary>
        public double SortXY;

        /// <summary>
        /// XZ 정렬
        /// </summary>
        public double SortXZ;

        /// <summary>
        /// YZ 정렬
        /// </summary>
        public double SortYZ;

        /// <summary>
        /// 사분면 값
        /// </summary>
        public int QuadrantValue;

        /// <summary>
        /// 하단 뷰 여부
        /// </summary>
        public bool BottomView;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - Quadrant(phi, axisXLine, axisYLine, axisZLine)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="phi">파이</param>
        /// <param name="axisXLine">X축 선</param>
        /// <param name="axisYLine">Y축 선</param>
        /// <param name="axisZLine">Z축 선</param>
        public Quadrant(double phi, Line axisXLine, Line axisYLine, Line axisZLine)
        {
            int section45 = (int)phi + 45;

            if(section45 > 360)
            {
                section45 -= 360;
            }

            section45 = Math.Min(3, section45 / 90);

            switch(section45)
            {
                case 0 : BottomView = axisXLine.Angle < 180d; break;
                case 1 : BottomView = axisYLine.Angle < 180d; break;
                case 2 : BottomView = axisXLine.Angle > 180d; break;
                case 3 : BottomView = axisYLine.Angle > 180d; break;
            }

            if(BottomView)
            {
                switch(section45)
                {
                    case 0 : QuadrantValue = axisXLine.Angle + 180d < axisZLine.Angle ? 1 : 0; break;
                    case 1 : QuadrantValue = axisYLine.Angle + 180d < axisZLine.Angle ? 2 : 1; break;
                    case 2 : QuadrantValue = axisXLine.Angle        < axisZLine.Angle ? 3 : 2; break;
                    case 3 : QuadrantValue = axisYLine.Angle        < axisZLine.Angle ? 0 : 3; break;
                }
            }
            else
            {
                switch(section45)
                {
                    case 0 : QuadrantValue = axisXLine.Angle        > axisZLine.Angle ? 1 : 0; break;
                    case 1 : QuadrantValue = axisYLine.Angle        > axisZLine.Angle ? 2 : 1; break;
                    case 2 : QuadrantValue = axisXLine.Angle + 180d > axisZLine.Angle ? 3 : 2; break;
                    case 3 : QuadrantValue = axisYLine.Angle + 180d > axisZLine.Angle ? 0 : 3; break;
                }
            }

            SortXY = (BottomView) ? 99999.9 : -99999.9;
            SortXZ = (QuadrantValue == 1 || QuadrantValue == 2) ? 99999.9 : -99999.9;
            SortYZ = (QuadrantValue == 0 || QuadrantValue == 1) ? 99999.9 : -99999.9;

            axisXLine.Sort = SortXZ;
            axisYLine.Sort = SortYZ;
            axisZLine.Sort = 0.0;
        }

        #endregion
    }
}