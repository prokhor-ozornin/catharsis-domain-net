namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="SeoWebPage"/> entity.</para>
/// </summary>
public sealed class SeoWebPageMapping : EntityMapping<SeoWebPage>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public SeoWebPageMapping()
  {
    Table("seo_web_page");
    Map(page => page.Title).Column("title").Not.Nullable();
    Map(page => page.Uri).Column("uri").Not.Nullable().Length(1000).Index("ix-seo_web_page-uri");
    Map(page => page.Locale).Column("locale").Not.Nullable().Length(2).Index("ix-seo_web_page-locale");
  }
}