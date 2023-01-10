using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Push уведомление</para>
/// </summary>
[Description("Push уведомление")]
[Serializable]
[DataContract(Name = nameof(PushNotification))]
public class PushNotification : Entity, IComparable<PushNotification>, IEquatable<PushNotification>
{
  /// <summary>
  ///   <para>Полезная нагрузка (данные) уведомления</para>
  /// </summary>
  [DataMember(Name = nameof(Payload))]
  [Description("Полезная нагрузка (данные) уведомления")]
  public virtual string Payload { get; set; }

  /// <summary>
  ///   <para>Провайдер/служба, через которую производится рассылка уведомлений</para>
  /// </summary>
  [DataMember(Name = nameof(Provider))]
  [Description("Провайдер/служба, через которую производится рассылка уведомлений")]
  public virtual ProviderType? Provider { get; set; }

  /// <summary>
  ///   <para>Признак того, что уведомление было отправлено на мобильное устройство</para>
  /// </summary>
  [DataMember(Name = nameof(Delivered))]
  [Description("Признак того, что уведомление было отправлено на мобильное устройство")]
  public virtual bool? Delivered { get; set; }

  /// <summary>
  ///   <para>Время жизни/длительность попыток доставки уведомления в секундах</para>
  /// </summary>
  [DataMember(Name = nameof(Ttl))]
  [Description("Время жизни/длительность попыток доставки уведомления в секундах")]
  public virtual long? Ttl { get; set; }

  /// <summary>
  ///   <para>Идентификаторы мобильных устройств - получателей уведомления</para>
  /// </summary>
  [DataMember(Name = nameof(Devices))]
  [Description("Идентификаторы мобильных устройств - получателей уведомления")]
  public virtual ISet<string> Devices { get; set; } = new HashSet<string>();

  /// <summary>
  ///   <para>Compares the current <see cref="PushNotification"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="PushNotification"/> to compare with this instance.</param>
  public virtual int CompareTo(PushNotification other) => Nullable.Compare(CreatedOn, other?.CreatedOn);

  /// <summary>
  ///   <para>Determines whether two <see cref="PushNotification"/> instances are equal.</para>
  /// </summary>
  /// <param name="other">The instance to compare with the current one.</param>
  /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
  public virtual bool Equals(PushNotification other) => this.Equality(other, nameof(CreatedOn), nameof(Provider));

  /// <summary>
  ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
  /// </summary>
  /// <param name="other">The object to compare with the current object.</param>
  /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
  public override bool Equals(object other) => Equals(other as PushNotification);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(nameof(CreatedOn), nameof(Provider));

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => Payload ?? string.Empty;

  public enum ProviderType
  {
    Apple,
    Google, 
    Microsoft
  }
}