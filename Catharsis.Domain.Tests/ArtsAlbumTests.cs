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
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(album.DateCreated.ISO(), album.LastUpdated.ISO()), album.Json());

      album = new ArtsAlbum("name");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[]}}".FormatSelf(album.DateCreated.ISO(), album.LastUpdated.ISO()), album.Json());
      Assert.Equal(album, album.Json().Json<ArtsAlbum>());

      var comment = new Comment("comment.name", "comment.text");
      album = new ArtsAlbum("name", "text", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      Assert.Equal(@"{{""Id"":1,""Comments"":[{{""Id"":0,""DateCreated"":""{1}"",""LastUpdated"":""{2}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{3}"",""Language"":""language"",""LastUpdated"":""{4}"",""Name"":""name"",""PublishedOn"":""{0}"",""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(DateTime.MinValue.ISO(), comment.DateCreated.ISO(), comment.LastUpdated.ISO(), album.DateCreated.ISO(), album.LastUpdated.ISO()), album.Json());
      Assert.Equal(album, album.Json().Json<ArtsAlbum>());
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