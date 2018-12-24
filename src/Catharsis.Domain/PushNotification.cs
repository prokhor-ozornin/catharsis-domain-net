using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Push уведомление</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class PushNotification : Entity, IComparable<PushNotification>, IEquatable<PushNotification>
  {
    /// <summary>
    ///   <para>Признак того, что уведомление было отправлено на мобильное устройство</para>
    /// </summary>
    [Description(Schema.ColumnCommentDelivered)]
    [Column(Schema.ColumnNameDelivered)]
    [NotNull]
    [Indexed(Name = "idx__push_notification__delivered")]
    public virtual bool? Delivered { get; set; }

    /// <summary>
    ///   <para>Идентификаторы мобильных устройств - получателей уведомления</para>
    /// </summary>
    [Description(Schema.ColumnCommentDevices)]
    [Column(Schema.ColumnNameDevices)]
    public virtual ICollection<string> Devices { get; set; } = new HashSet<string>();

    /// <summary>
    ///   <para>Полезная нагрузка (данные) уведомления</para>
    /// </summary>
    [Description(Schema.ColumnCommentPayload)]
    [Column(Schema.ColumnNamePayload)]
    [NotNull]
    public virtual string Payload { get; set; }

    /// <summary>
    ///   <para>Провайдер/служба, через которую производится рассылка уведомлений</para>
    /// </summary>
    [Description(Schema.ColumnCommentProvider)]
    [Column(Schema.ColumnNameProvider)]
    [NotNull]
    [Indexed(Name = "idx__push_notification__provider")]
    public virtual PushNotificationProvider? Provider { get; set; }

    /// <summary>
    ///   <para>Время жизни/длительность попыток доставки уведомления в секундах</para>
    /// </summary>
    [Description(Schema.ColumnCommentTtl)]
    [Column(Schema.ColumnNameTtl)]
    [Indexed(Name = "idx__push_notification__ttl")]
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

    public static new class Schema
    {
      public const string TableName = "push_notification";
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