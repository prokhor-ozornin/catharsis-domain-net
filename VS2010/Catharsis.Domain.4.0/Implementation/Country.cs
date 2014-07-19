using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents geographical country.</para>
  /// </summary>
  [Description("Represents geographical country")]
  public partial class Country : Entity, IComparable<Country>, INameable
  {
    private string isoCode;
    private string name;

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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Country"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Country"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}