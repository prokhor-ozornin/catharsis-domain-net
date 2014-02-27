using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Song"/>.</para>
  ///   <seealso cref="Song"/>
  /// </summary>
  public static class SongExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of songs, leaving those belonging to specified album.</para>
    /// </summary>
    /// <param name="songs">Source sequence of songs to filter.</param>
    /// <param name="album">Album of songs to search for.</param>
    /// <returns>Filtered sequence of songs in specified album.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="songs"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Song> Album(this IQueryable<Song> songs, SongsAlbum album)
    {
      Assertion.NotNull(songs);

      return album != null ? songs.Where(song => song.Album.Id == album.Id) : songs.Where(song => song.Album == null);
    }

    /// <summary>
    ///   <para>Filters sequence of songs, leaving those belonging to specified album.</para>
    /// </summary>
    /// <param name="songs">Source sequence of songs to filter.</param>
    /// <param name="album">Album of songs to search for.</param>
    /// <returns>Filtered sequence of songs in specified album.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="songs"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Song> Album(this IEnumerable<Song> songs, SongsAlbum album)
    {
      Assertion.NotNull(songs);

      return album != null ? songs.Where(song => song != null && song.Album.Equals(album)) : songs.Where(song => song != null && song.Album == null);
    }
  }
}