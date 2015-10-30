using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class LocationTest : EntityTest<Location>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Location();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Latitude);
      Assert.Null(fixture.Longitude);
      Assert.Null(fixture.Timezone);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Latitude", (decimal) 0, (decimal) 1);
      this.test_equals_and_hash_code("Longitude", (decimal) 0, (decimal) 1);
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Location().ToString());
      Assert.Equal("56.838607,60.605514", new Location { Latitude = (decimal) 56.838607, Longitude = (decimal) 60.605514 }.ToString());
    }
  }
}