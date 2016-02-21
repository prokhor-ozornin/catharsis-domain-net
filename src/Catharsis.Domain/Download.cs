using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Загружаемый материал</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Загружаемый материал")]
#endif
  [Table(Schema.TableName)]
  public partial class Download : Entity, IComparable<Download>, IEquatable<Download>
  {
    /// <summary>
    ///   <para>Описание материала</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDescription)]
#endif
    [Column(Schema.ColumnNameDescription)]
    [MaxLength(4000)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Количество скачиваний</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDownloads)]
#endif
    [Column(Schema.ColumnNameDownloads)]
    [NotNull]
    [Indexed(Name = "idx__downloads__downloads")]
    public virtual long? Downloads { get; set; }

    /// <summary>
    ///   <para>Файл, представляющий загружаемый материал</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentFile)]
#endif
    [Column(Schema.ColumnNameFile)]
    [NotNull]
    [Indexed(Name = "idx__downloads__file_id")]
    public virtual StorageFile File { get; set; }

    /// <summary>
    ///   <para>Изображение, связанное с материалом</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentImage)]
#endif
    [Column(Schema.ColumnNameImage)]
    [Indexed(Name = "idx__downloads__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование материала</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__downloads__name")]
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

    public static class Schema
    {
      public const string TableName = "downloads";
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