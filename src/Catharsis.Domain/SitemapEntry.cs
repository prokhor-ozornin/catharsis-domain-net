using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Элемент карты сайта</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Элемент карты сайта")]
#endif
  public partial class SitemapEntry : Entity, IComparable<SitemapEntry>, IEquatable<SitemapEntry>
  {
    /// <summary>
    ///   <para>Частота обновлений ресурса, доступного по URI адресу</para>
    /// </summary>
#if NET_35
    [Description("Частота обновлений ресурса, доступного по URI адресу")]
#endif
    public virtual SitemapChangeFrequency? ChangeFrequency { get; set; }

    /// <summary>
    ///   <para>Дата/время последнего обновления ресурса, доступного по URI адресу</para>
    /// </summary>
#if NET_35
    [Description("Дата/время последнего обновления ресурса, доступного по URI адресу")]
#endif
    public virtual DateTime? Date { get; set; }

    /// <summary>
    ///   <para>Описание ресурса, доступного по URI адресу</para>
    /// </summary>
#if NET_35
    [Description("Описание ресурса, доступного по URI адресу")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Приоритет ресурса среди элементов карты сайта</para>
    /// </summary>
#if NET_35
    [Description("Приоритет ресурса среди элементов карты сайта")]
#endif
    public virtual decimal? Priority { get; set; }

    /// <summary>
    ///   <para>URI адрес ресурса</para>
    /// </summary>
#if NET_35
    [Description("URI адрес ресурса")]
#endif
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(SitemapEntry other)
    {
      return this.Uri.ToString().CompareTo(other.Uri.ToString());
    }

    public bool Equals(SitemapEntry other)
    {
      return this.Equality(other, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as SitemapEntry);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.ToString() ?? string.Empty;
    }
  }
}