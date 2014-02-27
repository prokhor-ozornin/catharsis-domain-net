using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="ITimeableExtensions"/>.</para>
  /// </summary>
  public sealed class ITimeableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITimeableExtensions.CreatedOn{T}(IQueryable{T}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="ITimeableExtensions.CreatedOn{T}(IEnumerable{T}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void CreatedOn_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<TimeableEntity>)null).CreatedOn());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<TimeableEntity>)null).CreatedOn());

      Assert.False(Enumerable.Empty<TimeableEntity>().AsQueryable().CreatedOn().Any());
      Assert.False(Enumerable.Empty<TimeableEntity>().CreatedOn().Any());

      Assert.Equal(2, new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MinValue } }.AsQueryable().CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { DateCreated = DateTime.MaxValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.AsQueryable().CreatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { DateCreated = DateTime.MinValue }, new TimeableEntity { DateCreated = DateTime.MinValue } }.CreatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { DateCreated = DateTime.MaxValue }, new TimeableEntity { DateCreated = DateTime.MaxValue } }.CreatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="ITimeableExtensions.UpdatedOn{T}(IQueryable{T}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="ITimeableExtensions.UpdatedOn{T}(IEnumerable{T}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void UpdatedOn_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<TimeableEntity>)null).UpdatedOn());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<TimeableEntity>)null).UpdatedOn());

      Assert.False(Enumerable.Empty<TimeableEntity>().AsQueryable().UpdatedOn().Any());
      Assert.False(Enumerable.Empty<TimeableEntity>().UpdatedOn().Any());

      Assert.Equal(2, new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MinValue } }.AsQueryable().UpdatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { LastUpdated = DateTime.MaxValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.AsQueryable().UpdatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { LastUpdated = DateTime.MinValue }, new TimeableEntity { LastUpdated = DateTime.MinValue } }.UpdatedOn(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new TimeableEntity { LastUpdated = DateTime.MaxValue }, new TimeableEntity { LastUpdated = DateTime.MaxValue } }.UpdatedOn(null, DateTime.MaxValue.AddDays(-1)).Any());
    }

    private sealed class TimeableEntity : ITimeable
    {
      public DateTime DateCreated { get; set; }

      public DateTime LastUpdated { get; set; }
    }
  }
}