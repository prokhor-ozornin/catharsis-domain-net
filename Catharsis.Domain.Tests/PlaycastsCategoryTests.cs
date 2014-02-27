using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="PlaycastsCategory"/>.</para>
  /// </summary>
  public sealed class PlaycastsCategoryTests : CategoryUnitTests<PlaycastsCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="PlaycastsCategory()"/>
    ///   <seealso cref="PlaycastsCategory(string, PlaycastsCategory, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var category = new PlaycastsCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new PlaycastsCategory();
      category = new PlaycastsCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="PlaycastsCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new PlaycastsCategory();
      Assert.True(ReferenceEquals(new PlaycastsCategory { Parent = parent }.Parent, parent));
    }
  }
}