using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents album or collection of arts.</para>
  /// </summary>
  [Description("Represents album or collection of arts")]
  public partial class ArtsAlbum : Item, IComparable<ArtsAlbum>
  {
    /// <summary>
    ///   <para>Date of album's official publication.</para>
    /// </summary>
    [Description("Date of album's official publication")]
    public virtual DateTime? PublishedOn { get; set; }

    /// <summary>
    ///   <para>Creates new arts album.</para>
    /// </summary>
    public ArtsAlbum()
    {
    }

    /// <summary>
    ///   <para>Creates new arts album.</para>
    /// </summary>
    /// <param name="name">Name of album.</param>
    /// <param name="text">Album's description.</param>
    /// <param name="publishedOn">Date of album's official publication.</param>
    /// <exception cref="ArgumentNullException">If<paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public ArtsAlbum(string name, string text = null, DateTime? publishedOn = null) : base(name, text)
    {
      this.PublishedOn = publishedOn;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="ArtsAlbum"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ArtsAlbum"/> to compare with this instance.</param>
    public virtual int CompareTo(ArtsAlbum other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}