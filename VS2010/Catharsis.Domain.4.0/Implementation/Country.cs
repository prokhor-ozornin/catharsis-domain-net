using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents geographical country.</para>
  /// </summary>
  [Description("Represents geographical country")]
  public partial class Country : IComparable<Country>, IEquatable<Country>, IEntity, INameable
  {
    private string isoCode;
    private string name;

    /// <summary>
    ///   <para>Unique identifier of country.</para>
    /// </summary>
    [Description("Unique identifier of country")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current country instance.</para>
    /// </summary>
    [Description("Version number of current country instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>URI of country's flag image.</para>
    /// </summary>
    [Description("URI of country's flag image")]
    public virtual string Image { get; set; }

    /// <summary>
    ///   <para>ISO code of country.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("ISO code of country")]
    public virtual string IsoCode
    {
      get { return this.isoCode; }
      set
      {
        Assertion.NotEmpty(value);

        this.isoCode = value;
      }
    }

    /// <summary>
    ///   <para>Name of country.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Name of country")]
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
    ///   <para>Creates new country.</para>
    /// </summary>
    public Country()
    {
    }

    /// <summary>
    ///   <para>Creates new country.</para>
    /// </summary>
    /// <param name="name">Name of country.</param>
    /// <param name="isoCode">ISO code of country.</param>
    /// <param name="image">URI of country's flag image.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="isoCode"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="isoCode"/> is <see cref="string.Empty"/> string.</exception>
    public Country(string name, string isoCode, string image = null)
    {
      this.Name = name;
      this.IsoCode = isoCode;
      this.Image = image;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Country"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Country"/> to compare with this instance.</param>
    public virtual int CompareTo(Country other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="Country"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Country other)
    {
      return this.Equality(other, country => country.IsoCode);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Country);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(country => country.IsoCode);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Country"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Country"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}