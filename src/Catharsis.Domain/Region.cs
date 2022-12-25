using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Регион</para>
/// </summary>
[Description("Регион")]
[Serializable]
[DataContract(Name = nameof(Region))]
public class Region : Entity, IComparable<Region>, IEquatable<Region>
{
  /// <summary>
  ///   <para>Наименование региона</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование региона")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>Территория, к которой относится регион</para>
  /// </summary>
  [DataMember(Name = nameof(Area))]
  [Description("Территория, к которой относится регион")]
  public virtual Area? Area { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Region"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Region"/> to compare with this instance.</param>
  public virtual int CompareTo(Region? other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="Region"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Region? other) => this.Equality(other, nameof(Area), nameof(Name));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as Region);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Area), nameof(Name));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}