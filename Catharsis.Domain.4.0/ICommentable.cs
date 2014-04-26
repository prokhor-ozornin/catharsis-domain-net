using System.Collections.Generic;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which can be commented.</para>
  /// </summary>
  public interface ICommentable
  {
    /// <summary>
    ///   <para>Collection of comments, associated with the entity.</para>
    /// </summary>
    List<Comment> Comments { get; }
  }
}