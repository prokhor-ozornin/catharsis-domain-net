using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SitemapEntry"/>.</para>
/// </summary>
public sealed class SitemapEntryTest : EntityTest<SitemapEntry>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    var uri = "https://localhost".ToUri();
    new SitemapEntry { Uri = uri }.Uri.Should().Be(uri);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.ChangeFrequency"/> property.</para>
  /// </summary>
  [Fact]
  public void ChangeFrequency_Property()
  {
    new SitemapEntry { ChangeFrequency = SitemapEntry.SitemapChangeFrequency.Daily }.ChangeFrequency.Should().Be(SitemapEntry.SitemapChangeFrequency.Daily);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.Priority"/> property.</para>
  /// </summary>
  [Fact]
  public void Priority_Property()
  {
    new SitemapEntry { Priority = decimal.MaxValue }.Priority.Should().Be(decimal.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new SitemapEntry { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property()
  {
    new SitemapEntry { Description = Guid.Empty.ToString() }.Description.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="SitemapEntry()"/>
  [Fact]
  public void Constructors()
  {
    var entry = new SitemapEntry();

    entry.Id.Should().BeNull();
    entry.Uuid.Should().NotBeNull();
    entry.Version.Should().BeNull();
    entry.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    entry.UpdatedOn.Should().BeNull();

    entry.Uri.Should().BeNull();
    entry.ChangeFrequency.Should().BeNull();
    entry.Priority.Should().BeNull();
    entry.Date.Should().BeNull();
    entry.Description.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.CompareTo(SitemapEntry)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(SitemapEntry.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="SitemapEntry.Equals(SitemapEntry)"/></description></item>
  ///     <item><description><see cref="SitemapEntry.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(SitemapEntry.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(SitemapEntry.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SitemapEntry.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new SitemapEntry().ToString().Should().BeEmpty();
    new SitemapEntry { Uri = "schema://uri".ToUri() }.ToString().Should().Be("schema://uri/");
  }
}