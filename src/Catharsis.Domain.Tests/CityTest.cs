using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class CityTest : EntityTest<City>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new City();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Area);
      Assert.Null(fixture.Country);
      Assert.Null(fixture.Federal);
      Assert.Null(fixture.Location);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Region);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Area", new Area { Name = "first" }, new Area { Name = "second" });
      this.test_equals_and_hash_code("Country", new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
      this.test_equals_and_hash_code("Name", "first", "second");
      this.test_equals_and_hash_code("Region", new Region { Name = "first" }, new Region { Name = "second" });
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new City().ToString());
      Assert.Empty(new City { Name = string.Empty }.ToString());
      Assert.Empty(new City { Name = " " }.ToString());
      Assert.Equal("name", new City { Name = " name " }.ToString());
    }
  }
}