using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IEntity"/>.</para>
  ///   <seealso cref="IEntity"/>
  /// </summary>
  public static class IEntityExtensions
  {
    /// <summary>
    ///   <para>Returns single business entity width specified unique identifier.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entity.</typeparam>
    /// <param name="entities">Source sequence of entities to search in.</param>
    /// <param name="id">Identifier of entity.</param>
    /// <returns>Business entity with given identifier.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static ENTITY WithId<ENTITY>(this IQueryable<ENTITY> entities, long id) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      return entities.Single(entity => entity.Id == id);
    }

    /// <summary>
    ///   <para>Returns single business entity width specified unique identifier.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entity.</typeparam>
    /// <param name="entities">Source sequence of entities to search in.</param>
    /// <param name="id">Identifier of entity.</param>
    /// <returns>Business entity with given identifier.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static ENTITY WithId<ENTITY>(this IEnumerable<ENTITY> entities, long id) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      return entities.Single(entity => entity != null && entity.Id == id);
    }

    /// <summary>
    ///   <para>Determines whether business entity with specified identifier exists.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entity.</typeparam>
    /// <param name="entities">Source sequence of entities to search in.</param>
    /// <param name="id">Identifier of entity.</param>
    /// <returns><true> if entity with given identifier exists with <paramref name="entities"/> sequence, <c>false</c> if not.</true></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static bool Exists<ENTITY>(this IQueryable<ENTITY> entities, long id) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      return entities.Any(entity => entity.Id == id);
    }

    /// <summary>
    ///   <para>Determines whether business entity with specified identifier exists.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entity.</typeparam>
    /// <param name="entities">Source sequence of entities to search in.</param>
    /// <param name="id">Identifier of entity.</param>
    /// <returns><true> if entity with given identifier exists with <paramref name="entities"/> sequence, <c>false</c> if not.</true></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static bool Exists<ENTITY>(this IEnumerable<ENTITY> entities, long id) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      return entities.Any(entity => entity != null && entity.Id == id);
    }
  }
}