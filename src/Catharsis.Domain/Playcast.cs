using System.ComponentModel;
using System.Runtime.Serialization;

namespace Catharsis.Domain;

/// <summary>
///   <para>Плейкаст</para>
/// </summary>
[Description("Плейкаст")]
[Serializable]
[DataContract(Name = nameof(Playcast))]
public class Playcast : Entity, IComparable<Playcast>
{
  /// <summary>
  ///   <para>Наименование плейкаста</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Наименование плейкаста")]
  public virtual string? Name { get; set; }

  /// <summary>
  ///   <para>Текст плейкаста</para>
  /// </summary>
  [DataMember(Name = nameof(Text))]
  [Description("Текст плейкаста")]
  public virtual string? Text { get; set; }

  /// <summary>
  ///   <para>Изображение для плейкаста</para>
  /// </summary>
  [DataMember(Name = nameof(Image))]
  [Description("Изображение для плейкаста")]
  public virtual Image? Image { get; set; }

  /// <summary>
  ///   <para>Аудио-сопровождение плейкаста</para>
  /// </summary>
  [DataMember(Name = nameof(Audio))]
  [Description("Аудио-сопровождение плейкаста")]
  public virtual Audio? Audio { get; set; }

  /// <summary>
  ///   <para>Видео-содержимое плейкаста</para>
  /// </summary>
  [DataMember(Name = nameof(Video))]
  [Description("Видео-содержимое плейкаста")]
  public virtual Video? Video { get; set; }

  /// <summary>
  ///   <para>Ключевые слова, описывающие содержимое плейкаста</para>
  /// </summary>
  [DataMember(Name = nameof(Tags))]
  [Description("Ключевые слова, описывающие содержимое плейкаста")]
  public virtual ISet<Tag> Tags { get; set; } = new HashSet<Tag>();

  /// <summary>
  ///   <para>Compares the current <see cref="Playcast"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Playcast"/> to compare with this instance.</param>
  public virtual int CompareTo(Playcast? other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}