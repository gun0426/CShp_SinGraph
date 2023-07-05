namespace Chart_Project
{
    //////////////////////////////////////////////////////////////////////////////////////////////////// Delegate
    ////////////////////////////////////////////////////////////////////////////////////////// Public

    #region 렌더러 대리자 - RendererDelegate(x, y)

    /// <summary>
    /// 렌더러 대리자
    /// </summary>
    /// <param name="x">X</param>
    /// <param name="y">Y</param>
    /// <returns>값</returns>
    public delegate double RendererDelegate(double x, double y);

    #endregion
}