using SQLite;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Объявление</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Announcement : Entity, IComparable<Announcement>
  {
    /// <summary>
    ///   <para>Связанный файл изображения</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentImage)]
#endif
    [Column(Schema.ColumnNameImage)]
    [Indexed(Name = "idx__announcements__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование/заголовок</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__announcements__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Стоимость публикации</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentPrice)]
#endif
    [Column(Schema.ColumnNamePrice)]
    [Indexed(Name = "idx__announcements__price")]
    public virtual decimal? Price { get; set; }

    /// <summary>
    ///   <para>Валюта стоимости публикации</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentPriceCurrency)]
#endif
    [Column(Schema.ColumnNamePriceCurrency)]
    [Indexed(Name = "idx__announcements__price_currency")]
    public virtual string PriceCurrency { get; set; }

    /// <summary>
    ///   <para>Текстовое содержимое</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentText)]
#endif
    [Column(Schema.ColumnNameText)]
    [NotNull]
    [MaxLength(4000)]
    public virtual string Text { get; set; }

    public virtual int CompareTo(Announcement other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "announcements";
      public const string TableComment = "Объявления";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время публикации объявления";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления объявления";

      public const string ColumnNameImage = "image_id";
      public const string ColumnCommentImage = "Связанный файл изображения";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование/заголовок";

      public const string ColumnNamePrice = "price";
      public const string ColumnCommentPrice = "Стоимость публикации";

      public const string ColumnNamePriceCurrency = "price_currency";
      public const string ColumnCommentPriceCurrency = "Валюта стоимости публикации";

      public const string ColumnNameText = "text";
      public const string ColumnCommentText = "Текстовое содержимое";
    }
  }
}