namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a custom business entity.</para>
  /// </summary>
  public interface IEntity : IIdentifyable<long>
  {
    /// <summary>
    ///   <para>Version of entity instance.</para>
    /// </summary>
    long Version { get; set; }
  }
}