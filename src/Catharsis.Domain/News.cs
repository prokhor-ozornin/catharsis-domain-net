using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Новость проекта</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class News : Entity, IComparable<News>, IEquatable<News>
  {
    /// <summary>
    ///   <para>Аннотация к новости</para>
    /// </summary>
    [Description(Schema.ColumnCommentAnnotation)]
    [Column(Schema.ColumnNameAnnotation)]
    [NotNull]
    [MaxLength(1000)]
    public virtual string Annotation { get; set; }

    /// <summary>
    ///   <para>Файл изображения для новости</para>
    /// </summary>
    [Description(Schema.ColumnCommentImage)]
    [Column(Schema.ColumnNameImage)]
    [Indexed(Name = "idx__news__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Заголовок новости</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__news__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Ключевые слова, описывающие содержимое новости</para>
    /// </summary>
    [Description(Schema.ColumnCommentTags)]
    [Column(Schema.ColumnNameTags)]
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>
    ///   <para>Полный текст новости</para>
    /// </summary>
    [Description(Schema.ColumnCommentText)]
    [Column(Schema.ColumnNameText)]
    [NotNull]
    [MaxLength(4000)]
    public virtual string Text { get; set; }

    public virtual int CompareTo(News other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(News other)
    {
      return this.Equality(other, it => it.CreatedOn, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as News);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.CreatedOn, it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "news";
      public const string TableComment = "Новости проекта";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время публикации новости";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения новости";

      public const string ColumnNameAnnotation = "annotation";
      public const string ColumnCommentAnnotation = "Аннотация к новости";

      public const string ColumnNameImage = "image_id";
      public const string ColumnCommentImage = "Файл изображения для новости";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Заголовок новости";

      public const string ColumnNameTags = "tags";
      public const string ColumnCommentTags = "Ключевые слова, описывающие содержимое новости";

      public const string ColumnNameText = "text";
      public const string ColumnCommentText = "Полный текст новости";
    }
  }
}