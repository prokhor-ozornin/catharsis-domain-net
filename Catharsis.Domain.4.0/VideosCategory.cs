using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Category of videos.</para>
  /// </summary>
  public partial class VideosCategory : Category
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    [Description("Parent category")]
    public virtual VideosCategory Parent { get; set; }

    /// <summary>
    ///   <para>Creates new category of videos.</para>
    /// </summary>
    public VideosCategory()
    {
    }

    /// <summary>
    ///   <para>Creates new category of videos.</para>
    /// </summary>
    /// <param name="name">Name of category.</param>
    /// <param name="parent">Parent category.</param>
    /// <param name="description">Description of category.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public VideosCategory(string name, VideosCategory parent = null, string description = null) : base(name, description)
    {
      this.Parent = parent;
    }
  }
}