using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ApiKeyExtensions"/>.</para>
/// </summary>
public sealed class ApiKeyExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKeyExtensions.Name(IQueryable{ApiKey}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<ApiKey>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<ApiKey>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<ApiKey>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new ApiKey {AppName = "Third", Name = "First"}, new ApiKey {AppName = "Third", Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ApiKeyExtensions.Name(IEnumerable{ApiKey}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<ApiKey>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<ApiKey>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<ApiKey>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new ApiKey(), new ApiKey {Name = "First"}, new ApiKey {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}