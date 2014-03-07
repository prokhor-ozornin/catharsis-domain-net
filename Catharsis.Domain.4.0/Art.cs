using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a creative image which is usually displayed publically.</para>
  /// </summary>
  [Description("Represents a creative image which is usually displayed publically")]
  public partial class Art : Item, IComparable<Art>, IEquatable<Art>
  {
    private string image;

    /// <summary>
    ///   <para>Album that contains the art.</para>
    /// </summary>
    [Description("Album that contains the art")]
    public virtual ArtsAlbum Album { get; set; }
    
    /// <summary>
    ///   <para>URI of art's graphical image.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URI of art's graphical image")]
    public virtual string Image
    {
      get { return this.image; }
      set
      {
        Assertion.NotEmpty(value);

        this.image = value;
      }
    }
    
    /// <summary>
    ///   <para>Name of art's physical material.</para>
    /// </summary>
    [Description("Name of art's physical material")]
    public virtual string Material { get; set; }
    
    /// <summary>
    ///   <para>Creator of the art.</para>
    /// </summary>
    [Description("Creator of the art")]
    public virtual Person Person { get; set; }
    
    /// <summary>
    ///   <para>Place of art's physical exposition.</para>
    /// </summary>
    [Description("Place of art's physical exposition")]
    public virtual string Place { get; set; }

    /// <summary>
    ///   <para>Creates new art.</para>
    /// </summary>
    public Art()
    {
    }

    /// <summary>
    ///   <para>Creates new art.</para>
    /// </summary>
    /// <param name="name">Name of art.</param>
    /// <param name="image">URI of art's graphical image.</param>
    /// <param name="album">Album that contains the art.</param>
    /// <param name="text">Art's description text.</param>
    /// <param name="person">Author of the art, or a <c>null</c> reference.</param>
    /// <param name="place">Place of art's public disposition, or a <c>null</c> reference.</param>
    /// <param name="material">Physical material, used in art's painting, or a <c>null</c> reference.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="image"/> or <paramref name="image"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="image"/> is <see cref="string.Empty"/> string.</exception>
    public Art(string name, string image, ArtsAlbum album = null, string text = null, Person person = null, string place = null, string material = null) : base(name, text)
    {
      this.Image = image;
      this.Album = album;
      this.Person = person;
      this.Place = place;
      this.Material = material;
    }

    /// <summary>
    ///   <para>Compares the current art with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Art"/> to compare with this instance.</param>
    public virtual int CompareTo(Art other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two arts instances are equal.</para>
    /// </summary>
    /// <param name="other">The art to compare with the current one.</param>
    /// <returns><c>true</c> if specified art is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Art other)
    {
      return base.Equals(other) && this.Equality(other, art => art.Album, art => art.Person);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Art);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(art => art.Album, art => art.Person);
    }
  }
}