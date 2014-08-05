using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a playcast, which is a combination/mix of text/audio/image content.</para>
  /// </summary>
  [Description("Represents a playcast, which is a combination/mix of text/audio/image content")]
  public partial class Playcast : Item
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
  }
}