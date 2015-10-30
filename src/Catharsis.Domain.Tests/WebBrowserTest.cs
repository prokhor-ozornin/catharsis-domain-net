using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WebBrowserTest : EntityTest<WebBrowser>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new WebBrowser();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Uri);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("UserAgent", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("UserAgent", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new WebBrowser().ToString());
      Assert.Empty(new WebBrowser { UserAgent = string.Empty }.ToString());
      Assert.Empty(new WebBrowser { UserAgent = " " }.ToString());
      Assert.Equal("userAgent", new WebBrowser { UserAgent = " userAgent " }.ToString());
    }
  }
}