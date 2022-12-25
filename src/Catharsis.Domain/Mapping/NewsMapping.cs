namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="News"/> entity.</para>
/// </summary>
public sealed class NewsMapping : EntityMapping<News>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public NewsMapping()
  {
    Table("news");
    Map(news => news.Name).Column("name").Not.Nullable().Index("ix-news-name");
    References(news => news.Image).Column("image_id").Fetch.Join().ForeignKey("fk-news2image").Index("ix-news-image_id");
    Map(news => news.Annotation).Column("annotation").Not.Nullable().Length(1000);
    Map(news => news.Text).Column("text").Not.Nullable().Length(4000);
    HasMany(news => news.Tags).AsSet().Table("news2tag").KeyColumn("news_id").ForeignKeyConstraintName("fk-news2tag");
  }
}