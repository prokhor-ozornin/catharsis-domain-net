namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="StorageFile"/>.</para>
/// </summary>
/// <seealso cref="StorageFile"/>
public static class StorageFileExtensions
{
  public static IQueryable<StorageFile> ContentType(this IQueryable<StorageFile> files, string contentType) => files.Where(file => file.ContentType != null && file.ContentType.ToLower() == contentType.ToLower());

  public static IEnumerable<StorageFile> ContentType(this IEnumerable<StorageFile> files, string contentType) => files.Where(file => file?.ContentType != null && file.ContentType.ToLower() == contentType.ToLower());

  public static IQueryable<StorageFile> Storage(this IQueryable<StorageFile> files, string storage) => files.Where(file => file.Storage != null && file.Storage.ToLower() == storage.ToLower());

  public static IEnumerable<StorageFile> Storage(this IEnumerable<StorageFile> files, string storage) => files.Where(file => file?.Storage != null && file.Storage.ToLower() == storage.ToLower());
}