using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Location"/>.</para>
/// </summary>
public sealed class LocationTest : EntityTest<Location>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Location.Latitude"/> property.</para>
  /// </summary>
  [Fact]
  public void Latitude_Property()
  {
    new Location { Latitude = decimal.MaxValue }.Latitude.Should().Be(decimal.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Location.Longitude"/> property.</para>
  /// </summary>
  [Fact]
  public void Longitude_Property()
  {
    new Location { Longitude = decimal.MaxValue }.Latitude.Should().Be(decimal.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Location.TimeZone"/> property.</para>
  /// </summary>
  [Fact]
  public void TimeZone_Property()
  {
    new Location { TimeZone = Guid.Empty.ToString() }.TimeZone.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Location()"/>
  [Fact]
  public void Constructors()
  {
    var location = new Location();

    location.Id.Should().BeNull();
    location.Uuid.Should().NotBeNull();
    location.Version.Should().BeNull();
    location.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    location.UpdatedOn.Should().BeNull();

    location.Latitude.Should().BeNull();
    location.Longitude.Should().BeNull();
    location.TimeZone.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Location.Equals(Location)"/></description></item>
  ///     <item><description><see cref="Location.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Location.Latitude), 0, 1);
    TestEquality(nameof(Location.Longitude), 0, 1);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Location.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Location.Latitude), 0, 1);
    TestHashCode(nameof(Location.Longitude), 0, 1);
  }


  /// <summary>
  ///   <para>Performs testing of <see cref="Location.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Location().ToString().Should().BeEmpty();
    new Location { Latitude = (decimal) 56.838607, Longitude = (decimal) 60.605514 }.ToString().Should().Be("56.838607,60.605514");
  }
}