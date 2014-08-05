using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents downloadable content with metainformation.</para>
  /// </summary>
  [Description("Represents downloadable content with metainformation")]
  public partial class Download : Item, IComparable<Download>
  {
    private string url;

    /// <summary>
    ///   <para>Category of download.</para>
    /// </summary>
    [Description("Category of download")]
    public virtual DownloadsCategory Category { get; set; }

    /// <summary>
    ///   <para>Number of downloads.</para>
    /// </summary>
    [Description("Number of downloads")]
    public virtual long Downloads { get; set; }

    /// <summary>
    ///   <para>URL address of download.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URL address of download")]
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
    ///   <para>Creates new dowload.</para>
    /// </summary>
    public Download()
    {
    }

    /// <summary>
    ///   <para>Creates new download.</para>
    /// </summary>
    /// <param name="name">Name of download.</param>
    /// <param name="category">Category of download.</param>
    /// <param name="url">URL address of download.</param>
    /// <param name="text">Description of download.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="category"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="url"/> is <see cref="string.Empty"/> string.</exception>
    public Download(string name, string url, DownloadsCategory category = null, string text = null) : base(name, text)
    {
      this.Category = category;
      this.Url = url;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Download"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Download"/> to compare with this instance.</param>
    public virtual int CompareTo(Download other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }
  }
}