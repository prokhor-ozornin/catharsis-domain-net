using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDateableExtensions"/>.</para>
  /// </summary>
  public sealed class IDateableExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IDateableExtensions.Date{ENTITY}(IQueryable{ENTITY}, DateTime?, DateTime?)"/></description></item>
    ///     <item><description><see cref="IDateableExtensions.Date{ENTITY}(IEnumerable{ENTITY}, DateTime?, DateTime?)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Period_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<DateableEntity>)null).Date());
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<DateableEntity>)null).Date());

      Assert.False(Enumerable.Empty<DateableEntity>().AsQueryable().Date().Any());
      Assert.False(Enumerable.Empty<DateableEntity>().Date().Any());

      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.AsQueryable().Date(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.AsQueryable().Date(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.AsQueryable().Date(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.AsQueryable().Date(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MinValue } }.AsQueryable().Date(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new DateableEntity { Date = DateTime.MaxValue }, new DateableEntity { Date = DateTime.MaxValue } }.AsQueryable().Date(null, DateTime.MaxValue.AddDays(-1)).Any());

      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(DateTime.MinValue, DateTime.MaxValue).Count());
      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(DateTime.MinValue).Count());
      Assert.Equal(2, new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(null, DateTime.MaxValue).Count());
      Assert.False(new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(DateTime.MinValue.AddDays(1), DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new DateableEntity { Date = DateTime.MinValue }, new DateableEntity { Date = DateTime.MinValue } }.Date(DateTime.MaxValue.AddDays(-1)).Any());
      Assert.False(new[] { new DateableEntity { Date = DateTime.MaxValue }, new DateableEntity { Date = DateTime.MaxValue } }.Date(null, DateTime.MaxValue.AddDays(-1)).Any());
    }

    private sealed class DateableEntity : IDateable
    {
      public DateTime Date { get; set; }
    }
  }
}