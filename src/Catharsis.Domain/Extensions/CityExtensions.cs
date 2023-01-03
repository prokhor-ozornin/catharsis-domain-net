namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="City"/>.</para>
/// </summary>
/// <seealso cref="City"/>
public static class CityExtensions
{
  public static IQueryable<City> Area(this IQueryable<City> cities, Area area) => area != null ? cities.Where(city => city.Area != null && city.Area.Id == area.Id) : cities.Where(city => city.Area == null);

  public static IEnumerable<City> Area(this IEnumerable<City> cities, Area area) => area != null ? cities.Where(city => city?.Area != null && city.Area.Equals(area)) : cities.Where(city => city is {Area: null});

  public static IQueryable<City> Country(this IQueryable<City> cities, Country country) => country != null ? cities.Where(city => city.Country != null && city.Country.Id == country.Id) : cities.Where(city => city.Country == null);

  public static IEnumerable<City> Country(this IEnumerable<City> cities, Country country) => country != null ? cities.Where(city => city?.Country != null && city.Country.Equals(country)) : cities.Where(city => city is {Country: null});

  public static IQueryable<City> Federal(this IQueryable<City> cities, bool? federal) => cities.Where(city => city.Federal == federal);

  public static IEnumerable<City> Federal(this IEnumerable<City> cities, bool? federal) => cities.Where(city => city != null && city.Federal == federal);

  public static IQueryable<City> Name(this IQueryable<City> cities, string name) => cities.Where(city => city.Name != null && city.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<City> Name(this IEnumerable<City> cities, string name) => cities.Where(city => city?.Name != null && city.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<City> Region(this IQueryable<City> cities, Region region) => region != null ? cities.Where(city => city.Region != null && city.Region.Id == region.Id) : cities.Where(city => city.Region == null);

  public static IEnumerable<City> Region(this IEnumerable<City> cities, Region region) => region != null ? cities.Where(city => city?.Region != null && city.Region.Equals(region)) : cities.Where(city => city is {Region: null});
}