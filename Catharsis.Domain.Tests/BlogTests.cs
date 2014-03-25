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
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(blog.DateCreated.ISO(), blog.LastUpdated.ISO()), blog.Json());

      blog = new Blog("name");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[]}}".FormatSelf(blog.DateCreated.ISO(), blog.LastUpdated.ISO()), blog.Json());
      Assert.Equal(blog, blog.Json().Json<Blog>());

      var comment = new Comment("comment.name", "comment.text");
      blog = new Blog("name")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      Assert.Equal(@"{{""Id"":1,""Comments"":[{{""Id"":0,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{2}"",""Language"":""language"",""LastUpdated"":""{3}"",""Name"":""name"",""Tags"":[""tag""]}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO(), blog.DateCreated.ISO(), blog.LastUpdated.ISO()), blog.Json());
      Assert.Equal(blog, blog.Json().Json<Blog>());
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