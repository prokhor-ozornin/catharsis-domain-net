using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Comment"/>.</para>
  /// </summary>
  public sealed class CommentTests : EntityUnitTests<Comment>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Comment()"/>
    ///   <seealso cref="Comment(string, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var comment = new Comment();
      Assert.True(comment.DateCreated >= DateTime.MinValue && comment.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, comment.Id);
      Assert.True(comment.LastUpdated >= DateTime.MinValue && comment.LastUpdated <= DateTime.UtcNow);
      Assert.Null(comment.Name);
      Assert.Null(comment.Text);
      Assert.Equal(0, comment.Version);

      Assert.Throws<ArgumentNullException>(() => new Comment(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Comment("name", null));
      Assert.Throws<ArgumentException>(() => new Comment(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Comment("name", string.Empty));
      comment = new Comment("name", "text");
      Assert.True(comment.DateCreated >= DateTime.MinValue && comment.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, comment.Id);
      Assert.True(comment.LastUpdated >= DateTime.MinValue && comment.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", comment.Name);
      Assert.Equal("text", comment.Text);
      Assert.Equal(0, comment.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.DateCreated"/> property.</para>
    /// </summary>
    [Fact]
    public void DateCreated_Property()
    {
      Assert.Equal(DateTime.MinValue, new Comment { DateCreated = DateTime.MinValue }.DateCreated);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.LastUpdated"/> property.</para>
    /// </summary>
    [Fact]
    public void LastUpdated_Property()
    {
      Assert.Equal(DateTime.MinValue, new Comment { LastUpdated = DateTime.MinValue }.LastUpdated);
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
      Assert.True(new Comment { DateCreated = DateTime.MinValue }.CompareTo(new Comment { DateCreated = DateTime.MaxValue }) < 0);
      Assert.Equal(0, new Comment { DateCreated = DateTime.MinValue }.CompareTo(new Comment { DateCreated = DateTime.MinValue }));
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Comment.Equals(Comment)"/></description></item>
    ///     <item><description><see cref="Comment.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Name", "first", "second");
      this.TestEquality("Text", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Comment.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
      this.TestHashCode("Text", "first", "second");
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