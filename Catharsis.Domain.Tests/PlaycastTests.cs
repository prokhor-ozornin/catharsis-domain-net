using System;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Playcast"/>.</para>
  /// </summary>
  public sealed class PlaycastTests : EntityUnitTests<Playcast>
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Playcast()"/>
    ///   <seealso cref="Playcast(string, string, PlaycastsCategory, string, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var playcast = new Playcast();
      Assert.Null(playcast.Audio);
      Assert.Null(playcast.Category);
      Assert.False(playcast.Comments.Any());
      Assert.True(playcast.DateCreated >= DateTime.MinValue && playcast.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, playcast.Id);
      Assert.Null(playcast.Image);
      Assert.Null(playcast.Language);
      Assert.True(playcast.LastUpdated >= DateTime.MinValue && playcast.LastUpdated <= DateTime.UtcNow);
      Assert.Null(playcast.Name);
      Assert.False(playcast.Tags.Any());
      Assert.Null(playcast.Text);
      Assert.Equal(0, playcast.Version);

      Assert.Throws<ArgumentNullException>(() => new Playcast(null, "text"));
      Assert.Throws<ArgumentNullException>(() => new Playcast("name", null));
      Assert.Throws<ArgumentException>(() => new Playcast(string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new Playcast("name", string.Empty));
      playcast = new Playcast("name", "text", new PlaycastsCategory(), "audio", "name");
      Assert.NotNull(playcast.Audio);
      Assert.NotNull(playcast.Category);
      Assert.False(playcast.Comments.Any());
      Assert.True(playcast.DateCreated >= DateTime.MinValue && playcast.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, playcast.Id);
      Assert.NotNull(playcast.Image);
      Assert.Null(playcast.Language);
      Assert.True(playcast.LastUpdated >= DateTime.MinValue && playcast.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", playcast.Name);
      Assert.False(playcast.Tags.Any());
      Assert.Equal("text", playcast.Text);
      Assert.Equal(0, playcast.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.Audio"/> property.</para>
    /// </summary>
    [Fact]
    public void Audio_Property()
    {
      Assert.Equal("audio", new Playcast { Audio = "audio" }.Audio);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new PlaycastsCategory();
      Assert.True(ReferenceEquals(new Playcast { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.Image"/> property.</para>
    /// </summary>
    [Fact]
    public void Image_Property()
    {
      Assert.Equal("image", new Playcast { Image = "image" }.Image);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Playcast.Equals(Playcast)"/></description></item>
    ///     <item><description><see cref="Playcast.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new PlaycastsCategory { Name = "first" }, new PlaycastsCategory { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Playcast.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new PlaycastsCategory { Name = "first" }, new PlaycastsCategory { Name = "second" });
    }
  }
}