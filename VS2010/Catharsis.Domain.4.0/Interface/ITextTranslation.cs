namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a translation of literary text to target language.</para>
  /// </summary>
  public partial interface ITextTranslation : IEntity, ILocalizable, INameable
  {
    /// <summary>
    ///   <para>Translated text.</para>
    /// </summary>
    string Text { get; }

    /// <summary>
    ///   <para>Name of translator.</para>
    /// </summary>
    string Translator { get; }
  }
}