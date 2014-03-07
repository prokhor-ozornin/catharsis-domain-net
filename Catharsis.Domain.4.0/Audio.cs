using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents audio file/track with metainformation.</para>
  /// </summary>
  [Description("Represents audio file/track with metainformation")]
  public partial class Audio : IComparable<Audio>, IEquatable<Audio>, IEntity
  {
    private string file;

    /// <summary>
    ///   <para>Unique identifier of audio.</para>
    /// </summary>
    [Description("Unique identifier of audio")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current audio instance.</para>
    /// </summary>
    [Description("Version number of current audio instance")]
    [XmlIgnore]
    public virtual long Version { get; set; }

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
    ///   <para>Compares the current audio with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Audio"/> to compare with this instance.</param>
    public virtual int CompareTo(Audio other)
    {
      return this.File.CompareTo(other.File, StringComparison.InvariantCulture);
    }

    /// <summary>
    ///   <para>Determines whether two audios instances are equal.</para>
    /// </summary>
    /// <param name="other">The audio to compare with the current one.</param>
    /// <returns><c>true</c> if specified audio is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Audio other)
    {
      return this.Equality(other, audio => audio.Category, audio => audio.File);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Audio);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(audio => audio.Category, audio => audio.File);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current audio.</para>
    /// </summary>
    /// <returns>A string that represents the current audio.</returns>
    public override string ToString()
    {
      return this.File;
    }
  }
}