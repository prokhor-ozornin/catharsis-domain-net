using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WebLinkTest : EntityTest<WebLink>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new WebLink();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Image); 
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Uri);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Uri", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Uri", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new WebLink().ToString());
      Assert.Equal("schema://uri", new WebLink { Uri = "schema://uri" }.ToString());
    }
  }
}