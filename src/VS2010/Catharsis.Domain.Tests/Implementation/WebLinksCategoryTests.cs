using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="WebLinksCategory"/>.</para>
  /// </summary>
  public sealed class WebLinksCategoryTests : CategoryUnitTestsBase<WebLinksCategory>
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
      this.TestJson(new WebLinksCategory(), new { Id = 0 });
      this.TestJson(new WebLinksCategory("name"), new { Id = 0, Name = "name" });
      this.TestJson(
        new WebLinksCategory("name", new WebLinksCategory("parent.name"), "description")
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
      this.TestXml(new WebLinksCategory(), new { Id = 0 });
      this.TestXml(new WebLinksCategory("name"), new { Id = 0, Name = "name" });
      this.TestXml(
        new WebLinksCategory("name", new WebLinksCategory("parent.name"), "description")
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
    /// <seealso cref="WebLinksCategory()"/>
    /// <seealso cref="WebLinksCategory(string, WebLinksCategory, string)"/>
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