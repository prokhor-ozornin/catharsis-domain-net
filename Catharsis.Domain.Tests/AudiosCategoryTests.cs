using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AudiosCategory"/>.</para>
  /// </summary>
  public sealed class AudiosCategoryTests : CategoryUnitTests<AudiosCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="AudiosCategory()"/>
    ///   <seealso cref="AudiosCategory(string, AudiosCategory, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var category = new AudiosCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new AudiosCategory();
      category = new AudiosCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="AudiosCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new AudiosCategory();
      Assert.True(ReferenceEquals(new AudiosCategory { Parent = parent }.Parent, parent));
    }
  }
}