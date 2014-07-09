namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a named setting/option.</para>
  /// </summary>
  public partial interface ISetting : IEntity, INameable
  {
    /// <summary>
    ///   <para>Value of setting.</para>
    /// </summary>
    string Value { get; }
  }
}