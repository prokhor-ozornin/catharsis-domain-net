using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Announcement"/>.</para>
  /// </summary>
  /// <seealso cref="Announcement"/>
  public static class AnnouncementExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of announcements, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="announcements">Source sequence of announcements to filter.</param>
    /// <param name="category">Category of announcements to search for.</param>
    /// <returns>Filtered sequence of announcements with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="announcements"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Announcement> Category(this IQueryable<Announcement> announcements, AnnouncementsCategory category)
    {
      Assertion.NotNull(announcements);

      return category != null ? announcements.Where(announcement => announcement.Category.Id == category.Id) : announcements.Where(announcement => announcement.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of announcements, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="announcements">Source sequence of announcements to filter.</param>
    /// <param name="category">Category of announcements to search for.</param>
    /// <returns>Filtered sequence of announcements with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="announcements"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Announcement> Category(this IEnumerable<Announcement> announcements, AnnouncementsCategory category)
    {
      Assertion.NotNull(announcements);

      return category != null ? announcements.Where(announcement => announcement != null && announcement.Category.Equals(category)) : announcements.Where(announcement => announcement != null && announcement.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of announcements, leaving those in specified currency.</para>
    /// </summary>
    /// <param name="announcements">Source sequence of announcements to filter.</param>
    /// <param name="currency">Currency of announcements to search for.</param>
    /// <returns>Filtered sequence of announcements with specified currency.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="announcements"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Announcement> Currency(this IQueryable<Announcement> announcements, string currency)
    {
      Assertion.NotNull(announcements);

      return announcements.Where(announcement => announcement.Currency == currency);
    }

    /// <summary>
    ///   <para>Filters sequence of announcements, leaving those in specified currency.</para>
    /// </summary>
    /// <param name="announcements">Source sequence of announcements to filter.</param>
    /// <param name="currency">Currency of announcements to search for.</param>
    /// <returns>Filtered sequence of announcements with specified currency.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="announcements"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Announcement> Currency(this IEnumerable<Announcement> announcements, string currency)
    {
      Assertion.NotNull(announcements);

      return announcements.Where(announcement => announcement != null && announcement.Currency == currency);
    }

    /// <summary>
    ///   <para>Filters sequence of announcements, leaving those with a price in specified range.</para>
    /// </summary>
    /// <param name="announcements">Source sequence of announcements to filter.</param>
    /// <param name="from">Lower bound of price range.</param>
    /// <param name="to">Upper bound of price range.</param>
    /// <returns>Filtered sequence of announcements with a price between <paramref name="from"/> and <paramref name="to"/> inclusively.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="announcements"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Announcement> Price(this IQueryable<Announcement> announcements, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(announcements);

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

    /// <summary>
    ///   <para>Filters sequence of announcements, leaving those with a price in specified range.</para>
    /// </summary>
    /// <param name="announcements">Source sequence of announcements to filter.</param>
    /// <param name="from">Lower bound of price range.</param>
    /// <param name="to">Upper bound of price range.</param>
    /// <returns>Filtered sequence of announcements with a price between <paramref name="from"/> and <paramref name="to"/> inclusively.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="announcements"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Announcement> Price(this IEnumerable<Announcement> announcements, decimal? from = null, decimal? to = null)
    {
      Assertion.NotNull(announcements);

      if (from != null)
      {
        announcements = announcements.Where(announcement => announcement != null && announcement.Price >= from.Value);
      }

      if (to != null)
      {
        announcements = announcements.Where(announcement => announcement != null && announcement.Price <= to.Value);
      }

      return announcements;
    }
  }
}