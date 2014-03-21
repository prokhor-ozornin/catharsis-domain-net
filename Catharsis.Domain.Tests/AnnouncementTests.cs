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
    public void Attributes()
    {
      this.TestDescription("Category", "Comments", "Currency", "DateCreated", "Image", "Language", "Name", "Price", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var announcement = new Announcement();
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Tags"":[]}}".FormatSelf(announcement.DateCreated.ISO(), announcement.LastUpdated.ISO()), announcement.Json());

      announcement = new Announcement("name", "text");
      Assert.Equal(@"{{""Id"":0,""Comments"":[],""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Tags"":[],""Text"":""text""}}".FormatSelf(announcement.DateCreated.ISO(), announcement.LastUpdated.ISO()), announcement.Json());
      Assert.Equal(announcement, announcement.Json().Json<Announcement>());

      var comment = new Comment("comment.name", "comment.text");
      announcement = new Announcement("name", "text", new AnnouncementsCategory("category.name"), "image", "currency", (decimal)1.0) { Id = 1, Language = "language", Comments = new List<Comment> { comment }, Tags = new List<string> { "tag" } };
      Assert.Equal(@"{{""Id"":1,""Category"":{{""Id"":0,""Name"":""category.name""}},""Comments"":[{{""Id"":0,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""comment.name"",""Text"":""comment.text""}}],""Currency"":""currency"",""DateCreated"":""{2}"",""Image"":""image"",""Language"":""language"",""LastUpdated"":""{3}"",""Name"":""name"",""Price"":1.0,""Tags"":[""tag""],""Text"":""text""}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO(), announcement.DateCreated.ISO(), announcement.LastUpdated.ISO()), announcement.Json());
      Assert.Equal(announcement, announcement.Json().Json<Announcement>());
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