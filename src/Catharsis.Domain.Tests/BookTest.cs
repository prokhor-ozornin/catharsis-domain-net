using System;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class BookTest : EntityTest<Book>
  {
    [Fact]
    public void constructors()
    {
      var fixture = new Book();
      Assert.Null(fixture.Id);
      Assert.True(fixture.CreatedOn <= DateTime.UtcNow);
      Assert.Null(fixture.UpdatedOn);
      Assert.Null(fixture.Version);
      Assert.Null(fixture.Annotation);
      Assert.Null(fixture.Author);
      Assert.Null(fixture.Contents);
      Assert.Null(fixture.Cover);
      Assert.Null(fixture.Isbn);
      Assert.Null(fixture.Language);
      Assert.Null(fixture.Notes);
      Assert.Null(fixture.PublishDate);
      Assert.Null(fixture.Publisher);
      Assert.Empty(fixture.Tags);
      Assert.Null(fixture.Title);
    }

    [Fact]
    public void compare_to()
    {
      this.test_compare_to("Title", "first", "second");
    }

    [Fact]
    public void equals_and_hash_code()
    {
      this.test_equals_and_hash_code("Isbn", "first", "second");
    }

    [Fact]
    public void to_string()
    {
      Assert.Empty(new Book().ToString());
      Assert.Empty(new Book { Title = string.Empty }.ToString());
      Assert.Empty(new Book { Title = " " }.ToString());
      Assert.Equal("title", new Book { Title = " title " }.ToString());
    }
  }
}