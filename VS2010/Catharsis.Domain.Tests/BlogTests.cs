using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
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
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var blog = new Blog();
      this.TestJson(blog, new { Id = 0, Comments = new object[] { }, DateCreated = blog.DateCreated.ISO8601(), LastUpdated = blog.LastUpdated.ISO8601(), Tags = new object[] { } });

      blog = new Blog("name");
      this.TestJson(blog, new { Id = 0, Comments = new object[] { }, DateCreated = blog.DateCreated.ISO8601(), LastUpdated = blog.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { } });

      var comment = new Comment("comment.name", "comment.text");
      blog = new Blog("name")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(blog, new { Id = 1, Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } }, DateCreated = blog.DateCreated.ISO8601(), Language = "language", LastUpdated = blog.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { "tag" } });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var blog = new Blog();
      this.TestXml(blog, new { Id = 0, DateCreated = blog.DateCreated, LastUpdated = blog.LastUpdated });

      blog = new Blog("name");
      this.TestXml(blog, new { Id = 0, DateCreated = blog.DateCreated, LastUpdated = blog.LastUpdated, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      blog = new Blog("name")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(blog, new { Id = 1, DateCreated = blog.DateCreated, Language = "language", LastUpdated = blog.LastUpdated, Name = "name" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Blog()"/>
    /// <seealso cref="Blog(string)"/>
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