namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Contact"/>.</para>
/// </summary>
/// <seealso cref="Contact"/>
public static class ContactExtensions
{
  public static IQueryable<Contact> Email(this IQueryable<Contact> contacts, string email) => contacts.Where(contact => contact.Emails.Contains(email));

  public static IEnumerable<Contact?> Email(this IEnumerable<Contact?> contacts, string email) => contacts.Where(contact => contact?.Emails != null && contact.Emails.Contains(email));

  public static IQueryable<Contact> Fax(this IQueryable<Contact> contacts, string fax) => contacts.Where(contact => contact.Fax != null && contact.Fax.ToLower() == fax.ToLower());

  public static IEnumerable<Contact?> Fax(this IEnumerable<Contact?> contacts, string fax) => contacts.Where(contact => contact?.Fax != null && contact.Fax.ToLower() == fax.ToLower());

  public static IQueryable<Contact> Icq(this IQueryable<Contact> contacts, string icq) => contacts.Where(contact => contact.Icq != null && contact.Icq.ToLower() == icq.ToLower());

  public static IEnumerable<Contact?> Icq(this IEnumerable<Contact?> contacts, string icq) => contacts.Where(contact => contact?.Icq != null && contact.Icq.ToLower() == icq.ToLower());

  public static IQueryable<Contact> Jabber(this IQueryable<Contact> contacts, string jabber) => contacts.Where(contact => contact.Jabber != null && contact.Jabber.ToLower() == jabber.ToLower());

  public static IEnumerable<Contact?> Jabber(this IEnumerable<Contact?> contacts, string jabber) => contacts.Where(contact => contact?.Jabber != null && contact.Jabber.ToLower() == jabber.ToLower());

  public static IQueryable<Contact> Phone(this IQueryable<Contact> contacts, string phone) => contacts.Where(contact => contact.Phones.Contains(phone));

  public static IEnumerable<Contact?> Phone(this IEnumerable<Contact?> contacts, string phone) => contacts.Where(contact => contact?.Phones != null && contact.Phones.Contains(phone));

  public static IQueryable<Contact> Skype(this IQueryable<Contact> contacts, string skype) => contacts.Where(contact => contact.Skype != null && contact.Skype.ToLower() == skype.ToLower());

  public static IEnumerable<Contact?> Skype(this IEnumerable<Contact?> contacts, string skype) => contacts.Where(contact => contact?.Skype != null && contact.Skype.ToLower() == skype.ToLower());
}