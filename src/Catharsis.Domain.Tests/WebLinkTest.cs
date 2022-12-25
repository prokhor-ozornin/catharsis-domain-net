using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="WebLink"/>.</para>
/// </summary>
public sealed class WebLinkTest : EntityTest<WebLink>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new WebLink { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    new WebLink { Uri = Guid.Empty.ToString() }.Uri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.Image"/> property.</para>
  /// </summary>
  [Fact]
  public void Image_Property()
  {
    var image = new Image();
    new WebLink { Image = image }.Image.Should().BeSameAs(image);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property()
  {
    new WebLink { Description = Guid.Empty.ToString() }.Description.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="WebLink()"/>
  [Fact]
  public void Constructors()
  {
    var webLink = new WebLink();

    webLink.Id.Should().BeNull();
    webLink.Uuid.Should().NotBeNull();
    webLink.Version.Should().BeNull();
    webLink.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    webLink.UpdatedOn.Should().BeNull();

    webLink.Name.Should().BeNull();
    webLink.Uri.Should().BeNull();
    webLink.Image.Should().BeNull();
    webLink.Description.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.CompareTo(WebLink)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(WebLink.Uri), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="WebLink.Equals(WebLink)"/></description></item>
  ///     <item><description><see cref="WebLink.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(WebLink.Uri), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(WebLink.Uri), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="WebLink.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new WebLink().ToString().Should().BeEmpty();
    new WebLink { Uri = "schema://uri" }.ToString().Should().Be("schema://uri");
  }
}