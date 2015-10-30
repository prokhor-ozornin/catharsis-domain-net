using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WebPageExtensionsTests
  {
    [Fact]
    public void locale_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WebPage>)null).Locale("locale"));
      Assert.Throws<ArgumentNullException>(() => new WebPage[] { }.AsQueryable().Locale(null));
      Assert.Throws<ArgumentException>(() => new WebPage[] { }.AsQueryable().Locale(string.Empty));

      Assert.Equal(1, new[] { new WebPage { Locale = "First" }, new WebPage { Locale = "Second" } }.AsQueryable().Locale("first").Count());
    }

    [Fact]
    public void locale_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WebPage>)null).Locale("locale"));
      Assert.Throws<ArgumentNullException>(() => new WebPage[] { }.Locale(null));
      Assert.Throws<ArgumentException>(() => new WebPage[] { }.Locale(string.Empty));

      Assert.Equal(1, new[] { null, new WebPage(), new WebPage { Locale = "First" }, new WebPage { Locale = "Second" } }.Locale("first").Count());
    }

    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WebPage>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new WebPage[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new WebPage[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new WebPage { Name = "First" }, new WebPage { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WebPage>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new WebPage[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new WebPage[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new WebPage(), new WebPage { Name = "First" }, new WebPage { Name = "Second" } }.Name("f").Count());
    }
  }
}