using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents named hyperlink to external website.</para>
  /// </summary>
  [Description("Represents named hyperlink to external website")]
  public partial class WebLink : Item, IEquatable<WebLink>
  {
    private string url;

    /// <summary>
    ///   <para>Category of web link.</para>
    /// </summary>
    [Description("Category of web link")]
    public virtual WebLinksCategory Category { get; set; }
    
    /// <summary>
    ///   <para>URL address of hyperlink.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URL address of hyperlink")]
    public virtual string Url
    {
      get { return this.url; }
      set
      {
        Assertion.NotEmpty(value);

        this.url = value;
      }
    }

    /// <summary>
    ///   <para>Creates new web link.</para>
    /// </summary>
    public WebLink()
    {
    }

    /// <summary>
    ///   <para>Creates new web link.</para>
    /// </summary>
    /// <param name="name">Title of web link.</param>
    /// <param name="text">Description of web link.</param>
    /// <param name="url">URL address of web link.</param>
    /// <param name="category">Category of web link's belongings, or a <c>null</c> reference.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="text"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/>, <paramref name="text"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    public WebLink(string name, string text, string url, WebLinksCategory category = null) : base(name, text)
    {
      Assertion.NotEmpty(text);

      this.Url = url;
      this.Category = category;
    }

    /// <summary>
    ///   <para>Determines whether two weblinks instances are equal.</para>
    /// </summary>
    /// <param name="other">The weblink to compare with the current one.</param>
    /// <returns><c>true</c> if specified weblink is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(WebLink other)
    {
      return base.Equals(other) && this.Equality(other, weblink => weblink.Category, weblink => weblink.Url);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as WebLink);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(weblink => weblink.Category, weblink => weblink.Url);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current web link.</para>
    /// </summary>
    /// <returns>A string that represents the current web link.</returns>
    public override string ToString()
    {
      return this.Url;
    }
  }
}