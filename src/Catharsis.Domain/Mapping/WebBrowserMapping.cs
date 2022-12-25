namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="WebBrowser"/> entity.</para>
/// </summary>
public sealed class WebBrowserMapping : EntityMapping<WebBrowser>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public WebBrowserMapping()
  {
    Table("web_browser");
    Map(browser => browser.Name).Column("name");
    Map(browser => browser.Uri).Column("uri").Length(1000);
    Map(browser => browser.UserAgent).Column("user_agent").Not.Nullable().Length(1000).UniqueKey("uk-web_browser-user_agent");
    Map(browser => browser.Description).Column("description");
  }
}