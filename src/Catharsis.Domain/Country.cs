using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Страна</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Страна")]
#endif
  public partial class Country : Entity, IComparable<Country>, IEquatable<Country>
  {
    /// <summary>
    ///   <para>Наименование валюты, используемой в стране</para>
    /// </summary>
#if NET_35
    [Description("Наименование валюты, используемой в стране")]
#endif
    public virtual string Currency { get; set; }

    /// <summary>
    ///   <para>Код валюты, используемой в стране</para>
    /// </summary>
#if NET_35
    [Description("Код валюты, используемой в стране")]
#endif
    public virtual string CurrencyCode { get; set; }

    /// <summary>
    ///   <para>Уникальный ISO код страны</para>
    /// </summary>
#if NET_35
    [Description("Уникальный ISO код страны")]
#endif
    public virtual string IsoCode { get; set; }

    /// <summary>
    ///   <para>Основной язык страны</para>
    /// </summary>
#if NET_35
    [Description("Основной язык страны")]
#endif
    public virtual string Language { get; set; }

    /// <summary>
    ///   <para>Наименование страны</para>
    /// </summary>
#if NET_35
    [Description("Наименование страны")]
#endif
    public virtual string Name { get; set; }

    public virtual int CompareTo(Country other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(Country other)
    {
      return this.Equality(other, it => it.IsoCode);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Country);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.IsoCode);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}