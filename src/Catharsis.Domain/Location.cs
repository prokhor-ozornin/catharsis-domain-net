using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Географическая точка</para>
/// </summary>
[Description("Географическая точка")]
[Serializable]
[DataContract(Name = nameof(Location))]
public class Location : Entity, IEquatable<Location>
{
  /// <summary>
  ///   <para>Широта (градусов) географической точки</para>
  /// </summary>
  [DataMember(Name = nameof(Latitude))]
  [Description("Широта (градусов) географической точки")]
  public virtual decimal? Latitude { get; set; }

  /// <summary>
  ///   <para>Долгота (градусов) географической точки</para>
  /// </summary>
  [DataMember(Name = nameof(Longitude))]
  [Description("Долгота (градусов) географической точки")]
  public virtual decimal? Longitude { get; set; }

  /// <summary>
  ///   <para>Наименование связанной с географической точкой временной зоны</para>
  /// </summary>
  [DataMember(Name = nameof(TimeZone))]
  [Description("Наименование связанной с географической точкой временной зоны")]
  public virtual string TimeZone { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Location"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Location"/> to compare with this instance.</param>
  public virtual int CompareTo(Location other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="Location"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Location other) => this.Equality(other, nameof(Latitude), nameof(Longitude));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Location);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Latitude), nameof(Longitude));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Latitude != null && Longitude != null ? $"{Latitude.ToInvariantString()},{Longitude.ToInvariantString()}" : string.Empty;
}