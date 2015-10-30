using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Регион</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Регион")]
#endif
  public partial class Region : Entity, IComparable<Region>, IEquatable<Region>
  {
    /// <summary>
    ///   <para>Территория, к которой относится регион</para>
    /// </summary>
#if NET_35
    [Description("Территория, к которой относится регион")]
#endif
    public virtual Area Area { get; set; }

    /// <summary>
    ///   <para>Наименование региона</para>
    /// </summary>
#if NET_35
    [Description("Наименование региона")]
#endif
    public virtual string Name { get; set; }

    public virtual int CompareTo(Region other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(Region other)
    {
      return this.Equality(other, it => it.Area, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Region);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Area, it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}