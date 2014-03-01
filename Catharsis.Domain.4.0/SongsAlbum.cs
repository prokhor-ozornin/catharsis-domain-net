using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents an album of a musician or band.</para>
  /// </summary>
  [Description("Represents an album of a musician or band")]
  public partial class SongsAlbum : Item, IComparable<SongsAlbum>
  {
    /// <summary>
    ///   <para>URI of album's cover image.</para>
    /// </summary>
    [Description("URI of album's cover image")]
    public virtual string Image { get; set; }
    
    /// <summary>
    ///   <para>Date of album's official publication.</para>
    /// </summary>
    [Description("Date of album's official publication")]
    public virtual DateTime? PublishedOn { get; set; }

    /// <summary>
    ///   <para>Creates new songs album.</para>
    /// </summary>
    public SongsAlbum()
    {
    }

    /// <summary>
    ///   <para>Creates new songs album.</para>
    /// </summary>
    /// <param name="name">Name of album.</param>
    /// <param name="text">Album's description text.</param>
    /// <param name="image">URI of album's cover image.</param>
    /// <param name="publishedOn">Date of album's official publication.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public SongsAlbum(string name, string text = null, string image = null, DateTime? publishedOn = null) : base(name, text)
    {
      this.Image = image;
      this.PublishedOn = publishedOn;
    }

    /// <summary>
    ///   <para>Compares the current songs album with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="SongsAlbum"/> to compare with this instance.</param>
    public virtual int CompareTo(SongsAlbum other)
    {
      return this.Name.Compare(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}