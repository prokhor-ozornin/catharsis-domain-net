using Catharsis.Commons;
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
  [Description("Файл")]
#endif
  public partial class StorageFile : Entity, IComparable<StorageFile>, IEquatable<StorageFile>
  {
    /// <summary>
    ///   <para>MIME тип содержимого файла</para>
    /// </summary>
#if NET_35
    [Description("MIME тип содержимого файла")]
#endif
    public virtual string ContentType { get; set; }

    /// <summary>
    ///   <para>Наименование файла</para>
    /// </summary>
#if NET_35
    [Description("Наименование файла")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Путь к файлу в хранилище</para>
    /// </summary>
#if NET_35
    [Description("Путь к файлу в хранилище")]
#endif
    public virtual string Path { get; set; }

    /// <summary>
    ///   <para>Размер файла в байтах</para>
    /// </summary>
#if NET_35
    [Description("Размер файла в байтах")]
#endif
    public virtual long? Size { get; set; }

    /// <summary>
    ///   <para>Тип файлового хранилища</para>
    /// </summary>
#if NET_35
    [Description("Тип файлового хранилища")]
#endif
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

    public bool Equals(StorageFile other)
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
  }
}