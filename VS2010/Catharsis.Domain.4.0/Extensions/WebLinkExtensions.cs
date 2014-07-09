using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="WebLink"/>.</para>
  /// </summary>
  /// <seealso cref="WebLink"/>
  public static class WebLinkExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of web links, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="weblinks">Source sequence of web links to filter.</param>
    /// <param name="category">Category of web links to search for.</param>
    /// <returns>Filtered sequence of web links with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="weblinks"/> is a <c>null</c> reference.</exception>
    public static IQueryable<WebLink> Category(this IQueryable<WebLink> weblinks, WebLinksCategory category)
    {
      Assertion.NotNull(weblinks);

      return category != null ? weblinks.Where(weblink => weblink.Category.Id == category.Id) : weblinks.Where(weblink => weblink.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of web links, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="weblinks">Source sequence of web links to filter.</param>
    /// <param name="category">Category of web links to search for.</param>
    /// <returns>Filtered sequence of web links with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="weblinks"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<WebLink> Category(this IEnumerable<WebLink> weblinks, WebLinksCategory category)
    {
      Assertion.NotNull(weblinks);

      return category != null ? weblinks.Where(weblink => weblink != null && weblink.Category.Equals(category)) : weblinks.Where(weblink => weblink != null && weblink.Category == null);
    }
  }
}