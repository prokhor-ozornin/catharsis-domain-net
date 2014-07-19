using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents named hyperlink to external website.</para>
  /// </summary>
  [Description("Represents named hyperlink to external website")]
  public partial class WebLink : Item
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
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="WebLink"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="WebLink"/>.</returns>
    public override string ToString()
    {
      return this.Url;
    }
  }
}