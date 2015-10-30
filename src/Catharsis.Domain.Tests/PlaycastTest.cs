using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class PlaycastTest : EntityTest<Playcast>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Playcast();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Audio);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Image);
      Assert.Empty(fixture.Tags);
      Assert.Null(fixture.Text);
      Assert.Null(fixture.Video);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Playcast().ToString());
      Assert.Empty(new Playcast { Name = string.Empty }.ToString());
      Assert.Empty(new Playcast { Name = " " }.ToString());
      Assert.Equal("name", new Playcast { Name = " name " }.ToString());
    }
  }
}