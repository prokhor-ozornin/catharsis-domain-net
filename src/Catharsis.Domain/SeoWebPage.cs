using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>SEO данные о web странице</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("SEO данные о web странице")]
#endif
  public partial class SeoWebPage : Entity, IComparable<SeoWebPage>, IEquatable<SeoWebPage>
  {
    /// <summary>
    ///   <para>Наименование локали для содержимого web страницы</para>
    /// </summary>
#if NET_35
    [Description("Наименование локали для содержимого web страницы")]
#endif
    public virtual string Locale { get; set; }

    /// <summary>
    ///   <para>Значение title заголовка для web страницы</para>
    /// </summary>
#if NET_35
    [Description("Значение title заголовка для web страницы")]
#endif
    public virtual string Title { get; set; }

    /// <summary>
    ///   <para>URI адрес web страницы</para>
    /// </summary>
#if NET_35
    [Description("URI адрес web страницы")]
#endif
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(SeoWebPage other)
    {
      return this.Uri.ToString().CompareTo(other.Uri.ToString());
    }

    public bool Equals(SeoWebPage other)
    {
      return this.Equality(other, it => it.Locale, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as SeoWebPage);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Locale, it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.ToString() ?? string.Empty;
    }
  }
}