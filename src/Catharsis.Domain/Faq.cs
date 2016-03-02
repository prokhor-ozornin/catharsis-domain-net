using SQLite;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Часто Задаваемый Вопрос (Ч.А.В.О.)</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Faq : Entity, IComparable<Faq>
  {
    /// <summary>
    ///   <para>Текст вопроса</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentAnswer)]
#endif
    [Column(Schema.ColumnNameAnswer)]
    [NotNull]
    [MaxLength(4000)]
    public virtual string Answer { get; set; }

    /// <summary>
    ///   <para>Текст ответа</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentQuestion)]
#endif
    [Column(Schema.ColumnNameQuestion)]
    [NotNull]
    [MaxLength(4000)]
    public virtual string Question { get; set; }

    public virtual int CompareTo(Faq other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public override string ToString()
    {
      return this.Question?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "faqs";
      public const string TableComment = "Часто Задаваемые Вопросы";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления Часто Задаваемого Вопроса";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения Часто Задаваемого Вопроса";

      public const string ColumnNameAnswer = "answer";
      public const string ColumnCommentAnswer = "Текст ответа";

      public const string ColumnNameQuestion = "question";
      public const string ColumnCommentQuestion = "Текст вопроса";
    }
  }
}