using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class PersonTest : EntityTest<Person>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Person();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.BirthDate);
      Assert.Null(fixture.DeathDate);
      Assert.Null(fixture.FirstName);
      Assert.Null(fixture.LastName);
      Assert.Null(fixture.MiddleName);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("FirstName", "first", "second");
      this.test_compare_to("LastName", "first", "second");
      this.test_compare_to("MiddleName", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Person().ToString());
      Assert.Equal("Ozornin Prokhor Nikolaevich", new Person { FirstName = "Prokhor", LastName = "Ozornin", MiddleName = "Nikolaevich" }.ToString());
      Assert.Equal("Ozornin Prokhor", new Person { FirstName = "Prokhor", LastName = "Ozornin" }.ToString());
      Assert.Equal("Prokhor", new Person { FirstName = "Prokhor" }.ToString());
    }
  }
}