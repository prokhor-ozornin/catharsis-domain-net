using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class CityExtensions
  {
    public static IQueryable<City> Area(this IQueryable<City> cities, Area area)
    {
      Assertion.NotNull(cities);

      return area != null ? cities.Where(it => it.Area.Id == area.Id) : cities.Where(it => it.Area == null);
    }

    public static IEnumerable<City> Area(this IEnumerable<City> cities, Area area)
    {
      Assertion.NotNull(cities);

      return area != null ? cities.Where(it => it?.Area != null && it.Area.Equals(area)) : cities.Where(it => it != null && it.Area == null);
    }

    public static IQueryable<City> Country(this IQueryable<City> cities, Country country)
    {
      Assertion.NotNull(cities);

      return country != null ? cities.Where(it => it.Country.Id == country.Id) : cities.Where(it => it.Country == null);
    }

    public static IEnumerable<City> Country(this IEnumerable<City> cities, Country country)
    {
      Assertion.NotNull(cities);

      return country != null ? cities.Where(it => it?.Country != null && it.Country.Equals(country)) : cities.Where(it => it != null && it.Country == null);
    }

    public static IQueryable<City> Federal(this IQueryable<City> cities, bool federal)
    {
      Assertion.NotNull(cities);

      return cities.Where(it => it.Federal == federal);
    }

    public static IEnumerable<City> Federal(this IEnumerable<City> cities, bool federal)
    {
      Assertion.NotNull(cities);

      return cities.Where(it => it != null && it.Federal == federal);
    }

    public static IQueryable<City> Name(this IQueryable<City> cities, string name)
    {
      Assertion.NotNull(cities);
      Assertion.NotEmpty(name);

      return cities.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<City> Name(this IEnumerable<City> cities, string name)
    {
      Assertion.NotNull(cities);
      Assertion.NotEmpty(name);

      return cities.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IQueryable<City> Region(this IQueryable<City> cities, Region region)
    {
      Assertion.NotNull(cities);

      return region != null ? cities.Where(it => it.Region.Id == region.Id) : cities.Where(it => it.Region == null);
    }

    public static IEnumerable<City> Region(this IEnumerable<City> cities, Region region)
    {
      Assertion.NotNull(cities);

      return region != null ? cities.Where(it => it?.Region != null && it.Region.Equals(region)) : cities.Where(it => it != null && it.Region == null);
    }
  }
}