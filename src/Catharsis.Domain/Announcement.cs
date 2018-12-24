using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Объявление</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Announcement : Entity, IComparable<Announcement>
  {
    /// <summary>
    ///   <para>Связанный файл изображения</para>
    /// </summary>
    [Description(Schema.ColumnCommentImage)]
    [Column(Schema.ColumnNameImage)]
    [Indexed(Name = "idx__announcement__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование/заголовок</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__announcement__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Стоимость публикации</para>
    /// </summary>
    [Description(Schema.ColumnCommentPrice)]
    [Column(Schema.ColumnNamePrice)]
    [Indexed(Name = "idx__announcement__price")]
    public virtual decimal? Price { get; set; }

    /// <summary>
    ///   <para>Валюта стоимости публикации</para>
    /// </summary>
    [Description(Schema.ColumnCommentPriceCurrency)]
    [Column(Schema.ColumnNamePriceCurrency)]
    [Indexed(Name = "idx__announcement__price_currency")]
    public virtual string PriceCurrency { get; set; }

    /// <summary>
    ///   <para>Текстовое содержимое</para>
    /// </summary>
    [Description(Schema.ColumnCommentText)]
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

    public static new class Schema
    {
      public const string TableName = "announcement";
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