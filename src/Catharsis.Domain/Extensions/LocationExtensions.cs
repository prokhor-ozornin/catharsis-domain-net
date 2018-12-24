using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class LocationExtensions
  {
    public static IQueryable<Location> Latitude(this IQueryable<Location> locations, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(locations);

      if (from != null)
      {
        locations = locations.Where(it => it.Latitude >= from.Value);
      }

      if (to != null)
      {
        locations = locations.Where(it => it.Latitude <= to.Value);
      }

      return locations;
    }

    public static IEnumerable<Location> Latitude(this IEnumerable<Location> locations, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(locations);

      if (from != null)
      {
        locations = locations.Where(it => it != null && it.Latitude >= from.Value);
      }

      if (to != null)
      {
        locations = locations.Where(it => it != null && it.Latitude <= to.Value);
      }

      return locations.Where(it => it != null);
    }

    public static IQueryable<Location> Longitude(this IQueryable<Location> locations, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(locations);

      if (from != null)
      {
        locations = locations.Where(it => it.Longitude >= from.Value);
      }

      if (to != null)
      {
        locations = locations.Where(it => it.Longitude <= to.Value);
      }

      return locations;
    }

    public static IEnumerable<Location> Longitude(this IEnumerable<Location> locations, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(locations);

      if (from != null)
      {
        locations = locations.Where(it => it != null && it.Longitude >= from.Value);
      }

      if (to != null)
      {
        locations = locations.Where(it => it != null && it.Longitude <= to.Value);
      }

      return locations.Where(it => it != null);
    }

    public static IQueryable<Location> Timezone(this IQueryable<Location> locations, string timezone)
    {
      Assertion.NotNull(locations);
      Assertion.NotEmpty(timezone);

      return locations.Where(it => it.Timezone.ToLower().StartsWith(timezone.ToLower()));
    }

    public static IEnumerable<Location> Timezone(this IEnumerable<Location> locations, string timezone)
    {
      Assertion.NotNull(locations);
      Assertion.NotEmpty(timezone);

      return locations.Where(it => it?.Timezone != null && it.Timezone.ToLower().StartsWith(timezone.ToLower()));
    }
  }
}