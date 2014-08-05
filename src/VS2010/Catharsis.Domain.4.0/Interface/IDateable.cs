using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity that have an associated date.</para>
  /// </summary>
  public partial interface IDateable
  {
    /// <summary>
    ///   <para>Date/time of the associated entity.</para>
    /// </summary>
    DateTime Date { get; }
  }
}