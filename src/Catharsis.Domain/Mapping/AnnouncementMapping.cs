namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Announcement"/> entity.</para>
/// </summary>
public sealed class AnnouncementMapping : EntityMapping<Announcement>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public AnnouncementMapping()
  {
    Table("announcement");
    Map(announcement => announcement.Name).Column("name").Not.Nullable().Index("ix-announcement-name");
    Map(announcement => announcement.Text).Column("text").Not.Nullable().Length(4000);
    References(announcement => announcement.Image).Column("image_id").Fetch.Join().ForeignKey("fk-announcement2image").Index("ix-announcement-image_id");
    Map(announcement => announcement.Price).Column("price").Check("price >= 0").Index("ix-announcement-price");
    Map(announcement => announcement.PriceCurrency).Column("price_currency").Index("ix-announcement-price_currency");
  }
}