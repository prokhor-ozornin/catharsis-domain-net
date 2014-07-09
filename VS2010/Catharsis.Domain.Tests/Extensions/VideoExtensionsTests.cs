using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VideoExtensions"/>.</para>
  /// </summary>
  public sealed class VideoExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="VideoExtensions.Category(IQueryable{Video}, VideosCategory)"/></description></item>
    ///     <item><description><see cref="VideoExtensions.Category(IEnumerable{Video}, VideosCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Video>) null).Category(new VideosCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Video>)null).Category(new VideosCategory()));

      Assert.False(Enumerable.Empty<Video>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Video>().Category(null).Any());

      Assert.False(Enumerable.Empty<Video>().AsQueryable().Category(new VideosCategory()).Any());
      Assert.False(Enumerable.Empty<Video>().Category(new VideosCategory()).Any());

      Assert.Equal(1, new[] { new Video { Category = new VideosCategory { Id = 1 } }, new Video { Category = new VideosCategory { Id = 2 } } }.AsQueryable().Category(new VideosCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Video { Category = new VideosCategory { Name = "first" } }, null, new Video { Category = new VideosCategory { Name = "second" } } }.Category(new VideosCategory { Name = "first" }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="VideoExtensions.Bitrate(IQueryable{Video}, short)"/></description></item>
    ///     <item><description><see cref="VideoExtensions.Bitrate(IEnumerable{Video}, short)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Bitrate_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Video>) null).Bitrate(0));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Video>)null).Bitrate(0));

      Assert.False(Enumerable.Empty<Video>().AsQueryable().Bitrate(0).Any());
      Assert.False(Enumerable.Empty<Video>().Bitrate(0).Any());

      Assert.Equal(1, new[] { new Video { Bitrate = 1 }, new Video { Bitrate = 2 } }.Bitrate(1).Count());
      Assert.Equal(1, new[] { null, new Video { Bitrate = 1 }, null, new Video { Bitrate = 2 } }.Bitrate(1).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="VideoExtensions.Duration(IQueryable{Video}, long?, long?)"/></description></item>
    ///     <item><description><see cref="VideoExtensions.Duration(IEnumerable{Video}, long?, long?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Duration_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Video>) null).Duration());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Video>)null).Duration());

      Assert.False(Enumerable.Empty<Video>().AsQueryable().Duration(0, 0).Any());
      Assert.False(Enumerable.Empty<Video>().Duration(0, 0).Any());

      var videos = new[] { null, new Video { Duration = 1 }, null, new Video { Duration = 2 } };
      Assert.False(videos.Duration(0, 0).Any());
      Assert.Equal(1, videos.Duration(0, 1).Count());
      Assert.Equal(1, videos.Duration(1, 1).Count());
      Assert.Equal(2, videos.Duration(1, 2).Count());
      Assert.Equal(1, videos.Duration(2, 3).Count());
      Assert.False(videos.Duration(3, 3).Any());
    }
  }
}