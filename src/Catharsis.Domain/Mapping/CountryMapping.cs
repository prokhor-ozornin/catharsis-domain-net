namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Country"/> entity.</para>
/// </summary>
public sealed class CountryMapping : EntityMapping<Country>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public CountryMapping()
  {
    Table("country");
    Map(country => country.Name).Column("name").Not.Nullable().UniqueKey("uk-country-name");
    Map(country => country.Language).Column("language");
    Map(country => country.Currency).Column("currency").Not.Nullable();
    Map(country => country.IsoCode).Column("iso_code").Not.Nullable().Length(2).UniqueKey("uk-country-iso_code");
    Map(country => country.CurrencyCode).Column("currency_code").Not.Nullable().Length(3).Index("ix-country-currency_code");
  }
}