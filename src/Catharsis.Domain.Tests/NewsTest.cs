using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class NewsTest : EntityTest<News>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new News();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Annotation);
      Assert.Null(fixture.Image);
      Assert.Null(fixture.Name);
      Assert.Empty(fixture.Tags);
      Assert.Null(fixture.Text);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
      this.test_equals_and_hash_code("Name", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new News().ToString());
      Assert.Empty(new News { Name = string.Empty }.ToString());
      Assert.Empty(new News { Name = " " }.ToString());
      Assert.Equal("name", new News { Name = " name " }.ToString());
    }
  }
}