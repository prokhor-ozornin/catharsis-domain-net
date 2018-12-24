using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AddressTest : EntityTest<Address>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Address();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.City);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Location);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Zip);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Address().ToString());
      Assert.Empty(new Address { Name = string.Empty, Zip = string.Empty }.ToString());
      Assert.Empty(new Address { Name = string.Empty, Zip = string.Empty }.ToString());
      Assert.Equal("Екатеринбург", new Address { City = new City { Name = "Екатеринбург" } }.ToString());
      Assert.Equal("Екатеринбург,Свердлова", new Address { City = new City { Name = "Екатеринбург" }, Name = "Свердлова" }.ToString());
      Assert.Equal("Екатеринбург,Свердлова,620000", new Address { City = new City { Name = "Екатеринбург" }, Name = "Свердлова", Zip = "620000" }.ToString());
    }
  }
}