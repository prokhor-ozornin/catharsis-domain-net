using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which have both creation and last modification date/time.</para>
  /// </summary>
  public partial interface ITimestampable
  {
    /// <summary>
    ///   <para>Date of entity's creation.</para>
    /// </summary>
    DateTime CreatedAt { get; }
    
    /// <summary>
    ///   <para>Date/time of entity's modification.</para>
    /// </summary>
    DateTime UpdatedAt { get; }
  }
}