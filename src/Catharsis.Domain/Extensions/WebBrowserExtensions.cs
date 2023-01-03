namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="WebBrowser"/>.</para>
/// </summary>
/// <seealso cref="WebBrowser"/>
public static class WebBrowserExtensions
{
  public static IQueryable<WebBrowser> Name(this IQueryable<WebBrowser> browsers, string name) => browsers.Where(browser => browser.Name != null && browser.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<WebBrowser> Name(this IEnumerable<WebBrowser> browsers, string name) => browsers.Where(browser => browser?.Name != null && browser.Name.ToLower().StartsWith(name.ToLower()));

  public static WebBrowser ValueOf(this IQueryable<WebBrowser> browsers, string userAgent) => browsers.SingleOrDefault(browser => browser.UserAgent != null && browser.UserAgent.ToLower() == userAgent.ToLower());

  public static WebBrowser ValueOf(this IEnumerable<WebBrowser> browsers, string userAgent) => browsers.SingleOrDefault(browser => browser?.UserAgent != null && browser.UserAgent.ToLower() == userAgent.ToLower());
}