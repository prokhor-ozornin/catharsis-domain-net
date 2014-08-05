using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Location"/>.</para>
  /// </summary>
  public sealed class LocationTests : EntityUnitTests<Location>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Address", "City", "Latitude", "Longitude", "PostalCode");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var location = new Location();
      this.TestJson(location, new { Id = 0 });

      var city = new City("city.name", new Country("country.name", "country.isoCode"));

      location = new Location(city, "address");
      this.TestJson(location, new { Id = 0, Address = "address", City = new { Id = 0, Country = new { Id = 0, IsoCode = "country.isoCode", Name = "country.name" }, Name = "city.name" } });

      location = new Location(city, "address", (decimal) 1.5, (decimal) 2.5, "postalCode")
      {
        Id = 1
      };
      this.TestJson(location, new { Id = 1, Address = "address", City = new { Id = 0, Country = new { Id = 0, IsoCode = "country.isoCode", Name = "country.name"}, Name = "city.name" }, Latitude = 1.5, Longitude = 2.5, PostalCode = "postalCode" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var location = new Location();
      this.TestXml(location, new { Id = 0 });

      var city = new City("city.name", new Country("country.name", "country.isoCode"));

      location = new Location(city, "address");
      this.TestXml(location, new { Id = 0, Address = "address" });

      location = new Location(city, "address", (decimal)1.5, (decimal)2.5, "postalCode")
      {
        Id = 1
      };
      this.TestXml(location, new { Id = 1, Address = "address", Latitude = 1.5, Longitude = 2.5, PostalCode = "postalCode" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Location()"/>
    /// <seealso cref="Location(City, string, decimal?, decimal?, string)"/>
    [Fact]
    public void Constructors()
    {
      var location = new Location();
      Assert.Null(location.Address);
      Assert.Null(location.City);
      Assert.Equal(0, location.Id);
      Assert.Null(location.Latitude);
      Assert.Null(location.Longitude);
      Assert.Null(location.PostalCode);
      Assert.Equal(0, location.Version);

      Assert.Throws<ArgumentNullException>(() => new Location(null, "address"));
      Assert.Throws<ArgumentNullException>(() => new Location(new City(), null));
      Assert.Throws<ArgumentException>(() => new Location(new City(), string.Empty));
      location = new Location(new City(), "address", (decimal)1.0, (decimal)2.0, "postalCode");
      Assert.Equal("address", location.Address);
      Assert.NotNull(location.City);
      Assert.Equal(0, location.Id);
      Assert.Equal((decimal)1.0, location.Latitude);
      Assert.Equal((decimal)2.0, location.Longitude);
      Assert.Equal("postalCode", location.PostalCode);
      Assert.Equal(0, location.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Location.Address"/> property.</para>
    /// </summary>
    [Fact]
    public void Address_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Location { Address = null });
      Assert.Throws<ArgumentException>(() => new Location { Address = string.Empty });
      
      Assert.Equal("address", new Location { Address = "address" }.Address);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Location.City"/> property.</para>
    /// </summary>
    [Fact]
    public void City_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Location { City = null });
      
      var city = new City();
      Assert.True(ReferenceEquals(new Location { City = city }.City, city));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Location.Latitude"/> property.</para>
    /// </summary>
    [Fact]
    public void Latitude_Property()
    {
      Assert.Equal(1, new Location { Latitude = 1 }.Latitude);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Location.Longitude"/> property.</para>
    /// </summary>
    [Fact]
    public void Longitude_Property()
    {
      Assert.Equal(1, new Location { Longitude = 1 }.Longitude);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Location.PostalCode"/> property.</para>
    /// </summary>
    [Fact]
    public void PostalCode_Property()
    {
      Assert.Equal("postalCode", new Location { PostalCode = "postalCode" }.PostalCode);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Location.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("Country,City,Address", new Location { City = new City { Name = "City", Country = new Country { Name = "Country" } }, Address = "Address" }.ToString());
    }
  }
}