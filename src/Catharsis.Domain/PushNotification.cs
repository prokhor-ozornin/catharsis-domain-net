using Catharsis.Commons;
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
  public partial class PushNotification : Entity, IComparable<PushNotification>, IEquatable<PushNotification>
  {
    /// <summary>
    ///   <para>Признак того, что уведомление было отправлено на мобильное устройство</para>
    /// </summary>
#if NET_35
    [Description("Признак того, что уведомление было отправлено на мобильное устройство")]
#endif
    public virtual bool? Delivered { get; set; }

    /// <summary>
    ///   <para>Идентификаторы мобильных устройств - получателей уведомления</para>
    /// </summary>
#if NET_35
    [Description("Идентификаторы мобильных устройств - получателей уведомления")]
#endif
    public virtual ICollection<string> Devices { get; set; } = new HashSet<string>();

    /// <summary>
    ///   <para>Полезная нагрузка (данные) уведомления</para>
    /// </summary>
#if NET_35
    [Description("Полезная нагрузка (данные) уведомления")]
#endif
    public virtual string Payload { get; set; }

    /// <summary>
    ///   <para>Провайдер/служба, через которую производится рассылка уведомлений</para>
    /// </summary>
#if NET_35
    [Description("Провайдер/служба, через которую производится рассылка уведомлений")]
#endif
    public virtual PushNotificationProvider? Provider { get; set; }

    /// <summary>
    ///   <para>Время жизни/длительность попыток доставки уведомления в секундах</para>
    /// </summary>
#if NET_35
    [Description("Время жизни/длительность попыток доставки уведомления в секундах")]
#endif
    public virtual long? Ttl { get; set; }

    public virtual int CompareTo(PushNotification other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(PushNotification other)
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
  }
}