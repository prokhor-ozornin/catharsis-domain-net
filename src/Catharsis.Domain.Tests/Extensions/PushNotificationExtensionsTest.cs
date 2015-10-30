using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class PushNotificationExtensionsTest
  {
    [Fact]
    public void delivered_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<PushNotification>)null).Delivered(true));

      Assert.Equal(1, new[] { new PushNotification { Delivered = false }, new PushNotification { Delivered = true } }.AsQueryable().Delivered(true).Count());
    }

    [Fact]
    public void delivered_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<PushNotification>)null).Delivered(true));

      Assert.Equal(1, new[] { new PushNotification { Delivered = false }, new PushNotification { Delivered = true } }.Delivered(true).Count());
    }

    [Fact]
    public void provider_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<PushNotification>)null).Provider(PushNotificationProvider.Apple));

      Assert.Equal(1, new[] { new PushNotification { Provider = PushNotificationProvider.Apple }, new PushNotification { Provider = PushNotificationProvider.Google } }.AsQueryable().Provider(PushNotificationProvider.Google).Count());
    }

    [Fact]
    public void provider_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<PushNotification>)null).Provider(PushNotificationProvider.Apple));

      Assert.Equal(1, new[] { null, new PushNotification(), new PushNotification { Provider = PushNotificationProvider.Apple }, new PushNotification { Provider = PushNotificationProvider.Google } }.Provider(PushNotificationProvider.Google).Count());
    }

    [Fact]
    public void ttl_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<PushNotification>)null).Ttl());

      var notifications = new[] { new PushNotification { Ttl = 1 }, new PushNotification { Ttl = 2 } }.AsQueryable();
      Assert.Equal(2, notifications.Ttl().Count());
      Assert.Equal(2, notifications.Ttl(0).Count());
      Assert.Empty(notifications.Ttl(3));
      Assert.Equal(1, notifications.Ttl(0, 1).Count());
      Assert.Equal(2, notifications.Ttl(1, 2).Count());
      Assert.Empty(notifications.Ttl(to: 0));
      Assert.Equal(1, notifications.Ttl(to: 1).Count());
      Assert.Equal(2, notifications.Ttl(to: 3).Count());
    }

    [Fact]
    public void ttl_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<PushNotification>)null).Ttl());

      var notifications = new[] { null, new PushNotification(), new PushNotification { Ttl = 1 }, new PushNotification { Ttl = 2 } };
      Assert.Equal(3, notifications.Ttl().Count());
      Assert.Equal(2, notifications.Ttl(0).Count());
      Assert.Empty(notifications.Ttl(3));
      Assert.Equal(1, notifications.Ttl(0, 1).Count());
      Assert.Equal(2, notifications.Ttl(1, 2).Count());
      Assert.Empty(notifications.Ttl(to: 0));
      Assert.Equal(1, notifications.Ttl(to: 1).Count());
      Assert.Equal(2, notifications.Ttl(to: 3).Count());
    }
  }
}