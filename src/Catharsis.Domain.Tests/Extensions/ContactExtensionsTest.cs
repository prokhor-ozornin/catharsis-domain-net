using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ContactExtensionsTests
  {
    [Fact]
    public void email_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Contact>)null).Email("prokhor.ozornin@yandex.ru"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.AsQueryable().Email(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.AsQueryable().Email(string.Empty));

      Assert.Equal(1, new[] { new Contact { Emails = new HashSet<string> { "prokhor.ozornin@yandex.ru" } }, new Contact { Emails = new HashSet<string> { "prokhor.ozornin@gmail.com" } } }.AsQueryable().Email("prokhor.ozornin@yandex.ru").Count());
    }

    [Fact]
    public void email_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Contact>)null).Email("prokhor.ozornin@yandex.ru"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.Email(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.Email(string.Empty));

      Assert.Equal(1, new[] { null, new Contact(), new Contact { Emails = new HashSet<string> { "prokhor.ozornin@yandex.ru" } }, new Contact { Emails = new HashSet<string> { "prokhor.ozornin@gmail.com" } } }.Email("prokhor.ozornin@yandex.ru").Count());
    }

    [Fact]
    public void fax_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Contact>)null).Fax("fax"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.AsQueryable().Fax(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.AsQueryable().Fax(string.Empty));

      Assert.Equal(1, new[] { new Contact { Fax = "First" }, new Contact { Fax = "Second" } }.AsQueryable().Fax("first").Count());
    }

    [Fact]
    public void fax_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Contact>)null).Fax("level"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.Fax(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.Fax(string.Empty));

      Assert.Equal(1, new[] { null, new Contact(), new Contact { Fax = "First" }, new Contact { Fax = "Second" } }.Fax("first").Count());
    }

    [Fact]
    public void icq_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Contact>)null).Icq("icq"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.AsQueryable().Icq(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.AsQueryable().Icq(string.Empty));

      Assert.Equal(1, new[] { new Contact { Icq = "First" }, new Contact { Icq = "Second" } }.AsQueryable().Icq("first").Count());
    }

    [Fact]
    public void icq_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Contact>)null).Icq("level"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.Icq(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.Icq(string.Empty));

      Assert.Equal(1, new[] { null, new Contact(), new Contact { Icq = "First" }, new Contact { Icq = "Second" } }.Icq("first").Count());
    }

    [Fact]
    public void jabber_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Contact>)null).Jabber("icq"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.AsQueryable().Jabber(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.AsQueryable().Jabber(string.Empty));

      Assert.Equal(1, new[] { new Contact { Jabber = "First" }, new Contact { Jabber = "Second" } }.AsQueryable().Jabber("first").Count());
    }

    [Fact]
    public void jabber_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Contact>)null).Jabber("level"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.Jabber(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.Jabber(string.Empty));

      Assert.Equal(1, new[] { null, new Contact(), new Contact { Jabber = "First" }, new Contact { Jabber = "Second" } }.Jabber("first").Count());
    }

    [Fact]
    public void phone_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Contact>)null).Phone("+79650000000"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.AsQueryable().Phone(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.AsQueryable().Phone(string.Empty));

      Assert.Equal(1, new[] { new Contact { Phones = new HashSet<string> { "+79650000000" } }, new Contact { Phones = new HashSet<string> { "+79120000000" } } }.AsQueryable().Phone("+79650000000").Count());
    }

    [Fact]
    public void phone_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Contact>)null).Phone("+79650000000"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.Phone(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.Phone(string.Empty));

      Assert.Equal(1, new[] { null, new Contact(), new Contact { Phones = new HashSet<string> { "+79650000000" } }, new Contact { Phones = new HashSet<string> { "+79120000000" } } }.Phone("+79650000000").Count());
    }

    [Fact]
    public void skype_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Contact>)null).Skype("skype"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.AsQueryable().Skype(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.AsQueryable().Skype(string.Empty));

      Assert.Equal(1, new[] { new Contact { Skype = "First" }, new Contact { Skype = "Second" } }.AsQueryable().Skype("first").Count());
    }

    [Fact]
    public void skype_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Contact>)null).Skype("level"));
      Assert.Throws<ArgumentNullException>(() => new Contact[] { }.Skype(null));
      Assert.Throws<ArgumentException>(() => new Contact[] { }.Skype(string.Empty));

      Assert.Equal(1, new[] { null, new Contact(), new Contact { Skype = "First" }, new Contact { Skype = "Second" } }.Skype("first").Count());
    }
  }
}