using System;
using System.Linq;
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
    public void Attributes()
    {
      this.TestDescription("Annotation", "Category", "Comments", "DateCreated", "Image", "Language", "LastUpdated", "Name", "Tags", "Text");
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
      Assert.True(article.DateCreated >= DateTime.MinValue && article.DateCreated <= DateTime.UtcNow);
      Assert.Null(article.Image);
      Assert.Null(article.Language);
      Assert.True(article.LastUpdated >= DateTime.MinValue && article.LastUpdated <= DateTime.UtcNow);
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
      Assert.True(article.DateCreated >= DateTime.MinValue && article.DateCreated <= DateTime.UtcNow);
      Assert.NotNull(article.Image);
      Assert.Null(article.Language);
      Assert.True(article.LastUpdated >= DateTime.MinValue && article.LastUpdated <= DateTime.UtcNow);
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

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Article.Equals(Article)"/></description></item>
    ///     <item><description><see cref="Article.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new ArticlesCategory { Name = "first" }, new ArticlesCategory { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Article.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new ArticlesCategory { Name = "first" }, new ArticlesCategory { Name = "second" });
    }
  }
}