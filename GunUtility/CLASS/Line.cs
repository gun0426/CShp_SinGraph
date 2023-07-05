using System;
using System.Drawing;

namespace Chart_Project
{
    /// <summary>
    /// 선
    /// </summary>
    public class Line
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 메인 좌표 타입
        /// </summary>
        public CoordinateType MainCoordinateType;

        /// <summary>
        /// 보조 좌표 타입
        /// </summary>
        public CoordinateType SecondaryCoordinateType;

        /// <summary>
        /// 레이블
        /// </summary>
        public double Label;

        /// <summary>
        /// 펜
        /// </summary>
        public Pen Pen;

        /// <summary>
        /// 정렬
        /// </summary>
        public double Sort;

        /// <summary>
        /// 각도
        /// </summary>
        public double Angle;

        /// <summary>
        /// 포인트 3D 배열
        /// </summary>
        public Point3D[] Point3DArray = new Point3D[2] { new Point3D(), new Point3D() };

        /// <summary>
        /// 포인트 2D 배열
        /// </summary>
        public Point2D[] Point2DArray = new Point2D[2] { new Point2D(), new Point2D() };

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
                return Point2DArray[0].IsValid && Point2DArray[1].IsValid;
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 좌표 동일 여부 구하기 - EqualsCoordinate(line)

        /// <summary>
        /// 좌표 동일 여부 구하기
        /// </summary>
        /// <param name="line">선</param>
        /// <returns>좌표 동일 여부</returns>
        public bool EqualsCoordinate(Line line)
        {
            return Point3DArray[0].Equals(line.Point3DArray[0]) && Point3DArray[1].Equals(line.Point3DArray[1]);
        }

        #endregion
        #region 각도 계산하기 - CalculateAngle()

        /// <summary>
        /// 각도 계산하기
        /// </summary>
        public void CalculateAngle()
        {
            double deltaX = Point2DArray[1].X - Point2DArray[0].X;
            double deltaY = Point2DArray[1].Y - Point2DArray[0].Y;

            Angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

            if(Angle < 0.0)
            {
                Angle += 360.0;
            }
        }

        #endregion
    }
}