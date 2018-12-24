using Catharsis.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain
{
  public static class PushNotificationExtensions
  {
    public static IQueryable<PushNotification> Delivered(this IQueryable<PushNotification> notifications, bool delivered)
    {
      Assertion.NotNull(notifications);

      return notifications.Where(it => it.Delivered == delivered);
    }

    public static IEnumerable<PushNotification> Delivered(this IEnumerable<PushNotification> notifications, bool delivered)
    {
      Assertion.NotNull(notifications);

      return notifications.Where(it => it != null && it.Delivered == delivered);
    }

    public static IQueryable<PushNotification> Provider(this IQueryable<PushNotification> notifications, PushNotificationProvider provider)
    {
      Assertion.NotNull(notifications);

      return notifications.Where(it => it.Provider == provider);
    }

    public static IEnumerable<PushNotification> Provider(this IEnumerable<PushNotification> notifications, PushNotificationProvider provider)
    {
      Assertion.NotNull(notifications);

      return notifications.Where(it => it != null && it.Provider == provider);
    }

    public static IQueryable<PushNotification> Ttl(this IQueryable<PushNotification> notifications, long? from = null, long? to = null)
    {
      Assertion.NotNull(notifications); 

      if (from != null)
      {
        notifications = notifications.Where(it => it.Ttl >= from.Value);
      }

      if (to != null)
      {
        notifications = notifications.Where(it => it.Ttl <= to.Value);
      }

      return notifications;
    }

    public static IEnumerable<PushNotification> Ttl(this IEnumerable<PushNotification> notifications, long? from = null, long? to = null)
    {
      Assertion.NotNull(notifications);

      if (from != null)
      {
        notifications = notifications.Where(it => it != null && it.Ttl >= from.Value);
      }

      if (to != null)
      {
        notifications = notifications.Where(it => it != null && it.Ttl <= to.Value);
      }

      return notifications.Where(it => it != null);
    }
  }
}