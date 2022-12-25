namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="WeatherForecast"/>.</para>
/// </summary>
/// <seealso cref="WeatherForecast"/>
public static class WeatherForecastExtensions
{
  public static IQueryable<WeatherForecast> City(this IQueryable<WeatherForecast> forecasts, City? city) => city != null ? forecasts.Where(forecast => forecast.City != null && forecast.City.Id == city.Id) : forecasts.Where(forecast => forecast.City == null);

  public static IEnumerable<WeatherForecast?> City(this IEnumerable<WeatherForecast?> forecasts, City? city) => city != null ? forecasts.Where(forecast => forecast?.City != null && forecast.City.Equals(city)) : forecasts.Where(forecast => forecast is {City: null});

  public static IQueryable<WeatherForecast> Type(this IQueryable<WeatherForecast> forecasts, WeatherForecast.WeatherType? type) => forecasts.Where(forecast => forecast.Type == type);

  public static IEnumerable<WeatherForecast?> Type(this IEnumerable<WeatherForecast?> forecasts, WeatherForecast.WeatherType? type) => forecasts.Where(forecast => forecast != null && forecast.Type == type);

  public static IQueryable<WeatherForecast> Date(this IQueryable<WeatherForecast> forecasts, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      forecasts = forecasts.Where(forecast => forecast.Date >= from.Value);
    }

    if (to != null)
    {
      forecasts = forecasts.Where(forecast => forecast.Date <= to.Value);
    }

    return forecasts;
  }

  public static IEnumerable<WeatherForecast?> Date(this IEnumerable<WeatherForecast?> forecasts, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      forecasts = forecasts.Where(forecast => forecast != null && forecast.Date >= from.Value);
    }

    if (to != null)
    {
      forecasts = forecasts.Where(forecast => forecast != null && forecast.Date <= to.Value);
    }

    return forecasts.Where(forecast => forecast != null);
  }
}