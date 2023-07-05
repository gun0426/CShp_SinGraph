using System;

namespace Chart_Project
{
    /// <summary>
    /// 범위 3D
    /// </summary>
    public class Range3D
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 최소 X
        /// </summary>
        public double MinimumX = double.PositiveInfinity;

        /// <summary>
        /// 최대 X
        /// </summary>
        public double MaximumX = double.NegativeInfinity;

        /// <summary>
        /// 최소 Y
        /// </summary>
        public double MinimumY = double.PositiveInfinity;

        /// <summary>
        /// 최대 Y
        /// </summary>
        public double MaximumY = double.NegativeInfinity;

        /// <summary>
        /// 최소 Z
        /// </summary>
        public double MinimumZ = double.PositiveInfinity;

        /// <summary>
        /// 최대 Z
        /// </summary>
        public double MaximumZ = double.NegativeInfinity;

        /// <summary>
        /// 중심 포인트
        /// </summary>
        public Point3D CenterPoint = new Point3D();

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - Range3D(pointArray)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="pointArray">포인트 배열</param>
        public Range3D(Point3D[,] pointArray)
        {
            for(int x = 0; x < pointArray.GetLength(0); x++)
            {
                for(int y = 0; y < pointArray.GetLength(1); y++)
                {
                    Point3D point = pointArray[x,y];

                    MinimumX = Math.Min(MinimumX, point.X);
                    MaximumX = Math.Max(MaximumX, point.X);
                    MinimumY = Math.Min(MinimumY, point.Y);
                    MaximumY = Math.Max(MaximumY, point.Y);
                    MinimumZ = Math.Min(MinimumZ, point.Z);
                    MaximumZ = Math.Max(MaximumZ, point.Z);
                }
            }
        }

        #endregion
        #region 생성자 - Range3D(scatterArray)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="scatterArray">스캐터 배열</param>
        public Range3D(Scatter[] scatterArray)
        {
            foreach(Scatter scatter in scatterArray)
            {
                Point3D point = scatter.Point3D;

                MinimumX = Math.Min(MinimumX, point.X);
                MaximumX = Math.Max(MaximumX, point.X);
                MinimumY = Math.Min(MinimumY, point.Y);
                MaximumY = Math.Max(MaximumY, point.Y);
                MinimumZ = Math.Min(MinimumZ, point.Z);
                MaximumZ = Math.Max(MaximumZ, point.Z);
            }
        }

        #endregion
    }
}