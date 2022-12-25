using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Настроечная опция</para>
/// </summary>
[Description("Настроечная опция")]
[Serializable]
[DataContract(Name = nameof(Setting))]
public class Setting : Entity, IComparable<Setting>, IEquatable<Setting>
{
  /// <summary>
  ///   <para>Наименование настроечной опции</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование настроечной опции")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>Тип данных для значения настроечной опции</para>
  /// </summary>
  [DataMember(Name = nameof(Type))]
  [Description("Тип данных для значения настроечной опции")]
  public virtual SettingType? Type { get; set; }

  /// <summary>
  ///   <para>Описание настроечной опции</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Описание настроечной опции")]
  public virtual string? Description { get; set; }

  /// <summary>
  ///   <para>Значение настроечной опции</para>
  /// </summary>
  [DataMember(Name = nameof(Value))]
  [Description("Значение настроечной опции")]
  public virtual string? Value { get; set; }

  /// <summary>
  ///   <para>Список значений настроечной опции</para>
  /// </summary>
  [DataMember(Name = nameof(Values))]
  [Description("Список значений настроечной опции")]
  public virtual IList<string> Values { get; set; } = new List<string>();

  /// <summary>
  ///   <para>Compares the current <see cref="Setting"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Setting"/> to compare with this instance.</param>
  public virtual int CompareTo(Setting? other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="Setting"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Setting? other) => this.Equality(other, nameof(Name));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as Setting);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Name));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Value ?? Values.Text();

  public enum SettingType
  {
    Boolean,
    Date,
    Number,
    String,
    Url
  }
}