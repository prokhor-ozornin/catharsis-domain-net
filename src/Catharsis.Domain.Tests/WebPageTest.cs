using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WebPage"/>.</para>
/// </summary>
public sealed class WebPageTest : EntityTest<WebPage>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new WebPage { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    var uri = "http://localhost".ToUri();
    new WebPage { Uri = uri }.Uri.Should().Be(uri);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.Locale"/> property.</para>
  /// </summary>
  [Fact]
  public void Locale_Property()
  {
    new WebPage { Locale = Guid.Empty.ToString() }.Locale.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.Text"/> property.</para>
  /// </summary>
  [Fact]
  public void Text_Property()
  {
    new WebPage { Text = Guid.Empty.ToString() }.Text.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WebPage()"/>
  [Fact]
  public void Constructors()
  {
    var webPage = new WebPage();

    webPage.Id.Should().BeNull();
    webPage.Uuid.Should().NotBeNull();
    webPage.Version.Should().BeNull();
    webPage.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    webPage.UpdatedOn.Should().BeNull();

    webPage.Name.Should().BeNull();
    webPage.Uri.Should().BeNull();
    webPage.Locale.Should().BeNull();
    webPage.Text.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.CompareTo(WebPage)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(WebPage.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="WebPage.Equals(WebPage)"/></description></item>
  ///     <item><description><see cref="WebPage.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(WebPage.Locale), "first", "second");
    TestEquality(nameof(WebPage.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(WebPage.Locale), "first", "second");
    TestHashCode(nameof(WebPage.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebPage.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new WebPage().ToString().Should().BeEmpty();
    new WebPage {Name = string.Empty}.ToString().Should().BeEmpty();
    new WebPage {Name = " "}.ToString().Should().BeEmpty();
    new WebPage {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }
}