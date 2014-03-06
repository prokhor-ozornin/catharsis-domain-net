using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ITypeable"/>.</para>
  /// </summary>
  /// <seealso cref="ITypeable"/>
  public static class ITypeableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given type.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="type">Type to search for.</param>
    /// <returns>Filtered sequence of entities with specified type.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> Type<T>(this IQueryable<T> entities, int type) where T : ITypeable
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity.Type == type);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given type.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="type">Type to search for.</param>
    /// <returns>Filtered sequence of entities with specified type.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Type<T>(this IEnumerable<T> entities, int type) where T : ITypeable
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity != null && entity.Type == type);
    }
  }
}