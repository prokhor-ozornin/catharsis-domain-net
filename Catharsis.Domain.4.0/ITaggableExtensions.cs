using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ITaggable"/>.</para>
  /// </summary>
  /// <seealso cref="ITaggable"/>
  public static class ITaggableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given tag.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="tag">Tag to search for.</param>
    /// <returns>Filtered sequence of entities with specified tag.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> Tag<T>(this IQueryable<T> entities, string tag) where T : ITaggable
    {
      Assertion.NotNull(entities);
      Assertion.NotEmpty(tag);

      return entities.Where(entity => entity.Tags.Contains(tag));
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given tag.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="tag">Tag to search for.</param>
    /// <returns>Filtered sequence of entities with specified tag.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Tag<T>(this IEnumerable<T> entities, string tag) where T : ITaggable
    {
      Assertion.NotNull(entities);
      Assertion.NotEmpty(tag);

      return entities.Where(entity => entity != null && entity.Tags.Contains(tag));
    }
  }
}