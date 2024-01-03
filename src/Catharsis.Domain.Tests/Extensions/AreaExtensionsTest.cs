using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AreaExtensions"/>.</para>
/// </summary>
public sealed class AreaExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="AreaExtensions.Country(IQueryable{Area}, Country?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Country_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Area>) null).Country(new Country())).ThrowExactly<ArgumentNullException>();

    new[] {new Area {Country = new Country {Id = 1}}, new Area {Country = new Country {Id = 2}}}.AsQueryable().Country(new Country {Id = 1}).Should().ContainSingle();
    new[] {new Area {Country = new Country {Id = 1}}, new Area {Country = null}}.AsQueryable().Country(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AreaExtensions.Country(IEnumerable{Area}, Country?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Country_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Area>) null).Country(new Country())).ThrowExactly<ArgumentNullException>();

    new[] {null, new Area {Country = new Country {IsoCode = "first"}}, new Area {Country = new Country {IsoCode = "second"}}}.Country(new Country {IsoCode = "first"}).Should().ContainSingle();
    new[] {null, new Area(), new Area {Country = new Country {IsoCode = "first"}}}.Country(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AreaExtensions.Name(IQueryable{Area}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Area>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Area>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Area>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Area {Name = "First"}, new Area {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AreaExtensions.Name(IEnumerable{Area}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Area>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Area>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Area>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Area(), new Area {Name = "First"}, new Area {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}