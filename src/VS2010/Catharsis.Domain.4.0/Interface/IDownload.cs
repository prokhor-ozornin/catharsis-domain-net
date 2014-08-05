namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents downloadable content with metainformation.</para>
  /// </summary>
  public partial interface IDownload : IItem
  {
    /// <summary>
    ///   <para>Category of download.</para>
    /// </summary>
    IDownloadsCategory Category { get; }

    /// <summary>
    ///   <para>Number of downloads.</para>
    /// </summary>
    long Downloads { get; }

    /// <summary>
    ///   <para>URL address of download.</para>
    /// </summary>
    string Url { get; }
  }
}