using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class LogMessageTest : EntityTest<LogMessage>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new LogMessage();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Level);
      Assert.Null(fixture.Logger);
      Assert.Null(fixture.RequestId);
      Assert.Null(fixture.Text);
      Assert.Null(fixture.Thread);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("RequestId", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new LogMessage().ToString());
      Assert.Empty(new LogMessage { Text = string.Empty }.ToString());
      Assert.Empty(new LogMessage { Text = " " }.ToString());
      Assert.Equal("text", new LogMessage { Text = " text " }.ToString());
    }
  }
}