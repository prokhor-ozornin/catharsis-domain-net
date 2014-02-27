using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents category of audios.</para>
  /// </summary>
  public partial class AudiosCategory : Category
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    [Description("Parent category")]
    public virtual AudiosCategory Parent { get; set; }

    /// <summary>
    ///   <para>Creates new category of audios.</para>
    /// </summary>
    public AudiosCategory()
    {
    }

    /// <summary>
    ///   <para>Creates new category of audios.</para>
    /// </summary>
    /// <param name="name">Name of category.</param>
    /// <param name="parent">Parent category.</param>
    /// <param name="description">Description of category.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public AudiosCategory(string name, AudiosCategory parent = null, string description = null) : base(name, description)
    {
      this.Parent = parent;
    }
  }
}