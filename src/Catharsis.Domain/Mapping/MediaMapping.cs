namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Audio"/> entity.</para>
/// </summary>
public abstract class MediaMapping<TEntity> : EntityMapping<TEntity> where TEntity : Media
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  protected MediaMapping()
  {
    Map(media => media.AuthorName).Column("author_name");
    Map(media => media.AuthorUri).Column("author_uri").Length(1000);
    Map(media => media.ContentType).Column("content_type");
    Map(media => media.Description).Column("description");
    Map(media => media.Duration).Column("duration").Check("duration >= 0").Index($"ix-{nameof(TEntity).ToLowerInvariant()}-duration");
    Map(media => media.Height).Column("height").Check("height >= 0").Index($"ix-{nameof(TEntity).ToLowerInvariant()}-height");
    Map(media => media.Html).Column("html").Length(4000);
    Map(media => media.Name).Column("name").Index($"ix-{nameof(TEntity).ToLowerInvariant()}-name");
    Map(media => media.ProviderUri).Column("provider_uri").Length(1000);
    Map(media => media.ThumbnailHeight).Column("thumbnail_height").Check("thumbnail_height >= 0");
    Map(media => media.ThumbnailUri).Column("thumbnail_uri").Length(1000);
    Map(media => media.ThumbnailWidth).Column("thumbnail_width").Check("thumbnail_width >= 0");
    Map(media => media.Uri).Column("uri").Not.Nullable().Length(1000).UniqueKey("uk-audio-uri");
    Map(media => media.Width).Column("width").Check("width >= 0").Index($"ix-{nameof(TEntity).ToLowerInvariant()}-width");
  }
}