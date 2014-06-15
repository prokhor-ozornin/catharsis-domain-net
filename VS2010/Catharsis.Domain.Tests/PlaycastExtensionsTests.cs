using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="PlaycastExtensions"/>.</para>
  /// </summary>
  public sealed class PlaycastExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="PlaycastExtensions.Category(IQueryable{Playcast}, PlaycastsCategory)"/></description></item>
    ///     <item><description><see cref="PlaycastExtensions.Category(IEnumerable{Playcast}, PlaycastsCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Playcast>) null).Category(new PlaycastsCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Playcast>)null).Category(new PlaycastsCategory()));

      Assert.False(Enumerable.Empty<Playcast>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Playcast>().Category(null).Any());

      Assert.False(Enumerable.Empty<Playcast>().AsQueryable().Category(new PlaycastsCategory()).Any());
      Assert.False(Enumerable.Empty<Playcast>().Category(new PlaycastsCategory()).Any());
      
      Assert.True(new[] { new Playcast { Category = new PlaycastsCategory { Id = 1 } }, new Playcast { Category = new PlaycastsCategory { Id = 2 } } }.AsQueryable().Category(new PlaycastsCategory { Id = 1 }).Count() == 1);
      Assert.True(new[] { null, new Playcast { Category = new PlaycastsCategory { Name = "first" } }, null, new Playcast { Category = new PlaycastsCategory { Name = "second" } } }.Category(new PlaycastsCategory { Name = "first" }).Count() == 1);
    }
  }
}