using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Медиа ресурс</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Media : Entity, IComparable<Media>, IEquatable<Media>
  {
    /// <summary>
    ///   <para>Имя создателя медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentAuthorName)]
    [Column(Schema.ColumnNameAuthorName)]
    public virtual string AuthorName { get; set; }

    /// <summary>
    ///   <para>URI адрес страницы создателя медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentAuthorUri)]
    [Column(Schema.ColumnNameAuthorUri)]
    [MaxLength(1000)]
    public virtual string AuthorUri { get; set; }

    /// <summary>
    ///   <para>MIME тип медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentContentType)]
    [Column(Schema.ColumnNameContentType)]
    public virtual string ContentType { get; set; }

    /// <summary>
    ///   <para>Описание медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentDescription)]
    [Column(Schema.ColumnNameDescription)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Длительность воспроизведения медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentDuration)]
    [Column(Schema.ColumnNameDuration)]
    [Indexed(Name = "idx__media__duration")]
    public virtual long? Duration { get; set; }

    /// <summary>
    ///   <para>Высота медиа ресурса в пикселях</para>
    /// </summary>
    [Description(Schema.ColumnCommentHeight)]
    [Column(Schema.ColumnNameHeight)]
    [Indexed(Name = "idx__media__height")]
    public virtual short? Height { get; set; }

    /// <summary>
    ///   <para>Внедряемый HTML код медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentHtml)]
    [Column(Schema.ColumnNameHtml)]
    public virtual string Html { get; set; }

    /// <summary>
    ///   <para>Заголовок медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [Indexed(Name = "idx__media__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>URI адрес сайта провайдера ресурсов данного типа</para>
    /// </summary>
    [Description(Schema.ColumnCommentProviderUri)]
    [Column(Schema.ColumnNameProviderUri)]
    [MaxLength(1000)]
    public virtual string ProviderUri { get; set; }

    /// <summary>
    ///   <para>Высота миниатюры медиа ресурса в пикселях</para>
    /// </summary>
    [Description(Schema.ColumnCommentThumbnailHeight)]
    [Column(Schema.ColumnNameThumbnailHeight)]
    public virtual short? ThumbnailHeight { get; set; }

    /// <summary>
    ///   <para>URI адрес миниатюры медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentThumbnailUri)]
    [Column(Schema.ColumnNameThumbnailUri)]
    [MaxLength(1000)]
    public virtual string ThumbnailUri { get; set; }

    /// <summary>
    ///   <para>Ширина миниатюры медиа ресурса в пикселях</para>
    /// </summary>
    [Description(Schema.ColumnNameThumbnailHeight)]
    [Column(Schema.ColumnNameThumbnailWidth)]
    public virtual short? ThumbnailWidth { get; set; }

    /// <summary>
    ///   <para>URI адрес медиа ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentUri)]
    [Column(Schema.ColumnNameUri)]
    [NotNull]
    [MaxLength(1000)]
    [Unique(Name = "media__uri")]
    public virtual Uri Uri { get; set; }

    /// <summary>
    ///   <para>Ширина ресурса в пикселях</para>
    /// </summary>
    [Description(Schema.ColumnCommentWidth)]
    [Column(Schema.ColumnNameWidth)]
    [Indexed(Name = "idx__media__width")]
    public virtual short? Width { get; set; }

    public virtual int CompareTo(Media other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(Media other)
    {
      return this.Equality(other, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Media);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.ToString() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "media";
      public const string TableComment = "Медиа ресурсы";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время создания медиа ресурса";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения медиа ресурса";

      public const string ColumnNameAuthorName = "author_name";
      public const string ColumnCommentAuthorName = "Имя создателя медиа ресурса";

      public const string ColumnNameAuthorUri = "author_uri";
      public const string ColumnCommentAuthorUri = "URI адрес страницы создателя медиа ресурса";

      public const string ColumnNameContentType = "content_type";
      public const string ColumnCommentContentType = "MIME тип медиа ресурса";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание медиа ресурса";

      public const string ColumnNameDuration = "duration";
      public const string ColumnCommentDuration = "Длительность воспроизведения медиа ресурса";

      public const string ColumnNameHeight = "height";
      public const string ColumnCommentHeight = "Высота медиа ресурса в пикселях";

      public const string ColumnNameHtml = "html";
      public const string ColumnCommentHtml = "Внедряемый HTML код медиа ресурса";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Заголовок медиа ресурса";

      public const string ColumnNameProviderUri = "provider_uri";
      public const string ColumnCommentProviderUri = "URI адрес сайта провайдера ресурсов данного типа";

      public const string ColumnNameThumbnailHeight = "thumbnail_height";
      public const string ColumnCommentThumbnailHeight = "Высота миниатюры медиа ресурса в пикселях";

      public const string ColumnNameThumbnailUri = "thumbnail_uri";
      public const string ColumnCommentThumbnailUri = "URI адрес миниатюры медиа ресурса";

      public const string ColumnNameThumbnailWidth = "thumbnail_width";
      public const string ColumnCommentThumbnailWidth = "Ширина миниатюры медиа ресурса в пикселях";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "URI адрес медиа ресурса";

      public const string ColumnNameWidth = "width";
      public const string ColumnCommentWidth = "Ширина медиа ресурса в пикселях";
    }
  }
}