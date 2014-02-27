using System.Collections.Generic;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which can be tagged.</para>
  /// </summary>
  public interface ITaggable
  {
    /// <summary>
    ///   <para>Collection of tags (keywords) that are associated with the entity.</para>
    /// </summary>
    ICollection<string> Tags { get; }
  }
}