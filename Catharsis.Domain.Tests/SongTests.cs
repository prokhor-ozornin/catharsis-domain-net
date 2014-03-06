using System;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Song"/>.</para>
  /// </summary>
  public sealed class SongTests : EntityUnitTests<Song>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Album", "Audio", "Comments", "DateCreated", "Language", "LastUpdated", "Name", "Tags", "Text");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Song()"/>
    /// <seealso cref="Song(string, string, string, SongsAlbum)"/>
    [Fact]
    public void Constructors()
    {
      var song = new Song();
      Assert.Null(song.Album);
      Assert.Null(song.Audio);
      Assert.False(song.Comments.Any());
      Assert.True(song.DateCreated >= DateTime.MinValue && song.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, song.Id);
      Assert.Null(song.Language);
      Assert.True(song.LastUpdated >= DateTime.MinValue && song.LastUpdated <= DateTime.UtcNow);
      Assert.Null(song.Name);
      Assert.False(song.Tags.Any());
      Assert.Null(song.Text);
      Assert.Equal(0, song.Version);

      Assert.Throws<ArgumentNullException>(() => new Song(null, "text", "audio"));
      Assert.Throws<ArgumentNullException>(() => new Song("name", null, "audio"));
      Assert.Throws<ArgumentNullException>(() => new Song("name", "text", null));
      Assert.Throws<ArgumentException>(() => new Song(string.Empty, "name", "text"));
      Assert.Throws<ArgumentException>(() => new Song("name", string.Empty, "audio"));
      song = new Song("name", "text", "audio", new SongsAlbum());
      Assert.NotNull(song.Album);
      Assert.Equal("audio", song.Audio);
      Assert.False(song.Comments.Any());
      Assert.True(song.DateCreated >= DateTime.MinValue && song.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, song.Id);
      Assert.Null(song.Language);
      Assert.True(song.LastUpdated >= DateTime.MinValue && song.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", song.Name);
      Assert.False(song.Tags.Any());
      Assert.Equal("text", song.Text);
      Assert.Equal(0, song.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Song.Album"/> property.</para>
    /// </summary>
    [Fact]
    public void Album_Property()
    {
      var album = new SongsAlbum();
      Assert.True(ReferenceEquals(new Song { Album = album }.Album, album));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Song.Audio"/> property.</para>
    /// </summary>
    [Fact]
    public void Audio_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Song { Audio = null });
      Assert.Throws<ArgumentException>(() => new Song { Audio = string.Empty });
      
      Assert.Equal("audio", new Song { Audio = "audio" }.Audio);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Song.CompareTo(Song)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Song.Equals(Song)"/></description></item>
    ///     <item><description><see cref="Song.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Album", new SongsAlbum { Name = "first" }, new SongsAlbum { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Song.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Album", new SongsAlbum { Name = "first" }, new SongsAlbum { Name = "second" });
    }
  }
}