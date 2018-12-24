using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class WeatherForecast : Entity, IComparable<WeatherForecast>, IEquatable<WeatherForecast>
  {
    /// <summary>
    ///   <para>Город для прогноза</para>
    /// </summary>
    [Description(Schema.ColumnCommentCity)]
    [Column(Schema.ColumnNameCity)]
    [NotNull]
    [Indexed(Name = "idx__weather_forecast__city_id")]
    public virtual City City { get; set; }

    /// <summary>
    ///   <para>Облачность, %</para>
    /// </summary>
    [Description(Schema.ColumnCommentCloudiness)]
    [Column(Schema.ColumnNameCloudiness)]
    public virtual byte? Cloudiness { get; set; }

    /// <summary>
    ///   <para>Дата прогноза</para>
    /// </summary>
    [Description(Schema.ColumnCommentDate)]
    [Column(Schema.ColumnNameDate)]
    [NotNull]
    [Indexed(Name = "idx__weather_forecast__date")]
    public virtual DateTime? Date { get; set; }

    /// <summary>
    ///   <para>Влажность, %</para>
    /// </summary>
    [Description(Schema.ColumnCommentHumidity)]
    [Column(Schema.ColumnNameHumidity)]
    public virtual byte? Humidity { get; set; }

    /// <summary>
    ///   <para>Атмосферное давление, мм. рт. столба</para>
    /// </summary>
    [Description(Schema.ColumnCommentPressure)]
    [Column(Schema.ColumnNamePressure)]
    public virtual short? Pressure { get; set; }

    /// <summary>
    ///   <para>Температура воздуха, градусов Цельсия</para>
    /// </summary>
    [Description(Schema.ColumnCommentTemperature)]
    [Column(Schema.ColumnNameTemperature)]
    public virtual short? Temperature { get; set; }

    /// <summary>
    ///   <para>Тип погодных условий</para>
    /// </summary>
    [Description(Schema.ColumnCommentType)]
    [Column(Schema.ColumnNameType)]
    [NotNull]
    [Indexed(Name = "idx__weather_forecast__type")]
    public virtual WeatherType? Type { get; set; }

    /// <summary>
    ///   <para>Направление движения ветра, градусов</para>
    /// </summary>
    [Description(Schema.ColumnCommentWindDirection)]
    [Column(Schema.ColumnNameWindDirection)]
    public virtual decimal? WindDirection { get; set; }

    /// <summary>
    ///   <para>Скорость движения ветра, метров/сек.</para>
    /// </summary>
    [Description(Schema.ColumnCommentWindSpeed)]
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

    public static new class Schema
    {
      public const string TableName = "weather_forecast";
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