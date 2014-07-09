namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a video/movie.</para>
  /// </summary>
  public partial interface IVideo : IEntity, IDimensionable
  {
    /// <summary>
    ///   <para>Bitrate of video clip.</para>
    /// </summary>
    short Bitrate { get; }

    /// <summary>
    ///   <para>Category of video.</para>
    /// </summary>
    IVideosCategory Category { get; }

    /// <summary>
    ///   <para>Duration (in seconds) of video clip.</para>
    /// </summary>
    long Duration { get; }

    /// <summary>
    ///   <para>URI of video file.</para>
    /// </summary>
    string File { get; }
  }
}