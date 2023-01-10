using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Media"/>.</para>
/// </summary>
public sealed class MediaTest : EntityTest<Media>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Media { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.ContentType"/> property.</para>
  /// </summary>
  [Fact]
  public void ContentType_Property()
  {
    new Media { ContentType = Guid.Empty.ToString() }.ContentType.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Uri"/> property.</para>
  /// </summary>
  [Fact]
  public void Uri_Property()
  {
    var uri = "https://localhost".ToUri();
    new Media { Uri = uri }.Uri.Should().Be(uri);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.ProviderUri"/> property.</para>
  /// </summary>
  [Fact]
  public void ProviderUri_Property()
  {
    new Media { ProviderUri = Guid.Empty.ToString() }.ProviderUri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Width"/> property.</para>
  /// </summary>
  [Fact]
  public void Width_Property()
  {
    new Media { Width = short.MaxValue }.Width.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Height"/> property.</para>
  /// </summary>
  [Fact]
  public void Height_Property()
  {
    new Media { Height = short.MaxValue }.Height.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Duration"/> property.</para>
  /// </summary>
  [Fact]
  public void Duration_Property()
  {
    new Media { Duration = long.MaxValue }.Duration.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property()
  {
    new Media { Description = Guid.Empty.ToString() }.Description.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.Html"/> property.</para>
  /// </summary>
  [Fact]
  public void Html_Property()
  {
    new Media { Html = Guid.Empty.ToString() }.Html.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.AuthorName"/> property.</para>
  /// </summary>
  [Fact]
  public void AuthorName_Property()
  {
    new Media { AuthorName = Guid.Empty.ToString() }.AuthorName.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.AuthorUri"/> property.</para>
  /// </summary>
  [Fact]
  public void AuthorUri_Property()
  {
    new Media { AuthorUri = Guid.Empty.ToString() }.AuthorUri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.ThumbnailUri"/> property.</para>
  /// </summary>
  [Fact]
  public void ThumbnailUri_Property()
  {
    new Media { ThumbnailUri = Guid.Empty.ToString() }.ThumbnailUri.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.ThumbnailWidth"/> property.</para>
  /// </summary>
  [Fact]
  public void ThumbnailWidth_Property()
  {
    new Media { ThumbnailWidth = short.MaxValue }.ThumbnailWidth.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.ThumbnailHeight"/> property.</para>
  /// </summary>
  [Fact]
  public void ThumbnailHeight_Property()
  {
    new Media { ThumbnailHeight = short.MaxValue }.ThumbnailHeight.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Media()"/>
  [Fact]
  public void Constructors()
  {
    var media = new Media();

    media.Id.Should().BeNull();
    media.Uuid.Should().NotBeNull();
    media.Version.Should().BeNull();
    media.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    media.UpdatedOn.Should().BeNull();

    media.Name.Should().BeNull();
    media.ContentType.Should().BeNull();
    media.Uri.Should().BeNull();
    media.ProviderUri.Should().BeNull();
    media.Width.Should().BeNull();
    media.Height.Should().BeNull();
    media.Duration.Should().BeNull();
    media.Description.Should().BeNull();
    media.Html.Should().BeNull();
    media.AuthorName.Should().BeNull();
    media.AuthorUri.Should().BeNull();
    media.ThumbnailUri.Should().BeNull();
    media.ThumbnailWidth.Should().BeNull();
    media.ThumbnailHeight.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.CompareTo(Media)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Media.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Media.Equals(Media)"/></description></item>
  ///     <item><description><see cref="Media.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Media.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Media.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Media.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Media().ToString().Should().BeEmpty();
    new Media { Uri = "schema://uri".ToUri() }.ToString().Should().Be("schema://uri/");
  }
}