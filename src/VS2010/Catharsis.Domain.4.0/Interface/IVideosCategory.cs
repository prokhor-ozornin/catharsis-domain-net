namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Category of videos.</para>
  /// </summary>
  public partial interface IVideosCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IVideosCategory Parent { get; }
  }
}