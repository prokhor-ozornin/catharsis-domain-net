namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a business entity that can be categorized based on internal numeric type.</para>
  /// </summary>
  public partial interface ITypeable
  {
    /// <summary>
    ///   <para>Numeric representation of entity type.</para>
    /// </summary>
    int Type { get; }
  }
}