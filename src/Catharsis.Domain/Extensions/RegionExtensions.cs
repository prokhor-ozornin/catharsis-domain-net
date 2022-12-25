namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Region"/>.</para>
/// </summary>
/// <seealso cref="Region"/>
public static class RegionExtensions
{
  public static IQueryable<Region> Area(this IQueryable<Region> regions, Area? area) => area != null ? regions.Where(region => region.Area != null && region.Area.Id == area.Id) : regions.Where(region => region.Area == null);

  public static IEnumerable<Region?> Area(this IEnumerable<Region?> regions, Area? area) => area != null ? regions.Where(region => region?.Area != null && region.Area.Equals(area)) : regions.Where(region => region is {Area: null});

  public static IQueryable<Region> Name(this IQueryable<Region> regions, string name) => regions.Where(region => region.Name != null && region.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Region?> Name(this IEnumerable<Region?> regions, string name) => regions.Where(region => region?.Name != null && region.Name.ToLower().StartsWith(name.ToLower()));
}