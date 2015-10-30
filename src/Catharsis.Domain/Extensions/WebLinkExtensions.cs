using Catharsis.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain
{
  public static class WebLinkExtensions
  {
    public static IQueryable<WebLink> Name(this IQueryable<WebLink> webLinks, string name)
    {
      Assertion.NotNull(webLinks);
      Assertion.NotEmpty(name);

      return webLinks.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<WebLink> Name(this IEnumerable<WebLink> addresses, string name)
    {
      Assertion.NotNull(addresses);
      Assertion.NotEmpty(name);

      return addresses.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}