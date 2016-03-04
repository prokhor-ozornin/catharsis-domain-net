using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Web браузер</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class WebBrowser : Entity, IComparable<WebBrowser>, IEquatable<WebBrowser>
  {
    /// <summary>
    ///   <para>Описание браузера</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDescription)]
#endif
    [Column(Schema.ColumnNameDescription)]
    [MaxLength(1000)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Наименование/код браузера</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Адрес сайта разработчиков</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentUri)]
#endif
    [Column(Schema.ColumnNameUri)]
    [MaxLength(1000)]
    public virtual Uri Uri { get; set; }

    /// <summary>
    ///   <para>Значение HTTP заголовка User-Agent</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentUserAgent)]
#endif
    [Column(Schema.ColumnNameUserAgent)]
    [NotNull]
    [MaxLength(1000)]
    [Unique(Name = "idx__web_browsers__user_agent")]
    public virtual string UserAgent { get; set; }

    public virtual int CompareTo(WebBrowser other)
    {
      return this.UserAgent.CompareTo(other.UserAgent);
    }

    public virtual bool Equals(WebBrowser other)
    {
      return this.Equality(other, it => it.UserAgent);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebBrowser);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.UserAgent);
    }

    public override string ToString()
    {
      return this.UserAgent?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "web_browsers";
      public const string TableComment = "Web браузеры";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления web браузера";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения web браузера";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание браузера";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование/код браузера";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "Адрес сайта разработчиков";

      public const string ColumnNameUserAgent = "user_agent";
      public const string ColumnCommentUserAgent = "Значение HTTP заголовка User-Agent";
    }
  }
}