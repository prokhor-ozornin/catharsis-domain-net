using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TextsCategory"/>.</para>
  /// </summary>
  public sealed class TextsCategoryTests : CategoryUnitTests<TextsCategory>
  {
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