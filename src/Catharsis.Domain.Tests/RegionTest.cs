using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class RegionTest : EntityTest<Region>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Region();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Area);
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
      this.test_equals_and_hash_code("Area", new Area { Name = "first" }, new Area { Name = "second" });
      this.test_equals_and_hash_code("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Region().ToString());
      Assert.Empty(new Region { Name = string.Empty }.ToString());
      Assert.Empty(new Region { Name = " " }.ToString());
      Assert.Equal("value", new Region { Name = " value " }.ToString());
    }
  }
}