namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Area"/> entity.</para>
/// </summary>
public sealed class AreaMapping : EntityMapping<Area>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public AreaMapping()
  {
    Table("area");
    Map(area => area.Name).Column("name").Not.Nullable().Index("ix-area-name");
    References(area => area.Country).Column("country_id").Not.Nullable().Fetch.Join().ForeignKey("fk-area2country").Index("ix-area-country_id");
  }
}