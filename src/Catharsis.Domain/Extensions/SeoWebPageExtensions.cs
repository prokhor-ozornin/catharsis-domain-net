using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class SeoWebPageExtensions
  {
    public static IQueryable<SeoWebPage> Locale(this IQueryable<SeoWebPage> webPages, string locale)
    {
      Assertion.NotNull(webPages);
      Assertion.NotEmpty(locale);

      return webPages.Where(it => it.Locale.ToLower() == locale.ToLower());
    }

    public static IEnumerable<SeoWebPage> Locale(this IEnumerable<SeoWebPage> webPages, string locale)
    {
      Assertion.NotNull(webPages);
      Assertion.NotEmpty(locale);

      return webPages.Where(it => it?.Locale != null && it.Locale.ToLower() == locale.ToLower());
    }
  }
}