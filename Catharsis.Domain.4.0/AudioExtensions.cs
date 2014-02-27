using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Audio"/>.</para>
  ///   <seealso cref="Audio"/>
  /// </summary>
  public static class AudioExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of audios, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="audios">Source sequence of audios to filter.</param>
    /// <param name="category">Category of audios to search for.</param>
    /// <returns>Filtered sequence of audios with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="audios"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Audio> Category(this IQueryable<Audio> audios, AudiosCategory category)
    {
      Assertion.NotNull(audios);

      return category != null ? audios.Where(audio => audio.Category.Id == category.Id) : audios.Where(audio => audio.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of audios, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="audios">Source sequence of audios to filter.</param>
    /// <param name="category">Category of audios to search for.</param>
    /// <returns>Filtered sequence of audios with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="audios"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Audio> Category(this IEnumerable<Audio> audios, AudiosCategory category)
    {
      Assertion.NotNull(audios);

      return category != null ? audios.Where(audio => audio != null && audio.Category.Equals(category)) : audios.Where(audio => audio.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of audios, leaving those with specified bitrate.</para>
    /// </summary>
    /// <param name="audios">Source sequence of audios to filter.</param>
    /// <param name="bitrate">Bitrate of audios to search for.</param>
    /// <returns>Filtered sequence of audios with specified bitrate.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="audios"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Audio> Bitrate(this IQueryable<Audio> audios, short bitrate)
    {
      Assertion.NotNull(audios);

      return audios.Where(audio => audio.Bitrate == bitrate);
    }

    /// <summary>
    ///   <para>Filters sequence of audios, leaving those with specified bitrate.</para>
    /// </summary>
    /// <param name="audios">Source sequence of audios to filter.</param>
    /// <param name="bitrate">Bitrate of audios to search for.</param>
    /// <returns>Filtered sequence of audios with specified bitrate.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="audios"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Audio> Bitrate(this IEnumerable<Audio> audios, short bitrate)
    {
      Assertion.NotNull(audios);

      return audios.Where(audio => audio != null && audio.Bitrate == bitrate);
    }

    /// <summary>
    ///   <para>Filters sequence of audios, leaving those with specified duration (in seconds).</para>
    /// </summary>
    /// <param name="audios">Source sequence of audios to filter.</param>
    /// <param name="from">Lower bound of duration.</param>
    /// <param name="to">Upper bound of duration.</param>
    /// <returns>Filtered sequence of audios with specified duration.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="audios"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Audio> Duration(this IQueryable<Audio> audios, long? from = null, long? to = null)
    {
      Assertion.NotNull(audios);

      if (from != null)
      {
        audios = audios.Where(audio => audio.Duration >= from.Value);
      }

      if (to != null)
      {
        audios = audios.Where(audio => audio.Duration <= to.Value);
      }

      return audios;
    }

    /// <summary>
    ///   <para>Filters sequence of audios, leaving those with specified duration (in seconds).</para>
    /// </summary>
    /// <param name="audios">Source sequence of audios to filter.</param>
    /// <param name="from">Lower bound of duration.</param>
    /// <param name="to">Upper bound of duration.</param>
    /// <returns>Filtered sequence of audios with specified duration.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="audios"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Audio> Duration(this IEnumerable<Audio> audios, long? from = null, long? to = null)
    {
      Assertion.NotNull(audios);

      if (from != null)
      {
        audios = audios.Where(audio => audio != null && audio.Duration >= from.Value);
      }

      if (to != null)
      {
        audios = audios.Where(audio => audio != null && audio.Duration <= to.Value);
      }

      return audios;
    }
  }
}