using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Category of playcasts.</para>
  /// </summary>
  public partial class PlaycastsCategory : Category
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    [Description("Parent category")]
    public virtual PlaycastsCategory Parent { get; set; }
    
    /// <summary>
    ///   <para>Creates new category of playcasts.</para>
    /// </summary>
    public PlaycastsCategory()
    {
    }

    /// <summary>
    ///   <para>Creates new category of playcasts.</para>
    /// </summary>
    /// <param name="name">Name of category.</param>
    /// <param name="parent">Parent category.</param>
    /// <param name="description">Description of category.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public PlaycastsCategory(string name, PlaycastsCategory parent = null, string description = null) : base(name, description)
    {
      this.Parent = parent;
    }
  }
}