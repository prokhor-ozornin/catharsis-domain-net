using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DownloadsCategory"/>.</para>
  /// </summary>
  public sealed class DownloadsCategoryTests : CategoryUnitTests<DownloadsCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DownloadsCategory()"/>
    /// <seealso cref="DownloadsCategory(string, DownloadsCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var category = new DownloadsCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new DownloadsCategory();
      category = new DownloadsCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DownloadsCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new DownloadsCategory();
      Assert.True(ReferenceEquals(new DownloadsCategory { Parent = parent }.Parent, parent));
    }
  }
}