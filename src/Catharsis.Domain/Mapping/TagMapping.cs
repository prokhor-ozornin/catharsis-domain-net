namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Tag"/> entity.</para>
/// </summary>
public sealed class TagMapping : EntityMapping<Tag>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public TagMapping()
  {
    Table("tag");
    Map(tag => tag.Name).Column("name").Not.Nullable().UniqueKey("uk-tag-name");
  }
}