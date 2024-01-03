using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WebBrowserExtensions"/>.</para>
/// </summary>
public sealed class WebBrowserExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowserExtensions.Name(IQueryable{WebBrowser}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WebBrowser>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new WebBrowser {Name = "First"}, new WebBrowser {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowserExtensions.Name(IEnumerable{WebBrowser}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WebBrowser>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new WebBrowser(), new WebBrowser {Name = "First"}, new WebBrowser {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowserExtensions.ValueOf(IQueryable{WebBrowser}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WebBrowser>) null).ValueOf("Mozilla")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().AsQueryable().ValueOf(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().AsQueryable().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new WebBrowser {UserAgent = "Mozilla"}, new WebBrowser {UserAgent = "mozilla"}}.AsQueryable().ValueOf("mozilla")).ThrowExactly<InvalidOperationException>();

    Array.Empty<WebBrowser>().AsQueryable().ValueOf("mozilla").Should().BeNull();
    new[] {new WebBrowser {UserAgent = "Mozilla"}, new WebBrowser {UserAgent = "Opera"}}.AsQueryable().ValueOf("mozilla").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowserExtensions.ValueOf(IEnumerable{WebBrowser}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WebBrowser>) null).ValueOf("mozilla")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().ValueOf(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebBrowser>().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new WebBrowser {UserAgent = "Mozilla"}, new WebBrowser {UserAgent = "mozilla"}}.ValueOf("mozilla")).ThrowExactly<InvalidOperationException>();

    Array.Empty<WebBrowser>().ValueOf("mozilla").Should().BeNull();
    new[] {new WebBrowser {UserAgent = "Mozilla"}, new WebBrowser {UserAgent = "Opera"}}.ValueOf("mozilla").Should().NotBeNull();
  }
}