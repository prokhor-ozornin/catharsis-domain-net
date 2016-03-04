using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>SEO данные о web странице</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class SeoWebPage : Entity, IComparable<SeoWebPage>, IEquatable<SeoWebPage>
  {
    /// <summary>
    ///   <para>Наименование локали для содержимого web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentLocale)]
#endif
    [Column(Schema.ColumnNameLocale)]
    [NotNull]
    [MaxLength(2)]
    [Indexed(Name = "idx__seo_web_pages__locale")]
    public virtual string Locale { get; set; }

    /// <summary>
    ///   <para>Значение title заголовка для web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentTitle)]
#endif
    [Column(Schema.ColumnNameTitle)]
    [NotNull]
    public virtual string Title { get; set; }

    /// <summary>
    ///   <para>URI адрес web страницы</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentUri)]
#endif
    [Column(Schema.ColumnNameUri)]
    [NotNull]
    [MaxLength(1000)]
    [Indexed(Name = "idx__seo_web_pages__uri")]
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(SeoWebPage other)
    {
      return this.Uri.ToString().CompareTo(other.Uri.ToString());
    }

    public virtual bool Equals(SeoWebPage other)
    {
      return this.Equality(other, it => it.Locale, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as SeoWebPage);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Locale, it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.ToString() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "seo_web_pages";
      public const string TableComment = "SEO данные о web страницах";

      public const string ColumnNameId = "id";
      public const string ColumnCommentNameId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время создания seo записи для web страницы";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения seo записи для web страницы";

      public const string ColumnNameLocale = "locale";
      public const string ColumnCommentLocale = "Наименование локали для содержимого web страницы";

      public const string ColumnNameTitle = "title";
      public const string ColumnCommentTitle = "Значение title заголовка для web страницы";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "URI адрес web страницы";
    }
  }
}