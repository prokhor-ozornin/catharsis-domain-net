using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which have both creation and last modification date/time.</para>
  /// </summary>
  public interface ITimestampable
  {
    /// <summary>
    ///   <para>Date of entity's creation.</para>
    /// </summary>
    DateTime DateCreated { get; set; }
    
    /// <summary>
    ///   <para>Date/time of entity's modification.</para>
    /// </summary>
    DateTime LastUpdated { get; set; }
  }
}