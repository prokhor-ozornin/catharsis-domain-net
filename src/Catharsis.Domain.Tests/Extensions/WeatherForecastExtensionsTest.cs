using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WeatherForecastExtensions"/>.</para>
/// </summary>
public sealed class WeatherForecastExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecastExtensions.City(IQueryable{WeatherForecast}, City?)"/> method.</para>
  /// </summary>
  [Fact]
  public void City_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WeatherForecast>) null).City(new City())).ThrowExactly<ArgumentNullException>();

    new[] {new WeatherForecast {City = new City {Id = 1}}, new WeatherForecast {City = new City {Id = 2}}}.AsQueryable().City(new City {Id = 1}).Should().ContainSingle();
    new[] {new WeatherForecast {City = new City {Id = 1}}, new WeatherForecast {City = null}}.AsQueryable().City(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecastExtensions.City(IEnumerable{WeatherForecast}, City?)"/> method.</para>
  /// </summary>
  [Fact]
  public void City_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WeatherForecast>) null).City(new City())).ThrowExactly<ArgumentNullException>();

    new[] {null, new WeatherForecast {City = new City {Name = "first"}}, new WeatherForecast {City = new City {Name = "second"}}}.City(new City {Name = "first"}).Should().ContainSingle();
    new[] {null, new WeatherForecast(), new WeatherForecast {City = new City {Name = "first"}}}.City(null).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecastExtensions.Date(IQueryable{WeatherForecast}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Date_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WeatherForecast>) null).Date()).ThrowExactly<ArgumentNullException>();

    var entries = new[] {new WeatherForecast {Date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute:0, second: 0, TimeSpan.Zero)}, new WeatherForecast {Date = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}}.AsQueryable();
    entries.Date().Should().HaveCount(2);
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecastExtensions.Date(IEnumerable{WeatherForecast}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Date_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WeatherForecast>) null).Date()).ThrowExactly<ArgumentNullException>();

    var entries = new[] {null, new WeatherForecast(), new WeatherForecast {Date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new WeatherForecast {Date = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    entries.Date().Should().HaveCount(3);
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecastExtensions.Type(IQueryable{WeatherForecast}, WeatherForecast.WeatherType?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WeatherForecast>) null).Type(WeatherForecast.WeatherType.Thunderstorm)).ThrowExactly<ArgumentNullException>();

    new[] {new WeatherForecast {Type = WeatherForecast.WeatherType.ClearSky}, new WeatherForecast {Type = WeatherForecast.WeatherType.Thunderstorm}}.AsQueryable().Type(WeatherForecast.WeatherType.ClearSky).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecastExtensions.Type(IEnumerable{WeatherForecast}, WeatherForecast.WeatherType?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WeatherForecast>) null).Type(WeatherForecast.WeatherType.ClearSky)).ThrowExactly<ArgumentNullException>();

    new[] {null, new WeatherForecast(), new WeatherForecast {Type = WeatherForecast.WeatherType.ClearSky}, new WeatherForecast {Type = WeatherForecast.WeatherType.Thunderstorm}}.Type(WeatherForecast.WeatherType.ClearSky).Should().ContainSingle();
  }
}