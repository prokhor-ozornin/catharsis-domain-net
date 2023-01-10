using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Изображение</para>
/// </summary>
[Description("Изображение")]
[Serializable]
[DataContract(Name = nameof(Image))]
public class Image : Media, IComparable<Image>, IEquatable<Image>
{
  /// <summary>
  ///   <para>Файл, представляющий изображение</para>
  /// </summary>
  [DataMember(Name = nameof(File))]
  [Description("Файл, представляющий изображение")]
  public virtual StorageFile File { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Image"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Image"/> to compare with this instance.</param>
  public virtual int CompareTo(Image other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="Image"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Image other) => this.Equality(other, nameof(File), nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Image);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(File), nameof(Uri));
}