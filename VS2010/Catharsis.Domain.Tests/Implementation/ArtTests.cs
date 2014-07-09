using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Art"/>.</para>
  /// </summary>
  public sealed class ArtTests : EntityUnitTests<Art>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Album", "Comments", "Image", "Language", "LastUpdated", "Material", "Name", "Person", "Place", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var art = new Art();
      this.TestJson(art, new { Id = 0, Comments = new object[] {}, DateCreated = art.DateCreated.ISO8601(), LastUpdated = art.LastUpdated.ISO8601(), Tags = new object[] {} });

      art = new Art("name", "image");
      this.TestJson(art, new { Id = 0, Comments = new object[] {}, DateCreated = art.DateCreated.ISO8601(), Image = "image", LastUpdated = art.LastUpdated.ISO8601(), Name = "name", Tags = new object[] {} });

      var comment = new Comment("comment.name", "comment.text");
      var album = new ArtsAlbum("album.name");
      art = new Art("name", "image", album, "text", new Person("person.nameFirst", "person.nameLast"), "place", "material")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(art, new
      {
        Id = 1,
        Album = new { Id = 0, Comments = new object[] { }, DateCreated = album.DateCreated.ISO8601(), LastUpdated = album.LastUpdated.ISO8601(), Name = "album.name", Tags = new object[] { } },
        Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } },
        DateCreated = art.DateCreated.ISO8601(),
        Image = "image",
        Language = "language",
        LastUpdated = art.LastUpdated.ISO8601(),
        Material = "material",
        Name = "name",
        Person = new { Id = 0, NameFirst = "person.nameFirst", NameLast = "person.nameLast" },
        Place = "place",
        Tags = new object[] { "tag" },
        Text = "text"
      });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var art = new Art();
      this.TestXml(art, new { Id = 0, DateCreated = art.DateCreated, LastUpdated = art.LastUpdated });

      art = new Art("name", "image");
      this.TestXml(art, new { Id = 0, DateCreated = art.DateCreated, Image = "image", LastUpdated = art.LastUpdated, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      var album = new ArtsAlbum("album.name");
      art = new Art("name", "image", album, "text", new Person("person.nameFirst", "person.nameLast"), "place", "material")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(art, new
      {
        Id = 1,
        DateCreated = art.DateCreated,
        Image = "image",
        Language = "language",
        LastUpdated = art.LastUpdated,
        Material = "material",
        Name = "name",
        Place = "place",
        Text = "text"
      });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Art()"/>
    /// <seealso cref="Art(string, string, ArtsAlbum, string, Person, string, string)"/>
    [Fact]
    public void Constructors()
    {
      var art = new Art();
      Assert.Null(art.Album);
      Assert.False(art.Comments.Any());
      Assert.True(art.DateCreated >= DateTime.MinValue && art.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, art.Id);
      Assert.Null(art.Image);
      Assert.Null(art.Language);
      Assert.True(art.LastUpdated >= DateTime.MinValue && art.LastUpdated <= DateTime.UtcNow);
      Assert.Null(art.Material);
      Assert.Null(art.Name);
      Assert.Null(art.Person);
      Assert.Null(art.Place);
      Assert.False(art.Tags.Any());
      Assert.Null(art.Text);
      Assert.Equal(0, art.Version);

      Assert.Throws<ArgumentNullException>(() => new Art(null, "image"));
      Assert.Throws<ArgumentNullException>(() => new Art("name", null));
      Assert.Throws<ArgumentException>(() => new Art(string.Empty, "image"));
      Assert.Throws<ArgumentException>(() => new Art("name", string.Empty));
      art = new Art("name", "image", new ArtsAlbum(), "text", new Person(), "place", "material");
      Assert.NotNull(art.Album);
      Assert.False(art.Comments.Any());
      Assert.True(art.DateCreated >= DateTime.MinValue && art.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, art.Id);
      Assert.NotNull(art.Image);
      Assert.Null(art.Language);
      Assert.True(art.LastUpdated >= DateTime.MinValue && art.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("material", art.Material);
      Assert.Equal("name", art.Name);
      Assert.NotNull(art.Person);
      Assert.Equal("place", art.Place);
      Assert.False(art.Tags.Any());
      Assert.Equal("text", art.Text);
      Assert.Equal(0, art.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.Album"/> property.</para>
    /// </summary>
    [Fact]
    public void Album_Property()
    {
      var album = new ArtsAlbum();
      Assert.True(ReferenceEquals(new Art { Album = album }.Album, album));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Art { Image = null });
      Assert.Throws<ArgumentException>(() => new Art { Image = string.Empty });

      Assert.Equal("image", new Art { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.Material"/> property.</para>
    /// </summary>
    [Fact]
    public void Material_Property()
    {
      Assert.Equal("material", new Art { Material = "material" }.Material);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.Person"/> property.</para>
    /// </summary>
    [Fact]
    public void Person_Property()
    {
      var person = new Person();
      Assert.True(ReferenceEquals(new Art { Person = person }.Person, person));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.Place"/> property.</para>
    /// </summary>
    [Fact]
    public void Place_Property()
    {
      Assert.Equal("place", new Art { Place = "place" }.Place);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.CompareTo(Art)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Art.Equals(Art)"/></description></item>
    ///     <item><description><see cref="Art.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Album", new ArtsAlbum { Name = "first" }, new ArtsAlbum { Name = "second" });
      this.TestEquality("Person", new Person { NameFirst = "first" }, new Person { NameFirst = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Art.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Album", new ArtsAlbum { Name = "first" }, new ArtsAlbum { Name = "second" });
      this.TestHashCode("Person", new Person { NameFirst = "first" }, new Person { NameFirst = "second" });
    }
  }
}