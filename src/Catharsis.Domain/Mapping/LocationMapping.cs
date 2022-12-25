namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Location"/> entity.</para>
/// </summary>
public sealed class LocationMapping : EntityMapping<Location>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public LocationMapping()
  {
    Table("location");
    Map(location => location.Latitude).Column("latitude").Not.Nullable().Check("latitude BETWEEN -90 AND 90").Index("ix-location-latitude");
    Map(location => location.Longitude).Column("longitude").Not.Nullable().Check("longitude BETWEEN -180 AND 180").Index("ix-location-longitude");
    Map(location => location.TimeZone).Column("timezone").Index("ix-location-timezone");
  }
}