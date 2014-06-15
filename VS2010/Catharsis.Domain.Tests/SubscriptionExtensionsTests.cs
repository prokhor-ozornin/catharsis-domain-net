using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="SubscriptionExtensions"/>.</para>
  /// </summary>
  public sealed class SubscriptionExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SubscriptionExtensions.Active(IQueryable{Subscription})"/></description></item>
    ///     <item><description><see cref="SubscriptionExtensions.Active(IEnumerable{Subscription})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Active_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Subscription>) null).Active());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Subscription>)null).Active());

      Assert.False(Enumerable.Empty<Subscription>().AsQueryable().Active().Any());
      Assert.False(Enumerable.Empty<Subscription>().Active().Any());

      Assert.Equal(1, new[] { new Subscription { Active = true }, new Subscription { Active = false } }.AsQueryable().Active().Count());
      Assert.Equal(1, new[] { null, new Subscription { Active = true }, null, new Subscription { Active = false } }.Active().Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SubscriptionExtensions.Inactive(IQueryable{Subscription})"/></description></item>
    ///     <item><description><see cref="SubscriptionExtensions.Inactive(IEnumerable{Subscription})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Inactive_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Subscription>) null).Inactive());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Subscription>)null).Inactive());

      Assert.False(Enumerable.Empty<Subscription>().AsQueryable().Inactive().Any());
      Assert.False(Enumerable.Empty<Subscription>().Inactive().Any());

      Assert.Equal(1, new[] { new Subscription { Active = true }, new Subscription { Active = false } }.AsQueryable().Inactive().Count());
      Assert.Equal(1, new[] { null, new Subscription { Active = true }, null, new Subscription { Active = false } }.Inactive().Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SubscriptionExtensions.Token(IQueryable{Subscription}, string)"/></description></item>
    ///     <item><description><see cref="SubscriptionExtensions.Token(IEnumerable{Subscription}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Token_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Subscription>) null).Token("token"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Subscription>)null).Token("token"));

      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Subscription>().AsQueryable().Token(null));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Subscription>().Token(null));

      Assert.Equal("first", new[] { new Subscription { Token = "first" }, new Subscription { Token = "second" } }.AsQueryable().Token("first").Token);
      Assert.Equal("first", new[] { null, new Subscription { Token = "first" }, null, new Subscription { Token = "second" } }.Token("first").Token);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SubscriptionExtensions.Expired(IQueryable{Subscription})"/></description></item>
    ///     <item><description><see cref="SubscriptionExtensions.Expired(IEnumerable{Subscription})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Expired_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Subscription>)null).Expired());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Subscription>)null).Expired());

      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Subscription>().AsQueryable().Token(null));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Subscription>().Token(null));

      Assert.Equal(1, new[] { new Subscription { ExpiredOn = DateTime.MinValue }, new Subscription { ExpiredOn = DateTime.MaxValue } }.AsQueryable().Expired().Count());
      Assert.Equal(1, new[] { null, new Subscription { ExpiredOn = DateTime.MinValue }, null, new Subscription { ExpiredOn = DateTime.MaxValue } }.Expired().Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="SubscriptionExtensions.NonExpired(IQueryable{Subscription})"/></description></item>
    ///     <item><description><see cref="SubscriptionExtensions.NonExpired(IEnumerable{Subscription})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void NonExpired_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Subscription>)null).Expired());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Subscription>)null).Expired());

      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Subscription>().AsQueryable().Token(null));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Subscription>().Token(null));

      Assert.Equal(2, new[] { new Subscription(), new Subscription { ExpiredOn = DateTime.MinValue }, new Subscription { ExpiredOn = DateTime.MaxValue } }.AsQueryable().NonExpired().Count());
      Assert.Equal(2, new[] { null, new Subscription(), null, new Subscription { ExpiredOn = DateTime.MinValue }, null, new Subscription { ExpiredOn = DateTime.MaxValue } }.NonExpired().Count());
    }
  }
}