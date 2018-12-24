using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ImageTest : EntityTest<Image>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Image();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.File);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("File", new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
      this.test_equals_and_hash_code("Uri", new Uri("schema://first"), new Uri("schema://second"));
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Image().ToString());
      Assert.Equal("schema://uri/", new Image { Uri = new Uri("schema://uri") }.ToString());
    }
  }
}