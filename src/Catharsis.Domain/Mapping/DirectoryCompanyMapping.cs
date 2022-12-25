namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="DirectoryCompany"/> entity.</para>
/// </summary>
public sealed class DirectoryCompanyMapping : EntityMapping<DirectoryCompany>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public DirectoryCompanyMapping()
  {
    Cache.ReadOnly();
    Table("directory_company");
    Map(company => company.Name).Column("name");
    Map(company => company.ShortName).Column("short_name");
    Map(company => company.Code).Column("code");
    References(company => company.Contact).Column("contact_id").Fetch.Join().ForeignKey("fk-directory_company2contact").Index("ix-directory_company-contact_id");
  }
}