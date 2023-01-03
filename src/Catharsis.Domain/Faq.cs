using System.ComponentModel;
using System.Runtime.Serialization;

namespace Catharsis.Domain;

/// <summary>
///   <para>Часто Задаваемый Вопрос (Ч.А.В.О.)</para>
/// </summary>
[Description("Часто Задаваемый Вопрос (Ч.А.В.О.)")]
[Serializable]
[DataContract(Name = nameof(Faq))]
public class Faq : Entity, IComparable<Faq>
{
  /// <summary>
  ///   <para>Текст ответа</para>
  /// </summary>
  [DataMember(Name = nameof(Question))]
  [Description("Текст ответа")]
  public virtual string Question { get; set; }

  /// <summary>
  ///   <para>Текст вопроса</para>
  /// </summary>
  [DataMember(Name = nameof(Answer))]
  [Description("Текст вопроса")]
  public virtual string Answer { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Faq"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Faq"/> to compare with this instance.</param>
  public virtual int CompareTo(Faq other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Question ?? string.Empty;
}