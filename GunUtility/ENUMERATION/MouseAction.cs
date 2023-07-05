namespace Chart_Project
{
    /// <summary>
    /// 마우스 액션
    /// </summary>
    public enum MouseAction
    {
        /// <summary>
        /// 해당 무
        /// </summary>
        None = 0,

        /// <summary>
        /// 이동
        /// </summary>
        Move,

        /// <summary>
        /// RHO
        /// </summary>
        /// <remarks>원점으로부터 거리</remarks>
        Rho,

        /// <summary>
        /// THETA
        /// </summary>
        /// <remarks>Z축의 양의 방향으로부터 원점과 P가 이루는 직선까지의 각</remarks>
        Theta,

        /// <summary>
        /// PHI
        /// </summary>
        /// <remarks>x축의 양의 방향으로부터 원점과 P가 이루는 직선을 XY 평면에 투영시킨 직선까지의 각</remarks>
        Phi
    }
}