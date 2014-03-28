using Catharsis.Commons;
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
      var category = new WebLinksCategory();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new WebLinksCategory("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());

      category = new WebLinksCategory("name", new WebLinksCategory("parent.name"), "description")
      {
        Id = 1,
        Language = "language"
      };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name"",""Parent"":{""Id"":0,""Name"":""parent.name""}}", category.Json());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var category = new WebLinksCategory();
      this.TestXml(category, "<Id>0</Id>");

      category = new WebLinksCategory("name");
      this.TestXml(category, "<Id>0</Id><Name>name</Name>");
      Assert.Equal(category, category.Xml().Xml<WebLinksCategory>());

      category = new WebLinksCategory("name", new WebLinksCategory("parent.name"), "description")
      {
        Id = 1,
        Language = "language"
      };
      this.TestXml(category, "<Id>1</Id><Description>description</Description><Language>language</Language><Name>name</Name><Parent><Id>0</Id><Name>parent.name</Name></Parent>");
      Assert.Equal(category, category.Xml().Xml<WebLinksCategory>());
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