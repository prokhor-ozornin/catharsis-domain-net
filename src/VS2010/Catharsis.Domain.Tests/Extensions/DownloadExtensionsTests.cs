using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DownloadExtensions"/>.</para>
  /// </summary>
  public sealed class DownloadExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DownloadExtensions.Category(IQueryable{Download}, DownloadsCategory)"/></description></item>
    ///     <item><description><see cref="DownloadExtensions.Category(IEnumerable{Download}, DownloadsCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Download>) null).Category(new DownloadsCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Download>)null).Category(new DownloadsCategory()));

      Assert.False(Enumerable.Empty<Download>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Download>().Category(null).Any());

      Assert.False(Enumerable.Empty<Download>().AsQueryable().Category(new DownloadsCategory()).Any());
      Assert.False(Enumerable.Empty<Download>().Category(new DownloadsCategory()).Any());
      
      Assert.Equal(1, new[] { new Download { Category = new DownloadsCategory { Id = 1 } }, new Download { Category = new DownloadsCategory { Id = 2 } } }.AsQueryable().Category(new DownloadsCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Download { Category = new DownloadsCategory { Id = 1 } }, new Download { Category = new DownloadsCategory { Id = 2 } } }.Category(new DownloadsCategory { Id = 1 }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DownloadExtensions.Downloads(IQueryable{Download}, long?, long?)"/></description></item>
    ///     <item><description><see cref="DownloadExtensions.Downloads(IEnumerable{Download}, long?, long?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Downloads_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Download>) null).Downloads());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Download>)null).Downloads());

      Assert.False(Enumerable.Empty<Download>().AsQueryable().Downloads().Any());
      Assert.False(Enumerable.Empty<Download>().AsQueryable().Downloads(0, 0).Any());
      Assert.False(Enumerable.Empty<Download>().Downloads().Any());
      Assert.False(Enumerable.Empty<Download>().Downloads(0, 0).Any());

      var downloads = new[] { null, new Download { Downloads = 1 }, null, new Download { Downloads = 2 } };
      Assert.False(downloads.Downloads(0, 0).Any());
      Assert.Equal(1, downloads.Downloads(0, 1).Count());
      Assert.Equal(1, downloads.Downloads(1, 1).Count());
      Assert.Equal(2, downloads.Downloads(1, 2).Count());
      Assert.Equal(1, downloads.Downloads(2, 3).Count());
      Assert.False(downloads.Downloads(3, 3).Any());
    }
  }
}