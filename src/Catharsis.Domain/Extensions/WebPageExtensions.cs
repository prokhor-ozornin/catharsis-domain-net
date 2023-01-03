namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="WebPage"/>.</para>
/// </summary>
/// <seealso cref="WebPage"/>
public static class WebPageExtensions
{
  public static IQueryable<WebPage> Locale(this IQueryable<WebPage> webPages, string locale) => webPages.Where(page => page.Locale != null && page.Locale.ToLower() == locale.ToLower());

  public static IEnumerable<WebPage> Locale(this IEnumerable<WebPage> webPages, string locale) => webPages.Where(page => page?.Locale != null && page.Locale.ToLower() == locale.ToLower());

  public static IQueryable<WebPage> Name(this IQueryable<WebPage> webPages, string name) => webPages.Where(page => page.Name != null && page.Name.ToLower().StartsWith(name.ToLower()));
  
  public static IEnumerable<WebPage> Name(this IEnumerable<WebPage> webPages, string name) => webPages.Where(page => page?.Name != null && page.Name.ToLower().StartsWith(name.ToLower()));
}