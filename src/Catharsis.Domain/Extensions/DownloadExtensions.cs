namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Download"/>.</para>
/// </summary>
/// <seealso cref="Download"/>
public static class DownloadExtensions
{
  public static IQueryable<Download> Name(this IQueryable<Download> downloads, string name) => downloads.Where(download => download.Name != null && download.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Download> Name(this IEnumerable<Download> downloads, string name) => downloads.Where(download => download?.Name is not null && download.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<Download> Downloads(this IQueryable<Download> downloads, long? from = null, long? to = null)
  {
    if (from is not null)
    {
      downloads = downloads.Where(download => download.Downloads >= from.Value);
    }

    if (to is not null)
    {
      downloads = downloads.Where(download => download.Downloads <= to.Value);
    }

    return downloads;
  }

  public static IEnumerable<Download> Downloads(this IEnumerable<Download> downloads, long? from = null, long? to = null)
  {
    if (from is not null)
    {
      downloads = downloads.Where(download => download is not null && download.Downloads >= from.Value);
    }

    if (to is not null)
    {
      downloads = downloads.Where(download => download is not null && download.Downloads <= to.Value);
    }

    return downloads.Where(download => download is not null);
  }
}