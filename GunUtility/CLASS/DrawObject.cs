namespace Chart_Project
{
    /// <summary>
    /// 그리기 객체
    /// </summary>
    public class DrawObject
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region Field

        /// <summary>
        /// 다각형
        /// </summary>
        public Polygon Polygon;

        /// <summary>
        /// 스캐터
        /// </summary>
        public Scatter Scatter;

        /// <summary>
        /// 선
        /// </summary>
        public Line Line;

        /// <summary>
        /// 정렬
        /// </summary>
        public double Sort;

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

        #region 생성자 - DrawObject(polygon, sort)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="polygon">다각형</param>
        /// <param name="sort">정렬</param>
        public DrawObject(Polygon polygon, double sort)
        {
            Polygon = polygon;

            this.isValid = polygon.IsValid;

            Sort = sort;
        }

        #endregion
        #region 생성자 - DrawObject(scatter, sort)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="scatter">스캐터</param>
        /// <param name="sort">정렬</param>
        public DrawObject(Scatter scatter, double sort)
        {
            Scatter = scatter;

            this.isValid = scatter.IsValid;

            Sort = sort;
        }

        #endregion
        #region 생성자 - DrawObject(line, sort)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="line">선</param>
        /// <param name="sort">정렬</param>
        public DrawObject(Line line, double sort)
        {
            Line = line;

            this.isValid = line.IsValid;

            Sort = sort;
        }

        #endregion
    }
}