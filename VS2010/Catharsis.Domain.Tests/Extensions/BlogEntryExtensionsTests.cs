using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="BlogEntryExtensions"/>.</para>
  /// </summary>
  public sealed class BlogEntryExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="BlogEntryExtensions.Blog(IQueryable{BlogEntry}, Blog)"/></description></item>
    ///     <item><description><see cref="BlogEntryExtensions.Blog(IEnumerable{BlogEntry}, Blog)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void InBlog_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<BlogEntry>) null).Blog(new Blog()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<BlogEntry>)null).Blog(new Blog()));

      Assert.False(Enumerable.Empty<BlogEntry>().AsQueryable().Blog(new Blog()).Any());
      Assert.False(Enumerable.Empty<BlogEntry>().Blog(new Blog()).Any());

      Assert.Equal(1, new[] { new BlogEntry { Blog = new Blog { Id = 1 } }, new BlogEntry { Blog = new Blog { Id = 2 } } }.AsQueryable().Blog(new Blog { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new BlogEntry { Blog = new Blog { Id = 1 } }, new BlogEntry { Blog = new Blog { Id = 2 } } }.Blog(new Blog { Id = 1 }).Count());
    }
  }
}