using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="City"/>.</para>
/// </summary>
public sealed class CityTest : EntityTest<City>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="City.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new City { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.Federal"/> property.</para>
  /// </summary>
  [Fact]
  public void Federal_Property()
  {
    new City { Federal = true }.Federal.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.Country"/> property.</para>
  /// </summary>
  [Fact]
  public void Country_Property()
  {
    var country = new Country();
    new City { Country = country }.Country.Should().BeSameAs(country);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.Region"/> property.</para>
  /// </summary>
  [Fact]
  public void Region_Property()
  {
    var region = new Region();
    new City { Region = region }.Region.Should().BeSameAs(region);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.Area"/> property.</para>
  /// </summary>
  [Fact]
  public void Area_Property()
  {
    var area = new Area();
    new City { Area = area }.Area.Should().BeSameAs(area);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.Location"/> property.</para>
  /// </summary>
  [Fact]
  public void Location_Property()
  {
    var location = new Location();
    new City { Location = location }.Location.Should().BeSameAs(location);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="City()"/>
  [Fact]
  public void Constructors()
  {
    var city = new City();

    city.Id.Should().BeNull();
    city.Uuid.Should().NotBeNull();
    city.Version.Should().BeNull();
    city.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    city.UpdatedOn.Should().BeNull();

    city.Name.Should().BeNull();
    city.Federal.Should().BeNull();
    city.Country.Should().BeNull();
    city.Region.Should().BeNull();
    city.Area.Should().BeNull();
    city.Location.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.CompareTo(City)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(City.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="City.Equals(City)"/></description></item>
  ///     <item><description><see cref="City.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(City.Area), new Area { Name = "first" }, new Area { Name = "second" });
    TestEquality(nameof(City.Country), new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
    TestEquality(nameof(City.Name), "first", "second");
    TestEquality(nameof(City.Region), new Region { Name = "first" }, new Region { Name = "second" });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="City.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(City.Area), new Area { Name = "first" }, new Area { Name = "second" });
    TestHashCode(nameof(City.Country), new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
    TestHashCode(nameof(City.Name), "first", "second");
    TestHashCode(nameof(City.Region), new Region { Name = "first" }, new Region { Name = "second" });
  }


  /// <summary>
  ///   <para>Performs testing of <see cref="City.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new City().ToString().Should().BeEmpty();
    new City { Name = string.Empty }.ToString().Should().BeEmpty();
    new City { Name = " " }.ToString().Should().BeEmpty();
    new City { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}