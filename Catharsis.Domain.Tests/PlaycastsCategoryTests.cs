using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="PlaycastsCategory"/>.</para>
  /// </summary>
  public sealed class PlaycastsCategoryTests : CategoryUnitTestsBase<PlaycastsCategory>
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
      this.TestJson(new PlaycastsCategory(), new { Id = 0 });
      this.TestJson(new PlaycastsCategory("name"), new { Id = 0, Name = "name" });
      this.TestJson(
        new PlaycastsCategory("name", new PlaycastsCategory("parent.name"), "description")
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
      this.TestXml(new PlaycastsCategory(), new { Id = 0 });
      this.TestXml(new PlaycastsCategory("name"), new { Id = 0, Name = "name" });
      this.TestXml(
        new PlaycastsCategory("name", new PlaycastsCategory("parent.name"), "description")
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
    /// <seealso cref="PlaycastsCategory()"/>
    /// <seealso cref="PlaycastsCategory(string, PlaycastsCategory, string)"/>
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