using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a song on a musician or band.</para>
  /// </summary>
  [Description("Represents a song on a musician or band")]
  public partial class Song : Item, IComparable<Song>, IEquatable<Song>
  {
    private string audio;

    /// <summary>
    ///   <para>Album where this song was included.</para>
    /// </summary>
    [Description("Album where this song was included")]
    public virtual SongsAlbum Album { get; set; }
    
    /// <summary>
    ///   <para>URI of audio file.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URI of audio file")]
    public virtual string Audio
    {
      get { return this.audio; }
      set
      {
        Assertion.NotEmpty(value);

        this.audio = value;
      }
    }

    /// <summary>
    ///   <para>Creates new song.</para>
    /// </summary>
    public Song()
    {
    }

    /// <summary>
    ///   <para>Creates new song.</para>
    /// </summary>
    /// <param name="name">Name of song.</param>
    /// <param name="text">Song's lyrics text.</param>
    /// <param name="audio">URI of audio file.</param>
    /// <param name="album">Album where this song was included.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="text"/> or <paramref name="audio"/> is a <c>null</c> reference.</exception>
    public Song(string name, string text, string audio, SongsAlbum album = null) : base(name, text)
    {
      Assertion.NotEmpty(text);

      this.Audio = audio;
      this.Album = album;
    }

    /// <summary>
    ///   <para>Compares the current song with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Song"/> to compare with this instance.</param>
    public virtual int CompareTo(Song other)
    {
      return this.Name.Compare(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two songs instances are equal.</para>
    /// </summary>
    /// <param name="other">The song to compare with the current one.</param>
    /// <returns><c>true</c> if specified song is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Song other)
    {
      return base.Equals(other) && this.Equality(other, song => song.Album);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Song);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(song => song.Album);
    }
  }
}