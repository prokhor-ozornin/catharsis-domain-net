namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Region"/> entity.</para>
/// </summary>
public sealed class RegionMapping : EntityMapping<Region>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public RegionMapping()
  {
    Table("region");
    Map(region => region.Name).Column("name").Not.Nullable().Index("ix-region-name");
    References(region => region.Area).Column("area_id").Not.Nullable().Fetch.Join().ForeignKey("fk-region2area").Index("ix-region-area_id");
  }
}