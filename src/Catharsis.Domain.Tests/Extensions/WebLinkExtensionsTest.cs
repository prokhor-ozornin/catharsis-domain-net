using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WebLinkExtensions"/>.</para>
/// </summary>
public sealed class WebLinkExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WebLinkExtensions.Name(IQueryable{WebLink}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<WebLink>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebLink>().AsQueryable().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebLink>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new WebLink {Name = "First"}, new WebLink {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLinkExtensions.Name(IEnumerable{WebLink}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<WebLink>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebLink>().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<WebLink>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new WebLink(), new WebLink {Name = "First"}, new WebLink {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}