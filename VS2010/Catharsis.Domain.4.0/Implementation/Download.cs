using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents downloadable content with metainformation.</para>
  /// </summary>
  [Description("Represents downloadable content with metainformation")]
  public partial class Download : Item, IComparable<Download>, IEquatable<Download>
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

    /// <summary>
    ///   <para>Determines whether two <see cref="Download"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Download other)
    {
      return base.Equals(other) && this.Equality(other, download => download.Category);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Download);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(download => download.Category);
    }
  }
}