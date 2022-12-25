using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="RegionExtensions"/>.</para>
/// </summary>
public sealed class RegionExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="RegionExtensions.Area(IQueryable{Region}, Area?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Area_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Region>) null!).Area(new Area())).ThrowExactly<ArgumentNullException>();

    new[] {new Region {Area = new Area {Id = 1}}, new Region {Area = new Area {Id = 2}}}.AsQueryable().Area(new Area {Id = 1}).Should().ContainSingle();
    new[] {new Region {Area = new Area {Id = 1}}, new Region {Area = null}}.AsQueryable().Area(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionExtensions.Area(IEnumerable{Region}, Area?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Area_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Region>) null!).Area(new Area())).ThrowExactly<ArgumentNullException>();

    new[] {null, new Region {Area = new Area {Name = "first"}}, new Region {Area = new Area {Name = "second"}}}.Area(new Area {Name = "first"}).Should().ContainSingle();
    new[] {null, new Region(), new Region {Area = new Area {Name = "first"}}}.Area(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionExtensions.Name(IQueryable{Region}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Region>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Region>().AsQueryable().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Region>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Region {Name = "First"}, new Region {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="RegionExtensions.Name(IEnumerable{Region}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Region>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Region>().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Region>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Region(), new Region {Name = "First"}, new Region {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}