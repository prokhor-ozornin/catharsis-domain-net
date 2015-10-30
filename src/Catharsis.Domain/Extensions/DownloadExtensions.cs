using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class DownloadExtensions
  {
    public static IQueryable<Download> Downloads(this IQueryable<Download> downloads, long? from = null, long? to = null)
    {
      Assertion.NotNull(downloads);

      if (from != null)
      {
        downloads = downloads.Where(it => it.Downloads >= from.Value);
      }

      if (to != null)
      {
        downloads = downloads.Where(it => it.Downloads <= to.Value);
      }

      return downloads;
    }

    public static IEnumerable<Download> Downloads(this IEnumerable<Download> downloads, long? from = null, long? to = null)
    {
      Assertion.NotNull(downloads);

      if (from != null)
      {
        downloads = downloads.Where(it => it != null && it.Downloads >= from.Value);
      }

      if (to != null)
      {
        downloads = downloads.Where(it => it != null && it.Downloads <= to.Value);
      }

      return downloads.Where(it => it != null);
    }

    public static IQueryable<Download> Name(this IQueryable<Download> downloads, string name)
    {
      Assertion.NotNull(downloads);
      Assertion.NotEmpty(name);

      return downloads.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Download> Name(this IEnumerable<Download> downloads, string name)
    {
      Assertion.NotNull(downloads);
      Assertion.NotEmpty(name);

      return downloads.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }
  }
}