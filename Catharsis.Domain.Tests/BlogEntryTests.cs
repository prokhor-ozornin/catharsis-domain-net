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
    public void Attributes()
    {
      this.TestDescription("Blog", "Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var entry = new BlogEntry();
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(entry.DateCreated.ISO(), entry.LastUpdated.ISO()), entry.Json());

      var blog = new Blog("blog.name");

      entry = new BlogEntry(blog, "name", "text");
      Assert.Equal(@"{{""Id"":0,""Blog"":{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""blog.name"",""Tags"":[]}},""Comments"":[],""DateCreated"":""{2}"",""LastUpdated"":""{3}"",""Name"":""name"",""Tags"":[],""Text"":""text""}}".FormatSelf(blog.DateCreated.ISO(), blog.LastUpdated.ISO(), entry.DateCreated.ISO(), entry.LastUpdated.ISO()), entry.Json());
      Assert.Equal(entry, entry.Json().Json<BlogEntry>());

      var comment = new Comment("comment.name", "comment.text");
      entry = new BlogEntry(blog, "name", "text") { Id = 1, Language = "language", Comments = new List<Comment> { comment }, Tags = new List<string> { "tag" } };
      Assert.Equal(@"{{""Id"":1,""Blog"":{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""blog.name"",""Tags"":[]}},""Comments"":[{{""Id"":0,""DateCreated"":""{2}"",""LastUpdated"":""{3}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{4}"",""Language"":""language"",""LastUpdated"":""{5}"",""Name"":""name"",""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(blog.DateCreated.ISO(), blog.LastUpdated.ISO(), comment.DateCreated.ISO(), comment.LastUpdated.ISO(), entry.DateCreated.ISO(), entry.LastUpdated.ISO()), entry.Json());
      Assert.Equal(entry, entry.Json().Json<BlogEntry>());
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
      Assert.True(entry.DateCreated >= DateTime.MinValue && entry.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, entry.Id);
      Assert.Null(entry.Language);
      Assert.True(entry.LastUpdated >= DateTime.MinValue && entry.LastUpdated <= DateTime.UtcNow);
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
      Assert.True(entry.DateCreated >= DateTime.MinValue && entry.DateCreated <= DateTime.UtcNow);
      Assert.Null(entry.Language);
      Assert.True(entry.LastUpdated >= DateTime.MinValue && entry.LastUpdated <= DateTime.UtcNow);
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

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="BlogEntry.Equals(BlogEntry)"/></description></item>
    ///     <item><description><see cref="BlogEntry.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Blog", new Blog { Name = "first" }, new Blog { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="BlogEntry.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Blog", new Blog { Name = "first" }, new Blog { Name = "second" });
    }
  }
}