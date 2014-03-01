using System;
using System.Linq;
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
    public void Attributes()
    {
      this.TestDescription("Comments", "DateCreated", "Language", "LastUpdated", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="ArtsAlbum()"/>
    ///   <seealso cref="ArtsAlbum(string, string, DateTime?)"/>
    /// </summary>
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
      this.TestCompareTo<ArtsAlbum, string>("Name", "first", "second");
    }
  }
}