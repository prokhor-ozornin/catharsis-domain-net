using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Гиперссылка.</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class WebLink : Entity, IComparable<WebLink>, IEquatable<WebLink>
  {
    /// <summary>
    ///   <para>Описание гиперссылки</para>
    /// </summary>
    [Description(Schema.ColumnCommentDescription)]
    [Column(Schema.ColumnNameDescription)]
    [MaxLength(4000)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Изображение, представляющее гиперссылку</para>
    /// </summary>
    [Description(Schema.ColumnCommentImage)]
    [Column(Schema.ColumnNameImage)]
    [Indexed(Name = "idx__web_link__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование гиперссылки</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__web_link__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>URI адрес гиперссылки</para>
    /// </summary>
    [Description(Schema.ColumnCommentUri)]
    [Column(Schema.ColumnNameUri)]
    [NotNull]
    [MaxLength(1000)]
    [Unique(Name = "web_link__uri")]
    public virtual string Uri { get; set; }

    public virtual int CompareTo(WebLink other)
    {
      return this.Uri.CompareTo(other.Uri);
    }

    public virtual bool Equals(WebLink other)
    {
      return this.Equality(other, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebLink);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "web_link";
      public const string TableComment = "Web гиперссылки";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления web гиперссылки";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления web гиперссылки";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание гиперссылки";

      public const string ColumnNameImage = "image_id";
      public const string ColumnCommentImage = "Изображение, представляющее гиперссылку";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование гиперссылки";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "URI адрес гиперссылки";
    }
  }
}