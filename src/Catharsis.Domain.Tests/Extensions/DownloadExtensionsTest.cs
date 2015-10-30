using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class DownloadExtensionsTests
  {
    [Fact]
    public void downloads_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Download>)null).Downloads());

      var downloads = new[] { new Download { Downloads = 1 }, new Download { Downloads = 2 } }.AsQueryable();
      Assert.Equal(2, downloads.Downloads().Count());
      Assert.Equal(2, downloads.Downloads(0).Count());
      Assert.Empty(downloads.Downloads(3));
      Assert.Equal(1, downloads.Downloads(0, 1).Count());
      Assert.Equal(2, downloads.Downloads(1, 2).Count());
      Assert.Empty(downloads.Downloads(to: 0));
      Assert.Equal(1, downloads.Downloads(to: 1).Count());
      Assert.Equal(2, downloads.Downloads(to: 3).Count());
    }

    [Fact]
    public void downloads_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Download>)null).Downloads());

      var downloads = new[] { null, new Download(), new Download { Downloads = 1 }, new Download { Downloads = 2 } };
      Assert.Equal(3, downloads.Downloads().Count());
      Assert.Equal(2, downloads.Downloads(0).Count());
      Assert.Empty(downloads.Downloads(3));
      Assert.Equal(1, downloads.Downloads(0, 1).Count());
      Assert.Equal(2, downloads.Downloads(1, 2).Count());
      Assert.Empty(downloads.Downloads(to: 0));
      Assert.Equal(1, downloads.Downloads(to: 1).Count());
      Assert.Equal(2, downloads.Downloads(to: 3).Count());
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Download>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Download[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Download[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Download { Name = "First" }, new Download { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Download>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Download[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Download[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new Download(), new Download { Name = "First" }, new Download { Name = "Second" } }.Name("f").Count());
    }
  }
}