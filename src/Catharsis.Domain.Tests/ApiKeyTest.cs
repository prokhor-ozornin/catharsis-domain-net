using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ApiKeyTest : EntityTest<ApiKey>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new ApiKey();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.AppDescription);
      Assert.Null(fixture.AppDomain);
      Assert.Null(fixture.AppName);
      Assert.Null(fixture.Contact);
      Assert.Null(fixture.Name);
      Assert.NotEmpty(fixture.Value);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Value", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.NotEmpty(new ApiKey().ToString());
      Assert.Empty(new ApiKey { Value = string.Empty }.ToString());
      Assert.Empty(new ApiKey { Value = " " }.ToString());
      Assert.Equal("value", new ApiKey { Value = " value " }.ToString());
    }
  }
}