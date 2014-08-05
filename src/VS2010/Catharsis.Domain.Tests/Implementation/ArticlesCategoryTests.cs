using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ArticlesCategory"/>.</para>
  /// </summary>
  public sealed class ArticlesCategoryTests : CategoryUnitTestsBase<ArticlesCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Description", "Language", "Name", "Parent");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new ArticlesCategory(), new { Id = 0 });
      this.TestJson(new ArticlesCategory("name"), new { Id = 0, Name = "name" });
      this.TestJson(
        new ArticlesCategory("name", new ArticlesCategory("parent.name"), "description")
        {
          Id = 1,
          Language = "language"
        },
        new { Id = 1, Description = "description", Language = "language", Name = "name", Parent = new { Id = 0, Name = "parent.name" } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new ArticlesCategory(), new { Id = 0 });
      this.TestJson(new ArticlesCategory("name"), new { Id = 0, Name = "name" });
      this.TestJson(
        new ArticlesCategory("name", new ArticlesCategory("parent.name"), "description")
        {
          Id = 1,
          Language = "language"
        },
        new { Id = 1, Description = "description", Language = "language", Name = "name", Parent = new { Id = 0, Name = "parent.name" } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="ArticlesCategory()"/>
    /// <seealso cref="ArticlesCategory(string, ArticlesCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var category = new ArticlesCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new ArticlesCategory();
      category = new ArticlesCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ArticlesCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new ArticlesCategory();
      Assert.True(ReferenceEquals(new ArticlesCategory { Parent = parent }.Parent, parent));
    }
  }
}