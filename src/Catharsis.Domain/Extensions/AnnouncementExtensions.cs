namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Announcement"/>.</para>
/// </summary>
/// <seealso cref="Announcement"/>
public static class AnnouncementExtensions
{
  public static IQueryable<Announcement> Name(this IQueryable<Announcement> announcements, string name) => announcements.Where(announcement => announcement.Name != null && announcement.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Announcement> Name(this IEnumerable<Announcement> announcements, string name) => announcements.Where(announcement => announcement?.Name != null && announcement.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<Announcement> Price(this IQueryable<Announcement> announcements, decimal? from = null, decimal? to = null)
  {
    if (from != null)
    {
      announcements = announcements.Where(announcement => announcement.Price >= from.Value);
    }

    if (to != null)
    {
      announcements = announcements.Where(announcement => announcement.Price <= to.Value);
    }

    return announcements;
  }

  public static IEnumerable<Announcement> Price(this IEnumerable<Announcement> announcements, decimal? from = null, decimal? to = null)
  {
    if (from != null)
    {
      announcements = announcements.Where(announcement => announcement != null && announcement.Price >= from.Value);
    }

    if (to != null)
    {
      announcements = announcements.Where(announcement => announcement != null && announcement.Price <= to.Value);
    }

    return announcements.Where(announcement => announcement != null);
  }
}