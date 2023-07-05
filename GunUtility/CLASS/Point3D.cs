namespace Chart_Project
{
    /// <summary>
    /// 포인트 3D
    /// </summary>
    public class Point3D
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

        /// <summary>
        /// Z
        /// </summary>
        public double Z;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - Point3D

        /// <summary>
        /// 생성자
        /// </summary>
        public Point3D()
        {
        }

        #endregion
        #region 생성자 - Point3D(x, y, z)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 복제하기 - Clone()

        /// <summary>
        /// 복제하기
        /// </summary>
        /// <returns>포인트 3D</returns>
        public Point3D Clone()
        {
            return new Point3D(X, Y, Z);
        }

        #endregion
        #region 동일 여부 구하기 - Equals(point)

        /// <summary>
        /// 동일 여부 구하기
        /// </summary>
        /// <param name="point">포인트</param>
        /// <returns>동일 여부</returns>
        public bool Equals(Point3D point)
        {
            return X == point.X && Y == point.Y && Z == point.Z;
        }

        #endregion
 
        #region 값 설정하기 - SetValue(coordinateType, value)

        /// <summary>
        /// 값 설정하기
        /// </summary>
        /// <param name="coordinateType">좌표 타입</param>
        /// <param name="value">값</param>
        public void SetValue(CoordinateType coordinateType, double value)
        {
            switch(coordinateType)
            {
                case CoordinateType.X : X = value; break;
                case CoordinateType.Y : Y = value; break;
                case CoordinateType.Z : Z = value; break;
            }
        }

        #endregion
        #region 값 구하기 - GetValue(coordinateType)

        /// <summary>
        /// 값 구하기
        /// </summary>
        /// <param name="coordinateType">좌표 타입</param>
        /// <returns>값</returns>
        public double GetValue(CoordinateType coordinateType)
        {
            switch(coordinateType)
            {
                case CoordinateType.X : return X;
                case CoordinateType.Y : return Y;
                case CoordinateType.Z : return Z;
                default               : return 0d;
            }
        }

        #endregion

        #region 문자열 구하기 - ToString()

        /// <summary>
        /// 문자열 구하기
        /// </summary>
        /// <returns>문자열</returns>
        public override string ToString()
        {
            return string.Format("{0:0.00}, {1:0.00}, {2:0.00}", X, Y, Z);
        }

        #endregion
    }
}