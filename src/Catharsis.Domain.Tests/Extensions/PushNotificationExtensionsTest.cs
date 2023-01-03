using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PushNotificationExtensions"/>.</para>
/// </summary>
public sealed class PushNotificationExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotificationExtensions.Delivered(IQueryable{PushNotification}, bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Delivered_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<PushNotification>) null).Delivered(true)).ThrowExactly<ArgumentNullException>();

    new[] {new PushNotification {Delivered = false}, new PushNotification {Delivered = true}}.AsQueryable().Delivered(true).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotificationExtensions.Delivered(IEnumerable{PushNotification}, bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Delivered_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<PushNotification>) null).Delivered(true)).ThrowExactly<ArgumentNullException>();

    new[] {new PushNotification {Delivered = false}, new PushNotification {Delivered = true}}.Delivered(true).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotificationExtensions.Provider(IQueryable{PushNotification}, PushNotification.ProviderType?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Provider_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<PushNotification>) null).Provider(PushNotification.ProviderType.Apple)).ThrowExactly<ArgumentNullException>();

    new[] {new PushNotification {Provider = PushNotification.ProviderType.Apple}, new PushNotification {Provider = PushNotification.ProviderType.Google}}.AsQueryable().Provider(PushNotification.ProviderType.Google).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotificationExtensions.Provider(IEnumerable{PushNotification}, PushNotification.ProviderType?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Provider_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<PushNotification>) null).Provider(PushNotification.ProviderType.Apple)).ThrowExactly<ArgumentNullException>();

    new[] {null, new PushNotification(), new PushNotification {Provider = PushNotification.ProviderType.Apple}, new PushNotification {Provider = PushNotification.ProviderType.Google}}.Provider(PushNotification.ProviderType.Google).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotificationExtensions.Ttl(IQueryable{PushNotification}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ttl_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<PushNotification>) null).Ttl()).ThrowExactly<ArgumentNullException>();

    var notifications = new[] {new PushNotification {Ttl = 1}, new PushNotification {Ttl = 2}}.AsQueryable();
    notifications.Ttl().Should().HaveCount(2);
    notifications.Ttl(0).Should().HaveCount(2);
    notifications.Ttl(3).Should().BeEmpty();
    notifications.Ttl(0, 1).Should().ContainSingle();
    notifications.Ttl(1, 2).Should().HaveCount(2);
    notifications.Ttl(to: 0).Should().BeEmpty();
    notifications.Ttl(to: 1).Should().ContainSingle();
    notifications.Ttl(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotificationExtensions.Ttl(IEnumerable{PushNotification}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ttl_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<PushNotification>) null).Ttl()).ThrowExactly<ArgumentNullException>();

    var notifications = new[] {null, new PushNotification(), new PushNotification {Ttl = 1}, new PushNotification {Ttl = 2}};
    notifications.Ttl().Should().HaveCount(3);
    notifications.Ttl(0).Should().HaveCount(2);
    notifications.Ttl(3).Should().BeEmpty();
    notifications.Ttl(0, 1).Should().ContainSingle();
    notifications.Ttl(1, 2).Should().HaveCount(2);
    notifications.Ttl(to: 0).Should().BeEmpty();
    notifications.Ttl(to: 1).Should().ContainSingle();
    notifications.Ttl(to: 3).Should().HaveCount(2);
  }
}