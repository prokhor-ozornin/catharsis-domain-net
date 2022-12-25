namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="ApiKey"/> entity.</para>
/// </summary>
public sealed class ApiKeyMapping : EntityMapping<ApiKey>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public ApiKeyMapping()
  {
    Table("api_key");
    Map(key => key.Value).Column("value").Not.Nullable().UniqueKey("uk-api_key-value");
    Map(key => key.Name).Column("name").Not.Nullable().Index("ix-api_key-name");
    References(key => key.Contact).Column("contact_id").Fetch.Join().ForeignKey("fk-api_key2contact").Index("ix-api_key-contact_id");
    Map(key => key.AppName).Column("app_name").Index("ix-api_key-app_name");
    Map(key => key.AppDomain).Column("app_domain").Index("ix-api_key-app_domain");
    Map(key => key.AppDescription).Column("app_description").Length(4000);
  }
}