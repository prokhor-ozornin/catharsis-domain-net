using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for interface <see cref="ILocalizable"/>.</para>
  ///   <seealso cref="ILocalizable"/>
  /// </summary>
  public static class ILocalizableExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given ISO language code of their text content.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="language">ISO language code to search for.</param>
    /// <returns>Filtered sequence of entities with text content having specified ISO language code.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> Language<T>(this IQueryable<T> entities, string language) where T : ILocalizable
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity.Language == language);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given ISO language code of their text content.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="language">ISO language code to search for.</param>
    /// <returns>Filtered sequence of entities with text content having specified ISO language code.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Language<T>(this IEnumerable<T> entities, string language) where T : ILocalizable
    {
      Assertion.NotNull(entities);

      return entities.Where(entity => entity != null && entity.Language == language);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given culture of their text content.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="culture">Culture to search for.</param>
    /// <returns>Filtered sequence of entities with text content having specified culture.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IQueryable<T> Culture<T>(this IQueryable<T> entities, CultureInfo culture) where T : ILocalizable
    {
      Assertion.NotNull(entities);

      return entities.Language(culture != null ? culture.TwoLetterISOLanguageName : null);
    }

    /// <summary>
    ///   <para>Filters sequence of entities, leaving those with given culture of their text content.</para>
    /// </summary>
    /// <typeparam name="T">Type of entities.</typeparam>
    /// <param name="entities">Source sequence of entities to filter.</param>
    /// <param name="culture">Culture to search for.</param>
    /// <returns>Filtered sequence of entities with text content having specified culture.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="entities"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<T> Culture<T>(this IEnumerable<T> entities, CultureInfo culture) where T : ILocalizable
    {
      Assertion.NotNull(entities);

      return entities.Language(culture != null ? culture.TwoLetterISOLanguageName : null);
    }
  }
}