using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a video/movie.</para>
  /// </summary>
  [Description("Represents a video/movie")]
  public partial class Video : IComparable<Video>, IEquatable<Video>, IEntity, IDimensionable
  {
    private string file;

    /// <summary>
    ///   <para>Unique identifier of video.</para>
    /// </summary>
    [Description("Unique identifier of video")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current video instance.</para>
    /// </summary>
    [Description("Version number of current video instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Bitrate of video clip.</para>
    /// </summary>
    [Description("Bitrate of video clip")]
    public virtual short Bitrate { get; set; }
    
    /// <summary>
    ///   <para>Category of video.</para>
    /// </summary>
    [Description("Category of video")]
    public virtual VideosCategory Category { get; set; }
    
    /// <summary>
    ///   <para>Duration (in seconds) of video clip.</para>
    /// </summary>
    [Description("Duration (in seconds) of video clip")]
    public virtual long Duration { get; set; }
    
    /// <summary>
    ///   <para>URI of video file.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URI of video file")]
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
    ///   <para>Vertical height of video frame.</para>
    /// </summary>
    [Description("Vertical height of video frame")]
    public virtual short Height { get; set; }
    
    /// <summary>
    ///   <para>Horizontal width of video frame.</para>
    /// </summary>
    [Description("Horizontal width of video frame")]
    public virtual short Width { get; set; }

    /// <summary>
    ///   <para>Creates new video.</para>
    /// </summary>
    public Video()
    {
    }

    /// <summary>
    ///   <para>Creates new video.</para>
    /// </summary>
    /// <param name="file">URI of video file.</param>
    /// <param name="bitrate">Bitrate of video clip.</param>
    /// <param name="duration">Duration (in seconds) of video clip.</param>
    /// <param name="height">Vertical height of video frame.</param>
    /// <param name="width">Horizontal width of video frame.</param>
    /// <param name="category">Category of video.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="file"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="file"/> is <see cref="string.Empty"/> string.</exception>
    public Video(string file, short bitrate, long duration, short height, short width, VideosCategory category = null)
    {
      this.File = file;
      this.Bitrate = bitrate;
      this.Duration = duration;
      this.Height = height;
      this.Width = width;
      this.Category = category;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Video"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Video"/> to compare with this instance.</param>
    public virtual int CompareTo(Video other)
    {
      return this.File.CompareTo(other.File);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Video"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Video other)
    {
      return this.Equality(other, video => video.Category, video => video.File);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Video);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(video => video.Category, video => video.File);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Video"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Video"/>.</returns>
    public override string ToString()
    {
      return this.File;
    }
  }
}