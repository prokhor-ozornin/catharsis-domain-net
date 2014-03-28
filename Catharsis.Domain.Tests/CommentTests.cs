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
      this.TestDescription("DateCreated", "LastUpdated", "Name", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var comment = new Comment();
      Assert.Equal(@"{{""Id"":0,""DateCreated"":""{0}"",""LastUpdated"":""{1}""}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO()), comment.Json());

      comment = new Comment("name", "text");
      Assert.Equal(@"{{""Id"":0,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Text"":""text""}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO()), comment.Json());
      Assert.Equal(comment, comment.Json().Json<Comment>());

      comment = new Comment("name", "text")
      {
        Id = 1 
      };
      Assert.Equal(@"{{""Id"":1,""DateCreated"":""{0}"",""LastUpdated"":""{1}"",""Name"":""name"",""Text"":""text""}}".FormatSelf(comment.DateCreated.ISO(), comment.LastUpdated.ISO()), comment.Json());
      Assert.Equal(comment, comment.Json().Json<Comment>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var comment = new Comment();
      this.TestXml(comment, "<Id>0</Id><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated>".FormatSelf(comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString()));

      comment = new Comment("name", "text");
      this.TestXml(comment, "<Id>0</Id><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Name>name</Name><Text>text</Text>".FormatSelf(comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString()));
      Assert.Equal(comment, comment.Xml().Xml<Comment>());

      comment = new Comment("name", "text")
      {
        Id = 1
      };
      this.TestXml(comment, "<Id>1</Id><DateCreated>{0}</DateCreated><LastUpdated>{1}</LastUpdated><Name>name</Name><Text>text</Text>".FormatSelf(comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString(), comment.DateCreated.ToXmlString(), comment.LastUpdated.ToXmlString()));
      Assert.Equal(comment, comment.Xml().Xml<Comment>());
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
      this.TestCompareTo("DateCreated", DateTime.MinValue, DateTime.MaxValue);
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