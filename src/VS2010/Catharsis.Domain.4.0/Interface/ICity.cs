namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents geographical city.</para>
  /// </summary>
  public partial interface ICity : IEntity, INameable
  {
    /// <summary>
    ///   <para>Country where the city is located.</para>
    /// </summary>
    ICountry Country { get; }

    /// <summary>
    ///   <para>Region/area where city is located.</para>
    /// </summary>
    string Region { get; }
  }
}