namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Category of web links.</para>
  /// </summary>
  public partial interface IWebLinksCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IWebLinksCategory Parent { get; }
  }
}