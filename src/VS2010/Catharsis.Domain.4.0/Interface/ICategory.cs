namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom category of content.</para>
  /// </summary>
  public interface ICategory : IEntity, INameable, ILocalizable
  {
    /// <summary>
    ///   <para>Description of category.</para>
    /// </summary>
    string Description { get; }
  }
}