namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which have a localizable text content.</para>
  /// </summary>
  public partial interface ILocalizable
  {
    /// <summary>
    ///   <para>Language ISO code of entity's text content.</para>
    /// </summary>
    string Language { get; }
  }
}