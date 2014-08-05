using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDimensionableExtensions"/>.</para>
  /// </summary>
  public sealed class IDimensionableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IDimensionableExtensions.Height{T}(IQueryable{T}, short?, short?)"/></description></item>
    ///     <item><description><see cref="IDimensionableExtensions.Height{T}(IEnumerable{T}, short?, short?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Height_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<DimensionableEntity>)null).Height());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<DimensionableEntity>)null).Height());

      Assert.False(Enumerable.Empty<DimensionableEntity>().AsQueryable().Height().Any());
      Assert.False(Enumerable.Empty<DimensionableEntity>().AsQueryable().Height(0, 0).Any());
      
      Assert.False(Enumerable.Empty<DimensionableEntity>().Height().Any());
      Assert.False(Enumerable.Empty<DimensionableEntity>().Height(0, 0).Any());

      var entities = new[] { null, new DimensionableEntity { Height = 1 }, null, new DimensionableEntity { Height = 2 } };
      Assert.False(entities.Height(0, 0).Any());
      Assert.Equal(1, entities.Height(0, 1).Count());
      Assert.Equal(1, entities.Height(1, 1).Count());
      Assert.Equal(2, entities.Height(1, 2).Count());
      Assert.Equal(1, entities.Height(2, 3).Count());
      Assert.False(entities.Height(3, 3).Any());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IDimensionableExtensions.Width{T}(IQueryable{T}, short?, short?)"/></description></item>
    ///     <item><description><see cref="IDimensionableExtensions.Width{T}(IEnumerable{T}, short?, short?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Width_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<DimensionableEntity>)null).Width());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<DimensionableEntity>)null).Width());

      Assert.False(Enumerable.Empty<DimensionableEntity>().AsQueryable().Width().Any());
      Assert.False(Enumerable.Empty<DimensionableEntity>().AsQueryable().Width(0, 0).Any());
      
      Assert.False(Enumerable.Empty<DimensionableEntity>().Width().Any());
      Assert.False(Enumerable.Empty<DimensionableEntity>().Width(0, 0).Any());

      var queryable = new[] { new DimensionableEntity { Width = 1 }, new DimensionableEntity { Width = 2 } }.AsQueryable();
      Assert.False(queryable.Width(0, 0).Any());
      Assert.Equal(1, queryable.Width(0, 1).Count());
      Assert.Equal(1, queryable.Width(1, 1).Count());
      Assert.Equal(2, queryable.Width(1, 2).Count());
      Assert.Equal(1, queryable.Width(2, 3).Count());
      Assert.False(queryable.Width(3, 3).Any());

      var enumerable = new[] { null, new DimensionableEntity { Width = 1 }, null, new DimensionableEntity { Width = 2 } };
      Assert.False(enumerable.Width(0, 0).Any());
      Assert.Equal(1, enumerable.Width(0, 1).Count());
      Assert.Equal(1, enumerable.Width(1, 1).Count());
      Assert.Equal(2, enumerable.Width(1, 2).Count());
      Assert.Equal(1, enumerable.Width(2, 3).Count());
      Assert.False(enumerable.Width(3, 3).Any());
    }

    private sealed class DimensionableEntity : IDimensionable
    {
      public short Height { get; set; }

      public short Width { get; set; }
    }
  }
}