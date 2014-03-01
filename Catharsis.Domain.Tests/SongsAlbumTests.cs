using System;
using System.Linq;
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
    public void Attributes()
    {
      this.TestDescription("Comments", "DateCreated", "Image", "LastUpdated", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="SongsAlbum()"/>
    ///   <seealso cref="SongsAlbum(string, string, string, DateTime?)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var album = new SongsAlbum();
      Assert.False(album.Comments.Any());
      Assert.True(album.DateCreated >= DateTime.MinValue && album.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, album.Id);
      Assert.Null(album.Image);
      Assert.Null(album.Language);
      Assert.True(album.LastUpdated >= DateTime.MinValue && album.LastUpdated <= DateTime.UtcNow);
      Assert.Null(album.Name);
      Assert.Null(album.PublishedOn);
      Assert.False(album.Tags.Any());
      Assert.Null(album.Text);
      Assert.Equal(0, album.Version);

      Assert.Throws<ArgumentNullException>(() => new SongsAlbum(null));
      Assert.Throws<ArgumentException>(() => new SongsAlbum(string.Empty, "name"));
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue);
      Assert.False(album.Comments.Any());
      Assert.True(album.DateCreated >= DateTime.MinValue && album.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, album.Id);
      Assert.Equal("image", album.Image);
      Assert.Null(album.Language);
      Assert.True(album.LastUpdated >= DateTime.MinValue && album.LastUpdated <= DateTime.UtcNow);
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
      this.TestCompareTo<SongsAlbum, string>("Name", "first", "second");
    }
  }
}