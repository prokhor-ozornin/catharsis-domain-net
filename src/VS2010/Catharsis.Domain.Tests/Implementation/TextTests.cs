using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Text"/>.</para>
  /// </summary>
  public sealed class TextTests : EntityUnitTests<Text>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Category", "Comments", "CreatedAt", "Language", "UpdatedAt", "Name", "Tags", "Text", "Person", "Translations");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var text = new Text();
      this.TestJson(text, new { Id = 0, Comments = new object[] { }, CreatedAt = text.CreatedAt.ISO8601(), Tags = new object[] { }, Translations = new object[] { }, UpdatedAt = text.UpdatedAt.ISO8601() });

      var person = new Person("person.nameFirst", "person.nameLast");
      
      text = new Text("name", "text", person);
      this.TestJson(text, new { Id = 0, Comments = new object[] { }, CreatedAt = text.CreatedAt.ISO8601(), Name = "name", Person = new { Id = 0, NameFirst = "person.nameFirst", NameLast = "person.nameLast" }, Tags = new object[] { }, Text = "text", Translations = new object[] { }, UpdatedAt = text.UpdatedAt.ISO8601() });

      var comment = new Comment("comment.name", "comment.text");
      var translation = new TextTranslation("translation.language", "translation.name", "translation.text");
      text = new Text("name", "text", person, new TextsCategory("category.name"))
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" },
        Translations = new List<TextTranslation> { translation }
      };
      this.TestJson(text, new { Id = 1, Category = new { Id = 0, Name = "category.name" }, Comments = new object[] { new { Id = 0, CreatedAt = comment.CreatedAt.ISO8601(), Name = "comment.name", Text = "comment.text", UpdatedAt = comment.UpdatedAt.ISO8601() } }, CreatedAt = text.CreatedAt.ISO8601(), Language = "language", Name = "name", Person = new { Id = 0, NameFirst = "person.nameFirst", NameLast = "person.nameLast" }, Tags = new object[] { "tag" }, Text = "text", Translations = new object[] { new { Id = 0, Language = "translation.language", Name = "translation.name", Text = "translation.text" } }, UpdatedAt = text.UpdatedAt.ISO8601() });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var text = new Text();
      this.TestXml(text, new { Id = 0, CreatedAt = text.CreatedAt, UpdatedAt = text.UpdatedAt });

      var person = new Person("person.nameFirst", "person.nameLast");

      text = new Text("name", "text", person);
      this.TestXml(text, new { Id = 0, CreatedAt = text.CreatedAt, UpdatedAt = text.UpdatedAt, Name = "name", Text = "text" });

      var comment = new Comment("comment.name", "comment.text");
      var translation = new TextTranslation("translation.language", "translation.name", "translation.text");
      text = new Text("name", "text", person, new TextsCategory("category.name"))
      {
        Id = 1,
        Language = "language",
        Comments = new List<Comment> { comment },
        Tags = new List<string> { "tag" },
        Translations = new List<TextTranslation> { translation }
      };
      this.TestXml(text, new { Id = 1, CreatedAt = text.CreatedAt, Language = "language", UpdatedAt = text.UpdatedAt, Name = "name", Text = "text" });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Text()"/>
    /// <seealso cref="Text(string, string, Person, TextsCategory)"/>
    [Fact]
    public void Constructors()
    {
      var text = new Text();
      Assert.Null(text.Category);
      Assert.False(text.Comments.Any());
      Assert.True(text.CreatedAt >= DateTime.MinValue && text.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, text.Id);
      Assert.Null(text.Language);
      Assert.True(text.UpdatedAt >= DateTime.MinValue && text.UpdatedAt <= DateTime.UtcNow);
      Assert.Null(text.Name);
      Assert.False(text.Tags.Any());
      Assert.Null(text.Text);
      Assert.Null(text.Person);
      Assert.False(text.Translations.Any());
      Assert.Equal(0, text.Version);

      Assert.Throws<ArgumentNullException>(() => new Text(null, "text", new Person()));
      Assert.Throws<ArgumentNullException>(() => new Text("name", null, new Person()));
      Assert.Throws<ArgumentNullException>(() => new Text("name", "text", null));
      Assert.Throws<ArgumentException>(() => new Text(string.Empty, "text", new Person()));
      Assert.Throws<ArgumentException>(() => new Text("name", string.Empty, new Person()));
      text = new Text("name", "text", new Person(), new TextsCategory());
      Assert.NotNull(text.Category);
      Assert.False(text.Comments.Any());
      Assert.True(text.CreatedAt >= DateTime.MinValue && text.CreatedAt <= DateTime.UtcNow);
      Assert.Equal(0, text.Id);
      Assert.Null(text.Language);
      Assert.True(text.UpdatedAt >= DateTime.MinValue && text.UpdatedAt <= DateTime.UtcNow);
      Assert.Equal("name", text.Name);
      Assert.False(text.Tags.Any());
      Assert.Equal("text", text.Text);
      Assert.NotNull(text.Person);
      Assert.False(text.Translations.Any());
      Assert.Equal(0, text.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Text.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new TextsCategory();
      Assert.True(ReferenceEquals(new Text { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Text.Person"/> property.</para>
    /// </summary>
    [Fact]
    public void Person_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Text { Person = null });
      var person = new Person();

      Assert.True(ReferenceEquals(new Text { Person = person }.Person, person));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Text.Translations"/> property.</para>
    /// </summary>
    [Fact]
    public void Translations_Property()
    {
      var translation = new TextTranslation();
      var text = new Text();
      Assert.False(text.Translations.Any());
      text.Translations.Add(translation);
      Assert.Equal(1, text.Translations.Count);
      Assert.True(ReferenceEquals(text.Translations.Single(), translation));
      text.Translations.Add(translation);
      Assert.Equal(2, text.Translations.Count);
    }
  }
}