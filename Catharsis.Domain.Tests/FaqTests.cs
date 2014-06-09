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
      this.TestJson(faq, new { Id = 0, Comments = new object[] { }, DateCreated = faq.DateCreated.ISO8601(), LastUpdated = faq.LastUpdated.ISO8601(), Tags = new object[] { } });

      faq = new Faq("name", "text");
      this.TestJson(faq, new { Id = 0, Comments = new object[] {}, DateCreated = faq.DateCreated.ISO8601(), LastUpdated = faq.LastUpdated.ISO8601(), Name = "name", Tags = new object[] {}, Text = "text" });

      var comment = new Comment("comment.name", "comment.text");
      faq = new Faq("name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(faq, new { Id = 1, Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } }, DateCreated = faq.DateCreated.ISO8601(), Language = "language", LastUpdated = faq.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { "tag" }, Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var faq = new Faq();
      this.TestXml(faq, new { Id = 0, DateCreated = faq.DateCreated, LastUpdated = faq.LastUpdated });

      faq = new Faq("name", "text");
      this.TestXml(faq, new { Id = 0, DateCreated = faq.DateCreated, LastUpdated = faq.LastUpdated, Name = "name", Text = "text" });

      var comment = new Comment("comment.name", "comment.text");
      faq = new Faq("name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(faq, new { Id = 1, DateCreated = faq.DateCreated, Language = "language", LastUpdated = faq.LastUpdated, Name = "name", Text = "text" });
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