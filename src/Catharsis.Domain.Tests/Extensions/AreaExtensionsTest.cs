using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AreaExtensionsTests
  {
    [Fact]
    public void country_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Area>)null).Country(new Country()));

      Assert.Equal(1, new[] { new Area { Country = new Country { Id = 1 } }, new Area { Country = new Country { Id = 2 } } }.AsQueryable().Country(new Country { Id = 1 }).Count());
      Assert.Equal(1, new[] { new Area { Country = new Country { Id = 1 } }, new Area { Country = null } }.AsQueryable().Country(null).Count());
    }

    [Fact]
    public void country_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Area>)null).Country(new Country()));

      Assert.Single(new[] { null, new Area { Country = new Country { IsoCode = "first" } }, new Area { Country = new Country { IsoCode = "second" } } }.Country(new Country { IsoCode = "first" }));
      Assert.Single(new[] { null, new Area(), new Area { Country = new Country { IsoCode = "first" } } }.Country(null));
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Area>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Area[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Area[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Area { Name = "First" }, new Area { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Area>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Area[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Area[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new Area(), new Area { Name = "First" }, new Area { Name = "Second" } }.Name("f"));
    }
  }
}