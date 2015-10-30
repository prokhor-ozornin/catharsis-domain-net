using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class SitemapEntryExtensions
  {
    public static IQueryable<SitemapEntry> ChangeFrequency(this IQueryable<SitemapEntry> entries, SitemapChangeFrequency changeFrequency)
    {
      Assertion.NotNull(entries);

      return entries.Where(it => it.ChangeFrequency == changeFrequency);
    }

    public static IEnumerable<SitemapEntry> ChangeFrequency(this IEnumerable<SitemapEntry> entries, SitemapChangeFrequency changeFrequency)
    {
      Assertion.NotNull(entries);

      return entries.Where(it => it != null && it.ChangeFrequency == changeFrequency);
    }

    public static IQueryable<SitemapEntry> Date(this IQueryable<SitemapEntry> entries, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(entries);

      if (from != null)
      {
        entries = entries.Where(it => it.Date >= from.Value);
      }

      if (to != null)
      {
        entries = entries.Where(it => it.Date <= to.Value);
      }

      return entries;
    }

    public static IEnumerable<SitemapEntry> Date(this IEnumerable<SitemapEntry> entries, DateTime? from = null, DateTime? to = null)
    {
      Assertion.NotNull(entries);

      if (from != null)
      {
        entries = entries.Where(it => it != null && it.Date >= from.Value);
      }

      if (to != null)
      {
        entries = entries.Where(it => it != null && it.Date <= to.Value);
      }

      return entries.Where(it => it != null);
    }

    public static IQueryable<SitemapEntry> Priority(this IQueryable<SitemapEntry> entries, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(entries);

      if (from != null)
      {
        entries = entries.Where(it => it.Priority >= from.Value);
      }

      if (to != null)
      {
        entries = entries.Where(it => it.Priority <= to.Value);
      }

      return entries;
    }

    public static IEnumerable<SitemapEntry> Priority(this IEnumerable<SitemapEntry> entries, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(entries);

      if (from != null)
      {
        entries = entries.Where(it => it != null && it.Priority >= from.Value);
      }

      if (to != null)
      {
        entries = entries.Where(it => it != null && it.Priority <= to.Value);
      }

      return entries.Where(it => it != null);
    }
  }
}