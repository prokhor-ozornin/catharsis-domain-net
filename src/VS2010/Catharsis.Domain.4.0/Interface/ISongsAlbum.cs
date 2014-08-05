using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents an album of a musician or band.</para>
  /// </summary>
  public partial interface ISongsAlbum : IItem
  {
    /// <summary>
    ///   <para>URI of album's cover image.</para>
    /// </summary>
    string Image { get; }

    /// <summary>
    ///   <para>Date of album's official publication.</para>
    /// </summary>
    DateTime? PublishedOn { get; }
  }
}