using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SeoWebPage"/>.</para>
/// </summary>
public sealed class SeoWebPageTest : EntityTest<SeoWebPage>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPage.Title"/> property.</para>
  /// </summary>
  [Fact]
  public void Title_Property()
  {
    new SeoWebPage { Title = Guid.Empty.ToString() }.Title.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPage.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    var uri = "https://localhost".ToUri();
    new SeoWebPage { Uri = uri }.Uri.Should().Be(uri);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPage.Locale"/> property.</para>
  /// </summary>
  [Fact]
  public void Locale_Property()
  {
    new SeoWebPage { Locale = Guid.Empty.ToString() }.Locale.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="SeoWebPage()"/>
  [Fact]
  public void Constructors()
  {
    var webPage = new SeoWebPage();

    webPage.Id.Should().BeNull();
    webPage.Uuid.Should().NotBeNull();
    webPage.Version.Should().BeNull();
    webPage.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    webPage.UpdatedOn.Should().BeNull();

    webPage.Title.Should().BeNull();
    webPage.Uri.Should().BeNull();
    webPage.Locale.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPage.CompareTo(SeoWebPage)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(SeoWebPage.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="SeoWebPage.Equals(SeoWebPage)"/></description></item>
  ///     <item><description><see cref="SeoWebPage.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(SeoWebPage.Locale), "first", "second");
    TestEquality(nameof(SeoWebPage.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPage.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(SeoWebPage.Locale), "first", "second");
    TestHashCode(nameof(SeoWebPage.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SeoWebPage.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Audio().ToString().Should().BeEmpty();
    new Audio { Uri = "schema://uri".ToUri() }.ToString().Should().Be("schema://uri/");
  }
}