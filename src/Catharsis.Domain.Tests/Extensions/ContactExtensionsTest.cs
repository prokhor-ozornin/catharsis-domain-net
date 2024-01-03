using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ContactExtensions"/>.</para>
/// </summary>
public sealed class ContactExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Email(IQueryable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Email_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Contact>) null).Email("prokhor.ozornin@yandex.ru")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Email(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Email(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Contact {Emails = new HashSet<string> {"prokhor.ozornin@yandex.ru"}}, new Contact {Emails = new HashSet<string> {"prokhor.ozornin@gmail.com"}}}.AsQueryable().Email("prokhor.ozornin@yandex.ru").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Email(IEnumerable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Email_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Contact>) null).Email("prokhor.ozornin@yandex.ru")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Email(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Email(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Contact(), new Contact {Emails = new HashSet<string> {"prokhor.ozornin@yandex.ru"}}, new Contact {Emails = new HashSet<string> {"prokhor.ozornin@gmail.com"}}}.Email("prokhor.ozornin@yandex.ru").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Fax(IQueryable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Fax_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Contact>) null).Fax("fax")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Fax(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Fax(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Contact {Fax = "First"}, new Contact {Fax = "Second"}}.AsQueryable().Fax("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Fax(IEnumerable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Fax_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Contact>) null).Fax("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Fax(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Fax(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Contact(), new Contact {Fax = "First"}, new Contact {Fax = "Second"}}.Fax("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Icq(IQueryable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Icq_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Contact>) null).Icq("icq")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Icq(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Icq(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Contact {Icq = "First"}, new Contact {Icq = "Second"}}.AsQueryable().Icq("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Icq(IEnumerable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Icq_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Contact>) null).Icq("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Icq(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Icq(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Contact(), new Contact {Icq = "First"}, new Contact {Icq = "Second"}}.Icq("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Jabber(IQueryable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Jabber_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Contact>) null).Jabber("icq")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Jabber(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Jabber(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Contact {Jabber = "First"}, new Contact {Jabber = "Second"}}.AsQueryable().Jabber("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Jabber(IEnumerable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Jabber_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Contact>) null).Jabber("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Jabber(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Jabber(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Contact(), new Contact {Jabber = "First"}, new Contact {Jabber = "Second"}}.Jabber("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Phone(IQueryable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Phone_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Contact>) null).Phone("+79650000000")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Phone(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Phone(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Contact {Phones = new HashSet<string> {"+79650000000"}}, new Contact {Phones = new HashSet<string> {"+79120000000"}}}.AsQueryable().Phone("+79650000000").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Phone(IEnumerable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Phone_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Contact>) null).Phone("+79650000000")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Phone(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Phone(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Contact(), new Contact {Phones = new HashSet<string> {"+79650000000"}}, new Contact {Phones = new HashSet<string> {"+79120000000"}}}.Phone("+79650000000").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Skype(IQueryable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Skype_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Contact>) null).Skype("skype")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Skype(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().AsQueryable().Skype(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Contact {Skype = "First"}, new Contact {Skype = "Second"}}.AsQueryable().Skype("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ContactExtensions.Skype(IEnumerable{Contact}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Skype_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Contact>) null).Skype("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Skype(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Contact>().Skype(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Contact(), new Contact {Skype = "First"}, new Contact {Skype = "Second"}}.Skype("first").Should().ContainSingle();
  }
}