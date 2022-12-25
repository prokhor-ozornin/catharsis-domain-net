namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="WebLink"/> entity.</para>
/// </summary>
public sealed class WebLinkMapping : EntityMapping<WebLink>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public WebLinkMapping()
  {
    Table("web_link");
    Map(link => link.Name).Column("name").Not.Nullable().Index("ix-web_link-name");
    Map(link => link.Uri).Column("uri").Not.Nullable().Length(1000);
    References(link => link.Image).Column("image_id").Fetch.Join().ForeignKey("fk-web_link2image").Index("ix-web_link-image_id");
    Map(link => link.Description).Column("description").Length(4000);
  }
}