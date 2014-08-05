using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a named setting/option.</para>
  /// </summary>
  [Description("Represents a named setting/option")]
  public partial class Setting : Entity, IComparable<Setting>, INameable
  {
    private string name;

    /// <summary>
    ///   <para>Name of setting.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Name of setting")]
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
    ///   <para>Value of setting.</para>
    /// </summary>
    [Description("Value of setting")]
    public virtual string Value { get; set; }

    /// <summary>
    ///   <para>Creates new setting.</para>
    /// </summary>
    public Setting()
    {
    }

    /// <summary>
    ///   <para></para>
    /// </summary>
    /// <param name="name">Name of setting.</param>
    /// <param name="value">Value of setting.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public Setting(string name, string value)
    {
      this.Name = name;
      this.Value = value;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Setting"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Setting"/> to compare with this instance.</param>
    public virtual int CompareTo(Setting other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Setting"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Setting"/>.</returns>
    public override string ToString()
    {
      return this.Value;
    }
  }
}