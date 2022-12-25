using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Contact"/>.</para>
/// </summary>
public sealed class ContactTest : EntityTest<Contact>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Website"/> property.</para>
  /// </summary>
  [Fact]
  public void Website_Property()
  {
    new Contact { Website = Guid.Empty.ToString() }.Website.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Fax"/> property.</para>
  /// </summary>
  [Fact]
  public void Fax_Property()
  {
    new Contact { Fax = Guid.Empty.ToString() }.Fax.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Skype"/> property.</para>
  /// </summary>
  [Fact]
  public void Skype_Property()
  {
    new Contact { Skype = Guid.Empty.ToString() }.Skype.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Icq"/> property.</para>
  /// </summary>
  [Fact]
  public void Icq_Property()
  {
    new Contact { Icq = Guid.Empty.ToString() }.Icq.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Jabber"/> property.</para>
  /// </summary>
  [Fact]
  public void Jabber_Property()
  {
    new Contact { Jabber = Guid.Empty.ToString() }.Jabber.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Addresses"/> property.</para>
  /// </summary>
  [Fact]
  public void Addresses_Property()
  {
    var addresses = new List<Address>();
    new Contact { Addresses = addresses }.Addresses.Should().BeSameAs(addresses);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Phones"/> property.</para>
  /// </summary>
  [Fact]
  public void Phones_Property()
  {
    var phones = new List<string>();
    new Contact { Phones = phones }.Phones.Should().BeSameAs(phones);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.Emails"/> property.</para>
  /// </summary>
  [Fact]
  public void Emails_Property()
  {
    var emails = new List<string>();
    new Contact { Emails = emails }.Emails.Should().BeSameAs(emails);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Contact()"/>
  [Fact]
  public void Constructors()
  {
    var contact = new Contact();

    contact.Id.Should().BeNull();
    contact.Uuid.Should().NotBeNull();
    contact.Version.Should().BeNull();
    contact.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    contact.UpdatedOn.Should().BeNull();

    contact.Website.Should().BeNull();
    contact.Fax.Should().BeNull();
    contact.Skype.Should().BeNull();
    contact.Icq.Should().BeNull();
    contact.Jabber.Should().BeNull();
    contact.Addresses.Should().BeEmpty();
    contact.Phones.Should().BeEmpty();
    contact.Emails.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Contact.CompareTo(Contact)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Contact.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }
}