using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AddressExtensionsTest
  {
    [Fact]
    public void city_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Address>)null).City(new City()));

      Assert.Equal(1, new[] { new Address { City = new City { Id = 1 } }, new Address { City = new City { Id = 2 } } }.AsQueryable().City(new City { Id = 1 }).Count());
      Assert.Equal(1, new[] { new Address { City = new City { Id = 1 } }, new Address { City = null } }.AsQueryable().City(null).Count());
    }

    [Fact]
    public void city_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Address>)null).City(new City()));

      Assert.Equal(1, new[] { null, new Address { City = new City { Name = "first" } }, new Address { City = new City { Name = "second" } } }.City(new City { Name = "first" }).Count());
      Assert.Equal(1, new[] { null, new Address(), new Address { City = new City { Name = "first" } } }.City(null).Count());
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Address>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Address[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Address[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Address { Name = "First" }, new Address { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Address>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Address[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Address[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new Address(), new Address { Name = "First" }, new Address { Name = "Second" } }.Name("f").Count());
    }
  }
}