namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Area"/>.</para>
/// </summary>
/// <seealso cref="Area"/>
public static class AreaExtensions
{
  public static IQueryable<Area> Country(this IQueryable<Area> areas, Country country) => country is not null ? areas.Where(area => area.Country != null && area.Country.Id == country.Id) : areas.Where(area => area.Country == null);

  public static IEnumerable<Area> Country(this IEnumerable<Area> areas, Country country) => country is not null ? areas.Where(area => area?.Country is not null && area.Country.Equals(country)) : areas.Where(area => area is { Country: null });

  public static IQueryable<Area> Name(this IQueryable<Area> areas, string name) => areas.Where(area => area.Name != null && area.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Area> Name(this IEnumerable<Area> areas, string name) => areas.Where(area => area?.Name is not null && area.Name.ToLower().StartsWith(name.ToLower()));
}