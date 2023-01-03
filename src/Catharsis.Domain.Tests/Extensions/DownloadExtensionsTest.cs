using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DownloadExtensions"/>.</para>
/// </summary>
public sealed class DownloadExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="DownloadExtensions.Downloads(IQueryable{Download}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Downloads_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Download>) null).Downloads()).ThrowExactly<ArgumentNullException>();

    var downloads = new[] {new Download {Downloads = 1}, new Download {Downloads = 2}}.AsQueryable();
    downloads.Downloads().Should().HaveCount(2);
    downloads.Downloads(0).Should().HaveCount(2);
    downloads.Downloads(3).Should().BeEmpty();
    downloads.Downloads(0, 1).Should().ContainSingle();
    downloads.Downloads(1, 2).Should().HaveCount(2);
    downloads.Downloads(to: 0).Should().BeEmpty();
    downloads.Downloads(to: 1).Should().ContainSingle();
    downloads.Downloads(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DownloadExtensions.Downloads(IEnumerable{Download}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Downloads_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Download>) null).Downloads()).ThrowExactly<ArgumentNullException>();

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

  /// <summary>
  ///   <para>Performs testing of <see cref="DownloadExtensions.Name(IQueryable{Download}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Download>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Download>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Download>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Download {Name = "First"}, new Download {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DownloadExtensions.Name(IEnumerable{Download}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Download>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Download>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Download>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Download(), new Download {Name = "First"}, new Download {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}