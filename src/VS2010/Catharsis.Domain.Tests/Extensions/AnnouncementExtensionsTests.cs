using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AnnouncementExtensions"/>.</para>
  /// </summary>
  public sealed class AnnouncementExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="AnnouncementExtensions.Category(IQueryable{Announcement}, AnnouncementsCategory)"/></description></item>
    ///     <item><description><see cref="AnnouncementExtensions.Category(IEnumerable{Announcement}, AnnouncementsCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Announcement>) null).Category(new AnnouncementsCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Announcement>)null).Category(new AnnouncementsCategory()));

      Assert.False(Enumerable.Empty<Announcement>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Announcement>().Category(null).Any());

      Assert.False(Enumerable.Empty<Announcement>().AsQueryable().Category(new AnnouncementsCategory()).Any());
      Assert.False(Enumerable.Empty<Announcement>().Category(new AnnouncementsCategory()).Any());
      
      Assert.Equal(1, new[] { new Announcement { Category = new AnnouncementsCategory { Id = 1 } }, new Announcement { Category = new AnnouncementsCategory { Id = 2 } } }.AsQueryable().Category(new AnnouncementsCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Announcement { Category = new AnnouncementsCategory { Id = 1 } }, new Announcement { Category = new AnnouncementsCategory { Id = 2 } } }.Category(new AnnouncementsCategory { Id = 1 }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="AnnouncementExtensions.Currency(IQueryable{Announcement}, string)"/></description></item>
    ///     <item><description><see cref="AnnouncementExtensions.Currency(IEnumerable{Announcement}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Currency_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Announcement>) null).Currency("currency"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Announcement>)null).Currency("currency"));

      Assert.False(Enumerable.Empty<Announcement>().AsQueryable().Currency(null).Any());
      Assert.False(Enumerable.Empty<Announcement>().Currency(null).Any());

      Assert.Equal(1, new[] { new Announcement { Currency = "first" }, new Announcement { Currency = "second" } }.AsQueryable().Currency("first").Count());
      Assert.Equal(1, new[] { null, new Announcement { Currency = "first" }, null, new Announcement { Currency = "second" } }.Currency("first").Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="AnnouncementExtensions.Price(IQueryable{Announcement}, decimal?, decimal?)"/></description></item>
    ///     <item><description><see cref="AnnouncementExtensions.Price(IEnumerable{Announcement}, decimal?, decimal?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Price_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Announcement>) null).Price());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Announcement>)null).Price());

      Assert.False(Enumerable.Empty<Announcement>().AsQueryable().Price().Any());
      Assert.False(Enumerable.Empty<Announcement>().AsQueryable().Price(0, 0).Any());
      
      Assert.False(Enumerable.Empty<Announcement>().Price().Any());
      Assert.False(Enumerable.Empty<Announcement>().Price(0, 0).Any());

      var queryable = new[] { new Announcement { Price = 1 }, new Announcement { Price = 2 } }.AsQueryable();
      Assert.False(queryable.Price(0, 0).Any());
      Assert.Equal(1, queryable.Price(0, 1).Count());
      Assert.Equal(1, queryable.Price(1, 1).Count());
      Assert.Equal(2, queryable.Price(1, 2).Count());
      Assert.Equal(1, queryable.Price(2, 3).Count());
      Assert.False(queryable.Price(3, 3).Any());

      var enumerable = new[] { null, new Announcement { Price = 1 }, null, new Announcement { Price = 2 } };
      Assert.False(enumerable.Price(0, 0).Any());
      Assert.Equal(1, enumerable.Price(0, 1).Count());
      Assert.Equal(1, enumerable.Price(1, 1).Count());
      Assert.Equal(2, enumerable.Price(1, 2).Count());
      Assert.Equal(1, enumerable.Price(2, 3).Count());
      Assert.False(enumerable.Price(3, 3).Any());
    }
  }
}