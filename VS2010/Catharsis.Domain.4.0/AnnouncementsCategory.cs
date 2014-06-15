using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents category of announcements.</para>
  /// </summary>
  [Description("Represents category of announcements")]
  public partial class AnnouncementsCategory : Category
  {
    /// <summary>
    ///   <para>Parent category.</para>
    /// </summary>
    [Description("Parent category")]
    public virtual AnnouncementsCategory Parent { get; set; }

    /// <summary>
    ///   <para>Creates new category of announcements.</para>
    /// </summary>
    public AnnouncementsCategory()
    {
    }

    /// <summary>
    ///   <para>Creates new category of announcements.</para>
    /// </summary>
    /// <param name="name">Name of category.</param>
    /// <param name="parent">Parent category.</param>
    /// <param name="description">Description of category.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public AnnouncementsCategory(string name, AnnouncementsCategory parent = null, string description = null) : base(name, description)
    {
      this.Parent = parent;
    }
  }
}