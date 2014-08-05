namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents audio file/track with metainformation.</para>
  /// </summary>
  public partial interface IAudio : IEntity
  {
    /// <summary>
    ///   <para>Bitrate of audio track.</para>
    /// </summary>
    short Bitrate { get; }

    /// <summary>
    ///   <para>Category of audio.</para>
    /// </summary>
    IAudiosCategory Category { get; }

    /// <summary>
    ///   <para>Duration (in seconds) of audio track.</para>
    /// </summary>
    long Duration { get; }

    /// <summary>
    ///   <para>URI of audio file.</para>
    /// </summary>
    string File { get; }
  }
}