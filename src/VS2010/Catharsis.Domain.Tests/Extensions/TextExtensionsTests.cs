using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TextExtensions"/>.</para>
  /// </summary>
  public sealed class TextExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TextExtensions.Category(IQueryable{Text}, TextsCategory)"/></description></item>
    ///     <item><description><see cref="TextExtensions.Category(IQueryable{Text}, TextsCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Text>) null).Category(new TextsCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Text>)null).Category(new TextsCategory()));

      Assert.False(Enumerable.Empty<Text>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Text>().Category(null).Any());

      Assert.False(Enumerable.Empty<Text>().AsQueryable().Category(new TextsCategory()).Any());
      Assert.False(Enumerable.Empty<Text>().Category(new TextsCategory()).Any());
      
      Assert.Equal(1, new[] { new Text { Category = new TextsCategory { Id = 1 } }, new Text { Category = new TextsCategory { Id = 2 } } }.AsQueryable().Category(new TextsCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Text { Category = new TextsCategory { Id = 1 } }, new Text { Category = new TextsCategory { Id = 2 } } }.Category(new TextsCategory { Id = 1 }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TextExtensions.Person(IQueryable{Text}, Person)"/></description></item>
    ///     <item><description><see cref="TextExtensions.Person(IQueryable{Text}, Person)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Person_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Text>) null).Person(new Person()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Text>)null).Person(new Person()));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Text>().Person(null));

      Assert.False(Enumerable.Empty<Text>().AsQueryable().Person(new Person()).Any());
      Assert.False(Enumerable.Empty<Text>().Person(new Person()).Any());

      Assert.Equal(1, new[] { new Text { Person = new Person { Id = 1 } }, new Text { Person = new Person { Id = 2 } } }.AsQueryable().Person(new Person { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Text { Person = new Person { Id = 1 } }, new Text { Person = new Person { Id = 2 } } }.Person(new Person { Id = 1 }).Count());
    }
  }
}