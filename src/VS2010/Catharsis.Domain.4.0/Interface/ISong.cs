namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a song on a musician or band.</para>
  /// </summary>
  public partial interface ISong : IItem
  {
    /// <summary>
    ///   <para>Album where this song was included.</para>
    /// </summary>
    ISongsAlbum Album { get; }
    
    /// <summary>
    ///   <para>URI of audio file.</para>
    /// </summary>
    string Audio { get; }
  }
}