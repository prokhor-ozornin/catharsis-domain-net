using SQLite.Net.Attributes;
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
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Contact : Entity, IComparable<Contact>
  {
    /// <summary>
    ///   <para>Адреса</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentAddresses)]
#endif
    [Column(Schema.ColumnNameAddresses)]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    /// <summary>
    ///   <para>Адреса электронной почты</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentEmails)]
#endif
    [Column(Schema.ColumnNameEmails)]
    public virtual ICollection<string> Emails { get; set; } = new List<string>();

    /// <summary>
    ///   <para>Номер факса</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentFax)]
#endif
    [Column(Schema.ColumnNameFax)]
    [Indexed(Name = "idx__contacts__fax")]
    public virtual string Fax { get; set; }

    /// <summary>
    ///   <para>Логин ICQ мессенджера</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentIcq)]
#endif
    [Column(Schema.ColumnNameIcq)]
    [Indexed(Name = "idx__contacts__icq")]
    public virtual string Icq { get; set; }

    /// <summary>
    ///   <para>Логин Jabber мессенджера</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentJabber)]
#endif
    [Column(Schema.ColumnNameJabber)]
    [Indexed(Name = "idx__contacts__jabber")]
    public virtual string Jabber { get; set; }

    /// <summary>
    ///   <para>Номера телефонов</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentPhones)]
#endif
    [Column(Schema.ColumnNamePhones)]
    public virtual ICollection<string> Phones { get; set; } = new List<string>();

    /// <summary>
    ///   <para>Логин Skype мессенджера</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentSkype)]
#endif
    [Column(Schema.ColumnNameSkype)]
    [Indexed(Name = "idx__contacts__skype")]
    public virtual string Skype { get; set; }

    /// <summary>
    ///   <para>Веб-сайт</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentWebsite)]
#endif
    [Column(Schema.ColumnNameWebsite)]
    [Indexed(Name = "idx__contacts__website")]
    public virtual string Website { get; set; }

    public virtual int CompareTo(Contact other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public static class Schema
    {
      public const string TableName = "contacts";
      public const string TableComment = "Контактные данные";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления контактных данных";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения контактных данных";

      public const string ColumnNameAddresses = "addresses";
      public const string ColumnCommentAddresses = "Адреса";

      public const string ColumnNameEmails = "emails";
      public const string ColumnCommentEmails = "Адреса электронной почты";

      public const string ColumnNameFax = "fax";
      public const string ColumnCommentFax = "Номер факса";

      public const string ColumnNameIcq = "icq";
      public const string ColumnCommentIcq = "Логин ICQ мессенджера";

      public const string ColumnNameJabber = "jabber";
      public const string ColumnCommentJabber = "Логин Jabber мессенджера";

      public const string ColumnNamePhones = "phones";
      public const string ColumnCommentPhones = "Номера телефонов";

      public const string ColumnNameSkype = "skype";
      public const string ColumnCommentSkype = "Логин Skype мессенджера";

      public const string ColumnNameWebsite = "website";
      public const string ColumnCommentWebsite = "Веб-сайт";
    }
  }
}