using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Playcast"/>.</para>
  ///   <seealso cref="Playcast"/>
  /// </summary>
  public static class PlaycastExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of playcasts, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="playcasts">Source sequence of playcasts to filter.</param>
    /// <param name="category">Category of playcasts to search for.</param>
    /// <returns>Filtered sequence of playcasts with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="playcasts"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Playcast> Category(this IQueryable<Playcast> playcasts, PlaycastsCategory category)
    {
      Assertion.NotNull(playcasts);

      return category != null ? playcasts.Where(playcast => playcast.Category.Id == category.Id) : playcasts.Where(playcast => playcast.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of playcasts, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="playcasts">Source sequence of playcasts to filter.</param>
    /// <param name="category">Category of playcasts to search for.</param>
    /// <returns>Filtered sequence of playcasts with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="playcasts"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Playcast> Category(this IEnumerable<Playcast> playcasts, PlaycastsCategory category)
    {
      Assertion.NotNull(playcasts);

      return category != null ? playcasts.Where(playcast => playcast != null && playcast.Category.Equals(category)) : playcasts.Where(playcast => playcast != null && playcast.Category == null);
    }
  }
}