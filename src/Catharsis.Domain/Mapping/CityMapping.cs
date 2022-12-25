namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="City"/> entity.</para>
/// </summary>
public sealed class CityMapping : EntityMapping<City>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public CityMapping()
  {
    Table("city");
    Map(city => city.Name).Column("name").Not.Nullable().Index("ix-city-name");
    Map(city => city.Federal).Column("federal").Index("ix-city-federal");
    References(city => city.Country).Column("country_id").Not.Nullable().Fetch.Join().ForeignKey("fk-city2country").Index("ix-city-country_id");
    References(city => city.Region).Column("region_id").Fetch.Join().ForeignKey("fk-city2region").Index("ix-city-region_id");
    References(city => city.Area).Column("area_id").Fetch.Join().ForeignKey("fk-city2area").Index("ix-city-area_id");
    References(city => city.Location).Column("location_id").Fetch.Join().ForeignKey("fk-city2location").Index("ix-city-location_id");
  }
}