using Catharsis.Commons;
using SQLite;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Запись лога</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Запись лога")]
#endif
  [Table(Schema.TableName)]
  public partial class LogMessage : Entity, IComparable<LogMessage>, IEquatable<LogMessage>
  {
    /// <summary>
    ///   <para>Уровень логгирования записей</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentLevel)]
#endif
    [Column(Schema.ColumnNameLevel)]
    [NotNull]
    [Indexed(Name = "idx__logs__level")]
    public virtual string Level { get; set; }

    /// <summary>
    ///   <para>Название класса логгера</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentLogger)]
#endif
    [Column(Schema.ColumnNameLogger)]
    [NotNull]
    [Indexed(Name = "idx__logs__logger")]
    public virtual string Logger { get; set; }

    /// <summary>
    ///   <para>Идентификатор API запроса</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentRequestId)]
#endif
    [Column(Schema.ColumnNameRequestId)]
    [Indexed(Name = "idx__logs__request_id")]
    public virtual string RequestId { get; set; }

    /// <summary>
    ///   <para>Текст записи</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentText)]
#endif
    [Column(Schema.ColumnNameText)]
    [NotNull]
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>Имя потока, осуществлявшего логгирование</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentThread)]
#endif
    [Column(Schema.ColumnNameThread)]
    [NotNull]
    [Indexed(Name = "idx__logs__thread")]
    public virtual string Thread { get; set; }

    public virtual int CompareTo(LogMessage other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(LogMessage other)
    {
      return this.Equality(other, it => it.RequestId);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as LogMessage);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.RequestId);
    }

    public override string ToString()
    {
      return this.Text?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "log_messages";
      public const string TableComment = "Записи лога";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время создания записи";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения записи";

      public const string ColumnNameLevel = "level";
      public const string ColumnCommentLevel = "Уровень логгирования записей";

      public const string ColumnNameLogger = "logger";
      public const string ColumnCommentLogger = "Название класса логгера";

      public const string ColumnNameRequestId = "request_id";
      public const string ColumnCommentRequestId = "Идентификатор API запроса";

      public const string ColumnNameText = "text";
      public const string ColumnCommentText = "Текст записи";

      public const string ColumnNameThread = "thread";
      public const string ColumnCommentThread = "Имя потока, осуществлявшего логгирование";
    }
  }
}