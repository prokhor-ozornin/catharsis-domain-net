using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class WebPageExtensions
  {
    public static IQueryable<WebPage> Locale(this IQueryable<WebPage> webPages, string locale)
    {
      Assertion.NotNull(webPages);
      Assertion.NotEmpty(locale);

      return webPages.Where(it => it.Locale.ToLower() == locale.ToLower());
    }

    public static IEnumerable<WebPage> Locale(this IEnumerable<WebPage> webPages, string locale)
    {
      Assertion.NotNull(webPages);
      Assertion.NotEmpty(locale);

      return webPages.Where(it => it?.Locale != null && it.Locale.ToLower() == locale.ToLower());
    }

    public static IQueryable<WebPage> Name(this IQueryable<WebPage> webPages, string name)
    {
      Assertion.NotNull(webPages);
      Assertion.NotEmpty(name);

      return webPages.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<WebPage> Name(this IEnumerable<WebPage> webPages, string name)
    {
      Assertion.NotNull(webPages);
      Assertion.NotEmpty(name);

      return webPages.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}