namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="WeatherForecast"/> entity.</para>
/// </summary>
public sealed class WeatherForecastMapping : EntityMapping<WeatherForecast>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public WeatherForecastMapping()
  {
    Table("weather_forecast");
    References(forecast => forecast.City).Column("city_id").Not.Nullable().Fetch.Join().ForeignKey("fk-weather_forecast2city").Index("ix-weather_forecast-city_id");
    Map(forecast => forecast.Date).Column("date").Not.Nullable().Index("ix-weather_forecast-date");
    Map(forecast => forecast.Type).Column("type").Not.Nullable().Index("ix-weather_forecast-type");
    Map(forecast => forecast.Temperature).Column("temperature");
    Map(forecast => forecast.Humidity).Column("humidity").Check("humidity >= 0");
    Map(forecast => forecast.Pressure).Column("pressure").Check("pressure >= 0");
    Map(forecast => forecast.Cloudiness).Column("cloudiness").Check("cloudiness >= 0");
    Map(forecast => forecast.WindDirection).Column("wind_direction").Check("wind_direction BETWEEN 0 AND 360");
    Map(forecast => forecast.WindSpeed).Column("wind_speed").Check("wind_speed >= 0");
  }
}