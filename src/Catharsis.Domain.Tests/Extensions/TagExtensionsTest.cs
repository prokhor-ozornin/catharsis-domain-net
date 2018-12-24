using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class TagExtensionsTests
  {
    [Fact]
    public void for_name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Tag>)null).ForName("name"));
      Assert.Throws<ArgumentNullException>(() => new Tag[] { }.AsQueryable().ForName(null));
      Assert.Throws<ArgumentException>(() => new Tag[] { }.AsQueryable().ForName(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Tag { Name = "Name" }, new Tag { Name = "name" } }.AsQueryable().ForName("name"));

      Assert.Null(new Tag[] { }.AsQueryable().ForName("name"));
      Assert.NotNull(new[] { new Tag { Name = "First" }, new Tag { Name = "Second" } }.AsQueryable().ForName("first"));
    }

    [Fact]
    public void for_name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Tag>)null).ForName("name"));
      Assert.Throws<ArgumentNullException>(() => new Tag[] { }.ForName(null));
      Assert.Throws<ArgumentException>(() => new Tag[] { }.ForName(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Tag { Name = "Name" }, new Tag { Name = "name" } }.ForName("name"));

      Assert.Null(new Tag[] { }.ForName("name"));
      Assert.NotNull(new[] { new Tag { Name = "First" }, new Tag { Name = "Second" } }.ForName("first"));
    }
  }
}