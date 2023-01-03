using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="CountryExtensions"/>.</para>
/// </summary>
public sealed class CountryExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CountryExtensions.Name(IQueryable{Country}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Country>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Country {Name = "First"}, new Country {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CountryExtensions.Name(IEnumerable{Country}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Country>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Country(), new Country {Name = "First"}, new Country {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CountryExtensions.ValueOf(IQueryable{Country}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Country>) null).ValueOf("ru")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().AsQueryable().ValueOf(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().AsQueryable().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Country {IsoCode = "Ru"}, new Country {IsoCode = "ru"}}.AsQueryable().ValueOf("ru")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Country>().AsQueryable().ValueOf("ru").Should().BeNull();
    new[] {new Country {IsoCode = "Ru"}, new Country {IsoCode = "En"}}.AsQueryable().ValueOf("ru").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CountryExtensions.ValueOf(IEnumerable{Country}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Country>) null).ValueOf("isbn")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().ValueOf(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Country>().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Country {IsoCode = "Ru"}, new Country {IsoCode = "ru"}}.ValueOf("ru")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Country>().ValueOf("ru").Should().BeNull();
    new[] {new Country {IsoCode = "Ru"}, new Country {IsoCode = "En"}}.ValueOf("ru").Should().NotBeNull();
  }
}