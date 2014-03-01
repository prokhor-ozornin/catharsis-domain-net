using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents geographical city.</para>
  /// </summary>
  [Description("Represents geographical city")]
  public partial class City : IComparable<City>, IEquatable<City>, IEntity, INameable
  {
    private Country country;
    private string name;

    /// <summary>
    ///   <para>Unique identifier of city.</para>
    /// </summary>
    [Description("Unique identifier of city")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current city instance.</para>
    /// </summary>
    [Description("Version number of current city instance")]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Country where the city is located.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    [Description("Country where the city is located")]
    public virtual Country Country
    {
      get { return this.country; }
      set
      {
        Assertion.NotNull(value);

        this.country = value;
      }
    }

    /// <summary>
    ///   <para>Name of city.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Name of city")]
    public virtual string Name
    {
      get { return this.name; }
      set
      {
        Assertion.NotEmpty(value);

        this.name = value;
      }
    }

    /// <summary>
    ///   <para>Region/area where city is located.</para>
    /// </summary>
    [Description("Region/area where city is located")]
    public virtual string Region { get; set; }

    /// <summary>
    ///   <para>Creates new city.</para>
    /// </summary>
    public City()
    {
    }

    /// <summary>
    ///   <para>Creates new city.</para>
    /// </summary>
    /// <param name="name">Name of city.</param>
    /// <param name="country">Country where the city is located.</param>
    /// <param name="region">Region/area where city is located.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="country"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public City(string name, Country country, string region = null)
    {
      this.Name = name;
      this.Country = country;
      this.Region = region;
    }

    /// <summary>
    ///   <para>Compares the current city with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="City"/> to compare with this instance.</param>
    public virtual int CompareTo(City other)
    {
      return this.Name.Compare(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two cities instances are equal.</para>
    /// </summary>
    /// <param name="other">The city to compare with the current one.</param>
    /// <returns><c>true</c> if specified city is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(City other)
    {
      return this.Equality(other, city => city.Country, city => city.Name, city => city.Region);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as City);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(city => city.Country, city => city.Name, city => city.Region);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current item.</para>
    /// </summary>
    /// <returns>A string that represents the current item.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}