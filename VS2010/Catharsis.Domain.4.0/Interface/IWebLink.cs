namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents named hyperlink to external website.</para>
  /// </summary>
  public partial interface IWebLink : IItem
  {
    /// <summary>
    ///   <para>Category of web link.</para>
    /// </summary>
    IWebLinksCategory Category { get; }

    /// <summary>
    ///   <para>URL address of hyperlink.</para>
    /// </summary>
    string Url { get; }
  }
}