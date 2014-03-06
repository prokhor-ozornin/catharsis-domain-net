using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="City"/>.</para>
  /// </summary>
  /// <seealso cref="City"/>
  public static class CityExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of cities, leaving those located in specified country.</para>
    /// </summary>
    /// <param name="cities">Source sequence of cities to filter.</param>
    /// <param name="country">Country to search for.</param>
    /// <returns>Filtered sequence of cities in specified country.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="cities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<City> Country(this IQueryable<City> cities, Country country)
    {
      Assertion.NotNull(cities);

      return country != null ? cities.Where(city => city.Country.Id == country.Id) : cities.Where(city => city.Country == null);
    }

    /// <summary>
    ///   <para>Filters sequence of cities, leaving those located in specified country.</para>
    /// </summary>
    /// <param name="cities">Source sequence of cities to filter.</param>
    /// <param name="country">Country to search for.</param>
    /// <returns>Filtered sequence of cities in specified country.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="cities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<City> Country(this IEnumerable<City> cities, Country country)
    {
      Assertion.NotNull(cities);

      return country != null ? cities.Where(city => city != null && city.Country.Equals(country)) : cities.Where(city => city != null && city.Country == null);
    }

    /// <summary>
    ///   <para>Filters sequence of cities, leaving those located in specified region.</para>
    /// </summary>
    /// <param name="cities">Source sequence of cities to filter.</param>
    /// <param name="region">Region to search for.</param>
    /// <returns>Filtered sequence of cities in specified region.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="cities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<City> Region(this IQueryable<City> cities, string region)
    {
      Assertion.NotNull(cities);

      return cities.Where(city => city.Region == region);
    }

    /// <summary>
    ///   <para>Filters sequence of cities, leaving those located in specified region.</para>
    /// </summary>
    /// <param name="cities">Source sequence of cities to filter.</param>
    /// <param name="region">Region to search for.</param>
    /// <returns>Filtered sequence of cities in specified region.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="cities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<City> Region(this IEnumerable<City> cities, string region)
    {
      Assertion.NotNull(cities);

      return cities.Where(city => city != null && city.Region == region);
    }
  }
}