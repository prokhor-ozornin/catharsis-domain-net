namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a free or paid informational message.</para>
  /// </summary>
  public partial interface IAnnouncement : IItem
  {
    /// <summary>
    ///   <para>Category of announcement.</para>
    /// </summary>
    IAnnouncementsCategory Category { get; }

    /// <summary>
    ///   <para>Currency of announcement's price.</para>
    /// </summary>
    string Currency { get; }

    /// <summary>
    ///   <para>URI of announcement's image.</para>
    /// </summary>
    string Image { get; }

    /// <summary>
    ///   <para>Price of announcement.</para>
    /// </summary>
    decimal? Price { get; }
  }
}