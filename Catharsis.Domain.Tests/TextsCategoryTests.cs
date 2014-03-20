using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TextsCategory"/>.</para>
  /// </summary>
  public sealed class TextsCategoryTests : CategoryUnitTestsBase<TextsCategory>
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
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var category = new TextsCategory();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new TextsCategory("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());

      category = new TextsCategory("name", new TextsCategory("parent.name"), "description") { Id = 1, Language = "language" };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name"",""Parent"":{""Id"":0,""Name"":""parent.name""}}", category.Json());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="TextsCategory()"/>
    /// <seealso cref="TextsCategory(string, TextsCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var category = new TextsCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new TextsCategory();
      category = new TextsCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextsCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new TextsCategory();
      Assert.True(ReferenceEquals(new TextsCategory { Parent = parent }.Parent, parent));
    }
  }
}