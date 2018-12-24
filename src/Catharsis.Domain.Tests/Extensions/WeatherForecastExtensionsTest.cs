using Catharsis.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WeatherForecastExtensionsTest
  {
    [Fact]
    public void city_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WeatherForecast>)null).City(new City()));

      Assert.Equal(1, new[] { new WeatherForecast { City = new City { Id = 1 } }, new WeatherForecast { City = new City { Id = 2 } } }.AsQueryable().City(new City { Id = 1 }).Count());
      Assert.Equal(1, new[] { new WeatherForecast { City = new City { Id = 1 } }, new WeatherForecast { City = null } }.AsQueryable().City(null).Count());
    }

    [Fact]
    public void city_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WeatherForecast>)null).City(new City()));

      Assert.Single(new[] { null, new WeatherForecast { City = new City { Name = "first" } }, new WeatherForecast { City = new City { Name = "second" } } }.City(new City { Name = "first" }));
      Assert.Single(new[] { null, new WeatherForecast(), new WeatherForecast { City = new City { Name = "first" } } }.City(null));
    }

    [Fact]
    public void date_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WeatherForecast>)null).Date());

      var entries = new[] { new WeatherForecast { Date = new DateTime(2000, 1, 1) }, new WeatherForecast { Date = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, entries.Date().Count());
      Assert.Equal(2, entries.Date(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entries.Date(new DateTime(2000, 1, 3)));
      Assert.Equal(1, entries.Date(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entries.Date(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entries.Date(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, entries.Date(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, entries.Date(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void date_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WeatherForecast>)null).Date());

      var entries = new[] { null, new WeatherForecast(), new WeatherForecast { Date = new DateTime(2000, 1, 1) }, new WeatherForecast { Date = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, entries.Date().Count());
      Assert.Equal(2, entries.Date(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(entries.Date(new DateTime(2000, 1, 3)));
      Assert.Single(entries.Date(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)));
      Assert.Equal(2, entries.Date(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(entries.Date(to: new DateTime(1999, 12, 31)));
      Assert.Single(entries.Date(to: new DateTime(2000, 1, 1)));
      Assert.Equal(2, entries.Date(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void type_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WeatherForecast>)null).Type(WeatherType.Thunderstorm));

      Assert.Equal(1, new[] { new WeatherForecast { Type = WeatherType.ClearSky }, new WeatherForecast { Type = WeatherType.Thunderstorm } }.AsQueryable().Type(WeatherType.ClearSky).Count());
    }

    [Fact]
    public void type_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WeatherForecast>)null).Type(WeatherType.ClearSky));

      Assert.Single(new[] { null, new WeatherForecast(), new WeatherForecast { Type = WeatherType.ClearSky }, new WeatherForecast { Type = WeatherType.Thunderstorm } }.Type(WeatherType.ClearSky));
    }
  }
}