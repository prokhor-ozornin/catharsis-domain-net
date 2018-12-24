using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class SettingTest : EntityTest<Setting>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Setting();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Description);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Type);
      Assert.Null(fixture.Value);
      Assert.Empty(fixture.Values);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Name", "fist", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Equal("[]", new Setting().ToString());
      Assert.Empty(new Setting { Value = string.Empty }.ToString());
      Assert.Equal(" ", new Setting { Value = " " }.ToString());
      Assert.Equal("value", new Setting { Value = "value" }.ToString());
    }
  }
}