using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class NewsExtensions
  {
    public static IQueryable<News> Name(this IQueryable<News> news, string name)
    {
      Assertion.NotNull(news);
      Assertion.NotEmpty(name);

      return news.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<News> Name(this IEnumerable<News> news, string name)
    {
      Assertion.NotNull(news);
      Assertion.NotEmpty(name);

      return news.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IQueryable<News> Tag(this IQueryable<News> news, Tag tag)
    {
      Assertion.NotNull(news);
      Assertion.NotNull(tag);

      return news.Where(it => it.Tags.Contains(tag));
    }

    public static IEnumerable<News> Tag(this IEnumerable<News> news, Tag tag)
    {
      Assertion.NotNull(news);
      Assertion.NotNull(tag);

      return news.Where(it => it != null && it.Tags.Contains(tag));
    }
  }
}