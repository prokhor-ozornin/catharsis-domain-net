﻿using Catharsis.Commons;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VideosCategory"/>.</para>
  /// </summary>
  public sealed class VideosCategoryTests : CategoryUnitTestsBase<VideosCategory>
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
      this.TestJson(new VideosCategory(), new { Id = 0 });
      this.TestJson(new VideosCategory("name"), new { Id = 0, Name = "name" });
      this.TestJson(
        new VideosCategory("name", new VideosCategory("parent.name"), "description")
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
      this.TestXml(new VideosCategory(), new { Id = 0 });
      this.TestXml(new VideosCategory("name"), new { Id = 0, Name = "name" });
      this.TestXml(
        new VideosCategory("name", new VideosCategory("parent.name"), "description")
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
    /// <seealso cref="VideosCategory()"/>
    /// <seealso cref="VideosCategory(string, VideosCategory, string)"/>
    [Fact]
    public void Constructors()
    {
      var category = new VideosCategory();
      Assert.Null(category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Null(category.Name);
      Assert.Null(category.Parent);
      Assert.Equal(0, category.Version);

      var parent = new VideosCategory();
      category = new VideosCategory("name", parent, "description");
      Assert.Equal("description", category.Description);
      Assert.Equal(0, category.Id);
      Assert.Null(category.Language);
      Assert.Equal("name", category.Name);
      Assert.True(ReferenceEquals(category.Parent, parent));
      Assert.Equal(0, category.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VideosCategory.Parent"/> property.</para>
    /// </summary>
    [Fact]
    public void Parent_Property()
    {
      var parent = new VideosCategory();
      Assert.True(ReferenceEquals(new VideosCategory { Parent = parent }.Parent, parent));
    }
  }
}