using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class CountryTest : EntityTest<Country>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Country();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Currency);
      Assert.Null(fixture.CurrencyCode);
      Assert.Null(fixture.IsoCode);
      Assert.Null(fixture.Language);
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
      this.test_equals_and_hash_code("IsoCode", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Country().ToString());
      Assert.Empty(new Country { Name = string.Empty }.ToString());
      Assert.Empty(new Country { Name = " " }.ToString());
      Assert.Equal("name", new Country { Name = " name " }.ToString());
    }
  }
}