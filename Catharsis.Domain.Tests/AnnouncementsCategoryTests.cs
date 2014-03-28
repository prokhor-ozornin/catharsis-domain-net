using Catharsis.Commons;
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
      var category = new AnnouncementsCategory();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new AnnouncementsCategory("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());
      Assert.Equal(category, category.Json().Json<AnnouncementsCategory>());

      category = new AnnouncementsCategory("name", new AnnouncementsCategory("parent.name"), "description")
      {
        Id = 1,
        Language = "language"
      };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name"",""Parent"":{""Id"":0,""Name"":""parent.name""}}", category.Json());
      Assert.Equal(category, category.Json().Json<AnnouncementsCategory>());
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      var category = new AnnouncementsCategory();
      this.TestXml(category, "<Id>0</Id>");
      
      category = new AnnouncementsCategory("name");
      this.TestXml(category, "<Id>0</Id><Name>name</Name>");
      Assert.Equal(category, category.Xml().Xml<AnnouncementsCategory>());

      category = new AnnouncementsCategory("name", new AnnouncementsCategory("parent.name"), "description")
      {
        Id = 1,
        Language = "language"
      };
      this.TestXml(category, "<Id>1</Id><Description>description</Description><Language>language</Language><Name>name</Name><Parent><Id>0</Id><Name>parent.name</Name></Parent>");
      Assert.Equal(category, category.Xml().Xml<AnnouncementsCategory>());
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