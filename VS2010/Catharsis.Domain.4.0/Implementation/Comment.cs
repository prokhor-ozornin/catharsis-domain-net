using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom text comment.</para>
  /// </summary>
  [Description("Represents custom text comment")]
  public partial class Comment : Entity, IComparable<Comment>, INameable, ITimestampable
  {
    private string name;
    private string text;

    /// <summary>
    ///   <para>Date/time of comment publicaton.</para>
    /// </summary>
    [Description("Date/time of comment publicaton")]
    public virtual DateTime CreatedAt { get; set; }

    /// <summary>
    ///   <para>Date and time of comment's last modification.</para>
    /// </summary>
    [Description("Date and time of comment's last modification")]
    public virtual DateTime UpdatedAt { get; set; }

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
      this.CreatedAt = DateTime.UtcNow;
      this.UpdatedAt = DateTime.UtcNow;
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
    ///   <para>Compares the current <see cref="Comment"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Comment"/> to compare with this instance.</param>
    public virtual int CompareTo(Comment other)
    {
      return this.CreatedAt.CompareTo(other.CreatedAt);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Comment"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Comment"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}