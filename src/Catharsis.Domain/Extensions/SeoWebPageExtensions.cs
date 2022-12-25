namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="SeoWebPage"/>.</para>
/// </summary>
/// <seealso cref="SeoWebPage"/>
public static class SeoWebPageExtensions
{
  public static IQueryable<SeoWebPage> Locale(this IQueryable<SeoWebPage> webPages, string locale) => webPages.Where(page => page.Locale != null && page.Locale.ToLower() == locale.ToLower());

  public static IEnumerable<SeoWebPage?> Locale(this IEnumerable<SeoWebPage?> webPages, string locale) => webPages.Where(page => page?.Locale != null && page.Locale.ToLower() == locale.ToLower());
}