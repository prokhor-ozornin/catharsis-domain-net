using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;
using System.Text;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Файл</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class StorageFile : Entity, IComparable<StorageFile>, IEquatable<StorageFile>
  {
    /// <summary>
    ///   <para>MIME тип содержимого файла</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentContentType)]
#endif
    [Column(Schema.ColumnNameContentType)]
    [NotNull]
    [Indexed(Name = "idx__files__content_type")]
    public virtual string ContentType { get; set; }

    /// <summary>
    ///   <para>Наименование файла</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Путь к файлу в хранилище</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentPath)]
#endif
    [Column(Schema.ColumnNamePath)]
    [MaxLength(1000)]
    public virtual string Path { get; set; }

    /// <summary>
    ///   <para>Размер файла в байтах</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentSize)]
#endif
    [Column(Schema.ColumnNameSize)]
    [NotNull]
    [Indexed(Name = "idx__files__size")]
    public virtual long? Size { get; set; }

    /// <summary>
    ///   <para>Тип файлового хранилища</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentStorage)]
#endif
    [Column(Schema.ColumnNameStorage)]
    [Indexed(Name = "idx__files__storage")]
    public virtual string Storage { get; set; }

    public virtual string FullPath
    {
      get
      {
        var fullPath = new StringBuilder();

        if (!this.Path.IsEmpty())
        {
          fullPath.Append(this.Path.Trim());
          if (!this.Path.EndsWith("/") && !this.Path.EndsWith("\\"))
          {
            fullPath.Append("/");
          }
        }

        if (this.Name != null && !this.Name.Trim().IsEmpty())
        {
          fullPath.Append(this.Name.Trim());
        }

        return fullPath.ToString();
      }
    }

    public virtual int CompareTo(StorageFile other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(StorageFile other)
    {
      return this.Equality(other, it => it.Name, it => it.Path, it => it.Storage);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as StorageFile);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Name, it => it.Path, it => it.Storage);
    }

    public override string ToString()
    {
      return this.FullPath;
    }

    public static class Schema
    {
      public const string TableName = "files";
      public const string TableComment = "Файлы в хранилище";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления файла";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения файла";

      public const string ColumnNameContentType = "content_type";
      public const string ColumnCommentContentType = "MIME тип содержимого файла";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование файла";

      public const string ColumnNamePath = "path";
      public const string ColumnCommentPath = "Путь к файлу в хранилище";

      public const string ColumnNameSize = "size";
      public const string ColumnCommentSize = "Размер файла в байтах";

      public const string ColumnNameStorage = "storage";
      public const string ColumnCommentStorage = "Тип файлового хранилища";
    }
  }
}