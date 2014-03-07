using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom category of content.</para>
  /// </summary>
  [Description("Represents user blog/journal")]
  public partial class Category : IComparable<Category>, IEquatable<Category>, IEntity, INameable
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
    ///   <para>Compares the current category with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Category"/> to compare with this instance.</param>
    public virtual int CompareTo(Category other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two categories instances are equal.</para>
    /// </summary>
    /// <param name="other">The category to compare with the current one.</param>
    /// <returns><c>true</c> if specified category is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Category other)
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
      return this.Equals(other as Category);
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
    ///   <para>Returns a <see cref="string"/> that represents the current category.</para>
    /// </summary>
    /// <returns>A string that represents the current category.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}