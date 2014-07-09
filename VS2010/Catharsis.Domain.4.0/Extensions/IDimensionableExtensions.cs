using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDimensionable"/>.</para>
  /// </summary>
  /// <seealso cref="IDimensionable"/>
  public static class IDimensionableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with height in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of height range.</param>
    /// <param name="to">Upper bound of height range.</param>
    /// <returns>Filtered sequence of entities with height ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> Height<T>(this IQueryable<T> entities, short? from = null, short? to = null) where T : IDimensionable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.Height >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.Height <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with height in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of height range.</param>
    /// <param name="to">Upper bound of height range.</param>
    /// <returns>Filtered sequence of entities with height ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Height<T>(this IEnumerable<T> entities, short? from = null, short? to = null) where T : IDimensionable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.Height >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.Height <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with width in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of width range.</param>
    /// <param name="to">Upper bound of width range.</param>
    /// <returns>Filtered sequence of entities with width ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> Width<T>(this IQueryable<T> entities, short? from = null, short? to = null) where T : IDimensionable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.Width >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.Width <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with width in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of width range.</param>
    /// <param name="to">Upper bound of width range.</param>
    /// <returns>Filtered sequence of entities with width ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Width<T>(this IEnumerable<T> entities, short? from = null, short? to = null) where T : IDimensionable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.Width >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.Width <= to.Value);
      }

      return entities;
    }
  }
}