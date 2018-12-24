using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class PushNotificationTest : EntityTest<PushNotification>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new PushNotification();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Delivered);
      Assert.Empty(fixture.Devices);
      Assert.Null(fixture.Payload);
      Assert.Null(fixture.Provider);
      Assert.Null(fixture.Ttl);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
      this.test_equals_and_hash_code("Provider", PushNotificationProvider.Apple, PushNotificationProvider.Google);
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new PushNotification().ToString());
      Assert.Empty(new PushNotification { Payload = string.Empty }.ToString());
      Assert.Empty(new PushNotification { Payload = " " }.ToString());
      Assert.Equal("payload", new PushNotification { Payload = " payload " }.ToString());
    }
  }
}