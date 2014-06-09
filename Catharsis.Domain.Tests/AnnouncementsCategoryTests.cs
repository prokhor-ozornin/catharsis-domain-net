using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AnnouncementsCategory"/>.</para>
  /// </summary>
  public sealed class AnnouncementsCategoryTests : CategoryUnitTestsBase<AnnouncementsCategory>
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
      this.TestJson(new AnnouncementsCategory(), new { Id = 0 });
      this.TestJson(new AnnouncementsCategory("name"), new { Id = 0, Name = "name" });
      this.TestJson(
        new AnnouncementsCategory("name", new AnnouncementsCategory("parent.name"), "description")
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
      this.TestXml(new AnnouncementsCategory(), new { Id = 0 });
      this.TestXml(new AnnouncementsCategory("name"), new { Id = 0, Name = "name" });
      this.TestXml(
        new AnnouncementsCategory("name", new AnnouncementsCategory("parent.name"), "description")
        {
          Id = 1,
          Language = "language"
        },
        new { Id = 1, Description = "description", Language = "language", Name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="AnnouncementsCategory()"/>
    /// <seealso cref="AnnouncementsCategory(string, AnnouncementsCategory, string)"/>
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