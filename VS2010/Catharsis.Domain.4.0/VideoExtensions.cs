using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Video"/>.</para>
  /// </summary>
  /// <seealso cref="Video"/>
  public static class VideoExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of videos, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="videos">Source sequence of videos to filter.</param>
    /// <param name="category">Category of videos to search for.</param>
    /// <returns>Filtered sequence of videos with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="videos"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Video> Category(this IQueryable<Video> videos, VideosCategory category)
    {
      Assertion.NotNull(videos);

      return category != null ? videos.Where(video => video.Category.Id == category.Id) : videos.Where(video => video.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of videos, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="videos">Source sequence of videos to filter.</param>
    /// <param name="category">Category of videos to search for.</param>
    /// <returns>Filtered sequence of videos with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="videos"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Video> Category(this IEnumerable<Video> videos, VideosCategory category)
    {
      Assertion.NotNull(videos);

      return category != null ? videos.Where(video => video != null && video.Category.Equals(category)) : videos.Where(video => video != null && video.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of videos, leaving those with specified bitrate.</para>
    /// </summary>
    /// <param name="videos">Source sequence of videos to filter.</param>
    /// <param name="bitrate">Bitrate of videos to search for.</param>
    /// <returns>Filtered sequence of videos with specified bitrate.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="videos"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Video> Bitrate(this IQueryable<Video> videos, short bitrate)
    {
      Assertion.NotNull(videos);

      return videos.Where(video => video.Bitrate == bitrate);
    }

    /// <summary>
    ///   <para>Filters sequence of videos, leaving those with specified bitrate.</para>
    /// </summary>
    /// <param name="videos">Source sequence of videos to filter.</param>
    /// <param name="bitrate">Bitrate of videos to search for.</param>
    /// <returns>Filtered sequence of videos with specified bitrate.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="videos"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Video> Bitrate(this IEnumerable<Video> videos, short bitrate)
    {
      Assertion.NotNull(videos);

      return videos.Where(video => video != null && video.Bitrate == bitrate);
    }

    /// <summary>
    ///   <para>Filters sequence of videos, leaving those with duration in specified range.</para>
    /// </summary>
    /// <param name="videos">Source sequence of videos to filter.</param>
    /// <param name="from">Lower border of duration range.</param>
    /// <param name="to">Upper border of duration range.</param>
    /// <returns>Filtered sequence of videos with duration ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="videos"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Video> Duration(this IQueryable<Video> videos, long? from = null, long? to = null)
    {
      Assertion.NotNull(videos);

      if (from != null)
      {
        videos = videos.Where(video => video.Duration >= from.Value);
      }

      if (to != null)
      {
        videos = videos.Where(video => video.Duration <= to.Value);
      }

      return videos;
    }

    /// <summary>
    ///   <para>Filters sequence of videos, leaving those with duration in specified range.</para>
    /// </summary>
    /// <param name="videos">Source sequence of videos to filter.</param>
    /// <param name="from">Lower border of duration range.</param>
    /// <param name="to">Upper border of duration range.</param>
    /// <returns>Filtered sequence of videos with duration ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="videos"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Video> Duration(this IEnumerable<Video> videos, long? from = null, long? to = null)
    {
      Assertion.NotNull(videos);

      if (from != null)
      {
        videos = videos.Where(video => video != null && video.Duration >= from.Value);
      }

      if (to != null)
      {
        videos = videos.Where(video => video != null && video.Duration <= to.Value);
      }

      return videos;
    }
  }
}