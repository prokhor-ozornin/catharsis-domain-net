using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents user blog/journal.</para>
  /// </summary>
  [Description("Represents user blog/journal")]
  public partial class Blog : Item
  {
    /// <summary>
    ///   <para>Creates new blog.</para>
    /// </summary>
    public Blog()
    {
    }

    /// <summary>
    ///   <para>Creates new blog.</para>
    /// </summary>
    /// <param name="name">Title of blog.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public Blog(string name) : base(name)
    {
    }
  }
}