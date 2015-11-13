using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
#if NET_35
  [Serializable]
  [Description("Прогноз погоды")]
#endif
  public partial class WeatherForecast : Entity, IComparable<WeatherForecast>, IEquatable<WeatherForecast>
  {
    /// <summary>
    ///   <para>Город для прогноза</para>
    /// </summary>
#if NET_35
    [Description("Город для прогноза")]
#endif
    public virtual City City { get; set; }

    /// <summary>
    ///   <para>Облачность, %</para>
    /// </summary>
#if NET_35
    [Description("Облачность, %")]
#endif
    public virtual byte? Cloudiness { get; set; }

    /// <summary>
    ///   <para>Дата прогноза</para>
    /// </summary>
#if NET_35
    [Description("Дата прогноза")]
#endif
    public virtual DateTime? Date { get; set; }

    /// <summary>
    ///   <para>Влажность, %</para>
    /// </summary>
#if NET_35
    [Description("Влажность, %")]
#endif
    public virtual byte? Humidity { get; set; }

    /// <summary>
    ///   <para>Атмосферное давление, мм. рт. столба</para>
    /// </summary>
#if NET_35
    [Description("Атмосферное давление, мм. рт. столба")]
#endif
    public virtual short? Pressure { get; set; }

    /// <summary>
    ///   <para>Температура воздуха, градусов Цельсия</para>
    /// </summary>
#if NET_35
    [Description("Температура воздуха, градусов Цельсия")]
#endif
    public virtual short? Temperature { get; set; }

    /// <summary>
    ///   <para>Тип погодных условий</para>
    /// </summary>
#if NET_35
    [Description("Тип погодных условий")]
#endif
    public virtual WeatherType? Type { get; set; }

    /// <summary>
    ///   <para>Направление движения ветра, градусов</para>
    /// </summary>
#if NET_35
    [Description("Направление движения ветра, градусов")]
#endif
    public virtual decimal? WindDirection { get; set; }

    /// <summary>
    ///   <para>Скорость движения ветра, метров/сек.</para>
    /// </summary>
#if NET_35
    [Description("Скорость движения ветра, метров/сек.")]
#endif
    public virtual decimal? WindSpeed { get; set; }

    public virtual int CompareTo(WeatherForecast other)
    {
      return this.Date.Value.CompareTo(other.Date.Value);
    }

    public bool Equals(WeatherForecast other)
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
  }
}