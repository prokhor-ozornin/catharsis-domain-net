using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Запись лога</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class LogMessage : Entity, IComparable<LogMessage>, IEquatable<LogMessage>
  {
    /// <summary>
    ///   <para>Уровень логгирования записей</para>
    /// </summary>
    [Description(Schema.ColumnCommentLevel)]
    [Column(Schema.ColumnNameLevel)]
    [NotNull]
    [Indexed(Name = "idx__log__level")]
    public virtual string Level { get; set; }

    /// <summary>
    ///   <para>Название класса логгера</para>
    /// </summary>
    [Description(Schema.ColumnCommentLogger)]
    [Column(Schema.ColumnNameLogger)]
    [NotNull]
    [Indexed(Name = "idx__log__logger")]
    public virtual string Logger { get; set; }

    /// <summary>
    ///   <para>Идентификатор API запроса</para>
    /// </summary>
    [Description(Schema.ColumnCommentRequestId)]
    [Column(Schema.ColumnNameRequestId)]
    [Indexed(Name = "idx__log__request_id")]
    public virtual string RequestId { get; set; }

    /// <summary>
    ///   <para>Текст записи</para>
    /// </summary>
    [Description(Schema.ColumnCommentText)]
    [Column(Schema.ColumnNameText)]
    [NotNull]
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>Имя потока, осуществлявшего логгирование</para>
    /// </summary>
    [Description(Schema.ColumnCommentThread)]
    [Column(Schema.ColumnNameThread)]
    [NotNull]
    [Indexed(Name = "idx__log__thread")]
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

    public static new class Schema
    {
      public const string TableName = "log_message";
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