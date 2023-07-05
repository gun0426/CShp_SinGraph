namespace Chart_Project
{
    /// <summary>
    /// 래스터 타입
    /// </summary>
    public enum RasterType
    {
        /// <summary>
        /// OFF
        /// </summary>
        /// <remarks>좌표계를 그리지 않는다.</remarks>
        Off,

        /// <summary>
        /// 메인 축
        /// </summary>
        /// <remarks>X, Y, Z축을 그린다.</remarks>
        MainAxis,

        /// <summary>
        /// 래스터
        /// </summary>
        /// <remarks>축과 점선을 그린다.</remarks>
        Raster,

        /// <summary>
        /// 레이블
        /// </summary>
        /// <remarks>3사분면에서 축과 점선 그리고 레이블을 그린다.</remarks>
        Label,
    }
}