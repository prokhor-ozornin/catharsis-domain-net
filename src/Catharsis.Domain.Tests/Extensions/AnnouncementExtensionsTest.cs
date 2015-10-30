using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AnnouncementExtensionsTest
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Announcement>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Announcement[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Announcement[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Announcement { Name = "First" }, new Announcement { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Announcement>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Announcement[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Announcement[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new Announcement(), new Announcement { Name = "First" }, new Announcement { Name = "Second" } }.Name("f").Count());
    }

    [Fact]
    public void price_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Announcement>) null).Price());

      var announcements = new[] { new Announcement { Price = 1 }, new Announcement { Price = 2 } }.AsQueryable();
      Assert.Equal(2, announcements.Price().Count());
      Assert.Equal(2, announcements.Price(0).Count());
      Assert.Empty(announcements.Price(3));
      Assert.Equal(1, announcements.Price(0, 1).Count());
      Assert.Equal(2, announcements.Price(1, 2).Count());
      Assert.Empty(announcements.Price(to: 0));
      Assert.Equal(1, announcements.Price(to: 1).Count());
      Assert.Equal(2, announcements.Price(to: 3).Count());
    }

    [Fact]
    public void price_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Announcement>)null).Price());

      var announcements = new[] { null, new Announcement(), new Announcement { Price = 1 }, new Announcement { Price = 2 } };
      Assert.Equal(3, announcements.Price().Count());
      Assert.Equal(2, announcements.Price(0).Count());
      Assert.Empty(announcements.Price(3));
      Assert.Equal(1, announcements.Price(0, 1).Count());
      Assert.Equal(2, announcements.Price(1, 2).Count());
      Assert.Empty(announcements.Price(to: 0));
      Assert.Equal(1, announcements.Price(to: 1).Count());
      Assert.Equal(2, announcements.Price(to: 3).Count());
    }
  }
}