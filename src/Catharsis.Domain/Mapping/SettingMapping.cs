namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Setting"/> entity.</para>
/// </summary>
public sealed class SettingMapping : EntityMapping<Setting>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public SettingMapping()
  {
    Table("setting");
    Map(setting => setting.Name).Column("name").Not.Nullable().UniqueKey("ix-setting-name");
    Map(setting => setting.Type).Column("type").Not.Nullable().Index("ix-setting-type");
    Map(setting => setting.Description).Column("description");
    Map(setting => setting.Value).Column("value");
    HasMany(setting => setting.Values).AsList().Table("setting2value").KeyColumn("setting_id").Element("value", value => value.Not.Nullable()).ForeignKeyConstraintName("fk-setting2value");
  }
}