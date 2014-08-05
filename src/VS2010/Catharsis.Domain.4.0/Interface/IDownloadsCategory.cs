namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents category of downloads.</para>
  /// </summary>
  public partial interface IDownloadsCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IDownloadsCategory Parent { get; }
  }
}