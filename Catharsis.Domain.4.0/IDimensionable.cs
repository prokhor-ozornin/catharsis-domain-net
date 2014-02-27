namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity which have 2 dimensions (width/height).</para>
  /// </summary>
  public interface IDimensionable
  {
    /// <summary>
    ///   <para>Vertical height of entity.</para>
    /// </summary>
    short Height { get; set; }
    
    /// <summary>
    ///   <para>Horizontal width of entity.</para>
    /// </summary>
    short Width { get; set; }
  }
}