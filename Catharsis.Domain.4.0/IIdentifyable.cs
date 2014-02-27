using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity with a unique identifier.</para>
  /// </summary>
  /// <typeparam name="T">Type of identifier.</typeparam>
  public interface IIdentifyable<T>
  {
    /// <summary>
    ///   <para>Unique identifier of entity.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    T Id { get; set; }
  }
}