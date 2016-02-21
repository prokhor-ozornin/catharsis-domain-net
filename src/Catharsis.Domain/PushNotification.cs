using Catharsis.Commons;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Push уведомление</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Push уведомление")]
#endif
  [Table(Schema.TableName)]
  public partial class PushNotification : Entity, IComparable<PushNotification>, IEquatable<PushNotification>
  {
    /// <summary>
    ///   <para>Признак того, что уведомление было отправлено на мобильное устройство</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDelivered)]
#endif
    [Column(Schema.ColumnNameDelivered)]
    [NotNull]
    [Indexed(Name = "idx__push_notifications__delivered")]
    public virtual bool? Delivered { get; set; }

    /// <summary>
    ///   <para>Идентификаторы мобильных устройств - получателей уведомления</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDevices)]
#endif
    [Column(Schema.ColumnNameDevices)]
    public virtual ICollection<string> Devices { get; set; } = new HashSet<string>();

    /// <summary>
    ///   <para>Полезная нагрузка (данные) уведомления</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentPayload)]
#endif
    [Column(Schema.ColumnNamePayload)]
    [NotNull]
    public virtual string Payload { get; set; }

    /// <summary>
    ///   <para>Провайдер/служба, через которую производится рассылка уведомлений</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentProvider)]
#endif
    [Column(Schema.ColumnNameProvider)]
    [NotNull]
    [Indexed(Name = "idx__push_notifications__provider")]
    public virtual PushNotificationProvider? Provider { get; set; }

    /// <summary>
    ///   <para>Время жизни/длительность попыток доставки уведомления в секундах</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentTtl)]
#endif
    [Column(Schema.ColumnNameTtl)]
    [Indexed(Name = "idx__push_notifications__ttl")]
    public virtual long? Ttl { get; set; }

    public virtual int CompareTo(PushNotification other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(PushNotification other)
    {
      return this.Equality(other, it => it.CreatedOn, it => it.Provider);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as PushNotification);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.CreatedOn, it => it.Provider);
    }

    public override string ToString()
    {
      return this.Payload?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "push_notifications";
      public const string TableComment = "Push уведомления для мобильных устройств";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время создания push уведомления";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения push уведомления";

      public const string ColumnNameDelivered = "delivered";
      public const string ColumnCommentDelivered = "Признак того, что уведомление было отправлено на мобильное устройство";

      public const string ColumnNameDevices = "devices";
      public const string ColumnCommentDevices = "Идентификаторы мобильных устройств - получателей уведомления";

      public const string ColumnNamePayload = "payload";
      public const string ColumnCommentPayload = "Полезная нагрузка (данные) уведомления";

      public const string ColumnNameProvider = "provider";
      public const string ColumnCommentProvider = "Провайдер/служба, через которую производится рассылка уведомлений";

      public const string ColumnNameTtl = "ttl";
      public const string ColumnCommentTtl = "Время жизни/длительность попыток доставки уведомления в секундах";
    }
  }
}