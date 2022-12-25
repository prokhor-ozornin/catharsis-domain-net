using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Video"/>.</para>
/// </summary>
public sealed class VideoTest : EntityTest<Video>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Video.File"/> property.</para>
  /// </summary>
  [Fact]
  public void File_Property()
  {
    var file = new StorageFile();
    new Video {File = file}.File.Should().BeSameAs(file);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Video()"/>
  [Fact]
  public void Constructors()
  {
    var video = new Video();

    video.Id.Should().BeNull();
    video.Uuid.Should().NotBeNull();
    video.Version.Should().BeNull();
    video.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    video.UpdatedOn.Should().BeNull();

    video.File.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Video.CompareTo(Video)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Video.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Video.Equals(Video)"/></description></item>
  ///     <item><description><see cref="Video.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Video.File), new StorageFile {Name = "first"}, new StorageFile {Name = "second"});
    TestEquality(nameof(Video.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Video.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Video.File), new StorageFile {Name = "first"}, new StorageFile {Name = "second"});
    TestHashCode(nameof(Video.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Video.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Video().ToString().Should().BeEmpty();
    new Video {Uri = "schema://uri".ToUri()}.ToString().Should().Be("schema://uri/");
  }
}