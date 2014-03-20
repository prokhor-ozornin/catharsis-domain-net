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
  public partial class Item : IComparable<Item>, IEquatable<Item>, IEntity, ICommentable, ILocalizable, INameable, ITaggable, ITimestampable
  {
    private string name;

    /// <summary>
    ///   <para>Unique identifier of item.</para>
    /// </summary>
    [Description("Unique identifier of item")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current item instance.</para>
    /// </summary>
    [Description("Version number of current item instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Collection of associated comments.</para>
    /// </summary>
    [Description("Collection of associated comments")]
    public virtual ICollection<Comment> Comments { get; set; }

    /// <summary>
    ///   <para>List of associated comments.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    [Description("List of associated comments")]
    [XmlArray("Comments")]
    [JsonIgnore]
    public virtual Comment[] CommentsList
    {
      get { return this.Comments.ToArray(); }
      set
      {
        Assertion.NotNull(value);

        this.Comments.Clear();
        this.Comments.Add(value);
      }
    }

    /// <summary>
    ///   <para>Date/ time when item was first created.</para>
    /// </summary>
    [Description("Date/ time when item was first created")]
    public virtual DateTime DateCreated  { get; set; }
    
    /// <summary>
    ///   <para>ISO language code of item's content.</para>
    /// </summary>
    [Description("ISO language code of item's content")]
    public virtual string Language { get; set; }
    
    /// <summary>
    ///   <para>Date/time when item was modified.</para>
    /// </summary>
    [Description("Date/time when item was modified")]
    public virtual DateTime LastUpdated { get; set; }
    
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
    public virtual ICollection<string> Tags { get; set; }

    /// <summary>
    ///   <para>List of associated tags/keywords.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    [Description("List of associated tags/keywords")]
    [XmlArray("Tags")]
    [XmlArrayItem("Tag")]
    [JsonIgnore]
    public virtual string[] TagsList
    {
      get { return this.Tags.ToArray(); }
      set
      {
        Assertion.NotNull(value);

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
      this.Comments = new List<Comment>();
      this.DateCreated = DateTime.UtcNow;
      this.LastUpdated = DateTime.UtcNow;
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
    ///   <para>Compares the current item with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Item"/> to compare with this instance.</param>
    public virtual int CompareTo(Item other)
    {
      return this.DateCreated.CompareTo(other.DateCreated);
    }

    /// <summary>
    ///   <para>Determines whether two items instances are equal.</para>
    /// </summary>
    /// <param name="other">The item to compare with the current one.</param>
    /// <returns><c>true</c> if specified item is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Item other)
    {
      return this.Equality(other, item => item.Language, item => item.Name);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Item);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(item => item.Language, item => item.Name);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current item.</para>
    /// </summary>
    /// <returns>A string that represents the current item.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}