using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class DirectoryCompanyTest : EntityTest<DirectoryCompany>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new DirectoryCompany();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Code);
      Assert.Null(fixture.Contact);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.ShortName);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new DirectoryCompany().ToString());
      Assert.Empty(new DirectoryCompany { Name = string.Empty }.ToString());
      Assert.Empty(new DirectoryCompany { Name = " " }.ToString());
      Assert.Equal("name", new DirectoryCompany { Name = " name " }.ToString());
    }
  }
}