using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="IDateable"/>.</para>
  ///   <seealso cref="IDateable"/>
  /// </summary>
  public static class IDateableExtensions
  {
    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="ENTITY"></typeparam>
    /// <param name="entities"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<ENTITY> Date<ENTITY>(this IQueryable<ENTITY> entities, DateTime? from = null, DateTime? to = null) where ENTITY : IDateable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity.Date >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity.Date <= to.Value);
      }

      return entities;
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <typeparam name="ENTITY"></typeparam>
    /// <param name="entities"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<ENTITY> Date<ENTITY>(this IEnumerable<ENTITY> entities, DateTime? from = null, DateTime? to = null) where ENTITY : IDateable
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.Date >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.Date <= to.Value);
      }

      return entities;
    }
  }
}