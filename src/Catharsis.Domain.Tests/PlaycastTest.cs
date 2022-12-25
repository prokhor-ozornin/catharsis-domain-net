using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Playcast"/>.</para>
/// </summary>
public sealed class PlaycastTest : EntityTest<Playcast>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Playcast { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.Text"/> property.</para>
  /// </summary>
  [Fact]
  public void Text_Property()
  {
    new Playcast { Text = Guid.Empty.ToString() }.Text.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.Image"/> property.</para>
  /// </summary>
  [Fact]
  public void Image_Property()
  {
    var image = new Image();
    new Playcast { Image = image }.Image.Should().BeSameAs(image);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.Audio"/> property.</para>
  /// </summary>
  [Fact]
  public void Audio_Property()
  {
    var audio = new Audio();
    new Playcast { Audio = audio }.Audio.Should().BeSameAs(audio);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.Video"/> property.</para>
  /// </summary>
  [Fact]
  public void Video_Property()
  {
    var video = new Video();
    new Playcast { Video = video }.Video.Should().BeSameAs(video);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.Tags"/> property.</para>
  /// </summary>
  [Fact]
  public void Tags_Property()
  {
    var tags = new HashSet<Tag>();
    new Playcast { Tags = tags }.Tags.Should().BeSameAs(tags);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Playcast()"/>
  [Fact]
  public void Constructors()
  {
    var playcast = new Playcast();

    playcast.Id.Should().BeNull();
    playcast.Uuid.Should().NotBeNull();
    playcast.Version.Should().BeNull();
    playcast.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    playcast.UpdatedOn.Should().BeNull();

    playcast.Name.Should().BeNull();
    playcast.Text.Should().BeNull();
    playcast.Image.Should().BeNull();
    playcast.Audio.Should().BeNull();
    playcast.Video.Should().BeNull();
    playcast.Tags.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.CompareTo(Playcast)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Playcast.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Playcast.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Playcast().ToString().Should().BeEmpty();
    new Playcast { Name = string.Empty }.ToString().Should().BeEmpty();
    new Playcast { Name = " " }.ToString().Should().BeEmpty();
    new Playcast { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}