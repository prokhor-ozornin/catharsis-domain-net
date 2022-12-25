using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Audio"/>.</para>
/// </summary>
public sealed class AudioTest : EntityTest<Audio>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Audio.Bitrate"/> property.</para>
  /// </summary>
  [Fact]
  public void Bitrate_Property()
  {
    new Audio { Bitrate = short.MaxValue }.Bitrate.Should().Be(short.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Audio.File"/> property.</para>
  /// </summary>
  [Fact]
  public void File_Property()
  {
    var file = new StorageFile();
    new Audio { File = file }.File.Should().BeSameAs(file);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Audio()"/>
  [Fact]
  public void Constructors()
  {
    var audio = new Audio();

    audio.Id.Should().BeNull();
    audio.Uuid.Should().NotBeNull();
    audio.Version.Should().BeNull();
    audio.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    audio.UpdatedOn.Should().BeNull();

    audio.Bitrate.Should().BeNull();
    audio.File.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Audio.CompareTo(Audio)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Audio.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Audio.Equals(Audio)"/></description></item>
  ///     <item><description><see cref="Audio.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Audio.File), new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
    TestEquality(nameof(Audio.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Audio.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Audio.File), new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
    TestHashCode(nameof(Audio.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Audio.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Audio().ToString().Should().BeEmpty();
    new Audio { Uri = "schema://uri".ToUri() }.ToString().Should().Be("schema://uri/");
  }
}