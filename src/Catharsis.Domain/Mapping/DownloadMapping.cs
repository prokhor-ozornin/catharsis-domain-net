namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Download"/> entity.</para>
/// </summary>
public sealed class DownloadMapping : EntityMapping<Download>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public DownloadMapping()
  {
    Table("download");
    Map(download => download.Name).Column("name").Not.Nullable().Index("ix-download-name");
    Map(download => download.Description).Column("description").Length(4000);
    References(download => download.File).Column("file_id").Not.Nullable().Fetch.Join().ForeignKey("fk-download2storage_file").Index("ix-download-file_id");
    References(download => download.Image).Column("image_id").Fetch.Join().ForeignKey("fk-download2image").Index("ix-download-image_id");
    Map(download => download.Downloads).Column("downloads").Not.Nullable().Check("downloads >= 0").Index("ix-download-downloads");
  }
}