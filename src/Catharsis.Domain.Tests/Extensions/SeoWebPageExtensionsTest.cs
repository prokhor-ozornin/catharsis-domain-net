using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SeoWebPageExtensions"/>.</para>
/// </summary>
public sealed class SeoWebPageExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPageExtensions.Locale(IQueryable{SeoWebPage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Locale_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<SeoWebPage>) null!).Locale("locale")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<SeoWebPage>().AsQueryable().Locale(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<SeoWebPage>().AsQueryable().Locale(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new SeoWebPage {Locale = "First"}, new SeoWebPage {Locale = "Second"}}.AsQueryable().Locale("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPageExtensions.Locale(IEnumerable{SeoWebPage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Locale_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<SeoWebPage>) null!).Locale("locale")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<SeoWebPage>().Locale(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<SeoWebPage>().Locale(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new SeoWebPage(), new SeoWebPage {Locale = "First"}, new SeoWebPage {Locale = "Second"}}.Locale("first").Should().ContainSingle();
  }
}