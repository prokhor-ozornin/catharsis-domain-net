using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WebPageTest : EntityTest<WebPage>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new WebPage();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Locale);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Text);
      Assert.Null(fixture.Uri);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Locale", "first", "second");
      this.test_equals_and_hash_code("Uri", new Uri("schema://first"), new Uri("schema://second"));
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new WebPage().ToString());
      Assert.Empty(new WebPage { Name = string.Empty }.ToString());
      Assert.Empty(new WebPage { Name = " " }.ToString());
      Assert.Equal("name", new WebPage { Name = " name " }.ToString());
    }
  }
}