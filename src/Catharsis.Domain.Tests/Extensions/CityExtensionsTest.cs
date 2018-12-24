using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class CityExtensionsTests
  {
    [Fact]
    public void area_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<City>)null).Area(new Area()));

      Assert.Equal(1, new[] { new City { Area = new Area { Id = 1 } }, new City { Area = new Area { Id = 2 } } }.AsQueryable().Area(new Area { Id = 1 }).Count());
      Assert.Equal(1, new[] { new City { Area = new Area { Id = 1 } }, new City { Area = null } }.AsQueryable().Area(null).Count());
    }

    [Fact]
    public void area_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<City>)null).Area(new Area()));

      Assert.Single(new[] { null, new City { Area = new Area { Name = "first" } }, new City { Area = new Area { Name = "second" } } }.Area(new Area { Name = "first" }));
      Assert.Single(new[] { null, new City(), new City { Area = new Area { Name = "first" } } }.Area(null));
    }

    [Fact]
    public void country_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<City>)null).Country(new Country()));

      Assert.Equal(1, new[] { new City { Country = new Country { Id = 1 } }, new City { Country = new Country { Id = 2 } } }.AsQueryable().Country(new Country { Id = 1 }).Count());
      Assert.Equal(1, new[] { new City { Country = new Country { Id = 1 } }, new City { Country = null } }.AsQueryable().Country(null).Count());
    }

    [Fact]
    public void country_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<City>)null).Country(new Country()));

      Assert.Single(new[] { null, new City { Country = new Country { IsoCode = "first" } }, new City { Country = new Country { IsoCode = "second" } } }.Country(new Country { IsoCode = "first" }));
      Assert.Single(new[] { null, new City(), new City { Country = new Country { IsoCode = "first" } } }.Country(null));
    }

    [Fact]
    public void federal_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<City>)null).Federal(true));

      Assert.Equal(1, new[] { new City { Federal = false }, new City { Federal = true } }.AsQueryable().Federal(true).Count());
    }

    [Fact]
    public void federal_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Audio>)null).Bitrate(0));

      Assert.Single(new[] { null, new City(), new City { Federal = false }, new City { Federal = true } }.Federal(true));
    }

    [Fact]
    public void region_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<City>)null).Region(new Region()));

      Assert.Equal(1, new[] { new City { Region = new Region { Id = 1 } }, new City { Region = new Region { Id = 2 } } }.AsQueryable().Region(new Region { Id = 1 }).Count());
      Assert.Equal(1, new[] { new City { Region = new Region { Id = 1 } }, new City { Region = null } }.AsQueryable().Region(null).Count());
    }

    [Fact]
    public void region_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<City>)null).Region(new Region()));

      Assert.Single(new[] { null, new City { Region = new Region { Name = "first" } }, new City { Region = new Region { Name = "second" } } }.Region(new Region { Name = "first" }));
      Assert.Single(new[] { null, new City(), new City { Region = new Region { Name = "first" } } }.Region(null));
    }
  }
}