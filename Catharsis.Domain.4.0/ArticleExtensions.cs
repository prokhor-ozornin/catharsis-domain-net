using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Set of extension methods for class <see cref="Article"/>.</para>
  /// </summary>
  /// <seealso cref="Article"/>
  public static class ArticleExtensions
  {
    /// <summary>
    ///   <para>Filters sequence of articles, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="articles">Source sequence of articles to filter.</param>
    /// <param name="category">Category of articles to search for.</param>
    /// <returns>Filtered sequence of articles with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="articles"/> is a <c>null</c> reference.</exception>
    public static IQueryable<Article> Category(this IQueryable<Article> articles, ArticlesCategory category)
    {
      Assertion.NotNull(articles);

      return category != null ? articles.Where(article => article.Category.Id == category.Id) : articles.Where(article => article.Category == null);
    }

    /// <summary>
    ///   <para>Filters sequence of articles, leaving those belonging to specified category.</para>
    /// </summary>
    /// <param name="articles">Source sequence of articles to filter.</param>
    /// <param name="category">Category of articles to search for.</param>
    /// <returns>Filtered sequence of articles with specified category.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="articles"/> is a <c>null</c> reference.</exception>
    public static IEnumerable<Article> Category(this IEnumerable<Article> articles, ArticlesCategory category)
    {
      Assertion.NotNull(articles);

      return category != null ? articles.Where(article => article != null && article.Category.Equals(category)) : articles.Where(article => article != null && article.Category == null);
    }
  }
}