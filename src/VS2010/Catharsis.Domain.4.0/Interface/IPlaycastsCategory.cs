namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Category of playcasts.</para>
  /// </summary>
  public partial interface IPlaycastsCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IPlaycastsCategory Parent { get; }
  }
}