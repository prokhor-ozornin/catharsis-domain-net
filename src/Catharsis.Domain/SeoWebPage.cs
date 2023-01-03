using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>SEO данные о web странице</para>
/// </summary>
[Description("SEO данные о web странице")]
[Serializable]
[DataContract(Name = nameof(SeoWebPage))]
public class SeoWebPage : Entity, IComparable<SeoWebPage>, IEquatable<SeoWebPage>
{
  /// <summary>
  ///   <para>Значение title заголовка для web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Title))]
  [Description("Значение title заголовка для web страницы")]
  public virtual string Title { get; set; }

  /// <summary>
  ///   <para>URI адрес web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Uri))]
  [Description("URI адрес web страницы")]
  public virtual Uri Uri { get; set; }

  /// <summary>
  ///   <para>Наименование локали для содержимого web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Locale))]
  [Description("Наименование локали для содержимого web страницы")]
  public virtual string Locale { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="SeoWebPage"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="SeoWebPage"/> to compare with this instance.</param>
  public virtual int CompareTo(SeoWebPage other) => string.Compare(Uri?.ToString(), other?.Uri?.ToString(), StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="SeoWebPage"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(SeoWebPage other) => this.Equality(other, nameof(Locale), nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as SeoWebPage);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Locale), nameof(Uri));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Uri?.ToString() ?? string.Empty;
}