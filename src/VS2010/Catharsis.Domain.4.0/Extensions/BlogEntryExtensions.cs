using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="BlogEntry"/>.</para>
  /// </summary>
  /// <seealso cref="BlogEntry"/>
  public static class BlogEntryExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of blog entries, leaving those belonging to specified blog.</para>
    /// </summary>
    /// <param name="entries">Source sequence of entries to filter.</param>
    /// <param name="blog">Blog to search for.</param>
    /// <returns>Filtered sequence of entries in specified blog.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="entries"/> or <paramref name="blog"/> is a <c>null</c> reference.</exception>
    public static IQueryable<BlogEntry> Blog(this IQueryable<BlogEntry> entries, Blog blog)
    {
      Assertion.NotNull(entries);
      Assertion.NotNull(blog);

      return entries.Where(entry => entry.Blog.Id == blog.Id);
    }

    /// <summary>
    ///   <para>Filters sequence of blog entries, leaving those belonging to specified blog.</para>
    /// </summary>
    /// <param name="entries">Source sequence of entries to filter.</param>
    /// <param name="blog">Blog to search for.</param>
    /// <returns>Filtered sequence of entries in specified blog.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="entries"/> or <paramref name="blog"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<BlogEntry> Blog(this IEnumerable<BlogEntry> entries, Blog blog)
    {
      Assertion.NotNull(entries);
      Assertion.NotNull(blog);

      return entries.Where(entry => entry != null && entry.Blog.Equals(blog));
    }
  }
}