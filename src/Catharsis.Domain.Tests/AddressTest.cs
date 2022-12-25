using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Address"/>.</para>
/// </summary>
public sealed class AddressTest : EntityTest<Address>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Address.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Address {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Address.City"/> property.</para>
  /// </summary>
  [Fact]
  public void City_Property()
  {
    var city = new City();
    new Address {City = city}.City.Should().BeSameAs(city);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Address.Zip"/> property.</para>
  /// </summary>
  [Fact]
  public void Zip_Property() { new Address {Zip = Guid.Empty.ToString()}.Zip.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Address.Location"/> property.</para>
  /// </summary>
  [Fact]
  public void Location_Property()
  {
    var location = new Location();
    new Address {Location = location}.Location.Should().BeSameAs(location);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Address.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property() { new Address {Description = Guid.Empty.ToString()}.Description.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Address()"/>
  [Fact]
  public void Constructors()
  {
    var address = new Address();

    address.Id.Should().BeNull();
    address.Uuid.Should().NotBeNull();
    address.Version.Should().BeNull();
    address.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    address.UpdatedOn.Should().BeNull();
    address.Name.Should().BeNull();
    address.City.Should().BeNull();
    address.Zip.Should().BeNull();
    address.Location.Should().BeNull();
    address.Description.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Address.CompareTo(Address)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Address.Name), "first", "second"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Address.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Address().ToString().Should().BeEmpty();
    new Address {Name = string.Empty, Zip = string.Empty}.ToString().Should().BeEmpty();
    new Address {Name = string.Empty, Zip = string.Empty}.ToString().Should().BeEmpty();
    new Address {City = new City {Name = "Екатеринбург"}}.ToString().Should().Be("Екатеринбург");
    new Address {City = new City {Name = "Екатеринбург"}, Name = "Свердлова"}.ToString().Should().Be("Екатеринбург,Свердлова");
    new Address {City = new City {Name = "Екатеринбург"}, Name = "Свердлова", Zip = "620000"}.ToString().Should().Be("Екатеринбург,Свердлова,620000");
  }
}