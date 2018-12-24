using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ApiKeyExtensionsTest
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<ApiKey>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new ApiKey[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new ApiKey[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new ApiKey { AppName = "Third", Name = "First" }, new ApiKey { AppName = "Third", Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<ApiKey>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new ApiKey[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new ApiKey[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new ApiKey(), new ApiKey { Name = "First" }, new ApiKey { Name = "Second" } }.Name("f"));
    }
  }
}