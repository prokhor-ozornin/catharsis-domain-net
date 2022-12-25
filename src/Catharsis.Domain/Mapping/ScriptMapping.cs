namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Script"/> entity.</para>
/// </summary>
public sealed class ScriptMapping : EntityMapping<Script>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public ScriptMapping()
  {
    Table("script");
    Map(script => script.Name).Column("name").UniqueKey("uk-script-name");
    Map(script => script.Executed).Column("executed").Not.Nullable();
    Map(script => script.Duration).Column("duration").Check("duration >= 0");
    Map(script => script.Path).Column("path");
    Map(script => script.Code).Column("code").Length(short.MaxValue);
  }
}