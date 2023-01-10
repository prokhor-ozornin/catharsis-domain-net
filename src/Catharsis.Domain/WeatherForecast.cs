using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Прогноз погодных условий</para>
/// </summary>
[Description("Прогноз погодных условий")]
[Serializable]
[DataContract(Name = nameof(WeatherForecast))]
public class WeatherForecast : Entity, IComparable<WeatherForecast>, IEquatable<WeatherForecast>
{
  /// <summary>
  ///   <para>Город для прогноза</para>
  /// </summary>
  [DataMember(Name = nameof(City))]
  [Description("Город для прогноза")]
  public virtual City City { get; set; }

  /// <summary>
  ///   <para>Дата прогноза</para>
  /// </summary>
  [DataMember(Name = nameof(Date))]
  [Description("Дата прогноза")]
  public virtual DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Тип погодных условий</para>
  /// </summary>
  [DataMember(Name = nameof(Type))]
  [Description("Тип погодных условий")]
  public virtual WeatherType? Type { get; set; }

  /// <summary>
  ///   <para>Температура воздуха, градусов Цельсия</para>
  /// </summary>
  [DataMember(Name = nameof(Temperature))]
  [Description("Температура воздуха, градусов Цельсия")]
  public virtual short? Temperature { get; set; }

  /// <summary>
  ///   <para>Влажность, %</para>
  /// </summary>
  [DataMember(Name = nameof(Humidity))]
  [Description("Влажность, %")]
  public virtual byte? Humidity { get; set; }

  /// <summary>
  ///   <para>Атмосферное давление, мм. рт. столба</para>
  /// </summary>
  [DataMember(Name = nameof(Pressure))]
  [Description("Атмосферное давление, мм. рт. столба")]
  public virtual short? Pressure { get; set; }

  /// <summary>
  ///   <para>Облачность, %</para>
  /// </summary>
  [DataMember(Name = nameof(Cloudiness))]
  [Description("Облачность, %")]
  public virtual byte? Cloudiness { get; set; }

  /// <summary>
  ///   <para>Направление движения ветра, градусов</para>
  /// </summary>
  [DataMember(Name = nameof(WindDirection))]
  [Description("Направление движения ветра, градусов")]
  public virtual decimal? WindDirection { get; set; }

  /// <summary>
  ///   <para>Скорость движения ветра, метров/сек.</para>
  /// </summary>
  [DataMember(Name = nameof(WindSpeed))]
  [Description("Скорость движения ветра, метров/сек.")]
  public virtual decimal? WindSpeed { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="WeatherForecast"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="WeatherForecast"/> to compare with this instance.</param>
  public virtual int CompareTo(WeatherForecast other) => Nullable.Compare(Date, other?.Date);

  /// <summary>
  ///   <para>Determines whether two <see cref="WeatherForecast"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(WeatherForecast other) => this.Equality(other, nameof(City), nameof(Date));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as WeatherForecast);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(City), nameof(Date));

  public enum WeatherType
  {
    BrokenClouds,
    ClearSky,
    Extreme,
    FewClouds,
    Mist,
    Other,
    Rain,
    ScatteredClouds,
    ShowerRain,
    Snow,
    Thunderstorm
  }
}