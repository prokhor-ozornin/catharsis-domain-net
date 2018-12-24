using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Изображение</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Image : Media, IComparable<Image>, IEquatable<Image>
  {
    /// <summary>
    ///   <para>Файл, представляющий изображение</para>
    /// </summary>
    [Description(Schema.ColumnCommentFile)]
    [Column(Schema.ColumnNameFile)]
    [Indexed(Name = "idx__image__file_id")]
    public virtual StorageFile File { get; set; }

    public virtual int CompareTo(Image other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(Image other)
    {
      return this.Equality(other, it => it.File, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Image);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File, it => it.Uri);
    }

    public static new class Schema
    {
      public const string TableName = "image";
      public const string TableComment = "Изображения";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления изображения";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Файл, представляющий изображение";

      public const string ColumnNameFile = "file_id";
      public const string ColumnCommentFile = "Дата/время последнего изменения изображения";
    }
  }
}