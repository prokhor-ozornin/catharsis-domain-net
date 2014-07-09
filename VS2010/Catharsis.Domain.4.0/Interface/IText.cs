using System.Collections.Generic;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a literary text.</para>
  /// </summary>
  public partial interface IText : IItem
  {
    /// <summary>
    ///   <para>Category of text.</para>
    /// </summary>
    ITextsCategory Category { get; }

    /// <summary>
    ///   <para>Author of text.</para>
    /// </summary>
    IPerson Person { get; }

    /// <summary>
    ///   <para>Collection of text's translations to other languages.</para>
    /// </summary>
    ICollection<ITextTranslation> Translations { get; }
  }
}