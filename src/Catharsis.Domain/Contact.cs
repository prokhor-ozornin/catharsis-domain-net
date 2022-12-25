using System.ComponentModel;
using System.Runtime.Serialization;

namespace Catharsis.Domain;

/// <summary>
///   <para>Контакт</para>
/// </summary>
[Description("Контакт")]
[Serializable]
[DataContract(Name = nameof(Contact))]
public class Contact : Entity, IComparable<Contact>
{
  /// <summary>
  ///   <para>Веб-сайт</para>
  /// </summary>
  [DataMember(Name = nameof(Website))]
  [Description("Веб-сайт")]
  public virtual string? Website { get; set; }

  /// <summary>
  ///   <para>Номер факса</para>
  /// </summary>
  [DataMember(Name = nameof(Fax))]
  [Description("Номер факса")]
  public virtual string? Fax { get; set; }

  /// <summary>
  ///   <para>Логин Skype мессенджера</para>
  /// </summary>
  [DataMember(Name = nameof(Skype))]
  [Description("Логин Skype мессенджера")]
  public virtual string? Skype { get; set; }

  /// <summary>
  ///   <para>Логин ICQ мессенджера</para>
  /// </summary>
  [DataMember(Name = nameof(Icq))]
  [Description("Логин ICQ мессенджера")]
  public virtual string? Icq { get; set; }

  /// <summary>
  ///   <para>Логин Jabber мессенджера</para>
  /// </summary>
  [DataMember(Name = nameof(Jabber))]
  [Description("Логин Jabber мессенджера")]
  public virtual string? Jabber { get; set; }

  /// <summary>
  ///   <para>Адреса</para>
  /// </summary>
  [DataMember(Name = nameof(Addresses))]
  [Description("Адреса")]
  public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

  /// <summary>
  ///   <para>Номера телефонов</para>
  /// </summary>
  [DataMember(Name = nameof(Phones))]
  [Description("Номера телефонов")]
  public virtual ICollection<string> Phones { get; set; } = new List<string>();

  /// <summary>
  ///   <para>Адреса электронной почты</para>
  /// </summary>
  [DataMember(Name = nameof(Emails))]
  [Description("Адреса электронной почты")]
  public virtual ICollection<string> Emails { get; set; } = new List<string>();

  /// <summary>
  ///   <para>Compares the current <see cref="Contact"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Contact"/> to compare with this instance.</param>
  public virtual int CompareTo(Contact? other) => Nullable.Compare(CreatedOn, other?.CreatedOn);
}