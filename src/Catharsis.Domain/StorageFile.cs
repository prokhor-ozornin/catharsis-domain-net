using Catharsis.Commons;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Catharsis.Domain;

/// <summary>
///   <para>Файл</para>
/// </summary>
[Description("Файл")]
[Serializable]
[DataContract(Name = nameof(StorageFile))]
public class StorageFile : Entity, IComparable<StorageFile>, IEquatable<StorageFile>
{
  /// <summary>
  ///   <para>Наименование файла</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование файла")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Тип файлового хранилища</para>
  /// </summary>
  [DataMember(Name = nameof(Storage))]
  [Description("Тип файлового хранилища")]
  public virtual string Storage { get; set; }

  /// <summary>
  ///   <para>MIME тип содержимого файла</para>
  /// </summary>
  [DataMember(Name = nameof(ContentType))]
  [Description("MIME тип содержимого файла")]
  public virtual string ContentType { get; set; }

  /// <summary>
  ///   <para>Размер файла в байтах</para>
  /// </summary>
  [DataMember(Name = nameof(Size))]
  [Description("Размер файла в байтах")]
  public virtual long? Size { get; set; }

  /// <summary>
  ///   <para>Путь к файлу в хранилище</para>
  /// </summary>
  [DataMember(Name = nameof(Path))]
  [Description("Путь к файлу в хранилище")]
  public virtual string Path { get; set; }

  public virtual string FullPath
  {
    get
    {
      var fullPath = new StringBuilder();

      if (!Path.IsEmpty())
      {
        fullPath.Append(Path.Trim());

        if (!Path.EndsWith("/") && !Path.EndsWith("\\"))
        {
          fullPath.Append("/");
        }
      }

      if (Name != null && !Name.Trim().IsEmpty())
      {
        fullPath.Append(Name.Trim());
      }

      return fullPath.ToString();
    }
  }

  /// <summary>
  ///   <para>Compares the current <see cref="StorageFile"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="StorageFile"/> to compare with this instance.</param>
  public virtual int CompareTo(StorageFile other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="StorageFile"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(StorageFile other) => this.Equality(other, nameof(Name), nameof(Path), nameof(Storage));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as StorageFile);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Name), nameof(Path), nameof(Storage));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => FullPath;
}