using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents base content element.</para>
  /// </summary>
  [Description("Represents base content element")]
  public partial class Item : Entity, IComparable<Item>, ILocalizable, INameable, ITaggable, ITimestampable
  {
    private string name;

    /// <summary>
    ///   <para>Collection of associated comments.</para>
    /// </summary>
    [Description("Collection of associated comments")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual ICollection<Comment> Comments  { get; set; }

    /// <summary>
    ///   <para>Collection of associated comments.</para>
    /// </summary>
    [Description("Collection of associated comments")]
    [JsonProperty("Comments")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Comment[] CommentsArray
    {
      get { return this.Comments.ToArray(); }
      set
      {
        this.Comments.Clear();
        this.Comments.Add(value);
      }
    }

    /// <summary>
    ///   <para>Date/ time when item was first created.</para>
    /// </summary>
    [Description("Date/ time when item was first created")]
    public virtual DateTime CreatedAt  { get; set; }
    
    /// <summary>
    ///   <para>ISO language code of item's content.</para>
    /// </summary>
    [Description("ISO language code of item's content")]
    public virtual string Language { get; set; }
    
    /// <summary>
    ///   <para>Date/time when item was modified.</para>
    /// </summary>
    [Description("Date/time when item was modified")]
    public virtual DateTime UpdatedAt { get; set; }
    
    /// <summary>
    ///   <para>Name of item.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Name of item")]
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
    ///   <para>Collection of associated tags/keywords.</para>
    /// </summary>
    [Description("Collection of associated tags/keywords")]
    [JsonIgnore]
    [XmlIgnore]
    public virtual ICollection<string> Tags { get; set; }

    /// <summary>
    ///   <para>Collection of associated tags/keywords.</para>
    /// </summary>
    [Description("Collection of associated tags/keywords")]
    [JsonProperty("Tags")]
    [XmlElement("Tag")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual string[] TagsArray
    {
      get { return this.Tags.ToArray(); }
      set
      {
        this.Tags.Clear();
        this.Tags.Add(value);
      }
    }

    /// <summary>
    ///   <para>Text content of item.</para>
    /// </summary>
    [Description("Text content of item")]
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>Creates new item.</para>
    /// </summary>
    public Item()
    {
      var now = DateTime.UtcNow;
      this.CreatedAt = now;
      this.UpdatedAt = now;

      this.Comments = new List<Comment>();
      this.Tags = new List<string>();
    }

    /// <summary>
    ///   <para>Creates new item.</para>
    /// </summary>
    /// <param name="name">Name of item.</param>
    /// <param name="text">Text content of item.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="name"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="name"/> is <see cref="string.Empty"/> string.</exception>
    public Item(string name, string text = null) : this()
    {
      this.Name = name;
      this.Text = text;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Item"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Item"/> to compare with this instance.</param>
    public virtual int CompareTo(Item other)
    {
      return this.CreatedAt.CompareTo(other.CreatedAt);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Item"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Item"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}