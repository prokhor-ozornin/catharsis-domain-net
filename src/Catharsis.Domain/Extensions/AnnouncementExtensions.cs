using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class AnnouncementExtensions
  {
    public static IQueryable<Announcement> Name(this IQueryable<Announcement> announcements, string name)
    {
      Assertion.NotNull(announcements);
      Assertion.NotEmpty(name);

      return announcements.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Announcement> Name(this IEnumerable<Announcement> announcements, string name)
    {
      Assertion.NotNull(announcements);
      Assertion.NotEmpty(name);

      return announcements.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IQueryable<Announcement> Price(this IQueryable<Announcement> announcements, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(announcements);

      if (from != null)
      {
        announcements = announcements.Where(it => it.Price >= from.Value);
      }

      if (to != null)
      {
        announcements = announcements.Where(it => it.Price <= to.Value);
      }

      return announcements;
    }

    public static IEnumerable<Announcement> Price(this IEnumerable<Announcement> announcements, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(announcements);

      if (from != null)
      {
        announcements = announcements.Where(it => it != null && it.Price >= from.Value);
      }

      if (to != null)
      {
        announcements = announcements.Where(it => it != null && it.Price <= to.Value);
      }

      return announcements.Where(it => it != null);
    }
  }
}