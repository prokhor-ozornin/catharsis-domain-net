using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Book"/>.</para>
/// </summary>
public sealed class BookTest : EntityTest<Book>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Title"/> property.</para>
  /// </summary>
  [Fact]
  public void Title_Property()
  {
    new Book {Title = Guid.Empty.ToString()}.Title.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Author"/> property.</para>
  /// </summary>
  [Fact]
  public void Author_Property()
  {
    var author = new Person();
    new Book { Author = author }.Author.Should().BeSameAs(author);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Language"/> property.</para>
  /// </summary>
  [Fact]
  public void Language_Property()
  {
    new Book {Language = Guid.Empty.ToString()}.Language.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Isbn"/> property.</para>
  /// </summary>
  [Fact]
  public void Isbn_Property()
  {
    new Book {Isbn = Guid.Empty.ToString()}.Isbn.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Annotation"/> property.</para>
  /// </summary>
  [Fact]
  public void Annotation_Property()
  {
    new Book {Annotation = Guid.Empty.ToString()}.Annotation.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Notes"/> property.</para>
  /// </summary>
  [Fact]
  public void Notes_Property()
  {
    new Book {Notes = Guid.Empty.ToString()}.Notes.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.PublishDate"/> property.</para>
  /// </summary>
  [Fact]
  public void PublishDate_Property()
  {
    new Book { PublishDate = DateTimeOffset.MaxValue}.PublishDate.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Publisher"/> property.</para>
  /// </summary>
  [Fact]
  public void Publisher_Property()
  {
    new Book {Publisher = Guid.Empty.ToString()}.Publisher.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Cover"/> property.</para>
  /// </summary>
  [Fact]
  public void Cover_Property()
  {
    var cover = new Image();
    new Book { Cover = cover }.Cover.Should().BeSameAs(cover);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Contents"/> property.</para>
  /// </summary>
  [Fact]
  public void Contents_Property()
  {
    new Book {Contents = Guid.Empty.ToString()}.Contents.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.Tags"/> property.</para>
  /// </summary>
  [Fact]
  public void Tags_Property()
  {
    var tags = new HashSet<Tag>();
    new Book { Tags = tags}.Tags.Should().BeSameAs(tags);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Book()"/>
  [Fact]
  public void Constructors()
  {
    var book = new Book();

    book.Id.Should().BeNull();
    book.Uuid.Should().NotBeNull();
    book.Version.Should().BeNull();
    book.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    book.UpdatedOn.Should().BeNull();

    book.Title.Should().BeNull();
    book.Author.Should().BeNull();
    book.Language.Should().BeNull();
    book.Isbn.Should().BeNull();
    book.Annotation.Should().BeNull();
    book.Notes.Should().BeNull();
    book.PublishDate.Should().BeNull();
    book.Publisher.Should().BeNull();
    book.Cover.Should().BeNull();
    book.Contents.Should().BeNull();
    book.Tags.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.CompareTo(Book)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Book.Title), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Book.Equals(Book)"/></description></item>
  ///     <item><description><see cref="Book.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Book.Isbn), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Book.Isbn), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Book.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Book().ToString().Should().BeEmpty();
    new Book {Title = string.Empty}.ToString().Should().BeEmpty();
    new Book {Title = " "}.ToString().Should().BeEmpty();
    new Book {Title = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }
}