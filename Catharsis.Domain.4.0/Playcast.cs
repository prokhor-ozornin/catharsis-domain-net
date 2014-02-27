using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a playcast, which is a combination/mix of text/audio/image content.</para>
  /// </summary>
  public partial class Playcast : Item, IEquatable<Playcast>
  {
    /// <summary>
    ///   <para>URI of associated audio file.</para>
    /// </summary>
    [Description("URI of associated audio file")]
    public virtual string Audio { get; set; }

    /// <summary>
    ///   <para>Category of playcast.</para>
    /// </summary>
    [Description("Category of playcast")]
    public virtual PlaycastsCategory Category { get; set; }

    /// <summary>
    ///   <para>URI of associated image file.</para>
    /// </summary>
    [Description("URI of associated image file")]
    public virtual string Image { get; set; }

    /// <summary>
    ///   <para>Creates new playcast.</para>
    /// </summary>
    public Playcast()
    {
    }

    /// <summary>
    ///   <para>Creates new playcast.</para>
    /// </summary>
    /// <param name="name">Title of playcast.</param>
    /// <param name="text">Text of playcast.</param>
    /// <param name="category">Category of playcast.</param>
    /// <param name="audio">URI of associated audio file.</param>
    /// <param name="image">URI of associated image file.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public Playcast(string name, string text, PlaycastsCategory category = null, string audio = null, string image = null) : base(name, text)
    {
      Assertion.NotEmpty(text);

      this.Category = category;
      this.Audio = audio;
      this.Image = image;
    }

    /// <summary>
    ///   <para>Determines whether two playcasts instances are equal.</para>
    /// </summary>
    /// <param name="other">The playcast to compare with the current one.</param>
    /// <returns><c>true</c> if specified playcast is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Playcast other)
    {
      return base.Equals(other) && this.Equality(other, playcast => playcast.Category);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Playcast);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(playcast => playcast.Category);
    }
  }
}