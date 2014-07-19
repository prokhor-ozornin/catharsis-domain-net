using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="WebLinkExtensions"/>.</para>
  /// </summary>
  public sealed class WebLinkExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="WebLinkExtensions.Category(IQueryable{WebLink}, WebLinksCategory)"/></description></item>
    ///     <item><description><see cref="WebLinkExtensions.Category(IEnumerable{WebLink}, WebLinksCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void InCategory_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<WebLink>) null).Category(new WebLinksCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<WebLink>)null).Category(new WebLinksCategory()));

      Assert.False(Enumerable.Empty<WebLink>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<WebLink>().Category(null).Any());

      Assert.False(Enumerable.Empty<WebLink>().AsQueryable().Category(new WebLinksCategory()).Any());
      Assert.False(Enumerable.Empty<WebLink>().Category(new WebLinksCategory()).Any());

      Assert.Equal(1, new[] { new WebLink { Category = new WebLinksCategory { Id = 1 } }, new WebLink { Category = new WebLinksCategory { Id = 2 } } }.AsQueryable().Category(new WebLinksCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new WebLink { Category = new WebLinksCategory { Id = 1 } }, new WebLink { Category = new WebLinksCategory { Id = 2 } } }.Category(new WebLinksCategory { Id = 1 }).Count());
    }
  }
}