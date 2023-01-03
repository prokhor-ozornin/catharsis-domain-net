using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Компания из справочника</para>
/// </summary>
[Description("Компания из справочника")]
[Serializable]
[DataContract(Name = nameof(DirectoryCompany))]
public class DirectoryCompany : Entity, IComparable<DirectoryCompany>, IEquatable<DirectoryCompany>
{
  /// <summary>
  ///   <para>Полное наименование компании</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Полное наименование компании")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Краткое наименование компании</para>
  /// </summary>
  [DataMember(Name = nameof(ShortName))]
  [Description("Краткое наименование компании")]
  public virtual string ShortName { get; set; }

  /// <summary>
  ///   <para>Внешний служебный код компании</para>
  /// </summary>
  [DataMember(Name = nameof(Code))]
  [Description("Внешний служебный код компании")]
  public virtual string Code { get; set; }

  /// <summary>
  ///   <para>Контактные данные компании</para>
  /// </summary>
  [DataMember(Name = nameof(Contact))]
  [Description("Контактные данные компании")]
  public virtual Contact Contact { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="DirectoryCompany"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="DirectoryCompany"/> to compare with this instance.</param>
  public virtual int CompareTo(DirectoryCompany other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="DirectoryCompany"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(DirectoryCompany other) => this.Equality(other, nameof(CreatedOn), nameof(Name), nameof(ShortName));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as DirectoryCompany);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(CreatedOn), nameof(Name), nameof(ShortName));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}