using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents audio file/track with metainformation.</para>
  /// </summary>
  [Description("Represents audio file/track with metainformation")]
  public partial class Audio : Entity, IComparable<Audio>
  {
    private string file;

    /// <summary>
    ///   <para>Bitrate of audio track.</para>
    /// </summary>
    [Description("Bitrate of audio track")]
    public virtual short Bitrate { get; set; }

    /// <summary>
    ///   <para>Category of audio.</para>
    /// </summary>
    [Description("Category of audio")]
    public virtual AudiosCategory Category { get; set; }

    /// <summary>
    ///   <para>Duration (in seconds) of audio track.</para>
    /// </summary>
    [Description("Duration (in seconds) of audio track")]
    public virtual long Duration { get; set; }

    /// <summary>
    ///   <para>URI of audio file.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URI of audio file")]
    public virtual string File
    {
      get { return this.file; }
      set
      {
        Assertion.NotEmpty(value);

        this.file = value;
      }
    }

    /// <summary>
    ///   <para>Creates new audio.</para>
    /// </summary>
    public Audio()
    {
    }

    /// <summary>
    ///   <para>Creates new audio.</para>
    /// </summary>
    /// <param name="file">URI of audio file.</param>
    /// <param name="bitrate">Bitrate of audio track.</param>
    /// <param name="duration">Duration (in seconds) of audio track.</param>
    /// <param name="category">Category of audio.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="file"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="file"/> is <see cref="string.Empty"/> string.</exception>
    public Audio(string file, short bitrate, short duration, AudiosCategory category = null)
    {
      this.File = file;
      this.Bitrate = bitrate;
      this.Duration = duration;
      this.Category = category;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Audio"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Audio"/> to compare with this instance.</param>
    public virtual int CompareTo(Audio other)
    {
      return this.File.CompareTo(other.File, StringComparison.InvariantCulture);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Audio"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Audio"/>.</returns>
    public override string ToString()
    {
      return this.File;
    }
  }
}