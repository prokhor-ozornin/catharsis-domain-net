using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Web страница</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Web страница")]
#endif
  public partial class WebPage : Entity, IComparable<WebPage>, IEquatable<WebPage>
  {
    /// <summary>
    ///   <para>Наименование локали для текста web страницы</para>
    /// </summary>
#if NET_35
    [Description("Наименование локали для текста web страницы")]
#endif
    public virtual string Locale { get; set; }

    /// <summary>
    ///   <para>Наименование web страницы</para>
    /// </summary>
#if NET_35
    [Description("Наименование web страницы")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>HTML код (текст) web страницы</para>
    /// </summary>
#if NET_35
    [Description("HTML код (текст) web страницы")]
#endif
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>URI адрес web страницы</para>
    /// </summary>
#if NET_35
    [Description("URI адрес web страницы")]
#endif
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(WebPage other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(WebPage other)
    {
      return this.Equality(other, it => it.Locale, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebPage);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Locale, it => it.Uri);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}