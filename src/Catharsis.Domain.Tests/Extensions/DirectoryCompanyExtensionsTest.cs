using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DirectoryCompanyExtensions"/>.</para>
/// </summary>
public sealed class DirectoryCompanyExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompanyExtensions.Name(IQueryable{DirectoryCompany}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<DirectoryCompany>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<DirectoryCompany>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<DirectoryCompany>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new DirectoryCompany {Name = "First"}, new DirectoryCompany {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DirectoryCompanyExtensions.Name(IEnumerable{DirectoryCompany}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<DirectoryCompany>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<DirectoryCompany>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<DirectoryCompany>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new DirectoryCompany(), new DirectoryCompany {Name = "First"}, new DirectoryCompany {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}