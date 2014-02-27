using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="CityExtensions"/>.</para>
  /// </summary>
  public sealed class CityExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="CityExtensions.Country(IQueryable{City}, Country)"/></description></item>
    ///     <item><description><see cref="CityExtensions.Country(IEnumerable{City}, Country)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void WithCountry_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<City>) null).Country(new Country()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<City>)null).Country(new Country()));

      Assert.False(Enumerable.Empty<City>().AsQueryable().Country(null).Any());
      Assert.False(Enumerable.Empty<City>().Country(null).Any());

      Assert.False(Enumerable.Empty<City>().AsQueryable().Country(new Country()).Any());
      Assert.False(Enumerable.Empty<City>().Country(new Country()).Any());

      Assert.Equal(1, new[] { new City { Country = new Country { Id = 1 } }, new City { Country = new Country { Id = 2 } } }.AsQueryable().Country(new Country { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new City { Country = new Country { IsoCode = "first" } }, null, new City { Country = new Country { IsoCode = "second" } } }.Country(new Country { IsoCode = "first" }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="CityExtensions.Region(IQueryable{City}, string)"/></description></item>
    ///     <item><description><see cref="CityExtensions.Region(IEnumerable{City}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void WithRegion_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<City>) null).Region("Region"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<City>)null).Region("Region"));

      Assert.False(Enumerable.Empty<City>().Region(null).Any());
      Assert.False(Enumerable.Empty<City>().Region(string.Empty).Any());

      Assert.Equal(1, new[] { new City { Region = "first" }, new City { Region = "second" } }.AsQueryable().Region("first").Count());
      Assert.Equal(1, new[] { null, new City { Region = "first" }, null, new City { Region = "second" } }.Region("first").Count());
    }
  }
}