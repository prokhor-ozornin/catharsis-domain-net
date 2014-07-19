using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Download"/>.</para>
  /// </summary>
  public sealed class DownloadTests : EntityUnitTests<Download>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Category", "Comments", "CreatedAt", "Downloads", "Language", "UpdatedAt", "Name", "Tags", "Text", "Url");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var download = new Download();
      this.TestJson(download, new { Id = 0, Comments = new object[] { }, CreatedAt = download.CreatedAt.ISO8601(), Downloads = 0, Tags = new object[] { }, UpdatedAt = download.UpdatedAt.ISO8601() });

      download = new Download("name", "url");
      this.TestJson(download, new { Id = 0, Comments = new object[] {}, CreatedAt = download.CreatedAt.ISO8601(), Downloads = 0, Name = "name", Tags = new object[] {}, UpdatedAt = download.UpdatedAt.ISO8601(), Url = "url" });

      var comment = new Comment("comment.name", "comment.text");
      download = new Download("name", "url", new DownloadsCategory("category.name"), "text")
      {
        Id = 1,
        Language = "language",
        Downloads = 1,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(download, new { Id = 1, Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = download.CreatedAt.ISO8601(), Downloads = 1, Language = "language", Name = "name", Tags = new object[] { "tag" }, Text = "text", UpdatedAt = download.UpdatedAt.ISO8601(), Url = "url" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var download = new Download();
      this.TestXml(download, new { Id = 0, CreatedAt = download.CreatedAt, Downloads = 0, UpdatedAt = download.UpdatedAt });

      download = new Download("name", "url");
      this.TestXml(download, new { Id = 0, CreatedAt = download.CreatedAt, Downloads = 0, UpdatedAt = download.UpdatedAt, Name = "name", Url = "url" });

      var comment = new Comment("comment.name", "comment.text");
      download = new Download("name", "url", new DownloadsCategory("category.name"), "text")
      {
        Id = 1,
        Language = "language",
        Downloads = 1,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(download, new { Id = 1, CreatedAt = download.CreatedAt, Downloads = 1, Language = "language", UpdatedAt = download.UpdatedAt, Name = "name", Text = "text", Url = "url" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Download()"/>
    /// <seealso cref="Download(string, string, DownloadsCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var download = new Download();
      Assert.Null(download.Category);
      Assert.False(download.Comments.Any());
      Assert.True(download.CreatedAt >= DateTime.MinValue && download.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, download.Downloads);
      Assert.Equal(0, download.Id);
      Assert.Null(download.Language);
      Assert.True(download.UpdatedAt >= DateTime.MinValue && download.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(download.Name);
      Assert.False(download.Tags.Any());
      Assert.Null(download.Text);
      Assert.Null(download.Url);
      Assert.Equal(0, download.Version);

      Assert.Throws<ArgumentNullException>(() => new Download(null, "url"));
      Assert.Throws<ArgumentNullException>(() => new Download("name", null));
      Assert.Throws<ArgumentException>(() => new Download(string.Empty, "url"));
      Assert.Throws<ArgumentException>(() => new Download("name", string.Empty));
      download = new Download("name", "url", new DownloadsCategory(), "text");
      Assert.NotNull(download.Category);
      Assert.False(download.Comments.Any());
      Assert.True(download.CreatedAt >= DateTime.MinValue && download.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, download.Downloads);
      Assert.Equal(0, download.Id);
      Assert.Null(download.Language);
      Assert.True(download.UpdatedAt >= DateTime.MinValue && download.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", download.Name);
      Assert.False(download.Tags.Any());
      Assert.Equal("text", download.Text);
      Assert.Equal("url", download.Url);
      Assert.Equal(0, download.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new DownloadsCategory();
      Assert.True(ReferenceEquals(new Download { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Downloads"/> property.</para>
    /// </summary>
    [Fact]
    public void Downloads_Property()
    {
      Assert.Equal(1, new Download { Downloads = 1 }.Downloads);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Url"/> property.</para>
    /// </summary>
    [Fact]
    public void Url_Property()
    {
      Assert.Equal("url", new Download { Url = "url" }.Url);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.CompareTo(Download)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }
  }
}