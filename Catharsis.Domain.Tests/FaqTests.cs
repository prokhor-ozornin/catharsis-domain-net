using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Faq"/>.</para>
  /// </summary>
  public sealed class FaqTests : EntityUnitTests<Faq>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var faq = new Faq();

      faq = new Faq("name", "text");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[],""Text"":""text""}}".FormatSelf(faq.DateCreated.ISO(), faq.LastUpdated.ISO()), faq.Json());
      Assert.Equal(faq, faq.Json().Json<Faq>());

      var comment = new Comment("comment.name", "comment.text");
      faq = new Faq("name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      Assert.Equal(@"{{""Id"":1,""Comments"":[{{""Id"":0,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""DateCreated"":""{2}"",""Language"":""language"",""LastUpdated"":""{3}"",""Name"":""name"",""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO(), faq.DateCreated.ISO(), faq.LastUpdated.ISO(), faq.DateCreated.ISO(), faq.LastUpdated.ISO()), faq.Json());
      Assert.Equal(faq, faq.Json().Json<Faq>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var faq = new Faq();
      this.TestXml(faq, "<Id>0</Id><Comments /><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Tags />".FormatSelf(faq.DateCreated.ToXmlString(), faq.LastUpdated.ToXmlString()));

      faq = new Faq("name", "text");
      this.TestXml(faq, "<Id>0</Id><Comments /><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Name>name</Name><Tags /><Text>text</Text>".FormatSelf(faq.DateCreated.ToXmlString(), faq.LastUpdated.ToXmlString()));
      Assert.Equal(faq, faq.Xml().Xml<Faq>());

      var comment = new Comment("comment.name", "comment.text");
      faq = new Faq("name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(faq, "<Id>1</Id><Comments><Comment><Id>0</Id><DateCreated>{2}</DateCreated><LastUpdated>{3}</LastUpdated><Name>comment.name</Name><Text>comment.text</Text></Comment></Comments><DateCreated>{0}</DateCreated><Language>language</Language><LastUpdated>{1}</LastUpdated><Name>name</Name><Tags><Tag>tag</Tag></Tags><Text>text</Text>".FormatSelf(faq.DateCreated.ToXmlString(), faq.LastUpdated.ToXmlString(), comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString()));
      Assert.Equal(faq, faq.Xml().Xml<Faq>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Faq()"/>
    /// <seealso cref="Faq(string, string)"/>
    [Fact]
    public void Constructors()
    {
      var faq = new Faq();
      Assert.False(faq.Comments.Any());
      Assert.True(faq.DateCreated >= DateTime.MinValue && faq.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, faq.Id);
      Assert.Null(faq.Language);
      Assert.True(faq.LastUpdated >= DateTime.MinValue && faq.LastUpdated <= DateTime.UtcNow);
      Assert.Null(faq.Name);
      Assert.False(faq.Tags.Any());
      Assert.Null(faq.Text);
      Assert.Equal(0, faq.Version);

      Assert.Throws<ArgumentNullException>(() => new Faq(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Faq("name", null));
      Assert.Throws<ArgumentException>(() => new Faq(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Faq("name", string.Empty));
      faq = new Faq("name", "text");
      Assert.False(faq.Comments.Any());
      Assert.True(faq.DateCreated >= DateTime.MinValue && faq.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, faq.Id);
      Assert.Null(faq.Language);
      Assert.True(faq.LastUpdated >= DateTime.MinValue && faq.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", faq.Name);
      Assert.False(faq.Tags.Any());
      Assert.Equal("text", faq.Text);
      Assert.Equal(0, faq.Version);
    }
  }
}