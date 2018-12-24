using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class FaqTest : EntityTest<Faq>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Faq();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Answer);
      Assert.Null(fixture.Question);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Faq().ToString());
      Assert.Empty(new Faq { Question = string.Empty }.ToString());
      Assert.Empty(new Faq { Question = " " }.ToString());
      Assert.Equal("question", new Faq { Question = " question " }.ToString());
    }
  }
}