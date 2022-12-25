using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="AnnouncementExtensions"/>.</para>
/// </summary>
public sealed class AnnouncementExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="AnnouncementExtensions.Name(IQueryable{Announcement}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Announcement>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Announcement>().AsQueryable().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Announcement>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Announcement {Name = "First"}, new Announcement {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AnnouncementExtensions.Name(IEnumerable{Announcement}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Announcement>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Announcement>().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Announcement>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Announcement(), new Announcement {Name = "First"}, new Announcement {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AnnouncementExtensions.Price(IQueryable{Announcement}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Price_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Announcement>) null!).Price()).ThrowExactly<ArgumentNullException>();

    var announcements = new[] {new Announcement {Price = 1}, new Announcement {Price = 2}}.AsQueryable();
    announcements.Price().Should().HaveCount(2);
    announcements.Price(0).Should().HaveCount(2);
    announcements.Price(3).Should().BeEmpty();
    announcements.Price(0, 1).Should().ContainSingle();
    announcements.Price(1, 2).Should().HaveCount(2);
    announcements.Price(to: 0).Should().BeEmpty();
    announcements.Price(to: 1).Should().ContainSingle();
    announcements.Price(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="AnnouncementExtensions.Price(IEnumerable{Announcement}, decimal?, decimal?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Price_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Announcement>) null!).Price()).ThrowExactly<ArgumentNullException>();

    var announcements = new[] {null, new Announcement(), new Announcement {Price = 1}, new Announcement {Price = 2}};
    announcements.Price().Should().HaveCount(3);
    announcements.Price(0).Should().HaveCount(2);
    announcements.Price(3).Should().BeEmpty();
    announcements.Price(0, 1).Should().ContainSingle();
    announcements.Price(1, 2).Should().HaveCount(2);
    announcements.Price(to: 0).Should().BeEmpty();
    announcements.Price(to: 1).Should().ContainSingle();
    announcements.Price(to: 3).Should().HaveCount(2);
  }
}