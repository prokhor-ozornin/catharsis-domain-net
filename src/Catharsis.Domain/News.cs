using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Новость проекта</para>
/// </summary>
[Description("Новость проекта")]
[Serializable]
[DataContract(Name = nameof(News))]
public class News : Entity, IComparable<News>, IEquatable<News>
{
  /// <summary>
  ///   <para>Заголовок новости</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Заголовок новости")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Файл изображения для новости</para>
  /// </summary>
  [DataMember(Name = nameof(Image))]
  [Description("Файл изображения для новости")]
  public virtual Image Image { get; set; }

  /// <summary>
  ///   <para>Аннотация к новости</para>
  /// </summary>
  [DataMember(Name = nameof(Annotation))]
  [Description("Аннотация к новости")]
  public virtual string Annotation { get; set; }

  /// <summary>
  ///   <para>Полный текст новости</para>
  /// </summary>
  [DataMember(Name = nameof(Text))]
  [Description("Полный текст новости")]
  public virtual string Text { get; set; }

  /// <summary>
  ///   <para>Ключевые слова, описывающие содержимое новости</para>
  /// </summary>
  [DataMember(Name = nameof(Tags))]
  [Description("Ключевые слова, описывающие содержимое новости")]
  public virtual ISet<Tag> Tags { get; set; } = new HashSet<Tag>();

  /// <summary>
  ///   <para>Compares the current <see cref="News"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="News"/> to compare with this instance.</param>
  public virtual int CompareTo(News other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="News"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(News other) => this.Equality(other, nameof(CreatedOn), nameof(Name));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as News);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(CreatedOn), nameof(Name));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Name ?? string.Empty;
}