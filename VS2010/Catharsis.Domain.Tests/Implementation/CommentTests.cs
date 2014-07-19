using System;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Comment"/>.</para>
  /// </summary>
  public sealed class CommentTests : EntityUnitTests<Comment>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("CreatedAt", "UpdatedAt", "Name", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var comment = new Comment();
      this.TestJson(comment, new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), UpdatedAt = comment.UpdatedAt.ISO8601() });

      comment = new Comment("name", "text");
      this.TestJson(comment, new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "name", Text = "text", UpdatedAt = comment.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var comment = new Comment();
      this.TestXml(comment, new { Id = 0, CreatedAt = comment.CreatedAt, UpdatedAt = comment.UpdatedAt });

      comment = new Comment("name", "text");
      this.TestXml(comment, new { Id = 0, CreatedAt = comment.CreatedAt, UpdatedAt = comment.UpdatedAt, Name = "name", Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Comment()"/>
    /// <seealso cref="Comment(string, string)"/>
    [Fact]
    public void Constructors()
    {
      var comment = new Comment();
      Assert.True(comment.CreatedAt >= DateTime.MinValue && comment.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, comment.Id);
      Assert.True(comment.UpdatedAt >= DateTime.MinValue && comment.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(comment.Name);
      Assert.Null(comment.Text);
      Assert.Equal(0, comment.Version);

      Assert.Throws<ArgumentNullException>(() => new Comment(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Comment("name", null));
      Assert.Throws<ArgumentException>(() => new Comment(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Comment("name", string.Empty));
      comment = new Comment("name", "text");
      Assert.True(comment.CreatedAt >= DateTime.MinValue && comment.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, comment.Id);
      Assert.True(comment.UpdatedAt >= DateTime.MinValue && comment.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", comment.Name);
      Assert.Equal("text", comment.Text);
      Assert.Equal(0, comment.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.CreatedAt"/> property.</para>
    /// </summary>
    [Fact]
    public void CreatedAt_Property()
    {
      Assert.Equal(DateTime.MinValue, new Comment { CreatedAt = DateTime.MinValue }.CreatedAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.UpdatedAt"/> property.</para>
    /// </summary>
    [Fact]
    public void UpdatedAt_Property()
    {
      Assert.Equal(DateTime.MinValue, new Comment { UpdatedAt = DateTime.MinValue }.UpdatedAt);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Comment { Name = null });
      Assert.Throws<ArgumentException>(() => new Comment { Name = string.Empty });
      
      Assert.Equal("name", new Comment { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Comment { Text = null });
      Assert.Throws<ArgumentException>(() => new Comment { Text = string.Empty });
      
      Assert.Equal("text", new Comment { Text = "text" }.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.CompareTo(Comment)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("CreatedAt", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Comment { Name = "name" }.ToString());
    }
  }
}