using System.ComponentModel;
using System.Runtime.Serialization;

namespace Catharsis.Domain;

/// <summary>
///   <para>Объявление</para>
/// </summary>
[Description("Объявление")]
[Serializable]
[DataContract(Name = nameof(Announcement))]
public class Announcement : Entity, IComparable<Announcement>
{
  /// <summary>
  ///   <para>Наименование/заголовок</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование/заголовок")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Текстовое содержимое</para>
  /// </summary>
  [DataMember(Name = nameof(Text))]
  [Description("Текстовое содержимое")]
  public virtual string Text { get; set; }

  /// <summary>
  ///   <para>Связанный файл изображения</para>
  /// </summary>
  [DataMember(Name = nameof(Image))]
  [Description("Связанный файл изображения")]
  public virtual Image Image { get; set; }

  /// <summary>
  ///   <para>Стоимость публикации</para>
  /// </summary>
  [DataMember(Name = nameof(Price))]
  [Description("Стоимость публикации")]
  public virtual decimal? Price { get; set; }

  /// <summary>
  ///   <para>Валюта стоимости публикации</para>
  /// </summary>
  [DataMember(Name = nameof(PriceCurrency))]
  [Description("Валюта стоимости публикации")]
  public virtual string PriceCurrency { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Announcement"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Announcement"/> to compare with this instance.</param>
  public virtual int CompareTo(Announcement other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}