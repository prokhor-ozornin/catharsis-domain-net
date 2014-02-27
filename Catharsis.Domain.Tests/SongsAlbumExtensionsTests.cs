using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="SongsAlbumExtensions"/>.</para>
  /// </summary>
  public sealed class SongsAlbumExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SongsAlbumExtensions.PublishedOn(IQueryable{SongsAlbum}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="SongsAlbumExtensions.PublishedOn(IEnumerable{SongsAlbum}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void PublishedOn_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<SongsAlbum>)null).PublishedOn());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<SongsAlbum>)null).PublishedOn());

      Assert.False(Enumerable.Empty<SongsAlbum>().AsQueryable().PublishedOn().Any());
      Assert.False(Enumerable.Empty<SongsAlbum>().PublishedOn().Any());

      Assert.Equal(2, new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MinValue } }.AsQueryable().CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new SongsAlbum { PublishedOn = DateTime.MinValue }, new SongsAlbum { PublishedOn = DateTime.MinValue } }.CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
    }
  }
}