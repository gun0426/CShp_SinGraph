using System;
using System.Drawing;

namespace Chart_Project
{
    /// <summary>
    /// 변환
    /// </summary>
    public class Transform
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 정규화 X
        /// </summary>
        public double NormalizeX;

        /// <summary>
        /// 정규화 Y
        /// </summary>
        public double NormalizeY;

        /// <summary>
        /// 정규화 Z
        /// </summary>
        public double NormalizeZ;

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 거리
        /// </summary>
        private double distance;

        /// <summary>
        /// 로
        /// </summary>
        private double rho;

        /// <summary>
        /// 세타 싸인
        /// </summary>
        private double thetaSine;

        /// <summary>
        /// 세타 코싸인
        /// </summary>
        private double thetaCosine;

        /// <summary>
        /// 파이 싸인
        /// </summary>
        private double phiSine;

        /// <summary>
        /// 파이 코싸인
        /// </summary>
        private double phiCosine;

        /// <summary>
        /// 팩터 X
        /// </summary>
        private double factorX;

        /// <summary>
        /// 오프셋 X
        /// </summary>
        private double offsetX;

        /// <summary>
        /// 팩터 Y
        /// </summary>
        private double factorY;

        /// <summary>
        /// 오프셋 Y
        /// </summary>
        private double offsetY;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 계수 설정하기 - SetCoeficients(mouse)

        /// <summary>
        /// 계수 설정하기
        /// </summary>
        /// <param name="mouse">마우스</param>
        public void SetCoeficients(Mouse mouse)
        {
            this.rho =  mouse.Rho;

            double theta = mouse.Theta * Math.PI / 180d;
            double phi   = (mouse.Phi -180d) * Math.PI / 180d;

            this.phiSine     = Math.Sin(phi);
            this.phiCosine   = Math.Cos(phi);
            this.thetaSine   = Math.Sin(theta);
            this.thetaCosine = Math.Cos(theta);
            this.distance    = 0.5d;
        }

        #endregion
        #region 크기 설정하기 - SetSize(size)

        /// <summary>
        /// 크기 설정하기
        /// </summary>
        /// <param name="size">크기</param>
        public void SetSize(Size size)
        {
            double width  = size.Width  * 0.0254d / 96d;
            double height = size.Height * 0.0254d / 96d;

            this.factorX =  size.Width  / width;
            this.factorY = -size.Height / height;
                
            this.offsetX =  this.factorX * width  / 2d;
            this.offsetY = -this.factorY * height / 2d;
        }

        #endregion
        #region 투영하기 - Project(point3D, centerPoint3D)

        /// <summary>
        /// 투영하기
        /// </summary>
        /// <param name="point3D">포인트 3D</param>
        /// <param name="centerPoint3D">중심 포인트 3D</param>
        /// <returns>포인트 2D</returns>
        public Point2D Project(Point3D point3D, Point3D centerPoint3D)
        {
            double x = (point3D.X - centerPoint3D.X) * NormalizeX;
            double y = (point3D.Y - centerPoint3D.Y) * NormalizeY;
            double z = (point3D.Z - centerPoint3D.Z) * NormalizeZ;

            double xNegative = -this.phiSine * x + this.phiCosine * y;
            double yNegative = -this.phiCosine * this.thetaCosine * x - this.phiSine * this.thetaCosine * y + this.thetaSine * z;
            double zNegative = -this.phiCosine * this.thetaSine * x - this.phiSine * this.thetaSine * y - this.thetaCosine * z + this.rho;

            if(zNegative <= 0)
            {
                zNegative = 0.01d;
            }

            Point2D point2D = new Point2D();

            point2D.X = this.factorX * xNegative * this.distance / zNegative + this.offsetX;
            point2D.Y = this.factorY * yNegative * this.distance / zNegative + this.offsetY;

            return point2D;
        }

        #endregion
        #region XY 투영하기 - ProjectXY(x, y)

        /// <summary>
        /// XY 투영하기
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns>투영 값</returns>
        public double ProjectXY(double x, double y)
        {
            return x * this.phiCosine + y * this.phiSine;
        }

        #endregion
    }
}