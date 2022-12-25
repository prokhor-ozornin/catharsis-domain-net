using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Web браузер</para>
/// </summary>
[Description("Web браузер")]
[Serializable]
[DataContract(Name = nameof(WebBrowser))]
public class WebBrowser : Entity, IComparable<WebBrowser>, IEquatable<WebBrowser>
{
  /// <summary>
  ///   <para>Наименование/код браузера</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование/код браузера")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>Адрес сайта разработчиков</para>
  /// </summary>
  [DataMember(Name = nameof(Uri))]
  [Description("Адрес сайта разработчиков")]
  public virtual Uri? Uri { get; set; }

  /// <summary>
  ///   <para>Значение HTTP заголовка User-Agent</para>
  /// </summary>
  [DataMember(Name = nameof(UserAgent))]
  [Description("Значение HTTP заголовка User-Agent")]
  public virtual string? UserAgent { get; set; }

  /// <summary>
  ///   <para>Описание браузера</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Описание браузера")]
  public virtual string? Description { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="WebBrowser"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="WebBrowser"/> to compare with this instance.</param>
  public virtual int CompareTo(WebBrowser? other) => string.Compare(UserAgent, other?.UserAgent, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="WebBrowser"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(WebBrowser? other) => this.Equality(other, nameof(UserAgent));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object? other) => Equals(other as WebBrowser);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(UserAgent));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => UserAgent ?? string.Empty;
}