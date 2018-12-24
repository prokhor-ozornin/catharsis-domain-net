using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class AreaExtensions
  {
    public static IQueryable<Area> Country(this IQueryable<Area> areas, Country country)
    {
      Assertion.NotNull(areas);

      return country != null ? areas.Where(it => it.Country.Id == country.Id) : areas.Where(it => it.Country == null);
    }

    public static IEnumerable<Area> Country(this IEnumerable<Area> areas, Country country)
    {
      Assertion.NotNull(areas);

      return country != null ? areas.Where(it => it?.Country != null && it.Country.Equals(country)) : areas.Where(it => it != null && it.Country == null);
    }

    public static IQueryable<Area> Name(this IQueryable<Area> areas, string name)
    {
      Assertion.NotNull(areas);
      Assertion.NotEmpty(name);

      return areas.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Area> Name(this IEnumerable<Area> areas, string name)
    {
      Assertion.NotNull(areas);
      Assertion.NotEmpty(name);

      return areas.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}