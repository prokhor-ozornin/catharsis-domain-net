using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class CountryExtensions
  {
    public static IQueryable<Country> Name(this IQueryable<Country> countries, string name)
    {
      Assertion.NotNull(countries);
      Assertion.NotEmpty(name);

      return countries.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Country> Name(this IEnumerable<Country> countries, string name)
    {
      Assertion.NotNull(countries);
      Assertion.NotEmpty(name);

      return countries.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static Country ValueOf(this IQueryable<Country> countries, string isoCode)
    {
      Assertion.NotNull(countries);
      Assertion.NotEmpty(isoCode);

      return countries.SingleOrDefault(it => it.IsoCode.ToLower() == isoCode.ToLower());
    }

    public static Country ValueOf(this IEnumerable<Country> countries, string isoCode)
    {
      Assertion.NotNull(countries);
      Assertion.NotEmpty(isoCode);

      return countries.SingleOrDefault(it => it?.IsoCode != null && it.IsoCode.ToLower() == isoCode.ToLower());
    }
  }
}