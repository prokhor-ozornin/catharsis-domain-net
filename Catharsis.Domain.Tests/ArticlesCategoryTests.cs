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
    public void Attributes()
    {
      this.TestDescription("Description", "Language", "Name", "Parent");
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
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var category = new ArticlesCategory();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new ArticlesCategory("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());
      Assert.Equal(category, category.Json().Json<ArticlesCategory>());

      category = new ArticlesCategory("name", new ArticlesCategory("parent.name"), "description") { Id = 1, Language = "language" };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name"",""Parent"":{""Id"":0,""Name"":""parent.name""}}", category.Json());
      Assert.Equal(category, category.Json().Json<ArticlesCategory>());
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