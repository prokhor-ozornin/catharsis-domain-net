namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="WebLink"/>.</para>
/// </summary>
/// <seealso cref="WebLink"/>
public static class WebLinkExtensions
{
  public static IQueryable<WebLink> Name(this IQueryable<WebLink> webLinks, string name) => webLinks.Where(link => link.Name != null && link.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<WebLink?> Name(this IEnumerable<WebLink?> addresses, string name) => addresses.Where(link => link?.Name != null && link.Name.ToLower().StartsWith(name.ToLower()));
}