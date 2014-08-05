using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom category of content.</para>
  /// </summary>
  [Description("Represents user blog/journal")]
  public partial class Category : Entity, IComparable<ICategory>, ICategory
  {
    private string name;

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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Category"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Category"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}