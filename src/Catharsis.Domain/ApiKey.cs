using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Ключ доступа API</para>
/// </summary>
[Description("Ключ доступа API")]
[Serializable]
[DataContract(Name = nameof(ApiKey))]
public class ApiKey : Entity, IComparable<ApiKey>, IEquatable<ApiKey>
{
  /// <summary>
  ///   <para>Значение ключа доступа</para>
  /// </summary>
  [DataMember(Name = nameof(Value))]
  [Description("Значение ключа доступа")]
  public virtual string Value { get; set; } = Guid.NewGuid().ToString();

  /// <summary>
  ///   <para>Ф.И.О. контактного лица, на имя которого выдан ключ доступа</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Ф.И.О. контактного лица, на имя которого выдан ключ доступа")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Контактные данные лица, на имя которого выдан ключ доступ</para>
  /// </summary>
  [DataMember(Name = nameof(Contact))]
  [Description("Контактные данные лица, на имя которого выдан ключ доступ")]
  public virtual Contact Contact { get; set; }

  /// <summary>
  ///   <para>Наименование приложения, использующего ключ доступа</para>
  /// </summary>
  [DataMember(Name = nameof(AppName))]
  [Description("Наименование приложения, использующего ключ доступа")]
  public virtual string AppName { get; set; }

  /// <summary>
  ///   <para>Доменное имя, с которого приложение осуществляет запросы к API</para>
  /// </summary>
  [DataMember(Name = nameof(AppDomain))]
  [Description("Доменное имя, с которого приложение осуществляет запросы к API")]
  public virtual string AppDomain { get; set; }

  /// <summary>
  ///   <para>Описание приложения, использующего ключ доступа</para>
  /// </summary>
  [DataMember(Name = nameof(AppDescription))]
  [Description("Описание приложения, использующего ключ доступа")]
  public virtual string AppDescription { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="ApiKey"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="ApiKey"/> to compare with this instance.</param>
  public virtual int CompareTo(ApiKey other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="ApiKey"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(ApiKey other) => this.Equality(other, nameof(Value));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as ApiKey);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Value));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Value;
}