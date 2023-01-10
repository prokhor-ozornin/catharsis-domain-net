using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Страна</para>
/// </summary>
[Description("Страна")]
[Serializable]
[DataContract(Name = nameof(Country))]
public class Country : Entity, IComparable<Country>, IEquatable<Country>
{
  /// <summary>
  ///   <para>Наименование страны</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование страны")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Основной язык страны</para>
  /// </summary>
  [DataMember(Name = nameof(Language))]
  [Description("Основной язык страны")]
  public virtual string Language { get; set; }

  /// <summary>
  ///   <para>Наименование валюты, используемой в стране</para>
  /// </summary>
  [DataMember(Name = nameof(Currency))]
  [Description("Наименование валюты, используемой в стране")]
  public virtual string Currency { get; set; }

  /// <summary>
  ///   <para>Уникальный ISO код страны</para>
  /// </summary>
  [DataMember(Name = nameof(IsoCode))]
  [Description("Уникальный ISO код страны")]
  public virtual string IsoCode { get; set; }

  /// <summary>
  ///   <para>Код валюты, используемой в стране</para>
  /// </summary>
  [DataMember(Name = nameof(CurrencyCode))]
  [Description("Код валюты, используемой в стране")]
  public virtual string CurrencyCode { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Country"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Country"/> to compare with this instance.</param>
  public virtual int CompareTo(Country other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="Country"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Country other) => this.Equality(other, nameof(IsoCode));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Country);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(IsoCode));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}