using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="SongsAlbum"/>.</para>
  /// </summary>
  public sealed class SongsAlbumTests : EntityUnitTests<SongsAlbum>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Comments", "CreatedAt", "Image", "UpdatedAt", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var album = new SongsAlbum();
      this.TestJson(album, new { Id = 0, Comments = new object[] { }, CreatedAt = album.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = album.UpdatedAt.ISO8601() });

      album = new SongsAlbum("name");
      this.TestJson(album, new { Id = 0, Comments = new object[] { }, CreatedAt = album.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, UpdatedAt = album.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        PublishedOn = DateTime.MinValue,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(album, new { Id = 1, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = album.CreatedAt.ISO8601(), Image = "image", Language = "language", Name = "name", PublishedOn = DateTime.MinValue.ISO8601(), Tags = new object[] { "tag" }, Text = "text", UpdatedAt = album.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var album = new SongsAlbum();
      this.TestXml(album, new { Id = 0, CreatedAt = album.CreatedAt, UpdatedAt = album.UpdatedAt });

      album = new SongsAlbum("name");
      this.TestXml(album, new { Id = 0, CreatedAt = album.CreatedAt, UpdatedAt = album.UpdatedAt, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        PublishedOn = DateTime.MinValue,
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(album, new { Id = 1, CreatedAt = album.CreatedAt, Image = "image", Language = "language", UpdatedAt = album.UpdatedAt, Name = "name", PublishedOn = DateTime.MinValue, Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="SongsAlbum()"/>
    /// <seealso cref="SongsAlbum(string, string, string, DateTime?)"/>
    [Fact]
    public void Constructors()
    {
      var album = new SongsAlbum();
      Assert.False(album.Comments.Any());
      Assert.True(album.CreatedAt >= DateTime.MinValue && album.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, album.Id);
      Assert.Null(album.Image);
      Assert.Null(album.Language);
      Assert.True(album.UpdatedAt >= DateTime.MinValue && album.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(album.Name);
      Assert.Null(album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Null(album.Text);
      Assert.Equal(0, album.Version);

      Assert.Throws<ArgumentNullException>(() => new SongsAlbum(null));
      Assert.Throws<ArgumentException>(() => new SongsAlbum(string.Empty, "name"));
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue);
      Assert.False(album.Comments.Any());
      Assert.True(album.CreatedAt >= DateTime.MinValue && album.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, album.Id);
      Assert.Equal("image", album.Image);
      Assert.Null(album.Language);
      Assert.True(album.UpdatedAt >= DateTime.MinValue && album.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", album.Name);
      Assert.Equal(DateTime.MinValue, album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Equal("text", album.Text);
      Assert.Equal(0, album.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="SongsAlbum.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new SongsAlbum { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="SongsAlbum.PublishedOn"/> property.</para>
    /// </summary>
    [Fact]
    public void PublishedOn_Property()
    {
      Assert.Equal(DateTime.MinValue, new SongsAlbum { PublishedOn = DateTime.MinValue }.PublishedOn);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="SongsAlbum.CompareTo(SongsAlbum)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }
  }
}