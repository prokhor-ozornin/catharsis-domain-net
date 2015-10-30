using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class CountryExtensionsTests
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Country>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Country[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new Country[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new Country { Name = "First" }, new Country { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Country>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new Country[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new Country[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new Country(), new Country { Name = "First" }, new Country { Name = "Second" } }.Name("f").Count());
    }

    [Fact]
    public void value_of_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Country>)null).ValueOf("ru"));
      Assert.Throws<ArgumentNullException>(() => new Country[] { }.AsQueryable().ValueOf(null));
      Assert.Throws<ArgumentException>(() => new Country[] { }.AsQueryable().ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Country { IsoCode = "Ru" }, new Country { IsoCode = "ru" } }.AsQueryable().ValueOf("ru"));

      Assert.Null(new Country[] { }.AsQueryable().ValueOf("ru"));
      Assert.NotNull(new[] { new Country { IsoCode = "Ru" }, new Country { IsoCode = "En" } }.AsQueryable().ValueOf("ru"));
    }

    [Fact]
    public void value_of_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Country>)null).ValueOf("isbn"));
      Assert.Throws<ArgumentNullException>(() => new Country[] { }.ValueOf(null));
      Assert.Throws<ArgumentException>(() => new Country[] { }.ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Country { IsoCode = "Ru" }, new Country { IsoCode = "ru" } }.ValueOf("ru"));

      Assert.Null(new Country[] { }.ValueOf("ru"));
      Assert.NotNull(new[] { new Country { IsoCode = "Ru" }, new Country { IsoCode = "En" } }.ValueOf("ru"));
    }
  }
}