namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Representation of a custom business entity.</para>
  /// </summary>
  public partial interface IEntity : IIdentifyable<long>, IVersionable
  {
  }
}