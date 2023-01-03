using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Элемент карты сайта</para>
/// </summary>
[Description("Элемент карты сайта")]
[Serializable]
[DataContract(Name = nameof(SitemapEntry))]
public class SitemapEntry : Entity, IComparable<SitemapEntry>, IEquatable<SitemapEntry>
{
  /// <summary>
  ///   <para>URI адрес ресурса</para>
  /// </summary>
  [DataMember(Name = nameof(Uri))]
  [Description("URI адрес ресурса")]
  public virtual Uri Uri { get; set; }

  /// <summary>
  ///   <para>Частота обновлений ресурса, доступного по URI адресу</para>
  /// </summary>
  [DataMember(Name = nameof(ChangeFrequency))]
  [Description("Частота обновлений ресурса, доступного по URI адресу")]
  public virtual SitemapChangeFrequency? ChangeFrequency { get; set; }

  /// <summary>
  ///   <para>Приоритет ресурса среди элементов карты сайта</para>
  /// </summary>
  [DataMember(Name = nameof(Priority))]
  [Description("Приоритет ресурса среди элементов карты сайта")]
  public virtual decimal? Priority { get; set; }

  /// <summary>
  ///   <para>Дата/время последнего обновления ресурса, доступного по URI адресу</para>
  /// </summary>
  [DataMember(Name = nameof(Date))]
  [Description("Дата/время последнего обновления ресурса, доступного по URI адресу")]
  public virtual DateTimeOffset? Date { get; set; }

  /// <summary>
  ///   <para>Описание ресурса, доступного по URI адресу</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Описание ресурса, доступного по URI адресу")]
  public virtual string Description { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="SitemapEntry"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="SitemapEntry"/> to compare with this instance.</param>
  public virtual int CompareTo(SitemapEntry other) => string.Compare(Uri?.ToString(), other?.Uri?.ToString(), StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="SitemapEntry"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(SitemapEntry other) => this.Equality(other, nameof(Uri));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as SitemapEntry);

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

  public enum SitemapChangeFrequency
  {
    Always,
    Daily, 
    Hourly,
    Monthly,
    Never, 
    Weekly,
    Yearly
  }
}