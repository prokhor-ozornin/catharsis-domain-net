namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Address"/> entity.</para>
/// </summary>
public sealed class AddressMapping : EntityMapping<Address>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public AddressMapping()
  {
    Table("address");
    Map(address => address.Name).Column("name").Index("ix-address-name");
    References(address => address.City).Column("city_id").Not.Nullable().Fetch.Join().ForeignKey("fk-address2city").Index("ix-address-city_id");
    Map(address => address.Zip).Column("zip").Index("ix-address-zip");
    References(address => address.Location).Column("location_id").Fetch.Join().ForeignKey("fk-address2location").Index("ix-address-city_id");
    Map(address => address.Description).Column("description").Length(350);
  }
}