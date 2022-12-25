using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SitemapEntryExtensions"/>.</para>
/// </summary>
public sealed class SitemapEntryExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntryExtensions.ChangeFrequency(IQueryable{SitemapEntry}, SitemapEntry.SitemapChangeFrequency?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ChangeFequency_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<SitemapEntry>) null!).ChangeFrequency(SitemapEntry.SitemapChangeFrequency.Daily)).ThrowExactly<ArgumentNullException>();

    new[] {new SitemapEntry {ChangeFrequency = SitemapEntry.SitemapChangeFrequency.Always}, new SitemapEntry {ChangeFrequency = SitemapEntry.SitemapChangeFrequency.Daily}}.AsQueryable().ChangeFrequency(SitemapEntry.SitemapChangeFrequency.Daily).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntryExtensions.ChangeFrequency(IEnumerable{SitemapEntry}, SitemapEntry.SitemapChangeFrequency?)"/> method.</para>
  /// </summary>
  [Fact]
  public void ChangeFrequency_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<SitemapEntry>) null!).ChangeFrequency(SitemapEntry.SitemapChangeFrequency.Daily)).ThrowExactly<ArgumentNullException>();

    new[] {null, new SitemapEntry(), new SitemapEntry {ChangeFrequency = SitemapEntry.SitemapChangeFrequency.Always}, new SitemapEntry {ChangeFrequency = SitemapEntry.SitemapChangeFrequency.Daily}}.ChangeFrequency(SitemapEntry.SitemapChangeFrequency.Daily).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntryExtensions.Date(IQueryable{SitemapEntry}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Date_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<SitemapEntry>) null!).Date()).ThrowExactly<ArgumentNullException>();

    var entries = new[] {new SitemapEntry {Date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new SitemapEntry {Date = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}}.AsQueryable();
    entries.Date().Should().HaveCount(2);
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntryExtensions.Date(IEnumerable{SitemapEntry?}, DateTimeOffset?, DateTimeOffset?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Date_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<SitemapEntry>) null!).Date()).ThrowExactly<ArgumentNullException>();

    var entries = new[] {null, new SitemapEntry(), new SitemapEntry {Date = new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}, new SitemapEntry {Date = new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)}};
    entries.Date().Should().HaveCount(3);
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(new DateTimeOffset(year: 1999, month: 1, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero), new DateTimeOffset(year: 2000, month: 1, day: 2, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
    entries.Date(to: new DateTimeOffset(year: 1999, month: 12, day: 31, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().BeEmpty();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 1, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().ContainSingle();
    entries.Date(to: new DateTimeOffset(year: 2000, month: 1, day: 3, hour: 0, minute: 0, second: 0, TimeSpan.Zero)).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntryExtensions.Priority(IQueryable{SitemapEntry}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Priority_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Download>) null!).Downloads()).ThrowExactly<ArgumentNullException>();

    var downloads = new[] {new Download {Downloads = 1}, new Download {Downloads = 2}}.AsQueryable();
    downloads.Downloads().Should().HaveCount(3);
    downloads.Downloads(0).Should().HaveCount(2);
    downloads.Downloads(3).Should().HaveCount(3);
    downloads.Downloads(0, 1).Should().ContainSingle();
    downloads.Downloads(1, 2).Should().HaveCount(2);
    downloads.Downloads(to: 0).Should().BeEmpty();
    downloads.Downloads(to: 1).Should().ContainSingle();
    downloads.Downloads(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntryExtensions.Priority(IEnumerable{SitemapEntry}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Priority_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Download>) null!).Downloads()).ThrowExactly<ArgumentNullException>();

    var downloads = new[] {null, new Download(), new Download {Downloads = 1}, new Download {Downloads = 2}};
    downloads.Downloads().Should().HaveCount(3);
    downloads.Downloads(0).Should().HaveCount(2);
    downloads.Downloads(3).Should().BeEmpty();
    downloads.Downloads(0, 1).Should().ContainSingle();
    downloads.Downloads(1, 2).Should().HaveCount(2);
    downloads.Downloads(to: 0).Should().BeEmpty();
    downloads.Downloads(to: 1).Should().ContainSingle();
    downloads.Downloads(to: 3).Should().HaveCount(2);
  }
}