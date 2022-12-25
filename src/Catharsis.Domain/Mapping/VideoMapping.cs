namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Video"/> entity.</para>
/// </summary>
public sealed class VideoMapping : MediaMapping<Video>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public VideoMapping()
  {
    Table("video");
    References(video => video.File).Column("file_id").Not.Nullable().Fetch.Join().ForeignKey("fk-video2storage_file").Index("ix-video-file_id");
  }
}