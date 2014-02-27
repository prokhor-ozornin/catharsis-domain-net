using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Text"/>.</para>
  ///   <seealso cref="Text"/>
  /// </summary>
  public static class TextExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of texts, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="texts">Source sequence of texts to filter.</param>
    /// <param name="category">Category of texts to search for.</param>
    /// <returns>Filtered sequence of texts with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="texts"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Text> Category(this IQueryable<Text> texts, TextsCategory category)
    {
      Assertion.NotNull(texts);
      
      return category != null ? texts.Where(text => text.Category.Id == category.Id) : texts.Where(text => text.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of texts, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="texts">Source sequence of texts to filter.</param>
    /// <param name="category">Category of texts to search for.</param>
    /// <returns>Filtered sequence of texts with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="texts"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Text> Category(this IEnumerable<Text> texts, TextsCategory category)
    {
      Assertion.NotNull(texts);

      return category != null ? texts.Where(text => text != null && text.Category.Equals(category)) : texts.Where(text => text != null && text.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of texts, leaving those written by specified person.</para>
    /// </summary>
    /// <param name="texts">Source sequence of texts to filter.</param>
    /// <param name="person">Author of texts to search for.</param>
    /// <returns>Filtered sequence of texts with specified author.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="texts"/> or <paramref name="person"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Text> Person(this IQueryable<Text> texts, Person person)
    {
      Assertion.NotNull(texts);
      Assertion.NotNull(person);

      return texts.Where(text => text.Person.Id == person.Id);
    }

    /// <summary>
    ///   <para>Filters sequence of texts, leaving those written by specified person.</para>
    /// </summary>
    /// <param name="texts">Source sequence of texts to filter.</param>
    /// <param name="person">Author of texts to search for.</param>
    /// <returns>Filtered sequence of texts with specified author.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="texts"/> or <paramref name="person"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Text> Person(this IEnumerable<Text> texts, Person person)
    {
      Assertion.NotNull(texts);
      Assertion.NotNull(person);

      return texts.Where(text => text != null && text.Person.Equals(person));
    }
  }
}