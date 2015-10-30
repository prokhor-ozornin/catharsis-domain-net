using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Часто Задаваемый Вопрос (Ч.А.В.О.)</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Часто Задаваемый Вопрос (Ч.А.В.О.)")]
#endif
  public partial class Faq : Entity, IComparable<Faq>
  {
    /// <summary>
    ///   <para>Текст вопроса</para>
    /// </summary>
#if NET_35
    [Description("Текст вопроса")]
#endif
    public virtual string Answer { get; set; }

    /// <summary>
    ///   <para>Текст ответа</para>
    /// </summary>
#if NET_35
    [Description("Текст ответа")]
#endif
    public virtual string Question { get; set; }

    public virtual int CompareTo(Faq other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public override string ToString()
    {
      return this.Question?.Trim() ?? string.Empty;
    }
  }
}