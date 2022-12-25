namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Book"/> entity.</para>
/// </summary>
public sealed class BookMapping : EntityMapping<Book>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public BookMapping()
  {
    Table("book");
    Map(book => book.Title).Column("title").Not.Nullable().Index("ix-book-title");
    References(book => book.Author).Column("author_id").Not.Nullable().Fetch.Join().ForeignKey("fk-book2person").Index("ix-book-author_id");
    Map(book => book.Language).Column("language").Length(2).Index("ix-book-language");
    Map(book => book.Isbn).Column("isbn").Length(13).UniqueKey("uk-book-isbn");
    Map(book => book.Annotation).Column("annotation").Length(1000);
    Map(book => book.Notes).Column("notes").Length(1000);
    Map(book => book.PublishDate).Column("publish_date").Index("ix-book-publish_date");
    Map(book => book.Publisher).Column("publisher").Index("ix-book-publisher");
    References(book => book.Cover).Column("cover_id").Fetch.Join().ForeignKey("fk-book2image").Index("ix-book-cover_id");
    Map(book => book.Contents).Column("contents").Not.Nullable().Length(short.MaxValue);
    HasMany(book => book.Tags).AsSet().Table("book2tag").KeyColumn("book_id").ForeignKeyConstraintName("fk-book2tag");
  }
}