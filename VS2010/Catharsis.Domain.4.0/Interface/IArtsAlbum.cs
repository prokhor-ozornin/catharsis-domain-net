using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents album or collection of arts.</para>
  /// </summary>
  public partial interface IArtsAlbum : IItem
  {
    /// <summary>
    ///   <para>Date of album's official publication.</para>
    /// </summary>
    DateTime? PublishedOn { get; }
  }
}