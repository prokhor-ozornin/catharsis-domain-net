using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Персона</para>
/// </summary>
[Description("Персона")]
[Serializable]
[DataContract(Name = nameof(Person))]
public class Person : Entity, IComparable<Person>, IEquatable<Person>
{
  /// <summary>
  ///   <para>Имя</para>
  /// </summary>
  [DataMember(Name = nameof(FirstName))]
  [Description("Имя")]
  public virtual string FirstName { get; set; }

  /// <summary>
  ///   <para>Фамилия</para>
  /// </summary>
  [DataMember(Name = nameof(LastName))]
  [Description("Фамилия")]
  public virtual string LastName { get; set; }

  /// <summary>
  ///   <para>Отчество</para>
  /// </summary>
  [DataMember(Name = nameof(MiddleName))]
  [Description("Отчество")]
  public virtual string MiddleName { get; set; }

  /// <summary>
  ///   <para>Дата рождения</para>
  /// </summary>
  [DataMember(Name = nameof(BirthDate))]
  [Description("Дата рождения")]
  public virtual DateTimeOffset? BirthDate { get; set; }

  /// <summary>
  ///   <para>Дата смерти</para>
  /// </summary>
  [DataMember(Name = nameof(DeathDate))]
  [Description("Дата смерти")]
  public virtual DateTimeOffset? DeathDate { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Person"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Person"/> to compare with this instance.</param>
  public virtual int CompareTo(Person other) => string.Compare(ToString(), other?.ToString(), StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="Person"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Person other) => this.Equality(other, nameof(BirthDate), nameof(DeathDate), nameof(FirstName), nameof(LastName), nameof(MiddleName));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Person);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(BirthDate), nameof(DeathDate), nameof(FirstName), nameof(LastName), nameof(MiddleName));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => $"{LastName ?? string.Empty} {FirstName ?? string.Empty} {MiddleName ?? string.Empty}".Trim();
}