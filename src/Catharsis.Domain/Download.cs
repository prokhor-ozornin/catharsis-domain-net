using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Загружаемый материал</para>
/// </summary>
[Description("Загружаемый материал")]
[Serializable]
[DataContract(Name = nameof(Download))]
public class Download : Entity, IComparable<Download>, IEquatable<Download>
{
  /// <summary>
  ///   <para>Наименование материала</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование материала")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Описание материала</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Описание материала")]
  public virtual string Description { get; set; }

  /// <summary>
  ///   <para>Файл, представляющий загружаемый материал</para>
  /// </summary>
  [DataMember(Name = nameof(File))]
  [Description("Файл, представляющий загружаемый материал")]
  public virtual StorageFile File { get; set; }

  /// <summary>
  ///   <para>Изображение, связанное с материалом</para>
  /// </summary>
  [DataMember(Name = nameof(Image))]
  [Description("Изображение, связанное с материалом")]
  public virtual Image Image { get; set; }

  /// <summary>
  ///   <para>Количество скачиваний</para>
  /// </summary>
  [DataMember(Name = nameof(Downloads))]
  [Description("Количество скачиваний")]
  public virtual long? Downloads { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Download"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Download"/> to compare with this instance.</param>
  public virtual int CompareTo(Download other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="Download"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Download other) => this.Equality(other, nameof(File));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Download);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(File));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}