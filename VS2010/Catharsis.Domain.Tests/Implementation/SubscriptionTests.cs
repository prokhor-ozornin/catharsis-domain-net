using System;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Subscription"/>.</para>
  /// </summary>
  public sealed class SubscriptionTests : EntityUnitTests<Subscription>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Active", "CreatedAt", "Email", "ExpiredAt", "UpdatedAt", "Token");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var subscription = new Subscription();
      this.TestJson(subscription, new { Id = 0, Active = true, CreatedAt = subscription.CreatedAt.ISO8601(), Token = subscription.Token, UpdatedAt = subscription.UpdatedAt.ISO8601() });

      subscription = new Subscription("email");
      this.TestJson(subscription, new { Id = 0, Active = true, CreatedAt = subscription.CreatedAt.ISO8601(), Email = "email", Token = subscription.Token, UpdatedAt = subscription.UpdatedAt.ISO8601() });

      subscription = new Subscription("email", DateTime.MinValue)
      {
        Id = 1
      };
      this.TestJson(subscription, new { Id = 1, Active = true, CreatedAt = subscription.CreatedAt.ISO8601(), Email = "email", ExpiredAt = DateTime.MinValue.ISO8601(), Token = subscription.Token, UpdatedAt = subscription.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var subscription = new Subscription();
      this.TestXml(subscription, new { Id = 0, Active = true, CreatedAt = subscription.CreatedAt, UpdatedAt = subscription.UpdatedAt, Token = subscription.Token });

      subscription = new Subscription("email");
      this.TestXml(subscription, new { Id = 0, Active = true, CreatedAt = subscription.CreatedAt, Email = "email", UpdatedAt = subscription.UpdatedAt, Token = subscription.Token });

      subscription = new Subscription("email", DateTime.MinValue)
      {
        Id = 1
      };
      this.TestXml(subscription, new { Id = 1, Active = true, CreatedAt = subscription.CreatedAt, Email = "email", ExpiredAt = DateTime.MinValue, UpdatedAt = subscription.UpdatedAt, Token = subscription.Token });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Subscription()"/>
    /// <seealso cref="Subscription(string, DateTime?)"/>
    [Fact]
    public void Constructors()
    {
      var subscription = new Subscription();
      Assert.True(subscription.Active);
      Assert.True(subscription.CreatedAt >= DateTime.MinValue && subscription.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, subscription.Id);
      Assert.Null(subscription.Email);
      Assert.Null(subscription.ExpiredAt);
      Assert.True(subscription.UpdatedAt >= DateTime.MinValue && subscription.UpdatedAt <= DateTime.UtcNow);
      Assert.NotNull(subscription.Token);

      Assert.Throws<ArgumentNullException>(() => new Subscription(null));
      Assert.Throws<ArgumentException>(() => new Subscription(string.Empty));
      subscription = new Subscription("email", DateTime.MaxValue);
      Assert.True(subscription.Active);
      Assert.True(subscription.CreatedAt >= DateTime.MinValue && subscription.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, subscription.Id);
      Assert.Equal("email", subscription.Email);
      Assert.True(subscription.UpdatedAt >= DateTime.MinValue && subscription.UpdatedAt <= DateTime.UtcNow);
      Assert.NotNull(subscription.Token);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new Subscription { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.CreatedAt"/> property.</para>
    /// </summary>
    [Fact]
    public void CreatedAt_Property()
    {
      Assert.Equal(DateTime.MinValue, new Subscription { CreatedAt = DateTime.MinValue }.CreatedAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.Email"/> property.</para>
    /// </summary>
    [Fact]
    public void Email_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Subscription { Email = null });
      Assert.Throws<ArgumentException>(() => new Subscription { Email = string.Empty });
      
      Assert.Equal("email", new Subscription { Email = "email" }.Email);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.ExpiredAt"/> property.</para>
    /// </summary>
    [Fact]
    public void ExpiredOn_Property()
    {
      Assert.Equal(DateTime.MinValue, new Subscription { ExpiredAt = DateTime.MinValue }.ExpiredAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.UpdatedAt"/> property.</para>
    /// </summary>
    [Fact]
    public void UpdatedAt_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Subscription { UpdatedAt = DateTime.MaxValue }.UpdatedAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.Token"/> property.</para>
    /// </summary>
    [Fact]
    public void Token_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Subscription { Token = null });
      Assert.Throws<ArgumentException>(() => new Subscription { Token = string.Empty });
      
      Assert.Equal("token", new Subscription { Token = "token" }.Token);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.CompareTo(Subscription)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("CreatedAt", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("email", new Subscription { Email = "email" }.ToString());
    }
  }
}