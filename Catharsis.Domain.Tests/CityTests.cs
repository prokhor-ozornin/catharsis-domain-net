using System;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="City"/>.</para>
  /// </summary>
  public sealed class CityTests : EntityUnitTests<City>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Country", "Name", "Region");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var city = new City();
      Assert.Equal(@"{""Id"":0}", city.Json());

      var country = new Country("country.name", "country.isoCode");

      city = new City("name", country);
      Assert.Equal(@"{""Id"":0,""Country"":{""Id"":0,""IsoCode"":""country.isoCode"",""Name"":""country.name""},""Name"":""name""}", city.Json());
      Assert.Equal(city, city.Json().Json<City>());

      city = new City("name", country, "region")
      {
        Id = 1 
      };
      Assert.Equal(@"{""Id"":1,""Country"":{""Id"":0,""IsoCode"":""country.isoCode"",""Name"":""country.name""},""Name"":""name"",""Region"":""region""}", city.Json());
      Assert.Equal(city, city.Json().Json<City>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var city = new City();
      this.TestXml(city, "<Id>0</Id>");

      var country = new Country("country.name", "country.isoCode");

      city = new City("name", country);
      this.TestXml(city, "<Id>0</Id><Country><Id>0</Id><IsoCode>country.isoCode</IsoCode><Name>country.name</Name></Country><Name>name</Name>");
      Assert.Equal(city, city.Xml().Xml<City>());

      city = new City("name", country, "region")
      {
        Id = 1
      };
      this.TestXml(city, "<Id>1</Id><Country><Id>0</Id><IsoCode>country.isoCode</IsoCode><Name>country.name</Name></Country><Name>name</Name><Region>region</Region>");
      Assert.Equal(city, city.Xml().Xml<City>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="City()"/>
    /// <seealso cref="City(string, Country, string)"/>
    [Fact]
    public void Constructors()
    {
      var city = new City();
      Assert.Null(city.Country);
      Assert.Equal(0, city.Id);
      Assert.Null(city.Name);
      Assert.Null(city.Region);
      Assert.Equal(0, city.Version);

      Assert.Throws<ArgumentNullException>(() => new City(null, new Country()));
      Assert.Throws<ArgumentNullException>(() => new City("name", null));
      Assert.Throws<ArgumentException>(() => new City(string.Empty, new Country()));
      city = new City("name", new Country(), "region");
      Assert.NotNull(city.Country);
      Assert.Equal(0, city.Id);
      Assert.Equal("name", city.Name);
      Assert.Equal("region", city.Region);
      Assert.Equal(0, city.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.Country"/> property.</para>
    /// </summary>
    [Fact]
    public void Country_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new City { Country = null });
      
      var country = new Country();
      Assert.True(ReferenceEquals(new City { Country = country }.Country, country));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new City { Name = null });
      Assert.Throws<ArgumentException>(() => new City { Name = string.Empty });
      
      Assert.Equal("name", new City { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.Region"/> property.</para>
    /// </summary>
    [Fact]
    public void Region_Property()
    {
      Assert.Equal("region", new City { Region = "region" }.Region);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.CompareTo(City)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
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
      this.TestEquality("Country", new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
      this.TestEquality("Name", "first", "second");
      this.TestEquality("Region", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Country", new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
      this.TestHashCode("Name", "first", "second");
      this.TestHashCode("Region", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="City.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new City { Name = "name" }.ToString());
    }
  }
}