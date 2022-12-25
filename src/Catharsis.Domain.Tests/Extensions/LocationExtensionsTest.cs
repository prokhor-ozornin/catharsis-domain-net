using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LocationExtensions"/>.</para>
/// </summary>
public sealed class LocationExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LocationExtensions.Latitude(IQueryable{Location}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Latitude_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Location>) null!).Latitude()).ThrowExactly<ArgumentNullException>();

    var locations = new[] {new Location {Latitude = 1}, new Location {Latitude = 2}}.AsQueryable();
    locations.Latitude().Should().HaveCount(2);
    locations.Latitude(0).Should().HaveCount(2);
    locations.Latitude(3).Should().BeEmpty();
    locations.Latitude(0, 1).Should().ContainSingle();
    locations.Latitude(1, 2).Should().HaveCount(2);
    locations.Latitude(to: 0).Should().BeEmpty();
    locations.Latitude(to: 1).Should().ContainSingle();
    locations.Latitude(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LocationExtensions.Latitude(IEnumerable{Location}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Latitude_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Location>) null!).Latitude()).ThrowExactly<ArgumentNullException>();

    var locations = new[] {null, new Location(), new Location {Latitude = 1}, new Location {Latitude = 2}};
    locations.Latitude().Should().HaveCount(3);
    locations.Latitude(0).Should().HaveCount(2);
    locations.Latitude(3).Should().BeEmpty();
    locations.Latitude(0, 1).Should().ContainSingle();
    locations.Latitude(1, 2).Should().HaveCount(2);
    locations.Latitude(to: 0).Should().BeEmpty();
    locations.Latitude(to: 1).Should().ContainSingle();
    locations.Latitude(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LocationExtensions.Longitude(IQueryable{Location}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Longitude_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Location>) null!).Longitude()).ThrowExactly<ArgumentNullException>();

    var locations = new[] {new Location {Longitude = 1}, new Location {Longitude = 2}}.AsQueryable();
    locations.Longitude().Should().HaveCount(2);
    locations.Longitude(0).Should().HaveCount(2);
    locations.Longitude(3).Should().BeEmpty();
    locations.Longitude(0, 1).Should().ContainSingle();
    locations.Longitude(1, 2).Should().HaveCount(2);
    locations.Longitude(to: 0).Should().BeEmpty();
    locations.Longitude(to: 1).Should().ContainSingle();
    locations.Longitude(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LocationExtensions.Longitude(IEnumerable{Location?}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Longitude_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Location>) null!).Longitude()).ThrowExactly<ArgumentNullException>();

    var locations = new[] {null, new Location(), new Location {Longitude = 1}, new Location {Longitude = 2}};
    locations.Longitude().Should().HaveCount(3);
    locations.Longitude(0).Should().HaveCount(2);
    locations.Longitude(3).Should().BeEmpty();
    locations.Longitude(0, 1).Should().ContainSingle();
    locations.Longitude(1, 2).Should().HaveCount(2);
    locations.Longitude(to: 0).Should().BeEmpty();
    locations.Longitude(to: 1).Should().ContainSingle();
    locations.Longitude(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LocationExtensions.TimeZone(IQueryable{Location}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TimeZone_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Location>) null!).TimeZone("timezone")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Location>().AsQueryable().TimeZone(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Location>().AsQueryable().TimeZone(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Location {TimeZone = "First"}, new Location {TimeZone = "Second"}}.AsQueryable().TimeZone("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LocationExtensions.TimeZone(IEnumerable{Location?}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void TimeZone_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Location>) null!).TimeZone("timezone")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Location>().TimeZone(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Location>().TimeZone(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Location(), new Location {TimeZone = "First"}, new Location {TimeZone = "Second"}}.TimeZone("f").Should().ContainSingle();
  }
}