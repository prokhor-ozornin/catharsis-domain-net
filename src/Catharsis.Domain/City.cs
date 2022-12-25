using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Город</para>
/// </summary>
[Description("Город")]
[Serializable]
[DataContract(Name = nameof(City))]
public class City : Entity, IComparable<City>, IEquatable<City>
{
  /// <summary>
  ///   <para>Наименование города</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование города")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>Признак того, что город имеет федеральное значение</para>
  /// </summary>
  [DataMember(Name = nameof(Federal))]
  [Description("Признак того, что город имеет федеральное значение")]
  public virtual bool? Federal { get; set; }

  /// <summary>
  ///   <para>Страна, в которой расположен город</para>
  /// </summary>
  [DataMember(Name = nameof(Country))]
  [Description("Страна, в которой расположен город")]
  public virtual Country? Country { get; set; }

  /// <summary>
  ///   <para>Регион, к которому относится город</para>
  /// </summary>
  [DataMember(Name = nameof(Region))]
  [Description("Регион, к которому относится город")]
  public virtual Region? Region { get; set; }

  /// <summary>
  ///   <para>Территория, к которой относится город</para>
  /// </summary>
  [DataMember(Name = nameof(Area))]
  [Description("Территория, к которой относится город")]
  public virtual Area? Area { get; set; }

  /// <summary>
  ///   <para>Географические координаты города</para>
  /// </summary>
  [DataMember(Name = nameof(Location))]
  [Description("Географические координаты города")]
  public virtual Location? Location { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="City"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="City"/> to compare with this instance.</param>
  public virtual int CompareTo(City? other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="City"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(City? other) => this.Equality(other, nameof(Area), nameof(Country), nameof(Name), nameof(Region));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as City);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Area), nameof(Country), nameof(Name), nameof(Region));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}