using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="WebLink"/>.</para>
  /// </summary>
  public sealed class WebLinkTests : EntityUnitTests<WebLink>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Category", "Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text", "Url");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var weblink = new WebLink();
      this.TestJson(weblink, new { Id = 0, Comments = new object[] { }, DateCreated = weblink.DateCreated.ISO8601(), LastUpdated = weblink.LastUpdated.ISO8601(), Tags = new object[] { } });

      weblink = new WebLink("name", "text", "url");
      this.TestJson(weblink, new { Id = 0, Comments = new object[] { }, DateCreated = weblink.DateCreated.ISO8601(), LastUpdated = weblink.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { }, Text = "text", Url = "url" });

      var comment = new Comment("comment.name", "comment.text");
      weblink = new WebLink("name", "text", "url", new WebLinksCategory("category.name"))
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(weblink, new { Id = 1, Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } }, DateCreated = weblink.DateCreated.ISO8601(), Language = "language", LastUpdated = weblink.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { "tag" }, Text = "text", Url = "url" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var weblink = new WebLink();
      this.TestXml(weblink, new { Id = 0, DateCreated = weblink.DateCreated, LastUpdated = weblink.LastUpdated });

      weblink = new WebLink("name", "text", "url");
      this.TestXml(weblink, new { Id = 0, DateCreated = weblink.DateCreated, LastUpdated = weblink.LastUpdated, Name = "name", Text = "text", Url = "url" });
      
      var comment = new Comment("comment.name", "comment.text");
      weblink = new WebLink("name", "text", "url", new WebLinksCategory("category.name"))
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(weblink, new { Id = 1, DateCreated = weblink.DateCreated, Language = "language", LastUpdated = weblink.LastUpdated, Name = "name", Text = "text", Url = "url" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="WebLink()"/>
    /// <seealso cref="WebLink(string, string, string, WebLinksCategory)"/>
    [Fact]
    public void Constructors()
    {
      var weblink = new WebLink();
      Assert.Null(weblink.Category);
      Assert.False(weblink.Comments.Any());
      Assert.True(weblink.DateCreated >= DateTime.MinValue && weblink.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, weblink.Id);
      Assert.Null(weblink.Language);
      Assert.True(weblink.LastUpdated >= DateTime.MinValue && weblink.LastUpdated <= DateTime.UtcNow);
      Assert.Null(weblink.Name);
      Assert.False(weblink.Tags.Any());
      Assert.Null(weblink.Text);
      Assert.Null(weblink.Url);
      Assert.Equal(0, weblink.Version);

      Assert.Throws<ArgumentNullException>(() => new WebLink(null, "text", "url"));
      Assert.Throws<ArgumentNullException>(() => new WebLink("name", null, "url"));
      Assert.Throws<ArgumentNullException>(() => new WebLink("name", "text", null));
      Assert.Throws<ArgumentException>(() => new WebLink(string.Empty, "text", "url"));
      Assert.Throws<ArgumentException>(() => new WebLink("name", string.Empty, "url"));
      Assert.Throws<ArgumentException>(() => new WebLink("name", "text", string.Empty));
      weblink = new WebLink("name", "text", "url", new WebLinksCategory());
      Assert.NotNull(weblink.Category);
      Assert.False(weblink.Comments.Any());
      Assert.True(weblink.DateCreated >= DateTime.MinValue && weblink.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, weblink.Id);
      Assert.Null(weblink.Language);
      Assert.True(weblink.LastUpdated >= DateTime.MinValue && weblink.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", weblink.Name);
      Assert.False(weblink.Tags.Any());
      Assert.Equal("text", weblink.Text);
      Assert.Equal("url", weblink.Url);
      Assert.Equal(0, weblink.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WebLink.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new WebLinksCategory();
      Assert.True(ReferenceEquals(new WebLink { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WebLink.Url"/> property.</para>
    /// </summary>
    [Fact]
    public void Url_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new WebLink { Url = null });
      Assert.Throws<ArgumentException>(() => new WebLink { Url = string.Empty });
      
      Assert.Equal("url", new WebLink { Url = "url" }.Url);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="WebLink.Equals(WebLink)"/></description></item>
    ///     <item><description><see cref="WebLink.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new WebLinksCategory { Name = "first" }, new WebLinksCategory { Name = "second" });
      this.TestEquality("Url", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WebLink.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new WebLinksCategory { Name = "first" }, new WebLinksCategory { Name = "second" });
      this.TestHashCode("Url", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WebLink.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("url", new WebLink { Url = "url" }.ToString());
    }
  }
}