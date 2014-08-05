namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents category of articles.</para>
  /// </summary>
  public partial interface IArticlesCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IArticlesCategory Parent { get; }
  }
}