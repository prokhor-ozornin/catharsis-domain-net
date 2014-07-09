namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a geographical location point.</para>
  /// </summary>
  public partial interface ILocation : IEntity
  {
    /// <summary>
    ///   <para>Address in a string form, suitable for geocoding.</para>
    /// </summary>
    string Address { get; }

    /// <summary>
    ///   <para>City of address.</para>
    /// </summary>
    ICity City { get; }

    /// <summary>
    ///   <para>Geo map latitude.</para>
    /// </summary>
    decimal? Latitude { get; }

    /// <summary>
    ///   <para>Geo map longitude.</para>
    /// </summary>
    decimal? Longitude { get; }

    /// <summary>
    ///   <para>Postal code of city address.</para>
    /// </summary>
    string PostalCode { get; }
  }
}