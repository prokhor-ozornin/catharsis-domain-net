using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Территория</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Территория")]
#endif
  public partial class Area : Entity, IComparable<Area>, IEquatable<Area>
  {
    /// <summary>
    ///   <para>Страна, в которой расположена территория</para>
    /// </summary>
#if NET_35
    [Description("Страна, в которой расположена территория")]
#endif
    public virtual Country Country { get; set; }

    /// <summary>
    ///   <para>Наименование территории</para>
    /// </summary>
#if NET_35
    [Description("Наименование территории")]
#endif
    public virtual string Name { get; set; }

    public virtual int CompareTo(Area other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(Area other)
    {
      return this.Equality(other, it => it.Country, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Area);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Country, it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}