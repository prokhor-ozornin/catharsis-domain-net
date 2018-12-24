using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class DownloadTest : EntityTest<Download>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Download();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Downloads);
      Assert.Null(fixture.File);
      Assert.Null(fixture.Image);
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
      this.test_equals_and_hash_code("File", new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Download().ToString());
      Assert.Empty(new Download { Name = string.Empty }.ToString());
      Assert.Empty(new Download { Name = " " }.ToString());
      Assert.Equal("name", new Download { Name = " name " }.ToString());
    }
  }
}