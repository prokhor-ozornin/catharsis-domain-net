using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class MediaTest : EntityTest<Media>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Media();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.AuthorName);
      Assert.Null(fixture.AuthorUri);
      Assert.Null(fixture.ContentType);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Duration);
      Assert.Null(fixture.Height);
      Assert.Null(fixture.Html);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.ProviderUri);
      Assert.Null(fixture.ThumbnailHeight);
      Assert.Null(fixture.ThumbnailUri);
      Assert.Null(fixture.ThumbnailWidth);
      Assert.Null(fixture.Uri);
      Assert.Null(fixture.Width);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Uri", new Uri("schema://first"), new Uri("schema://second"));
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Media().ToString());
      Assert.Equal("schema://uri/", new Media { Uri = new Uri("schema://uri") }.ToString());
    }
  }
}