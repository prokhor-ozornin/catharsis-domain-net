using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VideosCategory"/>.</para>
  /// </summary>
  public sealed class VideosCategoryTests : CategoryUnitTests<VideosCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="VideosCategory()"/>
    ///   <seealso cref="VideosCategory(string, VideosCategory, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var category = new VideosCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new VideosCategory();
      category = new VideosCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VideosCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new VideosCategory();
      Assert.True(ReferenceEquals(new VideosCategory { Parent = parent }.Parent, parent));
    }
  }
}