using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Контакт</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Contact : Entity, IComparable<Contact>
  {
    /// <summary>
    ///   <para>Адреса</para>
    /// </summary>
    [Description(Schema.ColumnCommentAddresses)]
    [Column(Schema.ColumnNameAddresses)]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    /// <summary>
    ///   <para>Адреса электронной почты</para>
    /// </summary>
    [Description(Schema.ColumnCommentEmails)]
    [Column(Schema.ColumnNameEmails)]
    public virtual ICollection<string> Emails { get; set; } = new List<string>();

    /// <summary>
    ///   <para>Номер факса</para>
    /// </summary>
    [Description(Schema.ColumnCommentFax)]
    [Column(Schema.ColumnNameFax)]
    [Indexed(Name = "idx__contact__fax")]
    public virtual string Fax { get; set; }

    /// <summary>
    ///   <para>Логин ICQ мессенджера</para>
    /// </summary>
    [Description(Schema.ColumnCommentIcq)]
    [Column(Schema.ColumnNameIcq)]
    [Indexed(Name = "idx__contact__icq")]
    public virtual string Icq { get; set; }

    /// <summary>
    ///   <para>Логин Jabber мессенджера</para>
    /// </summary>
    [Description(Schema.ColumnCommentJabber)]
    [Column(Schema.ColumnNameJabber)]
    [Indexed(Name = "idx__contact__jabber")]
    public virtual string Jabber { get; set; }

    /// <summary>
    ///   <para>Номера телефонов</para>
    /// </summary>
    [Description(Schema.ColumnCommentPhones)]
    [Column(Schema.ColumnNamePhones)]
    public virtual ICollection<string> Phones { get; set; } = new List<string>();

    /// <summary>
    ///   <para>Логин Skype мессенджера</para>
    /// </summary>
    [Description(Schema.ColumnCommentSkype)]
    [Column(Schema.ColumnNameSkype)]
    [Indexed(Name = "idx__contact__skype")]
    public virtual string Skype { get; set; }

    /// <summary>
    ///   <para>Веб-сайт</para>
    /// </summary>
    [Description(Schema.ColumnCommentWebsite)]
    [Column(Schema.ColumnNameWebsite)]
    [Indexed(Name = "idx__contact__website")]
    public virtual string Website { get; set; }

    public virtual int CompareTo(Contact other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public static new class Schema
    {
      public const string TableName = "contact";
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