namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="PushNotification"/> entity.</para>
/// </summary>
public sealed class PushNotificationMapping : EntityMapping<PushNotification>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public PushNotificationMapping()
  {
    Table("push_notification");
    Map(notification => notification.Payload).Column("payload").Length(short.MaxValue);
    Map(notification => notification.Provider).Column("provider").Not.Nullable().Index("ix-push_notification-provider");
    Map(notification => notification.Delivered).Column("delivered").Not.Nullable().Index("ix-push_notification-delivered");
    Map(notification => notification.Ttl).Column("ttl").Check("ttl >= 0").Index("ix-push_notification-ttl");
    HasMany(notification => notification.Devices).AsSet().Table("push_notification2device").KeyColumn("push_notification_id").Element("device", device => device.Not.Nullable());
  }
}