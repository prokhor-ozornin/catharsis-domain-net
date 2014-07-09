using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom category of content.</para>
  /// </summary>
  [Description("Represents user blog/journal")]
  public partial class Category : IComparable<ICategory>, IEquatable<ICategory>, ICategory
  {
    private string name;

    /// <summary>
    ///   <para>Unique identifier of category.</para>
    /// </summary>
    [Description("Unique identifier of category")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current category instance.</para>
    /// </summary>
    [Description("Version number of current category instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Description of category.</para>
    /// </summary>
    [Description("Description of category")]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>ISO language code of category's text.</para>
    /// </summary>
    [Description("ISO language code of category's text")]
    public virtual string Language { get; set; }

    /// <summary>
    ///   <para>Name of category.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Name of category")]
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
    ///   <para>Creates new category.</para>
    /// </summary>
    public Category()
    {
    }

    /// <summary>
    ///   <para>Creates new category.</para>
    /// </summary>
    /// <param name="name">Name of category.</param>
    /// <param name="description">Description of category.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public Category(string name, string description = null)
    {
      this.Name = name;
      this.Description = description;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="ICategory"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ICategory"/> to compare with this instance.</param>
    public virtual int CompareTo(ICategory other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ICategory"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(ICategory other)
    {
      return this.Equality(other, category => category.Language, category => category.Name);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as ICategory);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(category => category.Language, category => category.Name);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Category"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Category"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}