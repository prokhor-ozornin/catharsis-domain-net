using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AudiosCategory"/>.</para>
  /// </summary>
  public sealed class AudiosCategoryTests : CategoryUnitTestsBase<AudiosCategory>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Description", "Language", "Name", "Parent");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="AudiosCategory()"/>
    /// <seealso cref="AudiosCategory(string, AudiosCategory, string)"/>
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
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var category = new AudiosCategory();
      Assert.Equal(@"{""Id"":0}", category.Json());

      category = new AudiosCategory("name");
      Assert.Equal(@"{""Id"":0,""Name"":""name""}", category.Json());
      Assert.Equal(category, category.Json().Json<AudiosCategory>());

      category = new AudiosCategory("name", new AudiosCategory("parent.name"), "description") { Id = 1, Language = "language" };
      Assert.Equal(@"{""Id"":1,""Description"":""description"",""Language"":""language"",""Name"":""name"",""Parent"":{""Id"":0,""Name"":""parent.name""}}", category.Json());
      Assert.Equal(category, category.Json().Json<AudiosCategory>());
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