using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class NewsExtensionsTests
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<News>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new News[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new News[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new News { Name = "First" }, new News { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<News>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new News[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new News[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new News(), new News { Name = "First" }, new News { Name = "Second" } }.Name("f"));
    }

    [Fact]
    public void tag_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<News>)null).Tag(new Tag()));
      Assert.Throws<ArgumentNullException>(() => new News[] { }.AsQueryable().Tag(null));

      Assert.Equal(1, new[] { new News { Tags = new HashSet<Tag> { new Tag { Name = "first" } } }, new News { Tags = new HashSet<Tag> { new Tag { Name = "second" } } } }.AsQueryable().Tag(new Tag { Name = "first" }).Count());
    }

    [Fact]
    public void tag_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<News>)null).Tag(new Tag()));
      Assert.Throws<ArgumentNullException>(() => new News[] { }.Tag(null));

      Assert.Single(new[] { null, new News(), new News { Tags = new HashSet<Tag> { new Tag { Name = "first" } } }, new News { Tags = new HashSet<Tag> { new Tag { Name = "second" } } } }.Tag(new Tag { Name = "first" }));
    }
  }
}