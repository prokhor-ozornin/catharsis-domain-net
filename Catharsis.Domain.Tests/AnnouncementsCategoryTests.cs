using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AnnouncementsCategory"/>.</para>
  /// </summary>
  public sealed class AnnouncementsCategoryTests : CategoryUnitTests<AnnouncementsCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="AnnouncementsCategory()"/>
    ///   <seealso cref="AnnouncementsCategory(string, AnnouncementsCategory, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var category = new AnnouncementsCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new AnnouncementsCategory();
      category = new AnnouncementsCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="AnnouncementsCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new AnnouncementsCategory();
      Assert.True(ReferenceEquals(new AnnouncementsCategory { Parent = parent }.Parent, parent));
    }
  }
}