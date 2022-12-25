using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="CityExtensions"/>.</para>
/// </summary>
public sealed class CityExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Area(IQueryable{City}, Area?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Area_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<City>) null!).Area(new Area())).ThrowExactly<ArgumentNullException>();

    new[] {new City {Area = new Area {Id = 1}}, new City {Area = new Area {Id = 2}}}.AsQueryable().Area(new Area {Id = 1}).Should().ContainSingle();
    new[] {new City {Area = new Area {Id = 1}}, new City {Area = null}}.AsQueryable().Area(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Area(IEnumerable{City}, Area?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Area_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<City>) null!).Area(new Area())).ThrowExactly<ArgumentNullException>();

    new[] {null, new City {Area = new Area {Name = "first"}}, new City {Area = new Area {Name = "second"}}}.Area(new Area {Name = "first"}).Should().ContainSingle();
    new[] {null, new City(), new City {Area = new Area {Name = "first"}}}.Area(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Country(IQueryable{City}, Country?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Country_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<City>) null!).Country(new Country())).ThrowExactly<ArgumentNullException>();

    new[] {new City {Country = new Country {Id = 1}}, new City {Country = new Country {Id = 2}}}.AsQueryable().Country(new Country {Id = 1}).Should().ContainSingle();
    new[] {new City {Country = new Country {Id = 1}}, new City {Country = null}}.AsQueryable().Country(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Country(IEnumerable{City}, Country?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Country_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<City>) null!).Country(new Country())).ThrowExactly<ArgumentNullException>();

    new[] {null, new City {Country = new Country {IsoCode = "first"}}, new City {Country = new Country {IsoCode = "second"}}}.Country(new Country {IsoCode = "first"}).Should().ContainSingle();
    new[] {null, new City(), new City {Country = new Country {IsoCode = "first"}}}.Country(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Federal(IQueryable{City}, bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Federal_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<City>) null!).Federal(true)).ThrowExactly<ArgumentNullException>();

    new[] {new City {Federal = false}, new City {Federal = true}}.AsQueryable().Federal(true).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Federal(IEnumerable{City}, bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Federal_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Audio>) null!).Bitrate(0)).ThrowExactly<ArgumentNullException>();

    new[] {null, new City(), new City {Federal = false}, new City {Federal = true}}.Federal(true).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Region(IQueryable{City}, Region?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Region_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<City>) null!).Region(new Region())).ThrowExactly<ArgumentNullException>();

    new[] {new City {Region = new Region {Id = 1}}, new City {Region = new Region {Id = 2}}}.AsQueryable().Region(new Region {Id = 1}).Should().ContainSingle();
    new[] {new City {Region = new Region {Id = 1}}, new City {Region = null}}.AsQueryable().Region(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CityExtensions.Region(IEnumerable{City}, Region?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Region_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<City>) null!).Region(new Region())).ThrowExactly<ArgumentNullException>();

    new[] {null, new City {Region = new Region {Name = "first"}}, new City {Region = new Region {Name = "second"}}}.Region(new Region {Name = "first"}).Should().ContainSingle();
    new[] {null, new City(), new City {Region = new Region {Name = "first"}}}.Region(null).Should().ContainSingle();
  }
}