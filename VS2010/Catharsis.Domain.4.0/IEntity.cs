namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a custom business entity.</para>
  /// </summary>
  public interface IEntity : IIdentifyable<long>, IVersionable
  {
  }
}