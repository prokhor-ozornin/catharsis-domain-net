using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents geographical city.</para>
  /// </summary>
  [Description("Represents geographical city")]
  public partial class City : Entity, IComparable<City>, INameable
  {
    private Country country;
    private string name;

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
    ///   <para>Compares the current <see cref="City"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="City"/> to compare with this instance.</param>
    public virtual int CompareTo(City other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="City"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="City"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}