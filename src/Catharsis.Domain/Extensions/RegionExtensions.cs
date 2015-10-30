using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class RegionExtensions
  {
    public static IQueryable<Region> Area(this IQueryable<Region> regions, Area area)
    {
      Assertion.NotNull(regions);

      return area != null ? regions.Where(it => it.Area.Id == area.Id) : regions.Where(it => it.Area == null);
    }

    public static IEnumerable<Region> Area(this IEnumerable<Region> regions, Area area)
    {
      Assertion.NotNull(regions);

      return area != null ? regions.Where(it => it?.Area != null && it.Area.Equals(area)) : regions.Where(it => it != null && it.Area == null);
    }

    public static IQueryable<Region> Name(this IQueryable<Region> regions, string name)
    {
      Assertion.NotNull(regions);
      Assertion.NotEmpty(name);

      return regions.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Region> Name(this IEnumerable<Region> regions, string name)
    {
      Assertion.NotNull(regions);
      Assertion.NotEmpty(name);

      return regions.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}