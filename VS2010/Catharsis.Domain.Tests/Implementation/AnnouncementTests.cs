using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Announcement"/>.</para>
  /// </summary>
  public sealed class AnnouncementTests : EntityUnitTests<Announcement>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Category", "Comments", "Currency", "CreatedAt", "Image", "Language", "Name", "Price", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var announcement = new Announcement();
      this.TestJson(announcement, new { Id = 0, Comments = new object[] { }, CreatedAt = announcement.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = announcement.UpdatedAt.ISO8601() });

      announcement = new Announcement("name", "text");
      this.TestJson(announcement, new { Id = 0, Comments = new object[] { }, CreatedAt = announcement.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, Text = "text", UpdatedAt = announcement.UpdatedAt.ISO8601() });
      
      var comment = new Comment("comment.name", "comment.text");
      announcement = new Announcement("name", "text", new AnnouncementsCategory("category.name"), "image", "currency", (decimal)1.5)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(announcement, new { Id = 1, Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = announcement.CreatedAt.ISO8601(), Currency = "currency", Image = "image", Language = "language", Name = "name", Price = 1.5, Tags = new object[] { "tag" }, Text = "text", UpdatedAt = announcement.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var announcement = new Announcement();
      this.TestXml(announcement, new { Id = 0, CreatedAt = announcement.CreatedAt, UpdatedAt = announcement.UpdatedAt });

      announcement = new Announcement("name", "text");
      this.TestXml(announcement, new { Id = 0, CreatedAt = announcement.CreatedAt, UpdatedAt = announcement.UpdatedAt, Name = "name", Text = "text" });

      var comment = new Comment("comment.name", "comment.text");
      announcement = new Announcement("name", "text", new AnnouncementsCategory("category.name"), "image", "currency", (decimal)1.0)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(announcement, new { Id = 1, Currency = "currency", CreatedAt = announcement.CreatedAt, Image = "image", Language = "language", UpdatedAt = announcement.UpdatedAt, Name = "name", Price = 1.0, Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Announcement()"/>
    /// <seealso cref="Announcement(string, string, AnnouncementsCategory, string, string, decimal?)"/>
    [Fact]
    public void Constructors()
    {
      var announcement = new Announcement();
      Assert.Equal(0, announcement.Id);
      Assert.Null(announcement.Category);
      Assert.False(announcement.Comments.Any());
      Assert.Null(announcement.Currency);
      Assert.True(announcement.CreatedAt >= DateTime.MinValue && announcement.CreatedAt <= DateTime.UtcNow);
      Assert.Null(announcement.Image);
      Assert.Null(announcement.Language);
      Assert.True(announcement.UpdatedAt >= DateTime.MinValue && announcement.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(announcement.Name);
      Assert.Null(announcement.Price);
      Assert.False(announcement.Tags.Any());
      Assert.Null(announcement.Text);
      Assert.Equal(0, announcement.Version);

      Assert.Throws<ArgumentNullException>(() => new Announcement(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Announcement("name", null));
      Assert.Throws<ArgumentException>(() => new Announcement(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Announcement("name", string.Empty));
      announcement = new Announcement("name", "text", new AnnouncementsCategory(), "image", "currency", decimal.One);
      Assert.Equal(0, announcement.Id);
      Assert.NotNull(announcement.Category);
      Assert.False(announcement.Comments.Any());
      Assert.Equal("currency", announcement.Currency);
      Assert.True(announcement.CreatedAt >= DateTime.MinValue && announcement.CreatedAt <= DateTime.UtcNow);
      Assert.Equal("image", announcement.Image);
      Assert.Null(announcement.Language);
      Assert.True(announcement.UpdatedAt >= DateTime.MinValue && announcement.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", announcement.Name);
      Assert.Equal(decimal.One, announcement.Price);
      Assert.False(announcement.Tags.Any());
      Assert.Equal("text", announcement.Text);
      Assert.Equal(0, announcement.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Announcement.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new AnnouncementsCategory();
      Assert.True(ReferenceEquals(new Announcement { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Announcement.Currency"/> property.</para>
    /// </summary>
    [Fact]
    public void Currency_Property()
    {
      Assert.Equal("currency", new Announcement { Currency = "currency" }.Currency);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Announcement.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new Announcement { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Announcement.Price"/> property.</para>
    /// </summary>
    [Fact]
    public void Price_Property()
    {
      Assert.Equal(decimal.One, new Announcement { Price = decimal.One }.Price);
    }
  }
}