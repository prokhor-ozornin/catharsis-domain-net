using Catharsis.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Новость проекта</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Новость проекта")]
#endif
  public partial class News : Entity, IComparable<News>, IEquatable<News>
  {
    /// <summary>
    ///   <para>Аннотация к новости</para>
    /// </summary>
#if NET_35
    [Description("Аннотация к новости")]
#endif
    public virtual string Annotation { get; set; }

    /// <summary>
    ///   <para>Файл изображения для новости</para>
    /// </summary>
#if NET_35
    [Description("Файл изображения для новости")]
#endif
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Заголовок новости</para>
    /// </summary>
#if NET_35
    [Description("Заголовок новости")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Ключевые слова, описывающие содержимое новости</para>
    /// </summary>
#if NET_35
    [Description("Ключевые слова, описывающие содержимое новости")]
#endif
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>
    ///   <para>Полный текст новости</para>
    /// </summary>
#if NET_35
    [Description("Полный текст новости")]
#endif
    public virtual string Text { get; set; }

    public virtual int CompareTo(News other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(News other)
    {
      return this.Equality(other, it => it.CreatedOn, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as News);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.CreatedOn, it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}