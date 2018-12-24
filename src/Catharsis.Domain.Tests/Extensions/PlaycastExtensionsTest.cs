using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class PlaycastExtensionsTest
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Playcast>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Playcast[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Playcast[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Playcast { Name = "First" }, new Playcast { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Playcast>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Playcast[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Playcast[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new Playcast(), new Playcast { Name = "First" }, new Playcast { Name = "Second" } }.Name("f"));
    }

    [Fact]
    public void tag_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Playcast>)null).Tag(new Tag()));
      Assert.Throws<ArgumentNullException>(() => new Playcast[] { }.AsQueryable().Tag(null));

      Assert.Equal(1, new[] { new Playcast { Tags = new HashSet<Tag> { new Tag { Name = "first" } } }, new Playcast { Tags = new HashSet<Tag> { new Tag { Name = "second" } } } }.AsQueryable().Tag(new Tag { Name = "first" }).Count());
    }

    [Fact]
    public void tag_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Playcast>)null).Tag(new Tag()));
      Assert.Throws<ArgumentNullException>(() => new Playcast[] { }.Tag(null));

      Assert.Single(new[] { null, new Playcast(), new Playcast { Tags = new HashSet<Tag> { new Tag { Name = "first" } } }, new Playcast { Tags = new HashSet<Tag> { new Tag { Name = "second" } } } }.Tag(new Tag { Name = "first" }));
    }
  }
}