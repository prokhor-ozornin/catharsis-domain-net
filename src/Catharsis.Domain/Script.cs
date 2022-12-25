using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Программный скрипт</para>
/// </summary>
[Description("Программный скрипт")]
[Serializable]
[DataContract(Name = nameof(Script))]
public class Script : Entity, IComparable<Script>, IEquatable<Script>
{
  /// <summary>
  ///   <para>Наименование скрипта</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование скрипта")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>Признак того, был ли выполнен скрипт</para>
  /// </summary>
  [DataMember(Name = nameof(Executed))]
  [Description("Признак того, был ли выполнен скрипт")]
  public virtual bool? Executed { get; set; }

  /// <summary>
  ///   <para>Длительность выполнения скрипта в миллисекундах</para>
  /// </summary>
  [DataMember(Name = nameof(Duration))]
  [Description("Длительность выполнения скрипта в миллисекундах")]
  public virtual long? Duration { get; set; }

  /// <summary>
  ///   <para>Путь к файлу скрипта</para>
  /// </summary>
  [DataMember(Name = nameof(Path))]
  [Description("Путь к файлу скрипта")]
  public virtual string? Path { get; set; }

  /// <summary>
  ///   <para>Программный код скрипта</para>
  /// </summary>
  [DataMember(Name = nameof(Code))]
  [Description("Программный код скрипта")]
  public virtual string? Code { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Script"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Script"/> to compare with this instance.</param>
  public virtual int CompareTo(Script? other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="Script"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Script? other) => this.Equality(other, nameof(Name));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as Script);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Name));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}