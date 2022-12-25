namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Playcast"/> entity.</para>
/// </summary>
public sealed class PlaycastMapping : EntityMapping<Playcast>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public PlaycastMapping()
  {
    Table("playcast");
    Map(playcast => playcast.Name).Column("name").Not.Nullable().Index("ix-playcast-name");
    Map(playcast => playcast.Text).Column("text").Not.Nullable().Length(4000);
    References(playcast => playcast.Image).Column("image_id").Not.Nullable().Fetch.Join().ForeignKey("fk-playcast2image").Index("ix-playcast-image_id");
    References(playcast => playcast.Audio).Column("audio_id").Fetch.Join().ForeignKey("fk-playcast2audio").Index("ix-playcast-audio_id");
    References(playcast => playcast.Video).Column("video_id").Fetch.Join().ForeignKey("fk-playcast2video").Index("ix-playcast-video_id");
    HasMany(playcast => playcast.Tags).AsSet().Table("playcast2tag").KeyColumn("playcast_id").ForeignKeyConstraintName("fk-playcast2tag");
  }
}