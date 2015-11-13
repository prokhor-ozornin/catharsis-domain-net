using Catharsis.Commons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain.Extensions
{
  public static class WeatherForecastExtensions
  {
    public static IQueryable<WeatherForecast> City(this IQueryable<WeatherForecast> forecasts, City city)
    {
      Assertion.NotNull(forecasts);

      return city != null ? forecasts.Where(it => it.City.Id == city.Id) : forecasts.Where(it => it.City == null);
    }

    public static IEnumerable<WeatherForecast> City(this IEnumerable<WeatherForecast> forecasts, City city)
    {
      Assertion.NotNull(forecasts);

      return city != null ? forecasts.Where(it => it?.City != null && it.City.Equals(city)) : forecasts.Where(it => it != null && it.City == null);
    }

    public static IQueryable<WeatherForecast> Date(this IQueryable<WeatherForecast> forecasts, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(forecasts);

      if (from != null)
      {
        forecasts = forecasts.Where(it => it.Date >= from.Value);
      }

      if (to != null)
      {
        forecasts = forecasts.Where(it => it.Date <= to.Value);
      }

      return forecasts;
    }

    public static IEnumerable<WeatherForecast> Date(this IEnumerable<WeatherForecast> forecasts, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(forecasts);

      if (from != null)
      {
        forecasts = forecasts.Where(it => it != null && it.Date >= from.Value);
      }

      if (to != null)
      {
        forecasts = forecasts.Where(it => it != null && it.Date <= to.Value);
      }

      return forecasts.Where(it => it != null);
    }

    public static IQueryable<WeatherForecast> Type(this IQueryable<WeatherForecast> forecasts, WeatherType type)
    {
      Assertion.NotNull(forecasts);

      return forecasts.Where(it => it.Type == type);
    }

    public static IEnumerable<WeatherForecast> Type(this IEnumerable<WeatherForecast> forecasts, WeatherType type)
    {
      Assertion.NotNull(forecasts);

      return forecasts.Where(it => it != null && it.Type == type);
    }
  }
}