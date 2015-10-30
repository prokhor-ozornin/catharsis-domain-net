using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Контакт</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Контакт")]
#endif
  public partial class Contact : Entity, IComparable<Contact>
  {
    /// <summary>
    ///   <para>Адреса</para>
    /// </summary>
#if NET_35
    [Description("Адреса")]
#endif
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    /// <summary>
    ///   <para>Адреса электронной почты</para>
    /// </summary>
#if NET_35
    [Description("Адреса электронной почты")]
#endif
    public virtual ICollection<string> Emails { get; set; } = new List<string>();

    /// <summary>
    ///   <para>Номер факса</para>
    /// </summary>
#if NET_35
    [Description("Номер факса")]
#endif
    public virtual string Fax { get; set; }

    /// <summary>
    ///   <para>Логин ICQ мессенджера</para>
    /// </summary>
#if NET_35
    [Description("Логин ICQ мессенджера")]
#endif
    public virtual string Icq { get; set; }

    /// <summary>
    ///   <para>Логин Jabber мессенджера</para>
    /// </summary>
#if NET_35
    [Description("Логин Jabber мессенджера")]
#endif
    public virtual string Jabber { get; set; }

    /// <summary>
    ///   <para>Номера телефонов</para>
    /// </summary>
#if NET_35
    [Description("Номера телефонов")]
#endif
    public virtual ICollection<string> Phones { get; set; } = new List<string>();

    /// <summary>
    ///   <para>Логин Skype мессенджера</para>
    /// </summary>
#if NET_35
    [Description("Логин Skype мессенджера")]
#endif
    public virtual string Skype { get; set; }

    /// <summary>
    ///   <para>Веб-сайт</para>
    /// </summary>
#if NET_35
    [Description("Веб-сайт")]
#endif
    public virtual string Website { get; set; }

    public virtual int CompareTo(Contact other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }
  }
}