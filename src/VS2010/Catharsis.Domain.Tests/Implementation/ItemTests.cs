using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Item"/>.</para>
  /// </summary>
  public sealed class ItemTests : EntityUnitTests<Item>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Comments", "CreatedAt", "Language", "UpdatedAt", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var item = new Item();
      this.TestJson(item, new { Id = 0, Comments = new object[] { }, CreatedAt = item.CreatedAt.ISO8601(), Tags = new object[] { }, UpdatedAt = item.UpdatedAt.ISO8601() });

      item = new Item("name");
      this.TestJson(item, new { Id = 0, Comments = new object[] { }, CreatedAt = item.CreatedAt.ISO8601(), Name = "name", Tags = new object[] { }, UpdatedAt = item.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      item = new Item("name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestJson(item, new { Id = 1, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = item.CreatedAt.ISO8601(), Language = "language", Name = "name", Tags = new object[] { "tag" }, Text = "text", UpdatedAt = item.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var item = new Item();
      this.TestXml(item, new { Id = 0, CreatedAt = item.CreatedAt, UpdatedAt = item.UpdatedAt });

      item = new Item("name");
      this.TestXml(item, new { Id = 0, CreatedAt = item.CreatedAt, UpdatedAt = item.UpdatedAt, Name = "name" });

      var comment = new Comment("comment.name", "comment.text");
      item = new Item("name", "text")
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" }
      };
      this.TestXml(item, new { Id = 1, CreatedAt = item.CreatedAt, Language = "language", UpdatedAt = item.UpdatedAt, Name = "name", Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Item()"/>
    /// <seealso cref="Item(string, string)"/>
    [Fact]
    public void Constructors()
    {
      var item = new Item();
      Assert.False(item.Comments.Any());
      Assert.True(item.CreatedAt >= DateTime.MinValue && item.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, item.Id);
      Assert.Null(item.Language);
      Assert.True(item.UpdatedAt >= DateTime.MinValue && item.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(item.Name);
      Assert.False(item.Tags.Any());
      Assert.Null(item.Text);
      Assert.Equal(0, item.Version);

      Assert.Throws<ArgumentNullException>(() => new Item(null));
      Assert.Throws<ArgumentException>(() => new Item(string.Empty));
      item = new Item("name", "text");
      Assert.False(item.Comments.Any());
      Assert.True(item.CreatedAt >= DateTime.MinValue && item.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, item.Id);
      Assert.Null(item.Language);
      Assert.True(item.UpdatedAt >= DateTime.MinValue && item.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", item.Name);
      Assert.False(item.Tags.Any());
      Assert.Equal("text", item.Text);
      Assert.Equal(0, item.Version);
    }
    
    /// <summary>
    ///   <para>Performs testing of <see cref="Item.Comments"/> property.</para>
    /// </summary>
    [Fact]
    public void Comments_Property()
    {
      var comment = new Comment();
      var item = new Item();
      Assert.False(item.Comments.Any());
      item.Comments.Add(comment);
      Assert.Equal(1, item.Comments.Count);
      Assert.True(ReferenceEquals(item.Comments.Single(), comment));
      item.Comments.Add(comment);
      Assert.Equal(2, item.Comments.Count);
      item.Comments.Add(new Comment());
      Assert.Equal(3, item.Comments.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.CreatedAt"/> property.</para>
    /// </summary>
    [Fact]
    public void CreatedAt_Property()
    {
      Assert.Equal(DateTime.MinValue, new Item { CreatedAt = DateTime.MinValue }.CreatedAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.Language"/> property.</para>
    /// </summary>
    [Fact]
    public void Language_Property()
    {
      Assert.Equal("language", new Item { Language = "language" }.Language);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.UpdatedAt"/> property.</para>
    /// </summary>
    [Fact]
    public void UpdatedAt_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Item { UpdatedAt = DateTime.MaxValue }.UpdatedAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Item { Name = null });
      Assert.Throws<ArgumentException>(() => new Item { Name = string.Empty });
      
      Assert.Equal("name", new Item { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.Tags"/> property.</para>
    /// </summary>
    [Fact]
    public void Tags_Property()
    {
      var item = new Item();
      Assert.False(item.Tags.Any());
      item.Tags.Add("tag");
      Assert.Equal(1, item.Tags.Count);
      Assert.Equal("tag", item.Tags.Single());
      item.Tags.Add("tag");
      Assert.Equal(2, item.Tags.Count);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Equal("text", new Item { Text = "text" }.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.CompareTo(Item)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("CreatedAt", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Item { Name = "name" }.ToString());
    }
  }
}