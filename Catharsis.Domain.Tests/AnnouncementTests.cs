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
      this.TestDescription("Category", "Comments", "Currency", "DateCreated", "Image", "Language", "Name", "Price", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var announcement = new Announcement();
      this.TestJson(announcement, new { Id = 0, Comments = new object[] { }, DateCreated = announcement.DateCreated.ISO8601(), LastUpdated = announcement.LastUpdated.ISO8601(), Tags = new object[] { } });

      announcement = new Announcement("name", "text");
      this.TestJson(announcement, new { Id = 0, Comments = new object[] { }, DateCreated = announcement.DateCreated.ISO8601(), LastUpdated = announcement.LastUpdated.ISO8601(), Name = "name", Tags = new object[] { }, Text = "text" });
      
      var comment = new Comment("comment.name", "comment.text");
      announcement = new Announcement("name", "text", new AnnouncementsCategory("category.name"), "image", "currency", (decimal)1.5)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(announcement, new { Id = 1, Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, DateCreated = comment.DateCreated.ISO8601(), LastUpdated = comment.LastUpdated.ISO8601(), Name = "comment.name", Text = "comment.text" } }, Currency = "currency", DateCreated = announcement.DateCreated.ISO8601(), Image = "image", Language = "language", LastUpdated = announcement.LastUpdated.ISO8601(), Name = "name", Price = 1.5, Tags = new object[] { "tag" }, Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var announcement = new Announcement();
      this.TestXml(announcement, new { Id = 0, DateCreated = announcement.DateCreated, LastUpdated = announcement.LastUpdated });

      announcement = new Announcement("name", "text");
      this.TestXml(announcement, new { Id = 0, DateCreated = announcement.DateCreated, LastUpdated = announcement.LastUpdated, Name = "name", Text = "text" });

      var comment = new Comment("comment.name", "comment.text");
      announcement = new Announcement("name", "text", new AnnouncementsCategory("category.name"), "image", "currency", (decimal)1.0)
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(announcement, new { Id = 1, Currency = "currency", DateCreated = announcement.DateCreated, Image = "image", Language = "language", LastUpdated = announcement.LastUpdated, Name = "name", Price = 1.0, Text = "text" });
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
      Assert.True(announcement.DateCreated >= DateTime.MinValue && announcement.DateCreated <= DateTime.UtcNow);
      Assert.Null(announcement.Image);
      Assert.Null(announcement.Language);
      Assert.True(announcement.LastUpdated >= DateTime.MinValue && announcement.LastUpdated <= DateTime.UtcNow);
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
      Assert.True(announcement.DateCreated >= DateTime.MinValue && announcement.DateCreated <= DateTime.UtcNow);
      Assert.Equal("image", announcement.Image);
      Assert.Null(announcement.Language);
      Assert.True(announcement.LastUpdated >= DateTime.MinValue && announcement.LastUpdated <= DateTime.UtcNow);
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

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Announcement.Equals(Announcement)"/></description></item>
    ///     <item><description><see cref="Announcement.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new AnnouncementsCategory { Name = "first" }, new AnnouncementsCategory { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Announcement.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new AnnouncementsCategory { Name = "first" }, new AnnouncementsCategory { Name = "second" });
    }
  }
}