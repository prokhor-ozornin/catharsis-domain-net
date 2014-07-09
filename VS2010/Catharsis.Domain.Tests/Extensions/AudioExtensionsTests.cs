using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AudioExtensions"/>.</para>
  /// </summary>
  public sealed class AudioExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="AudioExtensions.Category(IQueryable{Audio}, AudiosCategory)"/></description></item>
    ///     <item><description><see cref="AudioExtensions.Category(IEnumerable{Audio}, AudiosCategory)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Category_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Audio>) null).Category(new AudiosCategory()));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Audio>)null).Category(new AudiosCategory()));

      Assert.False(Enumerable.Empty<Audio>().AsQueryable().Category(null).Any());
      Assert.False(Enumerable.Empty<Audio>().Category(null).Any());

      Assert.False(Enumerable.Empty<Audio>().AsQueryable().Category(new AudiosCategory()).Any());
      Assert.False(Enumerable.Empty<Audio>().Category(new AudiosCategory()).Any());

      Assert.Equal(1, new[] { new Audio { Category = new AudiosCategory { Id = 1 } }, new Audio { Category = new AudiosCategory { Id = 2 } } }.AsQueryable().Category(new AudiosCategory { Id = 1 }).Count());
      Assert.Equal(1, new[] { null, new Audio { Category = new AudiosCategory { Name = "first" } }, null, new Audio { Category = new AudiosCategory { Name = "second" } } }.Category(new AudiosCategory { Name = "first" }).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="AudioExtensions.Bitrate(IQueryable{Audio}, short)"/></description></item>
    ///     <item><description><see cref="AudioExtensions.Bitrate(IEnumerable{Audio}, short)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Bitrate_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Audio>) null).Bitrate(0));
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Audio>)null).Bitrate(0));

      Assert.False(Enumerable.Empty<Audio>().Bitrate(0).Any());
      Assert.Equal(1, new[] { null, new Audio { Bitrate = 1 }, null, new Audio { Bitrate = 2 } }.Bitrate(1).Count());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="AudioExtensions.Duration(IQueryable{Audio}, long?, long?)"/></description></item>
    ///     <item><description><see cref="AudioExtensions.Duration(IEnumerable{Audio}, long?, long?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Duration_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<Audio>)null).Duration());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<Audio>)null).Duration());

      Assert.False(Enumerable.Empty<Audio>().AsQueryable().Duration().Any());
      Assert.False(Enumerable.Empty<Audio>().AsQueryable().Duration(0, 0).Any());
      Assert.False(Enumerable.Empty<Audio>().Duration().Any());
      Assert.False(Enumerable.Empty<Audio>().Duration(0, 0).Any());

      var queryable = new[] { new Audio { Duration = 1 }, new Audio { Duration = 2 } }.AsQueryable();
      Assert.False(queryable.Duration(0, 0).Any());
      Assert.Equal(1, queryable.Duration(0, 1).Count());
      Assert.Equal(1, queryable.Duration(1, 1).Count());
      Assert.Equal(2, queryable.Duration(1, 2).Count());
      Assert.Equal(1, queryable.Duration(2, 3).Count());
      Assert.False(queryable.Duration(3, 3).Any());

      var entities = new[] { null, new Audio { Duration = 1 }, null, new Audio { Duration = 2 } };
      Assert.False(entities.Duration(0, 0).Any());
      Assert.Equal(1, entities.Duration(0, 1).Count());
      Assert.Equal(1, entities.Duration(1, 1).Count());
      Assert.Equal(2, entities.Duration(1, 2).Count());
      Assert.Equal(1, entities.Duration(2, 3).Count());
      Assert.False(entities.Duration(3, 3).Any());
    }
  }
}