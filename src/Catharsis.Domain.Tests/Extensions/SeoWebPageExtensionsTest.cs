using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class SeoWebPageExtensionsTests
  {
    [Fact]
    public void locale_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<SeoWebPage>)null).Locale("locale"));
      Assert.Throws<ArgumentNullException>(() => new SeoWebPage[] { }.AsQueryable().Locale(null));
      Assert.Throws<ArgumentException>(() => new SeoWebPage[] { }.AsQueryable().Locale(string.Empty));

      Assert.Equal(1, new[] { new SeoWebPage { Locale = "First" }, new SeoWebPage { Locale = "Second" } }.AsQueryable().Locale("first").Count());
    }

    [Fact]
    public void locale_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<SeoWebPage>)null).Locale("locale"));
      Assert.Throws<ArgumentNullException>(() => new SeoWebPage[] { }.Locale(null));
      Assert.Throws<ArgumentException>(() => new SeoWebPage[] { }.Locale(string.Empty));

      Assert.Equal(1, new[] { null, new SeoWebPage(), new SeoWebPage { Locale = "First" }, new SeoWebPage { Locale = "Second" } }.Locale("first").Count());
    }
  }
}