using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class ContactExtensions
  {
    public static IQueryable<Contact> Email(this IQueryable<Contact> contacts, string email)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(email);

      return contacts.Where(it => it.Emails.Contains(email));
    }

    public static IEnumerable<Contact> Email(this IEnumerable<Contact> contacts, string email)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(email);

      return contacts.Where(it => it?.Emails != null && it.Emails.Contains(email));
    }

    public static IQueryable<Contact> Fax(this IQueryable<Contact> contacts, string fax)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(fax);

      return contacts.Where(it => it.Fax.ToLower() == fax.ToLower());
    }

    public static IEnumerable<Contact> Fax(this IEnumerable<Contact> contacts, string fax)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(fax);

      return contacts.Where(it => it?.Fax != null && it.Fax.ToLower() == fax.ToLower());
    }

    public static IQueryable<Contact> Icq(this IQueryable<Contact> contacts, string icq)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(icq);

      return contacts.Where(it => it.Icq.ToLower() == icq.ToLower());
    }

    public static IEnumerable<Contact> Icq(this IEnumerable<Contact> contacts, string icq)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(icq);

      return contacts.Where(it => it?.Icq != null && it.Icq.ToLower() == icq.ToLower());
    }

    public static IQueryable<Contact> Jabber(this IQueryable<Contact> contacts, string jabber)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(jabber);

      return contacts.Where(it => it.Jabber.ToLower() == jabber.ToLower());
    }

    public static IEnumerable<Contact> Jabber(this IEnumerable<Contact> contacts, string jabber)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(jabber);

      return contacts.Where(it => it?.Jabber != null && it.Jabber.ToLower() == jabber.ToLower());
    }

    public static IQueryable<Contact> Phone(this IQueryable<Contact> contacts, string phone)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(phone);

      return contacts.Where(it => it.Phones.Contains(phone));
    }

    public static IEnumerable<Contact> Phone(this IEnumerable<Contact> contacts, string phone)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(phone);

      return contacts.Where(it => it?.Phones != null && it.Phones.Contains(phone));
    }

    public static IQueryable<Contact> Skype(this IQueryable<Contact> contacts, string skype)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(skype);

      return contacts.Where(it => it.Skype.ToLower() == skype.ToLower());
    }

    public static IEnumerable<Contact> Skype(this IEnumerable<Contact> contacts, string skype)
    {
      Assertion.NotNull(contacts);
      Assertion.NotEmpty(skype);

      return contacts.Where(it => it?.Skype != null && it.Skype.ToLower() == skype.ToLower());
    }
  }
}