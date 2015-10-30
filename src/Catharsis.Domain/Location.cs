using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Географическая точка</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Географическая точка")]
#endif
  public partial class Location : Entity, IEquatable<Location>
  {
    /// <summary>
    ///   <para>Широта (градусов) географической точки</para>
    /// </summary>
#if NET_35
    [Description("Широта (градусов) географической точки")]
#endif
    public virtual decimal? Latitude { get; set; }

    /// <summary>
    ///   <para>Долгота (градусов) географической точки</para>
    /// </summary>
#if NET_35
    [Description("Долгота (градусов) географической точки")]
#endif
    public virtual decimal? Longitude { get; set; }

    /// <summary>
    ///   <para>Наименование связанной с географической точкой временной зоны</para>
    /// </summary>
#if NET_35
    [Description("Наименование связанной с географической точкой временной зоны")]
#endif
    public virtual string Timezone { get; set; }
    
    public bool Equals(Location other)
    {
      return this.Equality(other, it => it.Latitude, it => it.Longitude);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Location);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Latitude, it => it.Longitude);
    }

    public override string ToString()
    {
      return this.Latitude != null && this.Longitude != null ? $"{this.Latitude.ToStringInvariant()},{this.Longitude.ToStringInvariant()}" : string.Empty;
    }
  }
}