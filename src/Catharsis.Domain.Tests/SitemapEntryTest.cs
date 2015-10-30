using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class SitemapEntryTest : EntityTest<SitemapEntry>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new SitemapEntry();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.ChangeFrequency);
      Assert.Null(fixture.Date);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Priority);
      Assert.Null(fixture.Uri);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Uri", new Uri("schema://first"), new Uri("schema://second"));
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Uri", new Uri("schema://first"), new Uri("schema://second"));
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new SitemapEntry().ToString());
      Assert.Equal("schema://uri/", new SitemapEntry { Uri = new Uri("schema://uri") }.ToString());
    }
  }
}