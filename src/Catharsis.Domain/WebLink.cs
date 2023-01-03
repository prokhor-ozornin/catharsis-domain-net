using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Гиперссылка</para>
/// </summary>
[Description("Гиперссылка")]
[Serializable]
[DataContract(Name = nameof(WebLink))]
public class WebLink : Entity, IComparable<WebLink>, IEquatable<WebLink>
{
  /// <summary>
  ///   <para>Наименование гиперссылки</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование гиперссылки")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>URI адрес гиперссылки</para>
  /// </summary>
  [DataMember(Name = nameof(Uri))]
  [Description("URI адрес гиперссылки")]
  public virtual string Uri { get; set; }

  /// <summary>
  ///   <para>Изображение, представляющее гиперссылку</para>
  /// </summary>
  [DataMember(Name = nameof(Image))]
  [Description("Изображение, представляющее гиперссылку")]
  public virtual Image Image { get; set; }

  /// <summary>
  ///   <para>Описание гиперссылки</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Описание гиперссылки")]
  public virtual string Description { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="WebLink"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="WebLink"/> to compare with this instance.</param>
  public virtual int CompareTo(WebLink other) => string.Compare(Uri, other?.Uri, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="WebLink"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(WebLink other) => this.Equality(other, nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as WebLink);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Uri));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Uri ?? string.Empty;
}