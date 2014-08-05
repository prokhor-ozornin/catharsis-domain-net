using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents text record in user's blog/journal.</para>
  /// </summary>
  [Description("Represents user blog/journal")]
  public partial class BlogEntry : Item
  {
    private Blog blog;

    /// <summary>
    ///   <para>Blog of published entry.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    [Description("Blog of published entry")]
    public virtual Blog Blog
    {
      get { return this.blog; }
      set
      {
        Assertion.NotNull(value);

        this.blog = value;
      }
    }

    /// <summary>
    ///   <para>Creates new blog entry.</para>
    /// </summary>
    public BlogEntry()
    {
    }

    /// <summary>
    ///   <para>Creates new blog entry.</para>
    /// </summary>
    /// <param name="blog"></param>
    /// <param name="name">Name of entry.</param>
    /// <param name="text">Text of entry.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="text"/> or <paramref name="blog"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public BlogEntry(Blog blog, string name, string text) : base(name, text)
    {
      Assertion.NotEmpty(text);

      this.Blog = blog;
    }
  }
}