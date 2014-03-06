using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom text comment.</para>
  /// </summary>
  [Description("Represents custom text comment")]
  public partial class Comment : IComparable<Comment>, IEquatable<Comment>, IEntity, INameable, ITimestampable
  {
    private string name;
    private string text;

    /// <summary>
    ///   <para>Unique identifier of comment.</para>
    /// </summary>
    [Description("Unique identifier of comment")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current comment instance.</para>
    /// </summary>
    [Description("Version number of current comment instance")]
    [XmlIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Date/time of comment publicaton.</para>
    /// </summary>
    [Description("Date/time of comment publicaton")]
    public virtual DateTime DateCreated { get; set; }

    /// <summary>
    ///   <para>Date and time of comment's last modification.</para>
    /// </summary>
    [Description("Date and time of comment's last modification")]
    public virtual DateTime LastUpdated { get; set; }

    /// <summary>
    ///   <para>Title of comment.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Title of comment")]
    public virtual string Name
    {
      get { return this.name; }
      set
      {
        Assertion.NotEmpty(value);

        this.name = value;
      }
    }

    /// <summary>
    ///   <para>Text of comment.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Text of comment")]
    public virtual string Text
    {
      get { return this.text; }
      set
      {
        Assertion.NotEmpty(value);

        this.text = value;
      }
    }

    /// <summary>
    ///   <para>Creates new comment.</para>
    /// </summary>
    public Comment()
    {
      this.DateCreated = DateTime.UtcNow;
      this.LastUpdated = DateTime.UtcNow;
    }

    /// <summary>
    ///   <para>Creates new comment.</para>
    /// </summary>
    /// <param name="name">Title of comment.</param>
    /// <param name="text">Text of comment.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public Comment(string name, string text) : this()
    {
      this.Name = name;
      this.Text = text;
    }

    /// <summary>
    ///   <para>Compares the current comment with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Comment"/> to compare with this instance.</param>
    public virtual int CompareTo(Comment other)
    {
      return this.DateCreated.CompareTo(other.DateCreated);
    }

    /// <summary>
    ///   <para>Determines whether two comments instances are equal.</para>
    /// </summary>
    /// <param name="other">The comment to compare with the current one.</param>
    /// <returns><c>true</c> if specified comment is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Comment other)
    {
      return this.Equality(other, comment => comment.Name, comment => comment.Text);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Comment);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(comment => comment.Name, comment => comment.Text);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current comment.</para>
    /// </summary>
    /// <returns>A string that represents the current comment.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}