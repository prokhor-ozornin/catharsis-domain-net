using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Download"/>.</para>
  ///   <seealso cref="Download"/>
  /// </summary>
  public static class DownloadExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of downloads, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="downloads">Source sequence of downloads to filter.</param>
    /// <param name="category">Category of downloads to search for.</param>
    /// <returns>Filtered sequence of downloads with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="downloads"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Download> Category(this IQueryable<Download> downloads, DownloadsCategory category)
    {
      Assertion.NotNull(downloads);

      return category != null ? downloads.Where(download => download.Category.Id == category.Id) : downloads.Where(download => download.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of downloads, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="downloads">Source sequence of downloads to filter.</param>
    /// <param name="category">Category of downloads to search for.</param>
    /// <returns>Filtered sequence of downloads with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="downloads"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Download> Category(this IEnumerable<Download> downloads, DownloadsCategory category)
    {
      Assertion.NotNull(downloads);

      return category != null ? downloads.Where(download => download != null && download.Category.Equals(category)) : downloads.Where(download => download != null && download.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of downloads, leaving those with count of downloads in specified range.</para>
    /// </summary>
    /// <param name="downloads">Source sequence of downloads to filter.</param>
    /// <param name="from">Lower bound of downloads range.</param>
    /// <param name="to">Upper bound of downloads range.</param>
    /// <returns>Filtered sequence of downloads with count of downloads ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="downloads"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Download> Downloads(this IQueryable<Download> downloads, long? from = null, long? to = null)
    {
      Assertion.NotNull(downloads);

      if (from != null)
      {
        downloads = downloads.Where(download => download.Downloads >= from.Value);
      }

      if (to != null)
      {
        downloads = downloads.Where(download => download.Downloads <= to.Value);
      }

      return downloads;
    }

    /// <summary>
    ///   <para>Filters sequence of downloads, leaving those with count of downloads in specified range.</para>
    /// </summary>
    /// <param name="downloads">Source sequence of downloads to filter.</param>
    /// <param name="from">Lower bound of downloads range.</param>
    /// <param name="to">Upper bound of downloads range.</param>
    /// <returns>Filtered sequence of downloads with count of downloads ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="downloads"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Download> Downloads(this IEnumerable<Download> downloads, long? from = null, long? to = null)
    {
      Assertion.NotNull(downloads);

      if (from != null)
      {
        downloads = downloads.Where(download => download != null && download.Downloads >= from.Value);
      }

      if (to != null)
      {
        downloads = downloads.Where(download => download != null && download.Downloads <= to.Value);
      }

      return downloads;
    }
  }
}