using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class WebBrowserExtensions
  {
    public static IQueryable<WebBrowser> Name(this IQueryable<WebBrowser> browsers, string name)
    {
      Assertion.NotNull(browsers);
      Assertion.NotEmpty(name);

      return browsers.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<WebBrowser> Name(this IEnumerable<WebBrowser> browsers, string name)
    {
      Assertion.NotNull(browsers);
      Assertion.NotEmpty(name);

      return browsers.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static WebBrowser ValueOf(this IQueryable<WebBrowser> browsers, string userAgent)
    {
      Assertion.NotNull(browsers);
      Assertion.NotEmpty(userAgent);

      return browsers.SingleOrDefault(it => it.UserAgent.ToLower() == userAgent.ToLower());
    }

    public static WebBrowser ValueOf(this IEnumerable<WebBrowser> browsers, string userAgent)
    {
      Assertion.NotNull(browsers);
      Assertion.NotEmpty(userAgent);

      return browsers.SingleOrDefault(it => it?.UserAgent != null && it.UserAgent.ToLower() == userAgent.ToLower());
    }
  }
}