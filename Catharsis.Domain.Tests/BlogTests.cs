using System;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Blog"/>.</para>
  /// </summary>
  public sealed class BlogTests : EntityUnitTests<Blog>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Blog()"/>
    ///   <seealso cref="Blog(string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var blog = new Blog();
      Assert.False(blog.Comments.Any());
      Assert.True(blog.DateCreated >= DateTime.MinValue && blog.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, blog.Id);
      Assert.Null(blog.Language);
      Assert.True(blog.LastUpdated >= DateTime.MinValue && blog.LastUpdated <= DateTime.UtcNow);
      Assert.Null(blog.Name);
      Assert.False(blog.Tags.Any());
      Assert.Null(blog.Text);
      Assert.Equal(0, blog.Version);

      Assert.Throws<ArgumentNullException>(() => new Blog(null));
      Assert.Throws<ArgumentException>(() => new Blog(string.Empty));
      blog = new Blog("name");
      Assert.False(blog.Comments.Any());
      Assert.True(blog.DateCreated >= DateTime.MinValue && blog.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, blog.Id);
      Assert.Null(blog.Language);
      Assert.True(blog.LastUpdated >= DateTime.MinValue && blog.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", blog.Name);
      Assert.False(blog.Tags.Any());
      Assert.Null(blog.Text);
      Assert.Equal(0, blog.Version);
    }
  }
}