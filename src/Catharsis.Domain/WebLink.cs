using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Гиперссылка.</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Web гиперссылка")]
#endif
  public partial class WebLink : Entity, IComparable<WebLink>, IEquatable<WebLink>
  {
    /// <summary>
    ///   <para>Описание гиперссылки</para>
    /// </summary>
#if NET_35
    [Description("Описание гиперссылки")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Наименование гиперссылки</para>
    /// </summary>
#if NET_35
    [Description("Наименование гиперссылки")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>URI адрес гиперссылки</para>
    /// </summary>
#if NET_35
    [Description("URI адрес гиперссылки")]
#endif
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(WebLink other)
    {
      return this.Uri.ToString().CompareTo(other.Uri.ToString());
    }

    public bool Equals(WebLink other)
    {
      return this.Equality(other, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as WebLink);
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