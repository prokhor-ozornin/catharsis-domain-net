using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class WebLinkExtensionsTests
  {
    [Fact]
    public void name_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WebLink>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new WebLink[] { }.AsQueryable().Name(null));
      Assert.Throws<ArgumentException>(() => new WebLink[] { }.AsQueryable().Name(string.Empty));

      Assert.Equal(1, new[] { new WebLink { Name = "First" }, new WebLink { Name = "Second" } }.AsQueryable().Name("f").Count());
    }

    [Fact]
    public void name_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WebLink>)null).Name("name"));
      Assert.Throws<ArgumentNullException>(() => new WebLink[] { }.Name(null));
      Assert.Throws<ArgumentException>(() => new WebLink[] { }.Name(string.Empty));

      Assert.Single(new[] { null, new WebLink(), new WebLink { Name = "First" }, new WebLink { Name = "Second" } }.Name("f"));
    }
  }
}