namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Book"/>.</para>
/// </summary>
/// <seealso cref="Book"/>
public static class BookExtensions
{
  public static IQueryable<Book> Author(this IQueryable<Book> books, Person? author) => author != null ? books.Where(book => book.Author != null && book.Author.Id == author.Id) : books.Where(book => book.Author == null);

  public static IEnumerable<Book?> Author(this IEnumerable<Book?> books, Person? author) => author != null ? books.Where(book => book?.Author != null && book.Author.Equals(author)) : books.Where(book => book is {Author: null});

  public static IQueryable<Book> Language(this IQueryable<Book> books, string language) => books.Where(book => book.Language != null && book.Language.ToLower() == language.ToLower());

  public static IEnumerable<Book?> Language(this IEnumerable<Book?> books, string language) => books.Where(book => book?.Language != null && book.Language.ToLower() == language.ToLower());

  public static IQueryable<Book> Tag(this IQueryable<Book> books, Tag tag) => books.Where(book => book.Tags.Contains(tag));

  public static IEnumerable<Book?> Tag(this IEnumerable<Book?> books, Tag tag) => books.Where(book => book != null && book.Tags.Contains(tag));

  public static Book? ValueOf(this IQueryable<Book> books, string isbn) => books.SingleOrDefault(book => book.Isbn != null && book.Isbn.ToLower() == isbn.ToLower());

  public static Book? ValueOf(this IEnumerable<Book?> books, string isbn) => books.SingleOrDefault(book => book?.Isbn != null && book.Isbn.ToLower() == isbn.ToLower());

  public static IQueryable<Book> PublishDate(this IQueryable<Book> books, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      books = books.Where(book => book.PublishDate != null && book.PublishDate >= from.Value);
    }

    if (to != null)
    {
      books = books.Where(book => book.PublishDate != null && book.PublishDate <= to.Value);
    }

    return books;
  }

  public static IEnumerable<Book?> PublishDate(this IEnumerable<Book?> books, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from != null)
    {
      books = books.Where(book => book != null && book.PublishDate >= from.Value);
    }

    if (to != null)
    {
      books = books.Where(book => book != null && book.PublishDate <= to.Value);
    }

    return books.Where(book => book != null);
  }
}