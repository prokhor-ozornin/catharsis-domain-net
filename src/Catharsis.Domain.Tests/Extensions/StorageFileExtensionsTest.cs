using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class StorageFileExtensionsTests
  {
    [Fact]
    public void content_type_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<StorageFile>)null).ContentType("locale"));
      Assert.Throws<ArgumentNullException>(() => new StorageFile[] { }.AsQueryable().ContentType(null));
      Assert.Throws<ArgumentException>(() => new StorageFile[] { }.AsQueryable().ContentType(string.Empty));

      Assert.Equal(1, new[] { new StorageFile { ContentType = "First" }, new StorageFile { ContentType = "Second" } }.AsQueryable().ContentType("first").Count());
    }

    [Fact]
    public void content_type_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<StorageFile>)null).ContentType("name"));
      Assert.Throws<ArgumentNullException>(() => new StorageFile[] { }.ContentType(null));
      Assert.Throws<ArgumentException>(() => new StorageFile[] { }.ContentType(string.Empty));

      Assert.Equal(1, new[] { null, new StorageFile(), new StorageFile { ContentType = "First" }, new StorageFile { ContentType = "Second" } }.ContentType("first").Count());
    }

    [Fact]
    public void storage_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<StorageFile>)null).Storage("storage"));
      Assert.Throws<ArgumentNullException>(() => new StorageFile[] { }.AsQueryable().Storage(null));
      Assert.Throws<ArgumentException>(() => new StorageFile[] { }.AsQueryable().Storage(string.Empty));

      Assert.Equal(1, new[] { new StorageFile { Storage = "First" }, new StorageFile { Storage = "Second" } }.AsQueryable().Storage("first").Count());
    }

    [Fact]
    public void storage_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<StorageFile>)null).Storage("name"));
      Assert.Throws<ArgumentNullException>(() => new StorageFile[] { }.Storage(null));
      Assert.Throws<ArgumentException>(() => new StorageFile[] { }.Storage(string.Empty));

      Assert.Equal(1, new[] { null, new StorageFile(), new StorageFile { Storage = "First" }, new StorageFile { Storage = "Second" } }.Storage("first").Count());
    }
  }
}