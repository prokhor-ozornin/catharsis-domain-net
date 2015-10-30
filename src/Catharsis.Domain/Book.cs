using System;
using System.ComponentModel;
using Catharsis.Commons;
using System.Collections.Generic;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Литературное произведение</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Литературное произведение")]
#endif
  public partial class Book : Entity, IComparable<Book>, IEquatable<Book>
  {
    /// <summary>
    ///   <para>Аннотация к произведению</para>
    /// </summary>
#if NET_35
    [Description("Аннотация к произведению")]
#endif
    public virtual string Annotation { get; set; }

    /// <summary>
    ///   <para>Автор произведения</para>
    /// </summary>
#if NET_35
    [Description("Автор произведения")]
#endif
    public virtual Person Author { get; set; }

    /// <summary>
    ///   <para>Текстовое содержимое произведения</para>
    /// </summary>
#if NET_35
    [Description("Текстовое содержимое произведения")]
#endif
    public virtual string Contents { get; set; }

    /// <summary>
    ///   <para>Изображение для обложки</para>
    /// </summary>
#if NET_35
    [Description("Изображение для обложки")]
#endif
    public virtual Image Cover { get; set; }

    /// <summary>
    ///   <para>Уникальный ISBN идентификатор</para>
    /// </summary>
#if NET_35
    [Description("Уникальный ISBN идентификатор")]
#endif
    public virtual string Isbn { get; set; }

    /// <summary>
    ///   <para>Национальный язык написания</para>
    /// </summary>
#if NET_35
    [Description("Национальный язык написания")]
#endif
    public virtual string Language { get; set; }

    /// <summary>
    ///   <para>Примечания к произведению</para>
    /// </summary>
#if NET_35
    [Description("Примечания к произведению")]
#endif
    public virtual string Notes { get; set; }

    /// <summary>
    ///   <para>Дата публикации</para>
    /// </summary>
#if NET_35
    [Description("Дата публикации")]
#endif
    public virtual DateTime? PublishDate { get; set; }

    /// <summary>
    ///   <para>Наименование издательства-публикатора</para>
    /// </summary>
#if NET_35
    [Description("Наименование издательства-публикатора")]
#endif
    public virtual string Publisher { get; set; }

    /// <summary>
    ///   <para>Ключевые слова, описывающие содержимое произведения</para>
    /// </summary>
#if NET_35
    [Description("Ключевые слова, описывающие содержимое произведения")]
#endif
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>
    ///   <para>Наименование произведения</para>
    /// </summary>
#if NET_35
    [Description("Наименование произведения")]
#endif
    public virtual string Title { get; set; }

    public virtual int CompareTo(Book other)
    {
      return this.Title.CompareTo(other.Title);
    }

    public bool Equals(Book other)
    {
      return this.Equality(other, it => it.Isbn);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Book);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Isbn);
    }

    public override string ToString()
    {
      return this.Title?.Trim() ?? string.Empty;
    }
  }
}