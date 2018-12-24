using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WeatherForecastTest : EntityTest<WeatherForecast>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new WeatherForecast();
      Assert.Null(fixture.Id);
      Assert.Null(fixture.City);
      Assert.Null(fixture.Cloudiness);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.Date);
      Assert.Null(fixture.Humidity);
      Assert.Null(fixture.Pressure);
      Assert.Null(fixture.Temperature);
      Assert.Null(fixture.Type);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.WindDirection);
      Assert.Null(fixture.WindSpeed);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("City", new City { Name = "first" }, new City { Name = "second" });
      this.test_equals_and_hash_code("Date", DateTime.MinValue, DateTime.MaxValue);
    }
  }
}