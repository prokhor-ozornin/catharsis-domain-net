using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="SongExtensions"/>.</para>
  /// </summary>
  public sealed class SongExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SongExtensions.Album(IQueryable{Song}, SongsAlbum)"/></description></item>
    ///     <item><description><see cref="SongExtensions.Album(IEnumerable{Song}, SongsAlbum)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Album_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Song>) null).Album(new SongsAlbum()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Song>)null).Album(new SongsAlbum()));

      Assert.False(Enumerable.Empty<Song>().AsQueryable().Album(null).Any());
      Assert.False(Enumerable.Empty<Song>().Album(null).Any());

      Assert.False(Enumerable.Empty<Song>().AsQueryable().Album(new SongsAlbum()).Any());
      Assert.False(Enumerable.Empty<Song>().Album(new SongsAlbum()).Any());
      
      Assert.Equal(1, new[] { new Song { Album = new SongsAlbum { Id = 1 } }, new Song { Album = new SongsAlbum { Id = 2 } } }.AsQueryable().Album(new SongsAlbum { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Song { Album = new SongsAlbum { Name = "first" } }, null, new Song { Album = new SongsAlbum { Name = "second" } } }.Album(new SongsAlbum { Name = "first" }).Count());
    }
  }
}