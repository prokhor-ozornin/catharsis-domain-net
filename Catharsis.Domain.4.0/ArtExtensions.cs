using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Art"/>.</para>
  /// </summary>
  /// <seealso cref="Art"/>
  public static class ArtExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of arts, leaving those belonging to specified album.</para>
    /// </summary>
    /// <param name="arts">Source sequence of arts to filter.</param>
    /// <param name="album">Arts album to search for.</param>
    /// <returns>Filtered sequence of arts in specified album.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="arts"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Art> Album(this IQueryable<Art> arts, ArtsAlbum album)
    {
      Assertion.NotNull(arts);

      return album != null ? arts.Where(art => art.Album.Id == album.Id) : arts.Where(art => art.Album == null);
    }

    /// <summary>
    ///   <para>Filters sequence of arts, leaving those belonging to specified album.</para>
    /// </summary>
    /// <param name="arts">Source sequence of arts to filter.</param>
    /// <param name="album">Arts album to search for.</param>
    /// <returns>Filtered sequence of arts in specified album.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="arts"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Art> Album(this IEnumerable<Art> arts, ArtsAlbum album)
    {
      Assertion.NotNull(arts);

      return album != null ? arts.Where(art => art != null && art.Album.Equals(album)) : arts.Where(art => art != null && art.Album == null);
    }

    /// <summary>
    ///   <para>Filters sequence of arts, leaving those belonging to specified album.</para>
    /// </summary>
    /// <param name="arts">Source sequence of arts to filter.</param>
    /// <param name="material">Material to search for.</param>
    /// <returns>Filtered sequence of arts with specified material.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="arts"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Art> Material(this IQueryable<Art> arts, string material)
    {
      Assertion.NotNull(arts);

      return arts.Where(art => art.Material == material);
    }

    /// <summary>
    ///   <para>Filters sequence of arts, leaving those belonging to specified album.</para>
    /// </summary>
    /// <param name="arts">Source sequence of arts to filter.</param>
    /// <param name="material">Material to search for.</param>
    /// <returns>Filtered sequence of arts with specified material.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="arts"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Art> Material(this IEnumerable<Art> arts, string material)
    {
      Assertion.NotNull(arts);

      return arts.Where(art => art != null && art.Material == material);
    }
  }
}