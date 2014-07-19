using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Article"/>.</para>
  /// </summary>
  public sealed class ArticleTests : EntityUnitTests<Article>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Annotation", "Category", "Comments", "CreatedAt", "Image", "Language", "UpdatedAt", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var article = new Article();
      this.TestJson(article, new { Id = 0, Comments = new object[] { }, CreatedAt = article.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = article.UpdatedAt.ISO8601() });

      article = new Article("name");
      this.TestJson(article, new { Id = 0, Comments = new object[] { }, CreatedAt = article.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, UpdatedAt = article.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      article = new Article("name", new ArticlesCategory("category.name"), "annotation", "text", "image")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(article, new { Id = 1, Annotation = "annotation", Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = article.CreatedAt.ISO8601(), Image = "image", Language = "language", Name = "name", Tags = new object[] { "tag" }, Text = "text", UpdatedAt = article.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var article = new Article();
      this.TestXml(article, new { Id = 0, CreatedAt = article.CreatedAt, UpdatedAt = article.UpdatedAt });

      article = new Article("name");
      this.TestXml(article, new { Id = 0, CreatedAt = article.CreatedAt, UpdatedAt = article.UpdatedAt, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      article = new Article("name", new ArticlesCategory("category.name"), "annotation", "text", "image")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(article, new { Id = 1, Annotation = "annotation", CreatedAt = article.CreatedAt, Image = "image", Language = "language", UpdatedAt = article.UpdatedAt, Name = "name", Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Article()"/>
    /// <seealso cref="Article(string, ArticlesCategory, string, string, string)"/>
    [Fact]
    public void Constructors()
    {
      var article = new Article();
      Assert.Null(article.Annotation);
      Assert.Equal(0, article.Id);
      Assert.Null(article.Category);
      Assert.False(article.Comments.Any());
      Assert.True(article.CreatedAt >= DateTime.MinValue && article.CreatedAt <= DateTime.UtcNow);
      Assert.Null(article.Image);
      Assert.Null(article.Language);
      Assert.True(article.UpdatedAt >= DateTime.MinValue && article.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(article.Name);
      Assert.False(article.Tags.Any());
      Assert.Null(article.Text);
      Assert.Equal(0, article.Version);

      Assert.Throws<ArgumentNullException>(() => new Article(null));
      Assert.Throws<ArgumentException>(() => new Article(string.Empty));
      article = new Article("name", new ArticlesCategory(), "annotation", "text", "image");
      Assert.Equal("annotation", article.Annotation);
      Assert.Equal(0, article.Id);
      Assert.NotNull(article.Category);
      Assert.False(article.Comments.Any());
      Assert.True(article.CreatedAt >= DateTime.MinValue && article.CreatedAt <= DateTime.UtcNow);
      Assert.NotNull(article.Image);
      Assert.Null(article.Language);
      Assert.True(article.UpdatedAt >= DateTime.MinValue && article.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", article.Name);
      Assert.False(article.Tags.Any());
      Assert.Equal("text", article.Text);
      Assert.Equal(0, article.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Article.Annotation"/> property.</para>
    /// </summary>
    [Fact]
    public void Annotation_Property()
    {
      Assert.Equal("annotation", new Article { Annotation = "annotation" }.Annotation);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Article.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new ArticlesCategory();
      Assert.True(ReferenceEquals(new Article { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Article.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new Article { Image = "image" }.Image);
    }
  }
}