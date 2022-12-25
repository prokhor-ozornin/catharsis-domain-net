namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="Image"/> entity.</para>
/// </summary>
public sealed class ImageMapping : MediaMapping<Image>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public ImageMapping()
  {
    Table("image");
    References(image => image.File).Column("file_id").Not.Nullable().Fetch.Join().ForeignKey("fk-image2storage_file").Index("ix-image-file_id");
  }
}