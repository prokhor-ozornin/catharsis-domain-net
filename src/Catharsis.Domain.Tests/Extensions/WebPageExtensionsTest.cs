using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WebPageExtensions"/>.</para>
/// </summary>
public sealed class WebPageExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WebPageExtensions.Locale(IQueryable{WebPage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Locale_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WebPage>) null).Locale("locale")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().AsQueryable().Locale(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().AsQueryable().Locale(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new WebPage {Locale = "First"}, new WebPage {Locale = "Second"}}.AsQueryable().Locale("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPageExtensions.Locale(IEnumerable{WebPage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Locale_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WebPage>) null).Locale("locale")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().Locale(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().Locale(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new WebPage(), new WebPage {Locale = "First"}, new WebPage {Locale = "Second"}}.Locale("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPageExtensions.Name(IQueryable{WebPage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WebPage>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new WebPage {Name = "First"}, new WebPage {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPageExtensions.Name(IEnumerable{WebPage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WebPage>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebPage>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new WebPage(), new WebPage {Name = "First"}, new WebPage {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}