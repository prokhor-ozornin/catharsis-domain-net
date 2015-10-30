using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Web браузер</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Web браузер")]
#endif
  public partial class WebBrowser : Entity, IComparable<WebBrowser>, IEquatable<WebBrowser>
  {
    /// <summary>
    ///   <para>Описание браузера</para>
    /// </summary>
#if NET_35
    [Description("Описание браузера")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Наименование/код браузера</para>
    /// </summary>
#if NET_35
    [Description("Наименование/код браузера")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Адрес сайта разработчиков</para>
    /// </summary>
#if NET_35
    [Description("Адрес сайта разработчиков")]
#endif
    public virtual Uri Uri { get; set; }

    /// <summary>
    ///   <para>Значение HTTP заголовка User-Agent</para>
    /// </summary>
#if NET_35
    [Description("Значение HTTP заголовка User-Agent")]
#endif
    public virtual string UserAgent { get; set; }

    public virtual int CompareTo(WebBrowser other)
    {
      return this.UserAgent.CompareTo(other.UserAgent);
    }

    public bool Equals(WebBrowser other)
    {
      return this.Equality(other, it => it.UserAgent);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebBrowser);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.UserAgent);
    }

    public override string ToString()
    {
      return this.UserAgent?.Trim() ?? string.Empty;
    }
  }
}