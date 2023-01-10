using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Литературное произведение</para>
/// </summary>
[Description("Литературное произведение")]
[Serializable]
[DataContract(Name = nameof(Book))]
public class Book : Entity, IComparable<Book>, IEquatable<Book>
{
  /// <summary>
  ///   <para>Наименование произведения</para>
  /// </summary>
  [DataMember(Name = nameof(Title))]
  [Description("Наименование произведения")]
  public virtual string Title { get; set; }

  /// <summary>
  ///   <para>Автор произведения</para>
  /// </summary>
  [DataMember(Name = nameof(Author))]
  [Description("Автор произведения")]
  public virtual Person Author { get; set; }

  /// <summary>
  ///   <para>Национальный язык написания</para>
  /// </summary>
  [DataMember(Name = nameof(Language))]
  [Description("Национальный язык написания")]
  public virtual string Language { get; set; }

  /// <summary>
  ///   <para>Уникальный ISBN идентификатор</para>
  /// </summary>
  [DataMember(Name = nameof(Isbn))]
  [Description("Уникальный ISBN идентификатор")]
  public virtual string Isbn { get; set; }

  /// <summary>
  ///   <para>Аннотация к произведению</para>
  /// </summary>
  [DataMember(Name = nameof(Annotation))]
  [Description("Аннотация к произведению")]
  public virtual string Annotation { get; set; }

  /// <summary>
  ///   <para>Примечания к произведению</para>
  /// </summary>
  [DataMember(Name = nameof(Notes))]
  [Description("Примечания к произведению")]
  public virtual string Notes { get; set; }

  /// <summary>
  ///   <para>Дата публикации</para>
  /// </summary>
  [DataMember(Name = nameof(PublishDate))]
  [Description("Дата публикации")]
  public virtual DateTimeOffset? PublishDate { get; set; }

  /// <summary>
  ///   <para>Наименование издательства-публикатора</para>
  /// </summary>
  [DataMember(Name = nameof(Publisher))]
  [Description("Наименование издательства-публикатора")]
  public virtual string Publisher { get; set; }

  /// <summary>
  ///   <para>Изображение для обложки</para>
  /// </summary>
  [DataMember(Name = nameof(Cover))]
  [Description("Изображение для обложки")]
  public virtual Image Cover { get; set; }

  /// <summary>
  ///   <para>Текстовое содержимое произведения</para>
  /// </summary>
  [DataMember(Name = nameof(Contents))]
  [Description("Текстовое содержимое произведения")]
  public virtual string Contents { get; set; }

  /// <summary>
  ///   <para>Ключевые слова, описывающие содержимое произведения</para>
  /// </summary>
  [DataMember(Name = nameof(Tags))]
  [Description("Ключевые слова, описывающие содержимое произведения")]
  public virtual ISet<Tag> Tags { get; set; } = new HashSet<Tag>();

  /// <summary>
  ///   <para>Compares the current <see cref="Book"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Book"/> to compare with this instance.</param>
  public virtual int CompareTo(Book other) => string.Compare(Title, other?.Title, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Determines whether two <see cref="Book"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(Book other) => this.Equality(other, nameof(Isbn));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as Book);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(Isbn));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Title ?? string.Empty;
}