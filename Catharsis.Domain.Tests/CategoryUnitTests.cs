using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Category"/>.</para>
  /// </summary>
  public sealed class CategoryTests : CategoryUnitTestsBase<Category>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public override void Attributes()
    {
      base.Attributes();
      this.TestDescription("Description", "Language", "Name");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var category = new Category();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new Category("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());
      Assert.Equal(category, category.Json().Json<Category>());

      category = new Category("name", "description") { Id = 1, Language = "language" };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name""}", category.Json());
      Assert.Equal(category, category.Json().Json<Category>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var category = new Category();
      this.TestXml(category, "<Id>0</Id>");

      category = new Category("name");
      this.TestXml(category, "<Id>0</Id><Name>name</Name>");
      Assert.Equal(category, category.Xml().Xml<Category>());

      category = new Category("name", "description")
      {
        Id = 1,
        Language = "language"
      };
      this.TestXml(category, "<Id>1</Id><Description>description</Description><Language>language</Language><Name>name</Name>");
      Assert.Equal(category, category.Xml().Xml<Category>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Category()"/>
    /// <seealso cref="Category(string, string)"/>
    [Fact]
    public void Constructors()
    {
      var category = new Category();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Equal(0, category.Version);

      category = new Category("name", "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="ArticlesCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new ArticlesCategory();
      Assert.True(ReferenceEquals(new ArticlesCategory { Parent = parent }.Parent, parent));
    }
  }
}