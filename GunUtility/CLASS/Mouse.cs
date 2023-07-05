using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chart_Project
{
    /// <summary>
    /// 마우스
    /// </summary>
    public class Mouse
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 마우스 액션
        /// </summary>
        public MouseAction MouseAction;

        /// <summary>
        /// 마지막 위치
        /// </summary>
        public Point LastPosition;

        /// <summary>
        /// 오프셋 포인트
        /// </summary>
        public Point OffsetPoint;

        /// <summary>
        /// 로 트랙바
        /// </summary>
        public TrackBar RhoTrackBar;

        /// <summary>
        /// 세타 트랙바
        /// </summary>
        public TrackBar ThetaTrackBar;

        /// <summary>
        /// 파이 트랙바
        /// </summary>
        public TrackBar PhiTrackBar;

        /// <summary>
        /// 로
        /// </summary>
        public double Rho = Chart3DControl.RHO_VALUE_ARRAY[2];

        /// <summary>
        /// 세타
        /// </summary>
        public double Theta = Chart3DControl.THETA_VALUE_ARRAY[2];

        /// <summary>
        /// 파이
        /// </summary>
        public double Phi = Chart3DControl.PHI_VALUE_ARRAY[2];

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 트랙바 할당하기 - AssignTrackBar(mouseAction, trackBar, scrollEventHandler)

        /// <summary>
        /// 트랙바 할당하기
        /// </summary>
        /// <param name="mouseAction">마우스 액션</param>
        /// <param name="trackBar">트랙바</param>
        /// <param name="scrollEventHandler">스크롤 이벤트 핸들러</param>
        public void AssignTrackBar(MouseAction mouseAction, TrackBar trackBar, EventHandler scrollEventHandler)
        {
            if(trackBar == null)
            {
                return;
            }

            double[] valueArray = null;

            switch(mouseAction)
            {
                case MouseAction.Rho :

                    valueArray = Chart3DControl.RHO_VALUE_ARRAY;

                    RhoTrackBar = trackBar;

                    break;

                case MouseAction.Theta :

                    valueArray = Chart3DControl.THETA_VALUE_ARRAY;

                    ThetaTrackBar = trackBar;

                    break;

                case MouseAction.Phi :

                    valueArray = Chart3DControl.PHI_VALUE_ARRAY;

                    PhiTrackBar = trackBar;

                    break;
            }

            trackBar.Minimum = (int)valueArray[0]; // 0 = 최소값
            trackBar.Maximum = (int)valueArray[1]; // 1 = 최대값
            trackBar.Value   = (int)valueArray[2]; // 2 = 디폴트 값

            trackBar.Scroll += scrollEventHandler;
        }

        #endregion

        #region 트랙바 스크롤시 처리하기 - ProcessTrackBarScroll()

        /// <summary>
        /// 트랙바 스크롤시 처리하기
        /// </summary>
        public void ProcessTrackBarScroll()
        {
            if(RhoTrackBar != null)
            {
                Rho = RhoTrackBar.Value;
            }

            if(ThetaTrackBar != null)
            {
                Theta = ThetaTrackBar.Value;
            }

            if(PhiTrackBar != null)
            {
                Phi = PhiTrackBar.Value;
            }
        }

        #endregion
        #region 마우스 휠 처리하기 - ProcessMouseWheel(delta)

        /// <summary>
        /// 마우스 휠 처리하기
        /// </summary>
        /// <param name="delta">델타</param>
        /// <returns>처리 결과</returns>
        public bool ProcessMouseWheel(int delta)
        {
            if(MouseAction != MouseAction.None)
            {
                return false;
            }

            MouseAction = MouseAction.Rho;

            ProcessMouseMove(0, delta / 10);

            MouseAction = MouseAction.None;

            return true;
        }

        #endregion
        #region 마우스 이동시 처리하기 - ProcessMouseMove(deltaX, deltaY)

        /// <summary>
        /// 마우스 이동시 처리하기
        /// </summary>
        /// <param name="deltaX">델타 X</param>
        /// <param name="deltaY">델타 Y</param>
        public void ProcessMouseMove(int deltaX, int deltaY)
        {
            switch(MouseAction)
            {
                case MouseAction.Rho :

                    Rho += deltaY * Chart3DControl.RHO_VALUE_ARRAY[3];

                    SetRho(Rho);

                    break;

                case MouseAction.Theta :

                    Theta -= deltaY * Chart3DControl.THETA_VALUE_ARRAY[3];

                    SetTheta(Theta);

                    break;

                case MouseAction.Phi:

                    Phi -= deltaX * Chart3DControl.PHI_VALUE_ARRAY[3];

                    SetPhi(Phi);

                    break;
            }
        }

        #endregion

        #region 로 설정하기 - SetRho(rho)

        /// <summary>
        /// 로 설정하기
        /// </summary>
        /// <param name="rho">로</param>
        public void SetRho(double rho)
        {
            Rho = rho;
            Rho = Math.Max(Rho, Chart3DControl.RHO_VALUE_ARRAY[0]);
            Rho = Math.Min(Rho, Chart3DControl.RHO_VALUE_ARRAY[1]);

            if(RhoTrackBar != null)
            {
                RhoTrackBar.Value = (int)Rho;
            }
        }

        #endregion
        #region 세타 설정하기 - SetTheta(theta)

        /// <summary>
        /// 세타 설정하기
        /// </summary>
        /// <param name="theta">세타</param>
        public void SetTheta(double theta)
        {
            Theta = theta;
            Theta = Math.Max(Theta, Chart3DControl.THETA_VALUE_ARRAY[0]);
            Theta = Math.Min(Theta, Chart3DControl.THETA_VALUE_ARRAY[1]);

            if(ThetaTrackBar != null)
            {
                ThetaTrackBar.Value = (int)Theta;
            }
        }

        #endregion
        #region 파이 설정하기 - SetPhi(phi)

        /// <summary>
        /// 파이 설정하기
        /// </summary>
        /// <param name="phi">파이</param>
        public void SetPhi(double phi)
        {
            Phi = phi;

            if(Phi > 360d)
            {
                Phi -= 360d;
            }

            if(Phi < 0d)
            {
                Phi += 360d;
            }

            if(PhiTrackBar != null)
            {
                PhiTrackBar.Value = (int)Phi;
            }
        }

        #endregion
    }
}