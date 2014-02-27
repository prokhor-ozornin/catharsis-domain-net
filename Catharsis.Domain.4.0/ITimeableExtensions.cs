using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class ITimeableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with creation date and time in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of date and time range.</param>
    /// <param name="to">Upper bound of date and time range.</param>
    /// <returns>Filtered sequence of entities with creation date and time ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> CreatedOn<T>(this IQueryable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimeable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.DateCreated >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.DateCreated <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with creation date and time in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of date and time range.</param>
    /// <param name="to">Upper bound of date and time range.</param>
    /// <returns>Filtered sequence of entities with creation date and time ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> CreatedOn<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimeable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.DateCreated >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.DateCreated <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with update date and time in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of date and time range.</param>
    /// <param name="to">Upper bound of date and time range.</param>
    /// <returns>Filtered sequence of entities with update date and time ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> UpdatedOn<T>(this IQueryable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimeable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.LastUpdated >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.LastUpdated <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with update date and time in specified range.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="from">Lower bound of date and time range.</param>
    /// <param name="to">Upper bound of date and time range.</param>
    /// <returns>Filtered sequence of entities with update date and time ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> UpdatedOn<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimeable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.LastUpdated >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.LastUpdated <= to.Value);
      }

      return entities;
    }
  }
}