using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using System;

namespace Catharsis.Domain
{
  public static class BookExtensions
  {
    public static IQueryable<Book> Author(this IQueryable<Book> books, Person author)
    {
      Assertion.NotNull(books);
      Assertion.NotNull(author);

      return author != null ? books.Where(it => it.Author.Id == author.Id) : books.Where(it => it.Author == null);
    }

    public static IEnumerable<Book> Author(this IEnumerable<Book> books, Person author)
    {
      Assertion.NotNull(books);
      Assertion.NotNull(author);

      return author != null ? books.Where(it => it?.Author != null && it.Author.Equals(author)) : books.Where(it => it != null && it.Author == null);
    }

    public static IQueryable<Book> Language(this IQueryable<Book> books, string language)
    {
      Assertion.NotNull(books);
      Assertion.NotEmpty(language);

      return books.Where(it => it.Language.ToLower() == language.ToLower());
    }

    public static IEnumerable<Book> Language(this IEnumerable<Book> books, string language)
    {
      Assertion.NotNull(books);
      Assertion.NotEmpty(language);

      return books.Where(it => it?.Language != null && it.Language.ToLower() == language.ToLower());
    }

    public static IQueryable<Book> PublishDate(this IQueryable<Book> books, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(books);

      if (from != null)
      {
        books = books.Where(it => it != null && it.PublishDate >= from.Value);
      }

      if (to != null)
      {
        books = books.Where(it => it != null && it.PublishDate <= to.Value);
      }

      return books;
    }

    public static IEnumerable<Book> PublishDate(this IEnumerable<Book> books, DateTime? from = null, DateTime? to = null)
    {
      if (from != null)
      {
        books = books.Where(it => it != null && it.PublishDate >= from.Value);
      }

      if (to != null)
      {
        books = books.Where(it => it != null && it.PublishDate <= to.Value);
      }

      return books.Where(it => it != null);
    }

    public static IQueryable<Book> Tag(this IQueryable<Book> books, Tag tag)
    {
      Assertion.NotNull(books);
      Assertion.NotNull(tag);

      return books.Where(it => it.Tags.Contains(tag));
    }

    public static IEnumerable<Book> Tag(this IEnumerable<Book> books, Tag tag)
    {
      Assertion.NotNull(books);
      Assertion.NotNull(tag);

      return books.Where(it => it != null && it.Tags.Contains(tag));
    }

    public static Book ValueOf(this IQueryable<Book> books, string isbn)
    {
      Assertion.NotNull(books);
      Assertion.NotEmpty(isbn);

      return books.SingleOrDefault(it => it.Isbn.ToLower() == isbn.ToLower());
    }

    public static Book ValueOf(this IEnumerable<Book> books, string isbn)
    {
      Assertion.NotNull(books);
      Assertion.NotEmpty(isbn);

      return books.SingleOrDefault(it => it.Isbn != null && it.Isbn.ToLower() == isbn.ToLower());
    }
  }
}