using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Area"/>.</para>
/// </summary>
public sealed class AreaTest : EntityTest<Area>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Area.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Area { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Area.Country"/> property.</para>
  /// </summary>
  [Fact]
  public void Country_Property()
  {
    var country = new Country();
    new Area { Country = country }.Country.Should().BeSameAs(country);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Area()"/>
  [Fact]
  public void Constructors()
  {
    var area = new Area();

    area.Id.Should().BeNull();
    area.Uuid.Should().NotBeNull();
    area.Version.Should().BeNull();
    area.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    area.UpdatedOn.Should().BeNull();

    area.Country.Should().BeNull();
    area.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Area.CompareTo(Area)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Area.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Area.Equals(Area)"/></description></item>
  ///     <item><description><see cref="Area.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Area.Country), new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
    TestEquality(nameof(Area.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Area.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Area.Country), new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
    TestHashCode(nameof(Area.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Area.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Area().ToString().Should().BeEmpty();
    new Area { Name = string.Empty }.ToString().Should().BeEmpty();
    new Area { Name = " " }.ToString().Should().BeEmpty();
    new Area { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}