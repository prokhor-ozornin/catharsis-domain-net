using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a geographical location point.</para>
  /// </summary>
  [Description("Represents a geographical location point")]
  public partial class Location : Entity
  {
    private string address;
    private City city;

    /// <summary>
    ///   <para>Address in a string form, suitable for geocoding.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Address in a string form, suitable for geocoding")]
    public virtual string Address
    {
      get { return this.address; }
      set
      {
        Assertion.NotEmpty(value);

        this.address = value;
      }
    }
    
    /// <summary>
    ///   <para>City of address.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    [Description("City of address")]
    public virtual City City
    {
      get { return this.city; }
      set
      {
        Assertion.NotNull(value);

        this.city = value;
      }
    }
    
    /// <summary>
    ///   <para>Geo map latitude.</para>
    /// </summary>
    [Description("Geo map latitude")]
    public virtual decimal? Latitude { get; set; }
    
    /// <summary>
    ///   <para>Geo map longitude.</para>
    /// </summary>
    [Description("Geo map longitude")]
    public virtual decimal? Longitude { get; set; }
    
    /// <summary>
    ///   <para>Postal code of city address.</para>
    /// </summary>
    [Description("Postal code of city address")]
    public virtual string PostalCode { get; set; }
    
    /// <summary>
    ///   <para>Creates new location.</para>
    /// </summary>
    public Location()
    {
    }

    /// <summary>
    ///   <para>Creates new location.</para>
    /// </summary>
    /// <param name="city">City of address.</param>
    /// <param name="address">Address in a string form, suitable for geocoding.</param>
    /// <param name="latitude">Geo map latitude.</param>
    /// <param name="longitude">Geo map longitude.</param>
    /// <param name="postalCode">Postal code of city address.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="city"/> or <paramref name="address"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="address"/> is <see cref="string.Empty"/> string.</exception>
    public Location(City city, string address, decimal? latitude = null, decimal? longitude = null, string postalCode = null)
    {
      this.City = city;
      this.Address = address;
      this.Latitude = latitude;
      this.Longitude = longitude;
      this.PostalCode = postalCode;
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Location"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Location"/>.</returns>
    public override string ToString()
    {
      return "{0},{1},{2}".FormatSelf(this.City.Country, this.City, this.Address);
    }
  }
}