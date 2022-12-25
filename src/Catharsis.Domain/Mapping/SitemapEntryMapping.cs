namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="SitemapEntry"/> entity.</para>
/// </summary>
public sealed class SitemapEntryMapping : EntityMapping<SitemapEntry>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public SitemapEntryMapping()
  {
    Table("sitemap_entry");
    Map(entry => entry.Uri).Column("uri").Not.Nullable().Length(1000).UniqueKey("uk-sitemap_entry-uri");
    Map(entry => entry.ChangeFrequency).Column("change_frequency").Index("ix-sitemap_entry-change_frequency");
    Map(entry => entry.Priority).Column("priority").Check("priority >= 0").Index("ix-sitemap_entry-priority");
    Map(entry => entry.Date).Column("date").Index("ix-sitemap_entry-date");
    Map(entry => entry.Description).Column("description");
  }
}