using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AreaTest : EntityTest<Area>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Area();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Country);
      Assert.Null(fixture.Name);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Country", new Country { IsoCode = "first" }, new Country { IsoCode = "second" });
      this.test_equals_and_hash_code("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Area().ToString());
      Assert.Empty(new Area { Name = string.Empty }.ToString());
      Assert.Empty(new Area { Name = " " }.ToString());
      Assert.Equal("name", new Area { Name = " name " }.ToString());
    }
  }
}