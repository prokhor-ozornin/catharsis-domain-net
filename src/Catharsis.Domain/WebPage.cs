using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Web страница</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class WebPage : Entity, IComparable<WebPage>, IEquatable<WebPage>
  {
    /// <summary>
    ///   <para>Наименование локали для текста web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentLocale)]
#endif
    [Column(Schema.ColumnNameLocale)]
    [NotNull]
    [MaxLength(2)]
    [Indexed(Name = "idx__web_pages__locale")]
    public virtual string Locale { get; set; }

    /// <summary>
    ///   <para>Наименование web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__web_pages__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>HTML код (текст) web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentText)]
#endif
    [Column(Schema.ColumnNameText)]
    [NotNull]
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>URI адрес web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentUri)]
#endif
    [Column(Schema.ColumnNameUri)]
    [NotNull]
    [MaxLength(1000)]
    [Indexed(Name = "idx__web_pages__uri")]
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(WebPage other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(WebPage other)
    {
      return this.Equality(other, it => it.Locale, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebPage);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Locale, it => it.Uri);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "web_pages";
      public const string TableComment = "Web страницы с динамическим содержимым";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время создания web страницы";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения web страницы";

      public const string ColumnNameLocale = "locale";
      public const string ColumnCommentLocale = "Наименование локали для текста web страницы";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование web страницы";

      public const string ColumnNameText = "text";
      public const string ColumnCommentText = "HTML код (текст) web страницы";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "URI адрес web страницы";
    }
  }
}