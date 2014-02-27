using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ArticleExtensions"/>.</para>
  /// </summary>
  public sealed class ArticleExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ArticleExtensions.Category(IQueryable{Article}, ArticlesCategory)"/></description></item>
    ///     <item><description><see cref="ArticleExtensions.Category(IEnumerable{Article}, ArticlesCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Method()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Article>) null).Category(new ArticlesCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Article>)null).Category(new ArticlesCategory()));

      Assert.False(Enumerable.Empty<Article>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Article>().Category(null).Any());

      Assert.False(Enumerable.Empty<Article>().AsQueryable().Category(new ArticlesCategory()).Any());
      Assert.False(Enumerable.Empty<Article>().Category(new ArticlesCategory()).Any());
      
      Assert.Equal(1, new[] { new Article { Category = new ArticlesCategory { Id = 1 } }, new Article { Category = new ArticlesCategory { Id = 2 } } }.AsQueryable().Category(new ArticlesCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Article { Category = new ArticlesCategory { Name = "first" } }, null, new Article { Category = new ArticlesCategory { Name = "second" } } }.Category(new ArticlesCategory { Name = "first" }).Count());
    }
  }
}