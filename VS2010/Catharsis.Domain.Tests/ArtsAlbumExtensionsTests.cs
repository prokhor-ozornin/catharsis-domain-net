using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ArtsAlbumExtensions"/>.</para>
  /// </summary>
  public sealed class ArtsAlbumExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ArtsAlbumExtensions.PublishedOn(IQueryable{ArtsAlbum}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="ArtsAlbumExtensions.PublishedOn(IEnumerable{ArtsAlbum}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void PublishedOn_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<ArtsAlbum>)null).PublishedOn());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<ArtsAlbum>)null).PublishedOn());

      Assert.False(Enumerable.Empty<ArtsAlbum>().AsQueryable().PublishedOn().Any());
      Assert.False(Enumerable.Empty<ArtsAlbum>().PublishedOn().Any());

      Assert.Equal(2, new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MinValue } }.AsQueryable().CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new ArtsAlbum { PublishedOn = DateTime.MinValue }, new ArtsAlbum { PublishedOn = DateTime.MinValue } }.CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
    }
  }
}