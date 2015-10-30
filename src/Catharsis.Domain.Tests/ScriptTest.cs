using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ScriptTest : EntityTest<Script>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Script();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Code);
      Assert.Null(fixture.Duration);
      Assert.Null(fixture.Executed);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Path);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Script().ToString());
      Assert.Empty(new Script { Name = string.Empty }.ToString());
      Assert.Empty(new Script { Name = " " }.ToString());
      Assert.Equal("name", new Script { Name = " name " }.ToString());
    }
  }
}