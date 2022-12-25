namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Country"/>.</para>
/// </summary>
/// <seealso cref="Country"/>
public static class CountryExtensions
{
  public static IQueryable<Country> Name(this IQueryable<Country> countries, string name) => countries.Where(country => country.Name != null && country.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Country?> Name(this IEnumerable<Country?> countries, string name) => countries.Where(country => country?.Name != null && country.Name.ToLower().StartsWith(name.ToLower()));

  public static Country? ValueOf(this IQueryable<Country> countries, string isoCode) => countries.SingleOrDefault(country => country.IsoCode != null && country.IsoCode.ToLower() == isoCode.ToLower());

  public static Country? ValueOf(this IEnumerable<Country?> countries, string isoCode) => countries.SingleOrDefault(country => country?.IsoCode != null && country.IsoCode.ToLower() == isoCode.ToLower());
}