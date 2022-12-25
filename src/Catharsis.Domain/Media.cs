using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Медиа ресурс</para>
/// </summary>
[Description("Медиа ресурс")]
[Serializable]
[DataContract(Name = nameof(Media))]
public class Media : Entity, IComparable<Media>, IEquatable<Media>
{
  /// <summary>
  ///   <para>Заголовок медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Заголовок медиа ресурса")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>MIME тип медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(ContentType))]
  [Description("MIME тип медиа ресурса")]
  public virtual string? ContentType { get; set; }

  /// <summary>
  ///   <para>URI адрес медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(Uri))]
  [Description("URI адрес медиа ресурса")]
  public virtual Uri? Uri { get; set; }

  /// <summary>
  ///   <para>URI адрес сайта провайдера ресурсов данного типа</para>
  /// </summary>
  [DataMember(Name = nameof(ProviderUri))]
  [Description("URI адрес сайта провайдера ресурсов данного типа")]
  public virtual string? ProviderUri { get; set; }

  /// <summary>
  ///   <para>Ширина ресурса в пикселях</para>
  /// </summary>
  [DataMember(Name = nameof(Width))]
  [Description("Ширина ресурса в пикселях")]
  public virtual short? Width { get; set; }

  /// <summary>
  ///   <para>Высота медиа ресурса в пикселях</para>
  /// </summary>
  [DataMember(Name = nameof(Height))]
  [Description("Высота медиа ресурса в пикселях")]
  public virtual short? Height { get; set; }

  /// <summary>
  ///   <para>Длительность воспроизведения медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(Duration))]
  [Description("Длительность воспроизведения медиа ресурса")]
  public virtual long? Duration { get; set; }

  /// <summary>
  ///   <para>Описание медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Описание медиа ресурса")]
  public virtual string? Description { get; set; }

  /// <summary>
  ///   <para>Внедряемый HTML код медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(Html))]
  [Description("Внедряемый HTML код медиа ресурса")]
  public virtual string? Html { get; set; }

  /// <summary>
  ///   <para>Имя создателя медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(AuthorName))]
  [Description("Имя создателя медиа ресурса")]
  public virtual string? AuthorName { get; set; }

  /// <summary>
  ///   <para>URI адрес страницы создателя медиа ресурса</para>
  /// </summary>
  [Description("URI адрес страницы создателя медиа ресурса")]
  [DataMember(Name = nameof(AuthorUri))]
  public virtual string? AuthorUri { get; set; }

  /// <summary>
  ///   <para>URI адрес миниатюры медиа ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(ThumbnailUri))]
  [Description("URI адрес миниатюры медиа ресурса")]
  public virtual string? ThumbnailUri { get; set; }

  /// <summary>
  ///   <para>Ширина миниатюры медиа ресурса в пикселях</para>
  /// </summary>
  [DataMember(Name = nameof(ThumbnailWidth))]
  [Description("Ширина миниатюры медиа ресурса в пикселях")]
  public virtual short? ThumbnailWidth { get; set; }

  /// <summary>
  ///   <para>Высота миниатюры медиа ресурса в пикселях</para>
  /// </summary>
  [DataMember(Name = nameof(ThumbnailHeight))]
  [Description("Высота миниатюры медиа ресурса в пикселях")]
  public virtual short? ThumbnailHeight { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Media"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Media"/> to compare with this instance.</param>
  public virtual int CompareTo(Media? other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="Media"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Media? other) => this.Equality(other, nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as Media);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Uri));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Uri?.ToString() ?? string.Empty;
}