using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class StorageFileTest : EntityTest<StorageFile>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new StorageFile();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.ContentType);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Path);
      Assert.Null(fixture.Size);
      Assert.Null(fixture.Storage);
    }

    [Fact]
    public void full_path()
    {
      Assert.Empty(new StorageFile().FullPath);
      Assert.Empty(new StorageFile { Path = string.Empty, Name = string.Empty }.FullPath);
      Assert.Equal("/", new StorageFile { Path = " ", Name = " " }.FullPath);
      Assert.Equal("/", new StorageFile { Path = "/" }.FullPath);
      Assert.Equal("\\", new StorageFile { Path = "\\" }.FullPath);
      Assert.Equal("path/name", new StorageFile { Path = "path", Name = "name" }.FullPath);
      Assert.Equal("/path/name/", new StorageFile { Path = "/path/", Name = "name/" }.FullPath);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Name", "first", "second");
      this.test_equals_and_hash_code("Path", "first", "second");
      this.test_equals_and_hash_code("Storage", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new StorageFile().ToString());
      Assert.Empty(new StorageFile { Path = string.Empty, Name = string.Empty }.ToString());
      Assert.Equal("/", new StorageFile { Path = " ", Name = " " }.ToString());
      Assert.Equal("/", new StorageFile { Path = "/" }.ToString());
      Assert.Equal("\\", new StorageFile { Path = "\\" }.ToString());
      Assert.Equal("path/name", new StorageFile { Path = "path", Name = "name" }.ToString());
      Assert.Equal("/path/name/", new StorageFile { Path = "/path/", Name = "name/" }.ToString());
    }
  }
}