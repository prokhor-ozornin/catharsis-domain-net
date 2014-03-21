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
    public void Attributes()
    {
      this.TestDescription("Active", "DateCreated", "Email", "ExpiredOn", "LastUpdated", "Token");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var subscription = new Subscription();
      Assert.Equal(@"{{""Id"":0,""Active"":true,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Token"":""{2}""}}".FormatSelf(subscription.DateCreated.ISO(), subscription.LastUpdated.ISO(), subscription.Token), subscription.Json());

      subscription = new Subscription("email");
      Assert.Equal(@"{{""Id"":0,""Active"":true,""DateCreated"":""{0}"",""Email"":""email"",""LastUpdated"":""{1}"",""Token"":""{2}""}}".FormatSelf(subscription.DateCreated.ISO(), subscription.LastUpdated.ISO(), subscription.Token), subscription.Json());
      Assert.Equal(subscription, subscription.Json().Json<Subscription>());

      subscription = new Subscription("email", DateTime.MinValue) { Id = 1 };
      Assert.Equal(@"{{""Id"":1,""Active"":true,""DateCreated"":""{0}"",""Email"":""email"",""ExpiredOn"":""{1}"",""LastUpdated"":""{2}"",""Token"":""{3}""}}".FormatSelf(subscription.DateCreated.ISO(), DateTime.MinValue.ISO(), subscription.LastUpdated.ISO(), subscription.Token), subscription.Json());
      Assert.Equal(subscription, subscription.Json().Json<Subscription>());
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
      Assert.True(subscription.DateCreated >= DateTime.MinValue && subscription.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, subscription.Id);
      Assert.Null(subscription.Email);
      Assert.Null(subscription.ExpiredOn);
      Assert.True(subscription.LastUpdated >= DateTime.MinValue && subscription.LastUpdated <= DateTime.UtcNow);
      Assert.NotNull(subscription.Token);

      Assert.Throws<ArgumentNullException>(() => new Subscription(null));
      Assert.Throws<ArgumentException>(() => new Subscription(string.Empty));
      subscription = new Subscription("email", DateTime.MaxValue);
      Assert.True(subscription.Active);
      Assert.True(subscription.DateCreated >= DateTime.MinValue && subscription.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, subscription.Id);
      Assert.Equal("email", subscription.Email);
      Assert.True(subscription.LastUpdated >= DateTime.MinValue && subscription.LastUpdated <= DateTime.UtcNow);
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
    ///   <para>Performs testing of <see cref="Subscription.DateCreated"/> property.</para>
    /// </summary>
    [Fact]
    public void DateCreated_Property()
    {
      Assert.Equal(DateTime.MinValue, new Subscription { DateCreated = DateTime.MinValue }.DateCreated);
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
    ///   <para>Performs testing of <see cref="Subscription.ExpiredOn"/> property.</para>
    /// </summary>
    [Fact]
    public void ExpiredOn_Property()
    {
      Assert.Equal(DateTime.MinValue, new Subscription { ExpiredOn = DateTime.MinValue }.ExpiredOn);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.LastUpdated"/> property.</para>
    /// </summary>
    [Fact]
    public void LastUpdated_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Subscription { LastUpdated = DateTime.MaxValue }.LastUpdated);
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
      this.TestCompareTo("DateCreated", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Subscription.Equals(Subscription)"/></description></item>
    ///     <item><description><see cref="Subscription.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Email", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Subscription.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Email", "first", "second");
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