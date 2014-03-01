using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a long informational text.</para>
  /// </summary>
  [Description("Represents a long informational text")]
  public partial class Article : Item, IEquatable<Article>
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

    /// <summary>
    ///   <para>Determines whether two articles instances are equal.</para>
    /// </summary>
    /// <param name="other">The article to compare with the current one.</param>
    /// <returns><c>true</c> if specified article is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Article other)
    {
      return base.Equals(other) && this.Equality(other, article => article.Category);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Article);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(article => article.Category);
    }
  }
}