using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class ContactTest : EntityTest<Contact>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Contact();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Empty(fixture.Addresses);
      Assert.Empty(fixture.Emails);
      Assert.Null(fixture.Fax);
      Assert.Null(fixture.Icq);
      Assert.Null(fixture.Jabber);
      Assert.Empty(fixture.Phones);
      Assert.Null(fixture.Skype);
      Assert.Null(fixture.Website);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("CreatedOn", DateTime.MinValue, DateTime.MaxValue);
    }
  }
}