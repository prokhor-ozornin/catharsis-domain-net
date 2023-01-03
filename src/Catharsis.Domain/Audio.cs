using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Аудио</para>
/// </summary>
[Description("Аудио")]
[Serializable]
[DataContract(Name = nameof(Audio))]
public class Audio : Media, IEquatable<Audio>
{
  /// <summary>
  ///   <para>Битрейт аудио дорожки</para>
  /// </summary>
  [Description("Битрейт аудио дорожки")]
  [DataMember(Name = nameof(Bitrate))]
  public virtual short? Bitrate { get; set; }

  /// <summary>
  ///   <para>Файл, представляющий аудио</para>
  /// </summary>
  [DataMember(Name = nameof(File))]
  [Description("Файл, представляющий аудио")]
  public virtual StorageFile File { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Audio"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Audio"/> to compare with this instance.</param>
  public virtual int CompareTo(Audio other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="Audio"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Audio other) => this.Equality(other, nameof(File), nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Audio);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(File), nameof(Uri));
}