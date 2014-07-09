using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LocationExtensions"/>.</para>
  /// </summary>
  public sealed class LocationExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LocationExtensions.Address(IQueryable{Location}, string)"/></description></item>
    ///     <item><description><see cref="LocationExtensions.Address(IEnumerable{Location}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void WithAddress_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Location>)null).Address(string.Empty));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Location>)null).Address(string.Empty));
      
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Location>().AsQueryable().Address(null));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Location>().Address(null));

      Assert.Equal(1, new[] { new Location { Address = "first" }, new Location { Address = "second" } }.AsQueryable().Address("first").Count());
      Assert.Equal(1, new[] { null, new Location { Address = "first" }, null, new Location { Address = "second" } }.Address("first").Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LocationExtensions.City(IQueryable{Location}, City)"/></description></item>
    ///     <item><description><see cref="LocationExtensions.City(IEnumerable{Location}, City)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void City_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Location>) null).City(new City()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Location>)null).City(new City()));

      Assert.False(Enumerable.Empty<Location>().AsQueryable().City(new City()).Any());
      Assert.False(Enumerable.Empty<Location>().City(new City()).Any());

      Assert.Equal(1, new[] { new Location { City = new City { Id = 1 } }, new Location { City = new City { Id = 2 } } }.AsQueryable().City(new City { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Location { City = new City { Name = "first" } }, null, new Location { City = new City { Name = "second" } } }.City(new City { Name = "first" }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LocationExtensions.PostalCode(IQueryable{Location}, string)"/></description></item>
    ///     <item><description><see cref="LocationExtensions.PostalCode(IEnumerable{Location}, string)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void PostalCode_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Location>) null).PostalCode("postalCode"));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Location>)null).PostalCode("postalCode"));

      Assert.False(Enumerable.Empty<Location>().PostalCode(null).AsQueryable().Any());
      Assert.False(Enumerable.Empty<Location>().PostalCode(null).Any());

      Assert.Equal(1, new[] { new Location { PostalCode = "first" }, new Location { PostalCode = "second" } }.AsQueryable().PostalCode("first").Count());
      Assert.Equal(1, new[] { null, new Location { PostalCode = "first" }, null, new Location { PostalCode = "second" } }.PostalCode("first").Count());
    }
  }
}