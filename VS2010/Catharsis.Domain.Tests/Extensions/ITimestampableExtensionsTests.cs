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

      Assert.Equal(2, new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MinValue } }.AsQueryable().CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { DateCreated = DateTime.MaxValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { DateCreated = DateTime.MinValue }, new TimestampableEntity { DateCreated = DateTime.MinValue } }.CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { DateCreated = DateTime.MaxValue }, new TimestampableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());
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

      Assert.Equal(2, new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MinValue } }.AsQueryable().UpdatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { LastUpdated = DateTime.MaxValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { LastUpdated = DateTime.MinValue }, new TimestampableEntity { LastUpdated = DateTime.MinValue } }.UpdatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimestampableEntity { LastUpdated = DateTime.MaxValue }, new TimestampableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());
    }

    private sealed class TimestampableEntity : ITimestampable
    {
      public DateTime DateCreated { get; set; }

      public DateTime LastUpdated { get; set; }
    }
  }
}