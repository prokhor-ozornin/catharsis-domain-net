namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Audio"/> entity.</para>
/// </summary>
public sealed class AudioMapping : MediaMapping<Audio>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public AudioMapping()
  {
    Table("audio");
    Map(audio => audio.Bitrate).Column("bitrate").Check("bitrate >= 0").Index("ix-audio-bitrate");
    References(audio => audio.File).Column("file_id").Fetch.Join().ForeignKey("fk-audio2storage_file").Index("ix-audio-file_id");
  }
}