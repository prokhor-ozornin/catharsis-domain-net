using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WebBrowser"/>.</para>
/// </summary>
public sealed class WebBrowserTest : EntityTest<WebBrowser>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new WebBrowser { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    var uri = "https://localhost".ToUri();
    new WebBrowser { Uri = uri }.Uri.Should().Be(uri);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.UserAgent"/> property.</para>
  /// </summary>
  [Fact]
  public void UserAgent_Property()
  {
    new WebBrowser { UserAgent = Guid.Empty.ToString() }.UserAgent.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property()
  {
    new WebBrowser { Description = Guid.Empty.ToString() }.Description.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WebBrowser()"/>
  [Fact]
  public void Constructors()
  {
    var browser = new WebBrowser();

    browser.Id.Should().BeNull();
    browser.Uuid.Should().NotBeNull();
    browser.Version.Should().BeNull();
    browser.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    browser.UpdatedOn.Should().BeNull();

    browser.Name.Should().BeNull();
    browser.Uri.Should().BeNull();
    browser.UserAgent.Should().BeNull();
    browser.Description.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.CompareTo(WebBrowser)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(WebBrowser.UserAgent), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="WebBrowser.Equals(WebBrowser)"/></description></item>
  ///     <item><description><see cref="WebBrowser.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(WebBrowser.UserAgent), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(WebBrowser.UserAgent), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebBrowser.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new WebBrowser().ToString().Should().BeEmpty();
    new WebBrowser { UserAgent = string.Empty }.ToString().Should().BeEmpty();
    new WebBrowser { UserAgent = " " }.ToString().Should().BeEmpty();
    new WebBrowser { UserAgent = Guid.Empty.ToString() }.ToString().Should().BeEmpty(Guid.Empty.ToString());
  }
}