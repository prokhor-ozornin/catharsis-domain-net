using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class BookExtensionsTest
  {
    [Fact]
    public void author_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Book>) null).Author(new Person()));

      Assert.Empty(Enumerable.Empty<Book>().AsQueryable().Author(new Person()));
      Assert.Equal(1, new[] { new Book { Author = new Person { Id = 1 } }, new Book { Author = new Person { Id = 2 } } }.AsQueryable().Author(new Person { Id = 1 }).Count());
    }

    [Fact]
    public void author_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Book>)null).Author(new Person()));

      Assert.Empty(Enumerable.Empty<Book>().Author(new Person()));
      Assert.Single(new[] { null, new Book(), new Book { Author = new Person { FirstName = "first" } }, new Book { Author = new Person { FirstName = "second" } } }.Author(new Person { FirstName = "first" }));
    }

    [Fact]
    public void language_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Book>)null).Language("fax"));
      Assert.Throws<ArgumentNullException>(() => new Book[] { }.AsQueryable().Language(null));
      Assert.Throws<ArgumentException>(() => new Book[] { }.AsQueryable().Language(string.Empty));

      Assert.Equal(1, new[] { new Book { Language = "First" }, new Book { Language = "Second" } }.AsQueryable().Language("first").Count());
    }

    [Fact]
    public void language_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Book>)null).Language("level"));
      Assert.Throws<ArgumentNullException>(() => new Book[] { }.Language(null));
      Assert.Throws<ArgumentException>(() => new Book[] { }.Language(string.Empty));

      Assert.Single(new[] { null, new Book(), new Book { Language = "First" }, new Book { Language = "Second" } }.Language("first"));
    }

    [Fact]
    public void publish_date_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Book>)null).PublishDate());

      var books = new[] { new Book { PublishDate = new DateTime(2000, 1, 1) }, new Book { PublishDate = new DateTime(2000, 1, 2) } }.AsQueryable();
      Assert.Equal(2, books.PublishDate().Count());
      Assert.Equal(2, books.PublishDate(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(books.PublishDate(new DateTime(2000, 1, 3)));
      Assert.Equal(1, books.PublishDate(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, books.PublishDate(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(books.PublishDate(to: new DateTime(1999, 12, 31)));
      Assert.Equal(1, books.PublishDate(to: new DateTime(2000, 1, 1)).Count());
      Assert.Equal(2, books.PublishDate(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void publish_date_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Book>)null).PublishDate());

      var books = new[] { null, new Book(), new Book { PublishDate = new DateTime(2000, 1, 1) }, new Book { PublishDate = new DateTime(2000, 1, 2) } };
      Assert.Equal(3, books.PublishDate().Count());
      Assert.Equal(2, books.PublishDate(new DateTime(1999, 1, 31)).Count());
      Assert.Empty(books.PublishDate(new DateTime(2000, 1, 3)));
      Assert.Single(books.PublishDate(new DateTime(1999, 1, 31), new DateTime(2000, 1, 1)));
      Assert.Equal(2, books.PublishDate(new DateTime(2000, 1, 1), new DateTime(2000, 1, 2)).Count());
      Assert.Empty(books.PublishDate(to: new DateTime(1999, 12, 31)));
      Assert.Single(books.PublishDate(to: new DateTime(2000, 1, 1)));
      Assert.Equal(2, books.PublishDate(to: new DateTime(2000, 1, 3)).Count());
    }

    [Fact]
    public void tag_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Book>)null).Tag(new Tag()));
      Assert.Throws<ArgumentNullException>(() => new Book[] { }.AsQueryable().Tag(null));

      Assert.Equal(1, new[] { new Book { Tags = new HashSet<Tag> { new Tag { Name = "first" } } }, new Book { Tags = new HashSet<Tag> { new Tag { Name = "second" } } } }.AsQueryable().Tag(new Tag { Name = "first" }).Count());
    }

    [Fact]
    public void tag_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Book>)null).Tag(new Tag()));
      Assert.Throws<ArgumentNullException>(() => new Book[] { }.Tag(null));

      Assert.Single(new[] { null, new Book(), new Book { Tags = new HashSet<Tag> { new Tag { Name = "first" } } }, new Book { Tags = new HashSet<Tag> { new Tag { Name = "second" } } } }.Tag(new Tag { Name = "first" }));
    }

    [Fact]
    public void value_of_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Book>)null).ValueOf("isbn"));
      Assert.Throws<ArgumentNullException>(() => new Book[] { }.AsQueryable().ValueOf(null));
      Assert.Throws<ArgumentException>(() => new Book[] { }.AsQueryable().ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Book { Isbn = "Isbn" }, new Book { Isbn = "isbn" } }.AsQueryable().ValueOf("isbn"));

      Assert.Null(new Book[] { }.AsQueryable().ValueOf("isbn"));
      Assert.NotNull(new[] { new Book { Isbn = "First" }, new Book { Isbn = "Second" } }.AsQueryable().ValueOf("first"));
    }

    [Fact]
    public void value_of_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Book>)null).ValueOf("isbn"));
      Assert.Throws<ArgumentNullException>(() => new Book[] { }.ValueOf(null));
      Assert.Throws<ArgumentException>(() => new Book[] { }.ValueOf(string.Empty));
      Assert.Throws<InvalidOperationException>(() => new[] { new Book { Isbn = "Isbn" }, new Book { Isbn = "isbn" } }.ValueOf("isbn"));

      Assert.Null(new Book[] { }.ValueOf("isbn"));
      Assert.NotNull(new[] { new Book { Isbn = "First" }, new Book { Isbn = "Second" } }.ValueOf("first"));
    }
  }
}