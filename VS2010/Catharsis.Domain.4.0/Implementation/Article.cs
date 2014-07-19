using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a long informational text.</para>
  /// </summary>
  [Description("Represents a long informational text")]
  public partial class Article : Item
  {
    /// <summary>
    ///   <para>Short summary of article.</para>
    /// </summary>
    [Description("Short summary of article")]
    public virtual string Annotation { get; set; }
    
    /// <summary>
    ///   <para>Category of article.</para>
    /// </summary>
    [Description("Category of article")]
    public virtual ArticlesCategory Category { get; set; }
    
    /// <summary>
    ///   <para>URI of article's image.</para>
    /// </summary>
    [Description("URI of the article's image")]
    public virtual string Image { get; set; }

    /// <summary>
    ///   <para>Creates new article.</para>
    /// </summary>
    public Article()
    {
    }

    /// <summary>
    ///   <para>Creates new article.</para>
    /// </summary>
    /// <param name="name">Title of article.</param>
    /// <param name="category">Category of article.</param>
    /// <param name="annotation">Short summary of article</param>
    /// <param name="text">Article's contents.</param>
    /// <param name="image">URI of article's image.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public Article(string name, ArticlesCategory category = null, string annotation = null, string text = null, string image = null) : base(name, text)
    {
      this.Category = category;
      this.Annotation = annotation;
      this.Image = image;
    }
  }
}