namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="PushNotification"/>.</para>
/// </summary>
/// <seealso cref="PushNotification"/>
public static class PushNotificationExtensions
{
  public static IQueryable<PushNotification> Delivered(this IQueryable<PushNotification> notifications, bool? delivered) => notifications.Where(notification => notification.Delivered == delivered);

  public static IEnumerable<PushNotification> Delivered(this IEnumerable<PushNotification> notifications, bool? delivered) => notifications.Where(notification => notification is not null && notification.Delivered == delivered);

  public static IQueryable<PushNotification> Provider(this IQueryable<PushNotification> notifications, PushNotification.ProviderType? provider) => notifications.Where(notification => notification.Provider == provider);

  public static IEnumerable<PushNotification> Provider(this IEnumerable<PushNotification> notifications, PushNotification.ProviderType? provider) => notifications.Where(notification => notification is not null && notification.Provider == provider);

  public static IQueryable<PushNotification> Ttl(this IQueryable<PushNotification> notifications, long? from = null, long? to = null)
  {
    if (from is not null)
    {
      notifications = notifications.Where(notification => notification.Ttl >= from.Value);
    }

    if (to is not null)
    {
      notifications = notifications.Where(notification => notification.Ttl <= to.Value);
    }

    return notifications;
  }

  public static IEnumerable<PushNotification> Ttl(this IEnumerable<PushNotification> notifications, long? from = null, long? to = null)
  {
    if (from is not null)
    {
      notifications = notifications.Where(notification => notification is not null && notification.Ttl >= from.Value);
    }

    if (to is not null)
    {
      notifications = notifications.Where(notification => notification is not null && notification.Ttl <= to.Value);
    }

    return notifications.Where(notification => notification is not null);
  }
}