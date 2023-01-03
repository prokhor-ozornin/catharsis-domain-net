namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="News"/>.</para>
/// </summary>
/// <seealso cref="News"/>
public static class NewsExtensions
{
  public static IQueryable<News> Name(this IQueryable<News> news, string name) => news.Where(news => news.Name != null && news.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<News> Name(this IEnumerable<News> news, string name) => news.Where(news => news?.Name != null && news.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<News> Tag(this IQueryable<News> news, Tag tag) => news.Where(news => news.Tags.Contains(tag));

  public static IEnumerable<News> Tag(this IEnumerable<News> news, Tag tag) => news.Where(news => news != null && news.Tags.Contains(tag));
}