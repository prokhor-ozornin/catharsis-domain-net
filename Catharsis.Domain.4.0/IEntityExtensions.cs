using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IEntity"/>.</para>
  /// </summary>
  /// <seealso cref="IEntity"/>
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
    public static ENTITY Id<ENTITY>(this IQueryable<ENTITY> entities, long id) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      return entities.FirstOrDefault(entity => entity.Id == id);
    }

    /// <summary>
    ///   <para>Returns single business entity width specified unique identifier.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entity.</typeparam>
    /// <param name="entities">Source sequence of entities to search in.</param>
    /// <param name="id">Identifier of entity.</param>
    /// <returns>Business entity with given identifier.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static ENTITY Id<ENTITY>(this IEnumerable<ENTITY> entities, long id) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      return entities.FirstOrDefault(entity => entity != null && entity.Id == id);
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

    /// <summary>
    ///   <para>Picks up random entity from a specified sequence and returns it.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities in a sequence.</typeparam>
    /// <param name="entities">Source sequence of entities.</param>
    /// <returns>Random entity from <paramref name="entities"/> sequence. If <paramref name="entities"/> contains no elements, returns <c>null</c>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static ENTITY RandomEntity<ENTITY>(this IEnumerable<ENTITY> entities) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      if (!entities.Any())
      {
        return (ENTITY) (object) null;
      }

      var identifiers = entities.Select(entity => entity.Id).ToArray();
      return entities.Id(identifiers[new Random().Next(identifiers.Length)]);
    }

    /// <summary>
    ///   <para>Picks up random entity from <see cref="IQueryable{ENTITY}"/> source and returns it.</para>
    /// </summary>
    /// <typeparam name="ENTITY">Type of entities in <see cref="IQueryable{ENTITY}"/> source.</typeparam>
    /// <param name="entities">Source from which random entity is to be taken.</param>
    /// <returns>Random entity from <paramref name="entities"/> source. If <paramref name="entities"/> contains no elements, returns <c>null</c>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static ENTITY RandomEntity<ENTITY>(this IQueryable<ENTITY> entities) where ENTITY : IEntity
    {
      Assertion.NotNull(entities);

      if (!entities.Any())
      {
        return (ENTITY) (object) null;
      }

      var identifiers = entities.Select(entity => entity.Id).ToArray();
      return entities.Id(identifiers[new Random().Next(identifiers.Length)]);
    }
  }
}