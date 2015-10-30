using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Объявление</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Объявление")]
#endif
  public partial class Announcement : Entity, IComparable<Announcement>
  {
    /// <summary>
    ///   <para>Связанный файл изображения</para>
    /// </summary>
#if NET_35
    [Description("Связанный файл изображения")]
#endif
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование/заголовок</para>
    /// </summary>
#if NET_35
    [Description("Наименование/заголовок")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Стоимость публикации</para>
    /// </summary>
#if NET_35
    [Description("Стоимость публикации")]
#endif
    public virtual decimal? Price { get; set; }

    /// <summary>
    ///   <para>Валюта стоимости публикации</para>
    /// </summary>
#if NET_35
    [Description("Валюта стоимости публикации")]
#endif
    public virtual string PriceCurrency { get; set; }

    /// <summary>
    ///   <para>Текстовое содержимое</para>
    /// </summary>
#if NET_35
    [Description("Текстовое содержимое")]
#endif
    public virtual string Text { get; set; }

    public virtual int CompareTo(Announcement other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}