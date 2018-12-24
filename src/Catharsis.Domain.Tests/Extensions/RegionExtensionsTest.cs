using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class RegionExtensionsTests
  {
    [Fact]
    public void area_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Region>)null).Area(new Area()));

      Assert.Equal(1, new[] { new Region { Area = new Area { Id = 1 } }, new Region { Area = new Area { Id = 2 } } }.AsQueryable().Area(new Area { Id = 1 }).Count());
      Assert.Equal(1, new[] { new Region { Area = new Area { Id = 1 } }, new Region { Area = null } }.AsQueryable().Area(null).Count());
    }

    [Fact]
    public void area_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Region>)null).Area(new Area()));

      Assert.Single(new[] { null, new Region { Area = new Area { Name = "first" } }, new Region { Area = new Area { Name = "second" } } }.Area(new Area { Name = "first" }));
      Assert.Single(new[] { null, new Region(), new Region { Area = new Area { Name = "first" } } }.Area(null));
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Region>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Region[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Region[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Region { Name = "First" }, new Region { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Region>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Region[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Region[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new Region(), new Region { Name = "First" }, new Region { Name = "Second" } }.Name("f"));
    }
  }
}