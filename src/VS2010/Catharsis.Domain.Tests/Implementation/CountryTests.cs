using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Country"/>.</para>
  /// </summary>
  public sealed class CountryTests : EntityUnitTests<Country>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Image", "IsoCode", "Name");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var country = new Country();
      this.TestJson(country, new { Id = 0 });

      country = new Country("name", "isoCode");
      this.TestJson(country, new { Id = 0, IsoCode = "isoCode", Name = "name" });

      country = new Country("name", "isoCode", "image")
      {
        Id = 1 
      };
      this.TestJson(country, new { Id = 1, Image = "image", IsoCode = "isoCode", Name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var country = new Country();
      this.TestXml(country, new { Id = 0 });

      country = new Country("name", "isoCode");
      this.TestXml(country, new { Id = 0, IsoCode = "isoCode", Name = "name" });

      country = new Country("name", "isoCode", "image")
      {
        Id = 1
      };
      this.TestXml(country, new { Id = 1, Image = "image", IsoCode = "isoCode", Name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Country()"/>
    /// <seealso cref="Country(string, string, string)"/>
    [Fact]
    public void Constructors()
    {
      var country = new Country();
      Assert.Equal(0, country.Id);
      Assert.Null(country.Image);
      Assert.Null(country.IsoCode);
      Assert.Null(country.Name);
      Assert.Equal(0, country.Version);

      Assert.Throws<ArgumentNullException>(() => new Country(null, "isoCode"));
      Assert.Throws<ArgumentNullException>(() => new Country("name", null));
      Assert.Throws<ArgumentException>(() => new Country(string.Empty, null));
      country = new Country("name", "isoCode", "image");
      Assert.Equal(0, country.Id);
      Assert.NotNull(country.Image);
      Assert.Equal("isoCode", country.IsoCode);
      Assert.Equal("name", country.Name);
      Assert.Equal(0, country.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Country.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new Country { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Country.IsoCode"/> property.</para>
    /// </summary>
    [Fact]
    public void IsoCode_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Country { IsoCode = null });
      Assert.Throws<ArgumentException>(() => new Country { IsoCode = string.Empty });
      
      Assert.Equal("isoCode", new Country { IsoCode = "isoCode" }.IsoCode);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Country.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Country { Name = null });
      Assert.Throws<ArgumentException>(() => new Country { Name = string.Empty });
      
      Assert.Equal("name", new Country { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Country.CompareTo(Country)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Country.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Country { Name = "name" }.ToString());
    }
  }
}