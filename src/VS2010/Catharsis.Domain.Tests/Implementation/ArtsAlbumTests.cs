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
      this.TestDescription("Comments", "CreatedAt", "Language", "UpdatedAt", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var album = new ArtsAlbum();
      this.TestJson(album, new { Id = 0, Comments = new object[] { }, CreatedAt = album.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = album.UpdatedAt.ISO8601() });

      album = new ArtsAlbum("name");
      this.TestJson(album, new { Id = 0, Comments = new object[] { }, CreatedAt = album.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, UpdatedAt = album.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      album = new ArtsAlbum("name", "text", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        PublishedOn = DateTime.MaxValue,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(album, new { Id = 1, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = album.CreatedAt.ISO8601(), Language = "language", Name = "name", PublishedOn = DateTime.MaxValue.ISO8601(), Tags = new object[] { "tag" }, Text = "text", UpdatedAt = album.UpdatedAt.ISO8601() });
      Assert.Equal(album, album.Json().Json<ArtsAlbum>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var album = new ArtsAlbum();
      this.TestXml(album, new { Id = 0, CreatedAt = album.CreatedAt, UpdatedAt = album.UpdatedAt });

      album = new ArtsAlbum("name");
      this.TestXml(album, new { Id = 0, CreatedAt = album.CreatedAt, UpdatedAt = album.UpdatedAt, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      album = new ArtsAlbum("name", "text", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        PublishedOn = DateTime.MaxValue,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(album, new { Id = 1, CreatedAt = album.CreatedAt, Language = "language", UpdatedAt = album.UpdatedAt, Name = "name", PublishedOn = DateTime.MaxValue, Text = "text" });
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
      Assert.True(album.CreatedAt >= DateTime.MinValue && album.CreatedAt <= DateTime.UtcNow);
      Assert.Null(album.Language);
      Assert.True(album.UpdatedAt >= DateTime.MinValue && album.UpdatedAt <= DateTime.UtcNow);
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
      Assert.True(album.CreatedAt >= DateTime.MinValue && album.CreatedAt <= DateTime.UtcNow);
      Assert.Null(album.Language);
      Assert.True(album.UpdatedAt >= DateTime.MinValue && album.UpdatedAt <= DateTime.UtcNow);
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