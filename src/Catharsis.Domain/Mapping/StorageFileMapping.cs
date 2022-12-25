namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="StorageFile"/> entity.</para>
/// </summary>
public sealed class StorageFileMapping : EntityMapping<StorageFile>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public StorageFileMapping()
  {
    Table("storage_file");
    Map(file => file.Name).Column("name").Not.Nullable();
    Map(file => file.Storage).Column("storage").Index("ix-storage_file-storage");
    Map(file => file.ContentType).Column("content_type").Not.Nullable().Index("ix-storage_file-content_type");
    Map(file => file.Size).Column("size").Not.Nullable().Check("size >= 0").Index("ix-storage_file-size");
    Map(file => file.Path).Column("path").Length(1000);
  }
}