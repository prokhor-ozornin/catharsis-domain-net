using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a geographical location point.</para>
  /// </summary>
  [Description("Represents a geographical location point")]
  public partial class Location : IEquatable<Location>, IEntity
  {
    private string address;
    private City city;

    /// <summary>
    ///   <para>Unique identifier of location.</para>
    /// </summary>
    [Description("Unique identifier of location")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current location instance.</para>
    /// </summary>
    [Description("Version number of current location instance")]
    [XmlIgnore]
    public virtual long Version { get; set; }

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
    ///   <para>Determines whether two locations instances are equal.</para>
    /// </summary>
    /// <param name="other">The location to compare with the current one.</param>
    /// <returns><c>true</c> if specified location is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Location other)
    {
      return this.Equality(other, location => location.Address, location => location.City);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Location);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(location => location.Address, location => location.City);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current location.</para>
    /// </summary>
    /// <returns>A string that represents the current location.</returns>
    public override string ToString()
    {
      return "{0},{1},{2}".FormatSelf(this.City.Country, this.City, this.Address);
    }
  }
}