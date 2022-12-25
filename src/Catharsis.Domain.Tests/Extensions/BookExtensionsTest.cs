using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BookExtensions"/>.</para>
/// </summary>
public sealed class BookExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.Author(IQueryable{Book}, Person?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Author_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Book>) null!).Author(new Person())).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<Book>().AsQueryable().Author(new Person()).Should().BeEmpty();
    new[] {new Book {Author = new Person {Id = 1}}, new Book {Author = new Person {Id = 2}}}.AsQueryable().Author(new Person {Id = 1}).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.Author(IEnumerable{Book}, Person?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Author_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Book>) null!).Author(new Person())).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<Book>().Author(new Person()).Should().BeEmpty();
    new[] {null, new Book(), new Book {Author = new Person {FirstName = "first"}}, new Book {Author = new Person {FirstName = "second"}}}.Author(new Person {FirstName = "first"}).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.Language(IQueryable{Book}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Language_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Book>) null!).Language("fax")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().AsQueryable().Language(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().AsQueryable().Language(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Book {Language = "First"}, new Book {Language = "Second"}}.AsQueryable().Language("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.Language(IEnumerable{Book}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Language_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Book>) null!).Language("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().Language(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().Language(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Book(), new Book {Language = "First"}, new Book {Language = "Second"}}.Language("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.PublishDate(IQueryable{Book}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PublishDate_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Book>) null!).PublishDate()).ThrowExactly<ArgumentNullException>();

    var books = new[] {new Book {PublishDate = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Book {PublishDate = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}}.AsQueryable();
    books.PublishDate().Should().HaveCount(2);
    books.PublishDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    books.PublishDate(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    books.PublishDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    books.PublishDate(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    books.PublishDate(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    books.PublishDate(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    books.PublishDate(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.PublishDate(IEnumerable{Book}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void PublishDate_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Book>) null!).PublishDate()).ThrowExactly<ArgumentNullException>();

    var books = new[] {null, new Book(), new Book {PublishDate = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new Book {PublishDate = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    books.PublishDate().Should().HaveCount(3);
    books.PublishDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    books.PublishDate(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    books.PublishDate(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    books.PublishDate(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    books.PublishDate(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    books.PublishDate(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    books.PublishDate(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.Tag(IQueryable{Book}, Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void Tag_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Book>) null!).Tag(new Tag())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().AsQueryable().Tag(null!)).ThrowExactly<ArgumentNullException>();

    new[] {new Book {Tags = new HashSet<Tag> {new() {Name = "first"}}}, new Book {Tags = new HashSet<Tag> {new() {Name = "second"}}}}.AsQueryable().Tag(new Tag {Name = "first"}).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.Tag(IEnumerable{Book}, Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void Tag_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Book>) null!).Tag(new Tag())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().Tag(null!)).ThrowExactly<ArgumentNullException>();

    new[] {null, new Book(), new Book {Tags = new HashSet<Tag> {new() {Name = "first"}}}, new Book {Tags = new HashSet<Tag> {new() {Name = "second"}}}}.Tag(new Tag {Name = "first"}).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.ValueOf(IQueryable{Book}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Book>) null!).ValueOf("isbn")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().AsQueryable().ValueOf(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().AsQueryable().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new Book[] {new() {Isbn = "Isbn"}, new() {Isbn = "isbn"}}.AsQueryable().ValueOf("isbn")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Book>().AsQueryable().ValueOf("isbn").Should().BeNull();
    new[] {new Book {Isbn = "First"}, new Book {Isbn = "Second"}}.AsQueryable().ValueOf("first").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BookExtensions.ValueOf(IEnumerable{Book}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Book>) null!).ValueOf("isbn")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().ValueOf(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Book>().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Book {Isbn = "Isbn"}, new Book {Isbn = "isbn"}}.ValueOf("isbn")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Book>().ValueOf("isbn").Should().BeNull();
    new[] {new Book {Isbn = "First"}, new Book {Isbn = "Second"}}.ValueOf("first").Should().NotBeNull();
  }
}