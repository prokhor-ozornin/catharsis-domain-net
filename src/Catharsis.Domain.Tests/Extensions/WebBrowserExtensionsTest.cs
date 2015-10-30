using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WebBrowserExtensionsTests
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WebBrowser>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new WebBrowser[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new WebBrowser[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new WebBrowser { Name = "First" }, new WebBrowser { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WebBrowser>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new WebBrowser[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new WebBrowser[] { }.Name(string.Empty));

      Assert.Equal(1, new[] { null, new WebBrowser(), new WebBrowser { Name = "First" }, new WebBrowser { Name = "Second" } }.Name("f").Count());
    }

    [Fact]
    public void value_of_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WebBrowser>)null).ValueOf("Mozilla"));
      Assert.Throws<ArgumentNullException>(() => new WebBrowser[] { }.AsQueryable().ValueOf(null));
      Assert.Throws<ArgumentException>(() => new WebBrowser[] { }.AsQueryable().ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new WebBrowser { UserAgent = "Mozilla" }, new WebBrowser { UserAgent = "mozilla" } }.AsQueryable().ValueOf("mozilla"));

      Assert.Null(new WebBrowser[] { }.AsQueryable().ValueOf("mozilla"));
      Assert.NotNull(new[] { new WebBrowser { UserAgent = "Mozilla" }, new WebBrowser { UserAgent = "Opera" } }.AsQueryable().ValueOf("mozilla"));
    }

    [Fact]
    public void value_of_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WebBrowser>)null).ValueOf("mozilla"));
      Assert.Throws<ArgumentNullException>(() => new WebBrowser[] { }.ValueOf(null));
      Assert.Throws<ArgumentException>(() => new WebBrowser[] { }.ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new WebBrowser { UserAgent = "Mozilla" }, new WebBrowser { UserAgent = "mozilla" } }.ValueOf("mozilla"));

      Assert.Null(new WebBrowser[] { }.ValueOf("mozilla"));
      Assert.NotNull(new[] { new WebBrowser { UserAgent = "Mozilla" }, new WebBrowser { UserAgent = "Opera" } }.ValueOf("mozilla"));
    }
  }
}