using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Location"/>.</para>
  /// </summary>
  /// <seealso cref="Location"/>
  public static class LocationExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of locations, leaving those with specified address.</para>
    /// </summary>
    /// <param name="locations">Source sequence of locations to filter.</param>
    /// <param name="address">Address of locations to search for.</param>
    /// <returns>Filtered sequence of locations with specified address.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="locations"/> or <paramref name="address"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="address"/> is <see cref="string.Empty"/> string.</exception>
    public static IQueryable<Location> Address(this IQueryable<Location> locations, string address)
    {
      Assertion.NotNull(locations);
      Assertion.NotEmpty(address);

      return locations.Where(location => location.Address == address);
    }

    /// <summary>
    ///   <para>Filters sequence of locations, leaving those with specified address.</para>
    /// </summary>
    /// <param name="locations">Source sequence of locations to filter.</param>
    /// <param name="address">Address of locations to search for.</param>
    /// <returns>Filtered sequence of locations with specified address.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="locations"/> or <paramref name="address"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="address"/> is <see cref="string.Empty"/> string.</exception>
    public static IEnumerable<Location> Address(this IEnumerable<Location> locations, string address)
    {
      Assertion.NotNull(locations);
      Assertion.NotEmpty(address);

      return locations.Where(location => location != null && location.Address == address);
    }

    /// <summary>
    ///   <para>Filters sequence of locations, leaving those belonging to specified city.</para>
    /// </summary>
    /// <param name="locations">Source sequence of locations to filter.</param>
    /// <param name="city">City to search for.</param>
    /// <returns>Filtered sequence of locations in specified city.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="locations"/> or <paramref name="city"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Location> City(this IQueryable<Location> locations, City city)
    {
      Assertion.NotNull(locations);
      Assertion.NotNull(city);

      return locations.Where(location => location.City.Id == city.Id);
    }

    /// <summary>
    ///   <para>Filters sequence of locations, leaving those belonging to specified city.</para>
    /// </summary>
    /// <param name="locations">Source sequence of locations to filter.</param>
    /// <param name="city">City to search for.</param>
    /// <returns>Filtered sequence of locations in specified city.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="locations"/> or <paramref name="city"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Location> City(this IEnumerable<Location> locations, City city)
    {
      Assertion.NotNull(locations);
      Assertion.NotNull(city);

      return locations.Where(location => location != null && location.City.Equals(city));
    }

    /// <summary>
    ///   <para>Filters sequence of locations, leaving those with specified postal code.</para>
    /// </summary>
    /// <param name="locations">Source sequence of locations to filter.</param>
    /// <param name="postalCode">Postal code of locations to search for.</param>
    /// <returns>Filtered sequence of locations with specified postal code.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="locations"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Location> PostalCode(this IQueryable<Location> locations, string postalCode)
    {
      Assertion.NotNull(locations);

      return locations.Where(location => location.PostalCode == postalCode);
    }

    /// <summary>
    ///   <para>Filters sequence of locations, leaving those with specified postal code.</para>
    /// </summary>
    /// <param name="locations">Source sequence of locations to filter.</param>
    /// <param name="postalCode">Postal code of locations to search for.</param>
    /// <returns>Filtered sequence of locations with specified postal code.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="locations"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Location> PostalCode(this IEnumerable<Location> locations, string postalCode)
    {
      Assertion.NotNull(locations);

      return locations.Where(location => location != null && location.PostalCode == postalCode);
    }
  }
}