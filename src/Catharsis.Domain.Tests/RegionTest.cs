using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Region"/>.</para>
/// </summary>
public sealed class RegionTest : EntityTest<Region>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Region.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Region { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Region.Area"/> property.</para>
  /// </summary>
  [Fact]
  public void Area_Property()
  {
    var area = new Area();
    new Region { Area = area }.Area.Should().BeSameAs(area);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Region()"/>
  [Fact]
  public void Constructors()
  {
    var region = new Region();

    region.Id.Should().BeNull();
    region.Uuid.Should().NotBeNull();
    region.Version.Should().BeNull();
    region.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    region.UpdatedOn.Should().BeNull();

    region.Name.Should().BeNull();
    region.Area.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Region.CompareTo(Region)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Region.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Region.Equals(Region)"/></description></item>
  ///     <item><description><see cref="Region.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Region.Area), new Area { Name = "first" }, new Area { Name = "second" });
    TestEquality(nameof(Region.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Region.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Region.Area), new Area { Name = "first" }, new Area { Name = "second" });
    TestHashCode(nameof(Region.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Region.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Region().ToString().Should().BeEmpty();
    new Region { Name = string.Empty }.ToString().Should().BeEmpty();
    new Region { Name = " " }.ToString().Should().BeEmpty();
    new Region { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}