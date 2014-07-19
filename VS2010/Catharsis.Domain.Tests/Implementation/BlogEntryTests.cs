using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="BlogEntry"/>.</para>
  /// </summary>
  public sealed class BlogEntryTests : EntityUnitTests<BlogEntry>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Blog", "Comments", "CreatedAt", "Language", "UpdatedAt", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var entry = new BlogEntry();
      this.TestJson(entry, new { Id = 0, Comments = new object[] { }, CreatedAt = entry.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = entry.UpdatedAt.ISO8601() });

      var blog = new Blog("blog.name");

      entry = new BlogEntry(blog, "name", "text");
      this.TestJson(entry, new { Id = 0, Blog = new { Id = 0, Comments = new object[] { }, CreatedAt = blog.CreatedAt.ISO8601(), Name = "blog.name", Tags = new object[] { }, UpdatedAt = blog.UpdatedAt.ISO8601() }, Comments = new object[] { }, CreatedAt = entry.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, Text = "text", UpdatedAt = entry.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      entry = new BlogEntry(blog, "name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(entry, new { Id = 1, Blog = new { Id = 0, Comments = new object[] { }, CreatedAt = blog.CreatedAt.ISO8601(), Name = "blog.name", Tags = new object[] { }, UpdatedAt = blog.UpdatedAt.ISO8601() }, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = entry.CreatedAt.ISO8601(), Language = "language", Name = "name", Tags = new object[] { "tag" }, Text = "text", UpdatedAt = entry.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var entry = new BlogEntry();
      this.TestXml(entry, new { Id = 0, CreatedAt = entry.CreatedAt, UpdatedAt = entry.UpdatedAt });

      var blog = new Blog("blog.name");

      entry = new BlogEntry(blog, "name", "text");
      this.TestXml(entry, new { Id = 0, CreatedAt = entry.CreatedAt, UpdatedAt = entry.UpdatedAt, Name = "name", Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="BlogEntry()"/>
    /// <seealso cref="BlogEntry(Blog, string, string)"/>
    [Fact]
    public void Constructors()
    {
      var entry = new BlogEntry();
      Assert.Null(entry.Blog);
      Assert.False(entry.Comments.Any());
      Assert.True(entry.CreatedAt >= DateTime.MinValue && entry.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, entry.Id);
      Assert.Null(entry.Language);
      Assert.True(entry.UpdatedAt >= DateTime.MinValue && entry.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(entry.Name);
      Assert.False(entry.Tags.Any());
      Assert.Null(entry.Text);
      Assert.Equal(0, entry.Version);

      Assert.Throws<ArgumentNullException>(() => new BlogEntry(null, "name", "text"));
      Assert.Throws<ArgumentNullException>(() => new BlogEntry(new Blog(), null, "text"));
      Assert.Throws<ArgumentNullException>(() => new BlogEntry(new Blog(), "name", null));
      Assert.Throws<ArgumentException>(() => new BlogEntry(new Blog(), string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new BlogEntry(new Blog(), "name", string.Empty));

      entry = new BlogEntry(new Blog(), "name", "text");
      Assert.NotNull(entry.Blog);
      Assert.False(entry.Comments.Any());
      Assert.Equal(0, entry.Id);
      Assert.True(entry.CreatedAt >= DateTime.MinValue && entry.CreatedAt <= DateTime.UtcNow);
      Assert.Null(entry.Language);
      Assert.True(entry.UpdatedAt >= DateTime.MinValue && entry.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", entry.Name);
      Assert.False(entry.Tags.Any());
      Assert.Equal("text", entry.Text);
      Assert.Equal(0, entry.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="BlogEntry.Blog"/> property.</para>
    /// </summary>
    [Fact]
    public void Blog_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new BlogEntry { Blog = null });
      
      var blog = new Blog();
      Assert.True(ReferenceEquals(new BlogEntry { Blog = blog }.Blog, blog));
    }
  }
}