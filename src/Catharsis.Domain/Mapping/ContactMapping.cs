namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Contact"/> entity.</para>
/// </summary>
public sealed class ContactMapping : EntityMapping<Contact>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public ContactMapping()
  {
    Table("contact");
    Map(contact => contact.Website).Column("website").Index("ix-contact-website");
    Map(contact => contact.Fax).Column("fax").Index("ix-contact-fax");
    Map(contact => contact.Skype).Column("skype").Index("ix-contact-skype");
    Map(contact => contact.Icq).Column("icq").Index("ix-contact-icq");
    Map(contact => contact.Jabber).Column("jabber").Index("ix-contact-jabber");
    HasMany(contact => contact.Addresses).AsList().Table("contact2address").KeyColumn("contact_id").ForeignKeyConstraintName("fk-contact-address");
    HasMany(contact => contact.Phones).AsList().Table("contact2phone").KeyColumn("contact_id").Element("phone", phone => phone.Not.Nullable());
    HasMany(contact => contact.Emails).AsList().Table("contact2email").KeyColumn("contact_id").Element("email", email => email.Not.Nullable());
  }
}