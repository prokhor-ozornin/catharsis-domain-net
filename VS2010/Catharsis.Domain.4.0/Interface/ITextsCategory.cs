namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Category of texts.</para>
  /// </summary>
  public partial interface ITextsCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    ITextsCategory Parent { get; }
  }
}