using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Город</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Город")]
#endif
  public partial class City : Entity, IComparable<City>, IEquatable<City>
  {
    /// <summary>
    ///   <para>Территория, к которой относится город</para>
    /// </summary>
#if NET_35
    [Description("Территория, к которой относится город")]
#endif
    public virtual Area Area { get; set; }

    /// <summary>
    ///   <para>Страна, в которой расположен город</para>
    /// </summary>
#if NET_35
    [Description("Страна, в которой расположен город")]
#endif
    public virtual Country Country { get; set; }

    /// <summary>
    ///   <para>Признак того, что город имеет федеральное значение</para>
    /// </summary>
#if NET_35
    [Description("Признак того, что город имеет федеральное значение")]
#endif
    public virtual bool? Federal { get; set; }

    /// <summary>
    ///   <para>Географические координаты города</para>
    /// </summary>
#if NET_35
    [Description("Географические координаты города")]
#endif
    public virtual Location Location { get; set; }

    /// <summary>
    ///   <para>Наименование города</para>
    /// </summary>
#if NET_35
    [Description("Наименование города")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Регион, к которому относится город</para>
    /// </summary>
#if NET_35
    [Description("Регион, к которому относится город")]
#endif
    public virtual Region Region { get; set; }

    public virtual int CompareTo(City other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(City other)
    {
      return this.Equality(other, it => it.Area, it => it.Country, it => it.Name, it => it.Region);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as City);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Area, it => it.Country, it => it.Name, it => it.Region);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}