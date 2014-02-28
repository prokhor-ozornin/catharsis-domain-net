using System;
using System.Linq;
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
    public void Attributes()
    {
      this.TestDescription("Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Item()"/>
    ///   <seealso cref="Item(string, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var item = new Item();
      Assert.False(item.Comments.Any());
      Assert.True(item.DateCreated >= DateTime.MinValue && item.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, item.Id);
      Assert.Null(item.Language);
      Assert.True(item.LastUpdated >= DateTime.MinValue && item.LastUpdated <= DateTime.UtcNow);
      Assert.Null(item.Name);
      Assert.False(item.Tags.Any());
      Assert.Null(item.Text);
      Assert.Equal(0, item.Version);

      Assert.Throws<ArgumentNullException>(() => new Item(null));
      Assert.Throws<ArgumentException>(() => new Item(string.Empty));
      item = new Item("name", "text");
      Assert.False(item.Comments.Any());
      Assert.True(item.DateCreated >= DateTime.MinValue && item.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, item.Id);
      Assert.Null(item.Language);
      Assert.True(item.LastUpdated >= DateTime.MinValue && item.LastUpdated <= DateTime.UtcNow);
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
    ///   <para>Performs testing of <see cref="Item.CommentsList"/> property.</para>
    /// </summary>
    [Fact]
    public void CommentsList_Property()
    {
      var comment = new Comment();
      var item = new Item();
      Assert.False(item.CommentsList.Any());
      item.Comments.Add(comment);
      Assert.Equal(1, item.CommentsList.Count());
      Assert.True(ReferenceEquals(item.CommentsList.Single(), comment));
      item.Comments.Add(comment);
      Assert.Equal(2, item.CommentsList.Count());
      item.Comments.Add(new Comment());
      Assert.Equal(3, item.CommentsList.Count());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.DateCreated"/> property.</para>
    /// </summary>
    [Fact]
    public void DateCreated_Property()
    {
      Assert.Equal(DateTime.MinValue, new Item { DateCreated = DateTime.MinValue }.DateCreated);
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
    ///   <para>Performs testing of <see cref="Item.LastUpdated"/> property.</para>
    /// </summary>
    [Fact]
    public void LastUpdated_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Item { LastUpdated = DateTime.MaxValue }.LastUpdated);
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
    ///   <para>Performs testing of <see cref="Item.TagsList"/> property.</para>
    /// </summary>
    [Fact]
    public void TagsList_Propery()
    {
      var item = new Item();
      Assert.False(item.TagsList.Any());
      item.Tags.Add("tag");
      Assert.Equal(1, item.TagsList.Count());
      Assert.Equal("tag", item.TagsList.Single());
      item.Tags.Add("tag");
      Assert.Equal(2, item.TagsList.Count());
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
      Assert.True(new Item { DateCreated = DateTime.MinValue }.CompareTo(new Item { DateCreated = DateTime.MaxValue }) < 0);
      Assert.Equal(0, new Item { DateCreated = DateTime.MinValue }.CompareTo(new Item { DateCreated = DateTime.MinValue }));
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Item.Equals(Item)"/></description></item>
    ///     <item><description><see cref="Item.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Language", "first", "second");
      this.TestEquality("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Item.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Language", "first", "second");
      this.TestHashCode("Name", "first", "second");
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