using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Загружаемый материал</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Download : Entity, IComparable<Download>, IEquatable<Download>
  {
    /// <summary>
    ///   <para>Описание материала</para>
    /// </summary>
    [Description(Schema.ColumnCommentDescription)]
    [Column(Schema.ColumnNameDescription)]
    [MaxLength(4000)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Количество скачиваний</para>
    /// </summary>
    [Description(Schema.ColumnCommentDownloads)]
    [Column(Schema.ColumnNameDownloads)]
    [NotNull]
    [Indexed(Name = "idx__download__downloads")]
    public virtual long? Downloads { get; set; }

    /// <summary>
    ///   <para>Файл, представляющий загружаемый материал</para>
    /// </summary>
    [Description(Schema.ColumnCommentFile)]
    [Column(Schema.ColumnNameFile)]
    [NotNull]
    [Indexed(Name = "idx__download__file_id")]
    public virtual StorageFile File { get; set; }

    /// <summary>
    ///   <para>Изображение, связанное с материалом</para>
    /// </summary>
    [Description(Schema.ColumnCommentImage)]
    [Column(Schema.ColumnNameImage)]
    [Indexed(Name = "idx__download__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование материала</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__download__name")]
    public virtual string Name { get; set; }

    public virtual int CompareTo(Download other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(Download other)
    {
      return this.Equality(other, it => it.File);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Download);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "download";
      public const string TableComment = "Загружаемые материалы";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления материала";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления материала";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание материала";

      public const string ColumnNameDownloads = "downloads";
      public const string ColumnCommentDownloads = "Количество скачиваний";

      public const string ColumnNameFile = "file_id";
      public const string ColumnCommentFile = "Файл, представляющий загружаемый материал";

      public const string ColumnNameImage = "image_id";
      public const string ColumnCommentImage = "Изображение, связанное с материалом";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование материала";
    }
  }
}