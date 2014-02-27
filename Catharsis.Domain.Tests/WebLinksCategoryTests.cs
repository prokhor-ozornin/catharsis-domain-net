using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="WebLinksCategory"/>.</para>
  /// </summary>
  public sealed class WebLinksCategoryTests : CategoryUnitTests<WebLinksCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="WebLinksCategory()"/>
    ///   <seealso cref="WebLinksCategory(string, WebLinksCategory, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var category = new WebLinksCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new WebLinksCategory();
      category = new WebLinksCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="WebLinksCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new WebLinksCategory();
      Assert.True(ReferenceEquals(new WebLinksCategory { Parent = parent }.Parent, parent));
    }
  }
}