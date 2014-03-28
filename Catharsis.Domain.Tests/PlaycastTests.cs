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
      this.TestDescription("Audio", "Category", "Comments", "DateCreated", "Image", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var playcast = new Playcast();
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(playcast.DateCreated.ISO(), playcast.LastUpdated.ISO()), playcast.Json());

      playcast = new Playcast("name", "text");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[],""Text"":""text""}}".FormatSelf(playcast.DateCreated.ISO(), playcast.LastUpdated.ISO()), playcast.Json());
      Assert.Equal(playcast, playcast.Json().Json<Playcast>());

      var comment = new Comment("comment.name", "comment.text");
      playcast = new Playcast("name", "text", new PlaycastsCategory("category.name"), "audio", "image")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      Assert.Equal(@"{{""Id"":1,""Audio"":""audio"",""Category"":{{""Id"":0,""Name"":""category.name""}},""Comments"":[{{""Id"":0,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{2}"",""Image"":""image"",""Language"":""language"",""LastUpdated"":""{3}"",""Name"":""name"",""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO(), playcast.DateCreated.ISO(), playcast.LastUpdated.ISO()), playcast.Json());
      Assert.Equal(playcast, playcast.Json().Json<Playcast>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var playcast = new Playcast();
      this.TestXml(playcast, "<Id>0</Id><Comments /><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Tags />".FormatSelf(playcast.DateCreated.ToXmlString(), playcast.LastUpdated.ToXmlString()));

      playcast = new Playcast("name", "text");
      this.TestXml(playcast, "<Id>0</Id><Comments /><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Name>name</Name><Tags /><Text>text</Text>".FormatSelf(playcast.DateCreated.ToXmlString(), playcast.LastUpdated.ToXmlString()));
      Assert.Equal(playcast, playcast.Xml().Xml<Playcast>());

      var comment = new Comment("comment.name", "comment.text");
      playcast = new Playcast("name", "text", new PlaycastsCategory("category.name"), "audio", "image")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(playcast, "<Id>1</Id><Comments><Comment><Id>0</Id><DateCreated>{2}</DateCreated><LastUpdated>{3}</LastUpdated><Name>comment.name</Name><Text>comment.text</Text></Comment></Comments><DateCreated>{0}</DateCreated><Language>language</Language><LastUpdated>{1}</LastUpdated><Name>name</Name><Tags><Tag>tag</Tag></Tags><Text>text</Text><Audio>audio</Audio><Category><Id>0</Id><Name>category.name</Name></Category><Image>image</Image>".FormatSelf(playcast.DateCreated.ToXmlString(), playcast.LastUpdated.ToXmlString(), comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString()));
      Assert.Equal(playcast, playcast.Xml().Xml<Playcast>());
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
      Assert.True(playcast.DateCreated >= DateTime.MinValue && playcast.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, playcast.Id);
      Assert.Null(playcast.Image);
      Assert.Null(playcast.Language);
      Assert.True(playcast.LastUpdated >= DateTime.MinValue && playcast.LastUpdated <= DateTime.UtcNow);
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
      Assert.True(playcast.DateCreated >= DateTime.MinValue && playcast.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, playcast.Id);
      Assert.NotNull(playcast.Image);
      Assert.Null(playcast.Language);
      Assert.True(playcast.LastUpdated >= DateTime.MinValue && playcast.LastUpdated <= DateTime.UtcNow);
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

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Playcast.Equals(Playcast)"/></description></item>
    ///     <item><description><see cref="Playcast.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new PlaycastsCategory { Name = "first" }, new PlaycastsCategory { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new PlaycastsCategory { Name = "first" }, new PlaycastsCategory { Name = "second" });
    }
  }
}