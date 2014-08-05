using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Playcast"/>.</para>
  /// </summary>
  public sealed class PlaycastTests : EntityUnitTests<Playcast>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Audio", "Category", "Comments", "CreatedAt", "Image", "Language", "UpdatedAt", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var playcast = new Playcast();
      this.TestJson(playcast, new { Id = 0, Comments = new object[] { }, CreatedAt = playcast.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = playcast.UpdatedAt.ISO8601() });

      playcast = new Playcast("name", "text");
      this.TestJson(playcast, new { Id = 0, Comments = new object[] { }, CreatedAt = playcast.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, Text = "text", UpdatedAt = playcast.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      playcast = new Playcast("name", "text", new PlaycastsCategory("category.name"), "audio", "image")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(playcast, new { Id = 1, Audio = "audio", Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = playcast.CreatedAt.ISO8601(), Image = "image", Language = "language", Name = "name", Tags = new object[] { "tag" }, Text = "text", UpdatedAt = playcast.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var playcast = new Playcast();
      this.TestXml(playcast, new { Id = 0, CreatedAt = playcast.CreatedAt, UpdatedAt = playcast.UpdatedAt });

      playcast = new Playcast("name", "text");
      this.TestXml(playcast, new { Id = 0, CreatedAt = playcast.CreatedAt, UpdatedAt = playcast.UpdatedAt, Name = "name", Text = "text" });

      var comment = new Comment("comment.name", "comment.text");
      playcast = new Playcast("name", "text", new PlaycastsCategory("category.name"), "audio", "image")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(playcast, new { Id = 1, Audio = "audio", CreatedAt = playcast.CreatedAt, Image = "image", Language = "language", UpdatedAt = playcast.UpdatedAt, Name = "name", Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Playcast()"/>
    /// <seealso cref="Playcast(string, string, PlaycastsCategory, string, string)"/>
    [Fact]
    public void Constructors()
    {
      var playcast = new Playcast();
      Assert.Null(playcast.Audio);
      Assert.Null(playcast.Category);
      Assert.False(playcast.Comments.Any());
      Assert.True(playcast.CreatedAt >= DateTime.MinValue && playcast.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, playcast.Id);
      Assert.Null(playcast.Image);
      Assert.Null(playcast.Language);
      Assert.True(playcast.UpdatedAt >= DateTime.MinValue && playcast.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(playcast.Name);
      Assert.False(playcast.Tags.Any());
      Assert.Null(playcast.Text);
      Assert.Equal(0, playcast.Version);

      Assert.Throws<ArgumentNullException>(() => new Playcast(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Playcast("name", null));
      Assert.Throws<ArgumentException>(() => new Playcast(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Playcast("name", string.Empty));
      playcast = new Playcast("name", "text", new PlaycastsCategory(), "audio", "name");
      Assert.NotNull(playcast.Audio);
      Assert.NotNull(playcast.Category);
      Assert.False(playcast.Comments.Any());
      Assert.True(playcast.CreatedAt >= DateTime.MinValue && playcast.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, playcast.Id);
      Assert.NotNull(playcast.Image);
      Assert.Null(playcast.Language);
      Assert.True(playcast.UpdatedAt >= DateTime.MinValue && playcast.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", playcast.Name);
      Assert.False(playcast.Tags.Any());
      Assert.Equal("text", playcast.Text);
      Assert.Equal(0, playcast.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.Audio"/> property.</para>
    /// </summary>
    [Fact]
    public void Audio_Property()
    {
      Assert.Equal("audio", new Playcast { Audio = "audio" }.Audio);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new PlaycastsCategory();
      Assert.True(ReferenceEquals(new Playcast { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new Playcast { Image = "image" }.Image);
    }
  }
}