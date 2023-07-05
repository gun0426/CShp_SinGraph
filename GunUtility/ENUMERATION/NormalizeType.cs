namespace Chart_Project
{
    /// <summary>
    /// 정규화 타입
    /// </summary>
    /// <remarks>
    /// 함수가 예를 들어 "콜백"과 같이 X 및 Y에 대한 비대칭 범위를 갖는 경우 별도의 정규화는 항상 X, Y 값 간의 관계에 대한 왜곡이 되는 정사각형 X, Y 창으로 이어진다.
    /// MaintenanceXY는 X와 Y 값 간의 관계가 유지되도록 한다.
    /// MaintenanceXYZ는 추가로 X, Y 및 Z 값 간의 관계가 유지되도록 보장한다.
    /// </remarks>
    public enum NormalizeType
    {
        /// <summary>
        /// 분리
        /// </summary>
        /// <remarks>X,Y,Z를 별도로 정규화(이산 값에 사용)</remarks>
        Separate,

        /// <summary>
        /// XY 유지
        /// </summary>
        /// <remarks>관계를 변경하지 않고 X,Y 정규화(함수에 사용)</remarks>
        MaintainXY,

        /// <summary>
        /// XYZ 유지
        /// </summary>
        /// <remarks>관계를 변경하지 않고 X,Y,Z 정규화(함수에 사용)</remarks>
        MaintainXYZ
    }
}