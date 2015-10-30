using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class AnnouncementTest : EntityTest<Announcement>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Announcement();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Image);
      Assert.Null(fixture.Name);
      Assert.Null(fixture.Price);
      Assert.Null(fixture.PriceCurrency);
      Assert.Null(fixture.Text);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Announcement().ToString());
      Assert.Empty(new Announcement { Name = string.Empty }.ToString());
      Assert.Empty(new Announcement { Name = " " }.ToString());
      Assert.Equal("name", new Announcement { Name = " name " }.ToString());
    }
  }
}