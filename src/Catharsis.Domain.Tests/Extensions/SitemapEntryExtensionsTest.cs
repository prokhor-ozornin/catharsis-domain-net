using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class SitemapEntryExtensionsTests
  {
    [Fact]
    public void change_frequency_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<SitemapEntry>)null).ChangeFrequency(SitemapChangeFrequency.Daily));

      Assert.Equal(1, new[] { new SitemapEntry { ChangeFrequency = SitemapChangeFrequency.Always }, new SitemapEntry { ChangeFrequency = SitemapChangeFrequency.Daily } }.AsQueryable().ChangeFrequency(SitemapChangeFrequency.Daily).Count());
    }

    [Fact]
    public void change_frequency_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<SitemapEntry>)null).ChangeFrequency(SitemapChangeFrequency.Daily));

      Assert.Single(new[] { null, new SitemapEntry(), new SitemapEntry { ChangeFrequency = SitemapChangeFrequency.Always }, new SitemapEntry { ChangeFrequency = SitemapChangeFrequency.Daily } }.ChangeFrequency(SitemapChangeFrequency.Daily));
    }

    [Fact]
    public void date_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<SitemapEntry>)null).Date());

      var entries = new[] { new SitemapEntry { Date = new DateTime(2000, 1, 1) }, new SitemapEntry { Date = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, entries.Date().Count());
      Assert.Equal(2, entries.Date(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entries.Date(new DateTime(2000, 1, 3)));
      Assert.Equal(1, entries.Date(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entries.Date(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entries.Date(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, entries.Date(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entries.Date(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void date_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<SitemapEntry>)null).Date());

      var entries = new[] { null, new SitemapEntry(), new SitemapEntry { Date = new DateTime(2000, 1, 1) }, new SitemapEntry { Date = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, entries.Date().Count());
      Assert.Equal(2, entries.Date(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entries.Date(new DateTime(2000, 1, 3)));
      Assert.Single(entries.Date(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)));
      Assert.Equal(2, entries.Date(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entries.Date(to: new DateTime(1999, 12, 31)));
      Assert.Single(entries.Date(to: new DateTime(2000, 1, 1)));
      Assert.Equal(2, entries.Date(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void priority_queryable()
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
    public void priority_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Download>)null).Downloads());

      var downloads = new[] { null, new Download(), new Download { Downloads = 1 }, new Download { Downloads = 2 } };
      Assert.Equal(3, downloads.Downloads().Count());
      Assert.Equal(2, downloads.Downloads(0).Count());
      Assert.Empty(downloads.Downloads(3));
      Assert.Single(downloads.Downloads(0, 1));
      Assert.Equal(2, downloads.Downloads(1, 2).Count());
      Assert.Empty(downloads.Downloads(to: 0));
      Assert.Single(downloads.Downloads(to: 1));
      Assert.Equal(2, downloads.Downloads(to: 3).Count());
    }
  }
}