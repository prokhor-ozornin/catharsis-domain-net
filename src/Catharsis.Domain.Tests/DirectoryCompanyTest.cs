using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryCompany"/>.</para>
/// </summary>
public sealed class DirectoryCompanyTest : EntityTest<DirectoryCompany>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompany.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new DirectoryCompany { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompany.ShortName"/> property.</para>
  /// </summary>
  [Fact]
  public void ShortName_Property()
  {
    new DirectoryCompany { ShortName = Guid.Empty.ToString() }.ShortName.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompany.Code"/> property.</para>
  /// </summary>
  [Fact]
  public void Code_Property()
  {
    new DirectoryCompany { Code = Guid.Empty.ToString() }.Code.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompany.Contact"/> property.</para>
  /// </summary>
  [Fact]
  public void Contact_Property()
  {
    var contact = new Contact();
    new DirectoryCompany { Contact = contact }.Contact.Should().BeSameAs(contact);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DirectoryCompany()"/>
  [Fact]
  public void Constructors()
  {
    var company = new DirectoryCompany();

    company.Id.Should().BeNull();
    company.Uuid.Should().NotBeNull();
    company.Version.Should().BeNull();
    company.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    company.UpdatedOn.Should().BeNull();

    company.Name.Should().BeNull();
    company.ShortName.Should().BeNull();
    company.Code.Should().BeNull();
    company.Contact.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompany.CompareTo(DirectoryCompany)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(DirectoryCompany.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompany.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new DirectoryCompany().ToString().Should().BeEmpty();
    new DirectoryCompany { Name = string.Empty }.ToString().Should().BeEmpty();
    new DirectoryCompany { Name = " " }.ToString().Should().BeEmpty();
    new DirectoryCompany { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}