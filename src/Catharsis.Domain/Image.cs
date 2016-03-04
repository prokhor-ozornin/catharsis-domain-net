using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Изображение</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Image : Media, IComparable<Image>, IEquatable<Image>
  {
    /// <summary>
    ///   <para>Файл, представляющий изображение</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentFile)]
#endif
    [Column(Schema.ColumnNameFile)]
    [Indexed(Name = "idx__images__file_id")]
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

    public static class Schema
    {
      public const string TableName = "images";
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