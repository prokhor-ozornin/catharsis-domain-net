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
      this.TestDescription("Comments", "DateCreated", "Image", "LastUpdated", "Name", "PublishedOn", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var album = new SongsAlbum();
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(album.DateCreated.ISO(), album.LastUpdated.ISO()), album.Json());

      album = new SongsAlbum("name");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[]}}".FormatSelf(album.DateCreated.ISO(), album.LastUpdated.ISO()), album.Json());
      Assert.Equal(album, album.Json().Json<SongsAlbum>());

      var comment = new Comment("comment.name", "comment.text");
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      Assert.Equal(@"{{""Id"":1,""Comments"":[{{""Id"":0,""DateCreated"":""{1}"",""LastUpdated"":""{2}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{3}"",""Image"":""image"",""Language"":""language"",""LastUpdated"":""{4}"",""Name"":""name"",""PublishedOn"":""{0}"",""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(DateTime.MinValue.ISO(), comment.DateCreated.ISO(), comment.LastUpdated.ISO(), album.DateCreated.ISO(), album.LastUpdated.ISO()), album.Json());
      Assert.Equal(album, album.Json().Json<SongsAlbum>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var album = new SongsAlbum();
      this.TestXml(album, @"<Id>0</Id><Comments /><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Tags /><PublishedOn xsi:nil=""true"" />".FormatSelf(album.DateCreated.ToXmlString(), album.LastUpdated.ToXmlString()));

      album = new SongsAlbum("name");
      this.TestXml(album, @"<Id>0</Id><Comments /><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Name>name</Name><Tags /><PublishedOn xsi:nil=""true"" />".FormatSelf(album.DateCreated.ToXmlString(), album.LastUpdated.ToXmlString()));
      Assert.Equal(album, album.Xml().Xml<SongsAlbum>());

      var comment = new Comment("comment.name", "comment.text");
      album = new SongsAlbum("name", "text", "image", DateTime.MinValue)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(album, @"<Id>1</Id><Comments><Comment><Id>0</Id><DateCreated>{2}</DateCreated><LastUpdated>{3}</LastUpdated><Name>comment.name</Name><Text>comment.text</Text></Comment></Comments><DateCreated>{0}</DateCreated><Language>language</Language><LastUpdated>{1}</LastUpdated><Name>name</Name><Tags><Tag>tag</Tag></Tags><Text>text</Text><Image>image</Image><PublishedOn>{4}</PublishedOn>".FormatSelf(album.DateCreated.ToXmlString(), album.LastUpdated.ToXmlString(), comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString(), DateTime.MinValue.ToString("s")));
      Assert.Equal(album, album.Xml().Xml<SongsAlbum>());
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
      this.TestCompareTo("Name", "first", "second");
    }
  }
}