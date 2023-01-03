using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Web страница</para>
/// </summary>
[Description("Web страница")]
[Serializable]
[DataContract(Name = nameof(WebPage))]
public class WebPage : Entity, IComparable<WebPage>, IEquatable<WebPage>
{
  /// <summary>
  ///   <para>Наименование web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование web страницы")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>URI адрес web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Uri))]
  [Description("URI адрес web страницы")]
  public virtual Uri Uri { get; set; }

  /// <summary>
  ///   <para>Наименование локали для текста web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Locale))]
  [Description("Наименование локали для текста web страницы")]
  public virtual string Locale { get; set; }

  /// <summary>
  ///   <para>HTML код (текст) web страницы</para>
  /// </summary>
  [DataMember(Name = nameof(Text))]
  [Description("HTML код (текст) web страницы")]
  public virtual string Text { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="WebPage"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="WebPage"/> to compare with this instance.</param>
  public virtual int CompareTo(WebPage other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="WebPage"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(WebPage other) => this.Equality(other, nameof(Locale), nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as WebPage);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Locale), nameof(Uri));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}