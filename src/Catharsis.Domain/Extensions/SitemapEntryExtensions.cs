namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="SitemapEntry"/>.</para>
/// </summary>
/// <seealso cref="SitemapEntry"/>
public static class SitemapEntryExtensions
{
  public static IQueryable<SitemapEntry> ChangeFrequency(this IQueryable<SitemapEntry> entries, SitemapEntry.SitemapChangeFrequency? changeFrequency) => entries.Where(entry => entry.ChangeFrequency == changeFrequency);

  public static IEnumerable<SitemapEntry> ChangeFrequency(this IEnumerable<SitemapEntry> entries, SitemapEntry.SitemapChangeFrequency? changeFrequency) => entries.Where(entry => entry is not null && entry.ChangeFrequency == changeFrequency);

  public static IQueryable<SitemapEntry> Date(this IQueryable<SitemapEntry> entries, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from is not null)
    {
      entries = entries.Where(entry => entry.Date >= from.Value);
    }

    if (to is not null)
    {
      entries = entries.Where(entry => entry.Date <= to.Value);
    }

    return entries;
  }

  public static IEnumerable<SitemapEntry> Date(this IEnumerable<SitemapEntry> entries, DateTimeOffset? from = null, DateTimeOffset? to = null)
  {
    if (from is not null)
    {
      entries = entries.Where(entry => entry is not null && entry.Date >= from.Value);
    }

    if (to is not null)
    {
      entries = entries.Where(entry => entry is not null && entry.Date <= to.Value);
    }

    return entries.Where(entry => entry is not null);
  }

  public static IQueryable<SitemapEntry> Priority(this IQueryable<SitemapEntry> entries, decimal? from = null, decimal? to = null)
  {
    if (from is not null)
    {
      entries = entries.Where(entry => entry.Priority >= from.Value);
    }

    if (to is not null)
    {
      entries = entries.Where(entry => entry.Priority <= to.Value);
    }

    return entries;
  }

  public static IEnumerable<SitemapEntry> Priority(this IEnumerable<SitemapEntry> entries, decimal? from = null, decimal? to = null)
  {
    if (from is not null)
    {
      entries = entries.Where(entry => entry is not null && entry.Priority >= from.Value);
    }

    if (to is not null)
    {
      entries = entries.Where(entry => entry is not null && entry.Priority <= to.Value);
    }

    return entries.Where(entry => entry is not null);
  }
}