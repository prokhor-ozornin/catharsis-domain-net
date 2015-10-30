using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Плейкаст</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Плейкаст")]
#endif
  public partial class Playcast : Entity, IComparable<Playcast>
  {
    /// <summary>
    ///   <para>Аудио-сопровождение плейкаста</para>
    /// </summary>
#if NET_35
    [Description("Аудио-сопровождение плейкаста")]
#endif
    public virtual Audio Audio { get; set; }

    /// <summary>
    ///   <para>Наименование плейкаста</para>
    /// </summary>
#if NET_35
    [Description("Наименование плейкаста")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Изображение для плейкаста</para>
    /// </summary>
#if NET_35
    [Description("Изображение для плейкаста")]
#endif
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Ключевые слова, описывающие содержимое плейкаста</para>
    /// </summary>
#if NET_35
    [Description("Ключевые слова, описывающие содержимое плейкаста")]
#endif
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>
    ///   <para>Текст плейкаста</para>
    /// </summary>
#if NET_35
    [Description("Текст плейкаста")]
#endif
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>Видео-содержимое плейкаста</para>
    /// </summary>
#if NET_35
    [Description("Видео-содержимое плейкаста")]
#endif
    public virtual Video Video { get; set; }

    public virtual int CompareTo(Playcast other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}