using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WeatherForecast"/>.</para>
/// </summary>
public sealed class WeatherForecastTest : EntityTest<WeatherForecast>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.City"/> property.</para>
  /// </summary>
  [Fact]
  public void City_Property()
  {
    var city = new City();
    new WeatherForecast { City = city }.City.Should().BeSameAs(city);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new WeatherForecast { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property()
  {
    new WeatherForecast { Type = WeatherForecast.WeatherType.ClearSky }.Type.Should().Be(WeatherForecast.WeatherType.ClearSky);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.Temperature"/> property.</para>
  /// </summary>
  [Fact]
  public void Temperature_Property()
  {
    new WeatherForecast { Temperature = short.MaxValue }.Temperature.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.Humidity"/> property.</para>
  /// </summary>
  [Fact]
  public void Humidity_Property()
  {
    new WeatherForecast { Humidity = byte.MaxValue }.Humidity.Should().Be(byte.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.Pressure"/> property.</para>
  /// </summary>
  [Fact]
  public void Pressure_Property()
  {
    new WeatherForecast { Pressure = short.MaxValue }.Pressure.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.Cloudiness"/> property.</para>
  /// </summary>
  [Fact]
  public void Cloudiness_Property()
  {
    new WeatherForecast { Cloudiness = byte.MaxValue }.Cloudiness.Should().Be(byte.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.WindDirection"/> property.</para>
  /// </summary>
  [Fact]
  public void WindDirection_Property()
  {
    new WeatherForecast { WindDirection = decimal.MaxValue }.WindDirection.Should().Be(decimal.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.WindSpeed"/> property.</para>
  /// </summary>
  [Fact]
  public void WindSpeed_Property()
  {
    new WeatherForecast { WindSpeed = decimal.MaxValue }.WindSpeed.Should().Be(decimal.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WeatherForecast()"/>
  [Fact]
  public void Constructors()
  {
    var forecast = new WeatherForecast();

    forecast.Id.Should().BeNull();
    forecast.Uuid.Should().NotBeNull();
    forecast.Version.Should().BeNull();
    forecast.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    forecast.UpdatedOn.Should().BeNull();

    forecast.City.Should().BeNull();
    forecast.Date.Should().BeNull();
    forecast.Type.Should().BeNull();
    forecast.Temperature.Should().BeNull();
    forecast.Humidity.Should().BeNull();
    forecast.Pressure.Should().BeNull();
    forecast.Cloudiness.Should().BeNull();
    forecast.WindDirection.Should().BeNull();
    forecast.WindSpeed.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.CompareTo(WeatherForecast)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(WeatherForecast.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="WeatherForecast.Equals(WeatherForecast)"/></description></item>
  ///     <item><description><see cref="WeatherForecast.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(WeatherForecast.City), new City { Name = "first" }, new City { Name = "second" });
    TestEquality(nameof(WeatherForecast.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WeatherForecast.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(WeatherForecast.City), new City { Name = "first" }, new City { Name = "second" });
    TestHashCode(nameof(WeatherForecast.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }
}