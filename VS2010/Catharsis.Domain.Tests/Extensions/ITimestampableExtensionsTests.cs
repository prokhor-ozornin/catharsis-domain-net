using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ITimestampableExtensions"/>.</para>
  /// </summary>
  public sealed class ITimestampableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITimestampableExtensions.CreatedOn{T}(IQueryable{T}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="ITimestampableExtensions.CreatedOn{T}(IEnumerable{T}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void CreatedOn_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<TimestampableEntity>)null).CreatedOn());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<TimestampableEntity>)null).CreatedOn());

      Assert.False(Enumerable.Empty<TimestampableEntity>().AsQueryable().CreatedOn().Any());
      Assert.False(Enumerable.Empty<TimestampableEntity>().CreatedOn().Any());

      Assert.Equal(2, new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MinValue } }.AsQueryable().CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { CreatedAt = DateTime.MaxValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { CreatedAt = DateTime.MinValue }, new TimestampableEntity { CreatedAt = DateTime.MinValue } }.CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { CreatedAt = DateTime.MaxValue }, new TimestampableEntity { CreatedAt = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITimestampableExtensions.UpdatedOn{T}(IQueryable{T}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="ITimestampableExtensions.UpdatedOn{T}(IEnumerable{T}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void UpdatedOn_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<TimestampableEntity>)null).UpdatedOn());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<TimestampableEntity>)null).UpdatedOn());

      Assert.False(Enumerable.Empty<TimestampableEntity>().AsQueryable().UpdatedOn().Any());
      Assert.False(Enumerable.Empty<TimestampableEntity>().UpdatedOn().Any());

      Assert.Equal(2, new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.AsQueryable().UpdatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MinValue } }.AsQueryable().UpdatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { UpdatedAt = DateTime.MaxValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.AsQueryable().UpdatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.UpdatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { UpdatedAt = DateTime.MinValue }, new TimestampableEntity { UpdatedAt = DateTime.MinValue } }.UpdatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { UpdatedAt = DateTime.MaxValue }, new TimestampableEntity { UpdatedAt = DateTime.MaxValue } }.UpdatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());
    }

    private sealed class TimestampableEntity : ITimestampable
    {
      public DateTime CreatedAt { get; set; }

      public DateTime UpdatedAt { get; set; }
    }
  }
}