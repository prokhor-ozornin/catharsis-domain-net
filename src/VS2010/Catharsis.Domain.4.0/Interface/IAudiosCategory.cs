namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents category of audios.</para>
  /// </summary>
  public partial interface IAudiosCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IAudiosCategory Parent { get; }
  }
}