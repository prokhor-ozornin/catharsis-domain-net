using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class LocationExtensionsTests
  {
    [Fact]
    public void latitude_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Location>)null).Latitude());

      var locations = new[] { new Location { Latitude = 1 }, new Location { Latitude = 2 } }.AsQueryable();
      Assert.Equal(2, locations.Latitude().Count());
      Assert.Equal(2, locations.Latitude(0).Count());
      Assert.Empty(locations.Latitude(3));
      Assert.Equal(1, locations.Latitude(0, 1).Count());
      Assert.Equal(2, locations.Latitude(1, 2).Count());
      Assert.Empty(locations.Latitude(to: 0));
      Assert.Equal(1, locations.Latitude(to: 1).Count());
      Assert.Equal(2, locations.Latitude(to: 3).Count());
    }

    [Fact]
    public void latitude_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Location>)null).Latitude());

      var locations = new[] { null, new Location(), new Location { Latitude = 1 }, new Location { Latitude = 2 } };
      Assert.Equal(3, locations.Latitude().Count());
      Assert.Equal(2, locations.Latitude(0).Count());
      Assert.Empty(locations.Latitude(3));
      Assert.Equal(1, locations.Latitude(0, 1).Count());
      Assert.Equal(2, locations.Latitude(1, 2).Count());
      Assert.Empty(locations.Latitude(to: 0));
      Assert.Equal(1, locations.Latitude(to: 1).Count());
      Assert.Equal(2, locations.Latitude(to: 3).Count());
    }

    [Fact]
    public void longitude_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Location>)null).Longitude());

      var locations = new[] { new Location { Longitude = 1 }, new Location { Longitude = 2 } }.AsQueryable();
      Assert.Equal(2, locations.Longitude().Count());
      Assert.Equal(2, locations.Longitude(0).Count());
      Assert.Empty(locations.Longitude(3));
      Assert.Equal(1, locations.Longitude(0, 1).Count());
      Assert.Equal(2, locations.Longitude(1, 2).Count());
      Assert.Empty(locations.Longitude(to: 0));
      Assert.Equal(1, locations.Longitude(to: 1).Count());
      Assert.Equal(2, locations.Longitude(to: 3).Count());
    }

    [Fact]
    public void longitude_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Location>)null).Longitude());

      var locations = new[] { null, new Location(), new Location { Longitude = 1 }, new Location { Longitude = 2 } };
      Assert.Equal(3, locations.Longitude().Count());
      Assert.Equal(2, locations.Longitude(0).Count());
      Assert.Empty(locations.Longitude(3));
      Assert.Equal(1, locations.Longitude(0, 1).Count());
      Assert.Equal(2, locations.Longitude(1, 2).Count());
      Assert.Empty(locations.Longitude(to: 0));
      Assert.Equal(1, locations.Longitude(to: 1).Count());
      Assert.Equal(2, locations.Longitude(to: 3).Count());
    }

    [Fact]
    public void timezone_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Location>)null).Timezone("timezone"));
      Assert.Throws<ArgumentNullException>(() => new Location[] { }.AsQueryable().Timezone(null));
      Assert.Throws<ArgumentException>(() => new Location[] { }.AsQueryable().Timezone(string.Empty));

      Assert.Equal(1, new[] { new Location { Timezone = "First" }, new Location { Timezone = "Second" } }.AsQueryable().Timezone("f").Count());
    }

    [Fact]
    public void timezone_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Location>)null).Timezone("timezone"));
      Assert.Throws<ArgumentNullException>(() => new Location[] { }.Timezone(null));
      Assert.Throws<ArgumentException>(() => new Location[] { }.Timezone(string.Empty));

      Assert.Equal(1, new[] { null, new Location(), new Location { Timezone = "First" }, new Location { Timezone = "Second" } }.Timezone("f").Count());
    }
  }
}