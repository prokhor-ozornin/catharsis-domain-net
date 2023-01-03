using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Запись лога</para>
/// </summary>
[Description("Запись лога")]
[Serializable]
[DataContract(Name = nameof(LogMessage))]
public class LogMessage : Entity, IComparable<LogMessage>, IEquatable<LogMessage>
{
  /// <summary>
  ///   <para>Уровень логгирования записей</para>
  /// </summary>
  [DataMember(Name = nameof(Level))]
  [Description("Уровень логгирования записей")]
  public virtual string Level { get; set; }

  /// <summary>
  ///   <para>Название класса логгера</para>
  /// </summary>
  [DataMember(Name = nameof(Logger))]
  [Description("Название класса логгера")]
  public virtual string Logger { get; set; }

  /// <summary>
  ///   <para>Имя потока, осуществлявшего логгирование</para>
  /// </summary>
  [DataMember(Name = nameof(Thread))]
  [Description("Имя потока, осуществлявшего логгирование")]
  public virtual string Thread { get; set; }

  /// <summary>
  ///   <para>Идентификатор API запроса</para>
  /// </summary>
  [DataMember(Name = nameof(RequestId))]
  [Description("Идентификатор API запроса")]
  public virtual string RequestId { get; set; }

  /// <summary>
  ///   <para>Текст записи</para>
  /// </summary>
  [DataMember(Name = nameof(Text))]
  [Description("Текст записи")]
  public virtual string Text { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="LogMessage"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="LogMessage"/> to compare with this instance.</param>
  public virtual int CompareTo(LogMessage other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="LogMessage"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(LogMessage other) => this.Equality(other, nameof(RequestId));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as LogMessage);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(RequestId));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Text ?? string.Empty;
}