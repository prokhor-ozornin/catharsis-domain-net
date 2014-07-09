namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which have 2 dimensions (width/height).</para>
  /// </summary>
  public partial interface IDimensionable
  {
    /// <summary>
    ///   <para>Vertical height of entity.</para>
    /// </summary>
    short Height { get; }
    
    /// <summary>
    ///   <para>Horizontal width of entity.</para>
    /// </summary>
    short Width { get; }
  }
}