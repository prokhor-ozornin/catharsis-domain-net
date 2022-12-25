namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="WebPage"/> entity.</para>
/// </summary>
public sealed class WebPageMapping : EntityMapping<WebPage>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public WebPageMapping()
  {
    Table("web_page");
    Map(page => page.Name).Column("name").Not.Nullable().Index("ix-web_page-name");
    Map(page => page.Uri).Column("uri").Not.Nullable().Length(1000).Index("ix-web_page-uri");
    Map(page => page.Locale).Column("locale").Not.Nullable().Length(2).Index("ix-web_page-locale");
    Map(page => page.Text).Column("text").Not.Nullable().Length(short.MaxValue);
  }
}