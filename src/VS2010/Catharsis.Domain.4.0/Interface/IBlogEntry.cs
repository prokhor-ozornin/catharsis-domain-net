namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents text record in user's blog/journal.</para>
  /// </summary>
  public partial interface IBlogEntry : IItem
  {
    /// <summary>
    ///   <para>Blog of published entry.</para>
    /// </summary>
    IBlog Blog { get; }
  }
}