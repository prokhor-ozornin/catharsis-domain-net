namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents category of announcements.</para>
  /// </summary>
  public partial interface IAnnouncementsCategory : ICategory
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    IAnnouncementsCategory Parent { get; }
  }
}