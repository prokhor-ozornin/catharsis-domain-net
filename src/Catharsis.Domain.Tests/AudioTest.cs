using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AudioTest : EntityTest<Audio>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Audio();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Bitrate);
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
      Assert.Empty(new Audio().ToString());
      Assert.Equal("schema://uri/", new Audio { Uri = new Uri("schema://uri") }.ToString());
    }
  }
}