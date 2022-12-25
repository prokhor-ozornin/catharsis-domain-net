using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PushNotification"/>.</para>
/// </summary>
public sealed class PushNotificationTest : EntityTest<PushNotification>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.Payload"/> property.</para>
  /// </summary>
  [Fact]
  public void Payload_Property()
  {
    new PushNotification { Payload = Guid.Empty.ToString() }.Payload.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.Provider"/> property.</para>
  /// </summary>
  [Fact]
  public void Provider_Property()
  {
    new PushNotification { Provider = PushNotification.ProviderType.Microsoft }.Provider.Should().Be(PushNotification.ProviderType.Microsoft);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.Delivered"/> property.</para>
  /// </summary>
  [Fact]
  public void Delivered_Property()
  {
    new PushNotification { Delivered = true }.Delivered.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.Ttl"/> property.</para>
  /// </summary>
  [Fact]
  public void Ttl_Property()
  {
    new PushNotification { Ttl = long.MaxValue }.Ttl.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.Devices"/> property.</para>
  /// </summary>
  [Fact]
  public void Devices_Property()
  {
    var devices = new HashSet<string>();
    new PushNotification { Devices = devices }.Devices.Should().BeSameAs(devices);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="PushNotification()"/>
  [Fact]
  public void Constructors()
  {
    var notification = new PushNotification();

    notification.Id.Should().BeNull();
    notification.Uuid.Should().NotBeNull();
    notification.Version.Should().BeNull();
    notification.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    notification.UpdatedOn.Should().BeNull();

    notification.Payload.Should().BeNull();
    notification.Provider.Should().BeNull();
    notification.Delivered.Should().BeNull();
    notification.Ttl.Should().BeNull();
    notification.Devices.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.CompareTo(PushNotification)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(PushNotification.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="PushNotification.Equals(PushNotification)"/></description></item>
  ///     <item><description><see cref="PushNotification.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(PushNotification.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestEquality(nameof(PushNotification.Provider), PushNotification.ProviderType.Apple, PushNotification.ProviderType.Google);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode("CreatedOn", DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestHashCode("Provider", PushNotification.ProviderType.Apple, PushNotification.ProviderType.Google);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PushNotification.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new PushNotification().ToString().Should().BeEmpty();
    new PushNotification { Payload = string.Empty }.ToString().Should().BeEmpty();
    new PushNotification { Payload = " " }.ToString().Should().BeEmpty();
    new PushNotification { Payload = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}