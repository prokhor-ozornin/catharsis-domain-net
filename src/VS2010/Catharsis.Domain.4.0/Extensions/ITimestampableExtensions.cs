using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class ITimestampableExtensions
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
    public static IQueryable<T> CreatedOn<T>(this IQueryable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimestampable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.CreatedAt >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.CreatedAt <= to.Value);
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
    public static IEnumerable<T> CreatedOn<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimestampable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.CreatedAt >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.CreatedAt <= to.Value);
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
    public static IQueryable<T> UpdatedOn<T>(this IQueryable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimestampable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.UpdatedAt >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.UpdatedAt <= to.Value);
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
    public static IEnumerable<T> UpdatedOn<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : ITimestampable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.UpdatedAt >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.UpdatedAt <= to.Value);
      }

      return entities;
    }
  }
}