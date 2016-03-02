using Catharsis.Commons;
using SQLite;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class WeatherForecast : Entity, IComparable<WeatherForecast>, IEquatable<WeatherForecast>
  {
    /// <summary>
    ///   <para>Город для прогноза</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentCity)]
#endif
    [Column(Schema.ColumnNameCity)]
    [NotNull]
    [Indexed(Name = "idx__weather_forecasts__city_id")]
    public virtual City City { get; set; }

    /// <summary>
    ///   <para>Облачность, %</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentCloudiness)]
#endif
    [Column(Schema.ColumnNameCloudiness)]
    public virtual byte? Cloudiness { get; set; }

    /// <summary>
    ///   <para>Дата прогноза</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDate)]
#endif
    [Column(Schema.ColumnNameDate)]
    [NotNull]
    [Indexed(Name = "idx__weather_forecasts__date")]
    public virtual DateTime? Date { get; set; }

    /// <summary>
    ///   <para>Влажность, %</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentHumidity)]
#endif
    [Column(Schema.ColumnNameHumidity)]
    public virtual byte? Humidity { get; set; }

    /// <summary>
    ///   <para>Атмосферное давление, мм. рт. столба</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentPressure)]
#endif
    [Column(Schema.ColumnNamePressure)]
    public virtual short? Pressure { get; set; }

    /// <summary>
    ///   <para>Температура воздуха, градусов Цельсия</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentTemperature)]
#endif
    [Column(Schema.ColumnNameTemperature)]
    public virtual short? Temperature { get; set; }

    /// <summary>
    ///   <para>Тип погодных условий</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentType)]
#endif
    [Column(Schema.ColumnNameType)]
    [NotNull]
    [Indexed(Name = "idx__weather_forecasts__type")]
    public virtual WeatherType? Type { get; set; }

    /// <summary>
    ///   <para>Направление движения ветра, градусов</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentWindDirection)]
#endif
    [Column(Schema.ColumnNameWindDirection)]
    public virtual decimal? WindDirection { get; set; }

    /// <summary>
    ///   <para>Скорость движения ветра, метров/сек.</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentWindSpeed)]
#endif
    [Column(Schema.ColumnNameWindSpeed)]
    public virtual decimal? WindSpeed { get; set; }

    public virtual int CompareTo(WeatherForecast other)
    {
      return this.Date.Value.CompareTo(other.Date.Value);
    }

    public virtual bool Equals(WeatherForecast other)
    {
      return this.Equality(other, it => it.City, it => it.Date);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WeatherForecast);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.City, it => it.Date);
    }

    public static class Schema
    {
      public const string TableName = "weather_forecasts";
      public const string TableComment = "Прогнозы погоды по дням";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления прогноза погоды";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления прогноза погоды";

      public const string ColumnNameCity = "city_id";
      public const string ColumnCommentCity = "Город для прогноза";

      public const string ColumnNameCloudiness = "cloudiness";
      public const string ColumnCommentCloudiness = "Облачность, %";

      public const string ColumnNameDate = "date";
      public const string ColumnCommentDate = "Дата прогноза";

      public const string ColumnNameHumidity = "humidity";
      public const string ColumnCommentHumidity = "Влажность, %";

      public const string ColumnNamePressure = "pressure";
      public const string ColumnCommentPressure = "Атмосферное давление, мм. рт. столба";

      public const string ColumnNameTemperature = "temperature";
      public const string ColumnCommentTemperature = "Температура воздуха, градусов Цельсия";

      public const string ColumnNameType = "type";
      public const string ColumnCommentType = "Тип погодных условий";

      public const string ColumnNameWindDirection = "wind_direction";
      public const string ColumnCommentWindDirection = "Направление движения ветра, градусов";

      public const string ColumnNameWindSpeed = "wind_speed";
      public const string ColumnCommentWindSpeed = "Скорость движения ветра, метров/сек.";
    }
  }
}