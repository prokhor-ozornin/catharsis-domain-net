using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="SongsAlbum"/>.</para>
  /// </summary>
  /// <seealso cref="SongsAlbum"/>
  public static class SongsAlbumExtensions
  {
    /// <summary>
    ///   <para>Sorts sequence of songs albums, leaving those published in specified time span.</para>
    /// </summary>
    /// <param name="albums">Source sequence of albums to filters.</param>
    /// <param name="from">Lower bound of publication date range.</param>
    /// <param name="to">Upper bound of publication date range.</param>
    /// <returns>Filtered sequence of songs albums with publication date ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="albums"/> is a <c>null</c> reference.</exception>
    public static IQueryable<SongsAlbum> PublishedOn(this IQueryable<SongsAlbum> albums, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(albums);

      if (from != null)
      {
        albums = albums.Where(album => album.PublishedOn >= from.Value);
      }

      if (to != null)
      {
        albums = albums.Where(album => album.PublishedOn <= to.Value);
      }

      return albums;
    }

    /// <summary>
    ///   <para>Sorts sequence of songs albums, leaving those published in specified time span.</para>
    /// </summary>
    /// <param name="albums">Source sequence of albums to filters.</param>
    /// <param name="from">Lower bound of publication date range.</param>
    /// <param name="to">Upper bound of publication date range.</param>
    /// <returns>Filtered sequence of songs albums with publication date ranging inclusively from <paramref name="from"/> to <paramref name="to"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="albums"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<SongsAlbum> PublishedOn(this IEnumerable<SongsAlbum> albums, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(albums);

      if (from != null)
      {
        albums = albums.Where(album => album != null && album.PublishedOn >= from.Value);
      }

      if (to != null)
      {
        albums = albums.Where(album => album != null && album.PublishedOn <= to.Value);
      }

      return albums;
    }
  }
}