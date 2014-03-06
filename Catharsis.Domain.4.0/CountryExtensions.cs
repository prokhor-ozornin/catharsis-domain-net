using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Country"/>.</para>
  /// </summary>
  /// <seealso cref="Country"/>
  public static class CountryExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of countries, returning the one with specified ISO code.</para>
    /// </summary>
    /// <param name="countries">Source sequence of countries to filter.</param>
    /// <param name="isoCode">ISO code of searched country.</param>
    /// <returns>Country with specified ISO code.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="countries"/> is a <c>null</c> reference.</exception>
    public static Country IsoCode(this IQueryable<Country> countries, string isoCode)
    {
      Assertion.NotNull(countries);

      return countries.Single(entity => entity.IsoCode == isoCode);
    }

    /// <summary>
    ///   <para>Filters sequence of countries, returning the one with specified ISO code.</para>
    /// </summary>
    /// <param name="countries">Source sequence of countries to filter.</param>
    /// <param name="isoCode">ISO code of searched country.</param>
    /// <returns>Country with specified ISO code.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="countries"/> is a <c>null</c> reference.</exception>
    public static Country IsoCode(this IEnumerable<Country> countries, string isoCode)
    {
      Assertion.NotNull(countries);

      return countries.Single(entity => entity != null && entity.IsoCode == isoCode);
    }
  }
}