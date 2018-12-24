using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class StorageFileExtensions
  {
    public static IQueryable<StorageFile> ContentType(this IQueryable<StorageFile> files, string contentType)
    {
      Assertion.NotNull(files);
      Assertion.NotEmpty(contentType);

      return files.Where(it => it.ContentType.ToLower() == contentType.ToLower());
    }

    public static IEnumerable<StorageFile> ContentType(this IEnumerable<StorageFile> files, string contentType)
    {
      Assertion.NotNull(files);
      Assertion.NotEmpty(contentType);

      return files.Where(it => it?.ContentType != null && it.ContentType.ToLower() == contentType.ToLower());
    }

    public static IQueryable<StorageFile> Storage(this IQueryable<StorageFile> files, string storage)
    {
      Assertion.NotNull(files);
      Assertion.NotEmpty(storage);

      return files.Where(it => it.Storage.ToLower() == storage.ToLower());
    }

    public static IEnumerable<StorageFile> Storage(this IEnumerable<StorageFile> files, string storage)
    {
      Assertion.NotNull(files);
      Assertion.NotEmpty(storage);

      return files.Where(it => it?.Storage != null && it.Storage.ToLower() == storage.ToLower());
    }
  }
}