namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Location"/>.</para>
/// </summary>
/// <seealso cref="Location"/>
public static class LocationExtensions
{
  public static IQueryable<Location> TimeZone(this IQueryable<Location> locations, string timezone) => locations.Where(location => location.TimeZone != null && location.TimeZone.ToLower().StartsWith(timezone.ToLower()));

  public static IEnumerable<Location> TimeZone(this IEnumerable<Location> locations, string timezone) => locations.Where(location => location?.TimeZone != null && location.TimeZone.ToLower().StartsWith(timezone.ToLower()));

  public static IQueryable<Location> Latitude(this IQueryable<Location> locations, decimal? from = null, decimal? to = null)
  {
    if (from != null)
    {
      locations = locations.Where(location => location.Latitude >= from.Value);
    }

    if (to != null)
    {
      locations = locations.Where(location => location.Latitude <= to.Value);
    }

    return locations;
  }

  public static IEnumerable<Location> Latitude(this IEnumerable<Location> locations, decimal? from = null, decimal? to = null)
  {
    if (from != null)
    {
      locations = locations.Where(location => location != null && location.Latitude >= from.Value);
    }

    if (to != null)
    {
      locations = locations.Where(location => location != null && location.Latitude <= to.Value);
    }

    return locations.Where(location => location != null);
  }

  public static IQueryable<Location> Longitude(this IQueryable<Location> locations, decimal? from = null, decimal? to = null)
  {
    if (from != null)
    {
      locations = locations.Where(location => location.Longitude >= from.Value);
    }

    if (to != null)
    {
      locations = locations.Where(location => location.Longitude <= to.Value);
    }

    return locations;
  }

  public static IEnumerable<Location> Longitude(this IEnumerable<Location> locations, decimal? from = null, decimal? to = null)
  {
    if (from != null)
    {
      locations = locations.Where(location => location != null && location.Longitude >= from.Value);
    }

    if (to != null)
    {
      locations = locations.Where(location => location != null && location.Longitude <= to.Value);
    }

    return locations.Where(location => location != null);
  }
}