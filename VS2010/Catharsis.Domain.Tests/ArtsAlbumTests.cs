using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ArtsAlbum"/>.</para>
  /// </summary>
  public sealed class ArtsAlbumTests : EntityUnitTests<ArtsAlbum>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Comments", "DateCreated", "Language", "LastUpdated", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var album = new ArtsAlbum();
      this.TestJson(album, new { Id = 0, Comments = new object[] { }, DateCreated = album.DateCreated.ISO8601(), LastUpdated = album.LastUpdated.ISO8601(), Tags = new object[] { } });

      album = new ArtsAlbum("name");
      this.TestJson(album, new { Id = 0, Comments = new object[] { }, DateCreated = album.DateCreated.ISO8601(), LastUpdated = album.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { } });

      var comment = new Comment("comment.name", "comment.text");
      album = new ArtsAlbum("name", "text", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        PublishedOn = DateTime.MaxValue,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(album, new { Id = 1, Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } }, DateCreated = album.DateCreated.ISO8601(), Language = "language", LastUpdated = album.LastUpdated.ISO8601(), Name = "name", PublishedOn = DateTime.MaxValue.ISO8601(), Tags = new object[] { "tag" }, Text = "text" });
      Assert.Equal(album, album.Json().Json<ArtsAlbum>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var album = new ArtsAlbum();
      this.TestXml(album, new { Id = 0, DateCreated = album.DateCreated, LastUpdated = album.LastUpdated });

      album = new ArtsAlbum("name");
      this.TestXml(album, new { Id = 0, DateCreated = album.DateCreated, LastUpdated = album.LastUpdated, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      album = new ArtsAlbum("name", "text", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        PublishedOn = DateTime.MaxValue,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(album, new { Id = 1, DateCreated = album.DateCreated, Language = "language", LastUpdated = album.LastUpdated, Name = "name", PublishedOn = DateTime.MaxValue, Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ArtsAlbum()"/>
    /// <seealso cref="ArtsAlbum(string, string, DateTime?)"/>
    [Fact]
    public void Constructors()
    {
      var album = new ArtsAlbum();
      Assert.False(album.Comments.Any());
      Assert.Equal(0, album.Id);
      Assert.True(album.DateCreated >= DateTime.MinValue && album.DateCreated <= DateTime.UtcNow);
      Assert.Null(album.Language);
      Assert.True(album.LastUpdated >= DateTime.MinValue && album.LastUpdated <= DateTime.UtcNow);
      Assert.Null(album.Name);
      Assert.Null(album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Null(album.Text);
      Assert.Equal(0, album.Version);

      Assert.Throws<ArgumentNullException>(() => new ArtsAlbum(null));
      Assert.Throws<ArgumentException>(() => new ArtsAlbum(string.Empty));
      album = new ArtsAlbum("name", "text", DateTime.MinValue);
      Assert.False(album.Comments.Any());
      Assert.Equal(0, album.Id);
      Assert.True(album.DateCreated >= DateTime.MinValue && album.DateCreated <= DateTime.UtcNow);
      Assert.Null(album.Language);
      Assert.True(album.LastUpdated >= DateTime.MinValue && album.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", album.Name);
      Assert.Equal(DateTime.MinValue, album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Equal("text", album.Text);
      Assert.Equal(0, album.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ArtsAlbum.PublishedOn"/> property.</para>
    /// </summary>
    [Fact]
    public void PublishedOn_Property()
    {
      Assert.Equal(DateTime.MinValue, new ArtsAlbum { PublishedOn = DateTime.MinValue }.PublishedOn);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ArtsAlbum.CompareTo(ArtsAlbum)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }
  }
}