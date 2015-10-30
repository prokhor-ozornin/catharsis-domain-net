using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class TagTest : EntityTest<Tag>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Tag();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Name);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Tag().ToString());
      Assert.Empty(new Tag { Name = string.Empty }.ToString());
      Assert.Empty(new Tag { Name = " " }.ToString());
      Assert.Equal("name", new Tag { Name = " name " }.ToString());
    }
  }
}