using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a literary text.</para>
  /// </summary>
  [Description("Represents a literary text")]
  public partial class Text : Item, IEquatable<Text>
  {
    private Person person;

    /// <summary>
    ///   <para>Category of text.</para>
    /// </summary>
    [Description("Category of text")]
    public virtual TextsCategory Category { get; set; }
    
    /// <summary>
    ///   <para>Author of text.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    [Description("Author of text")]
    public virtual Person Person
    {
      get { return this.person; }
      set
      {
        Assertion.NotNull(value);

        this.person = value;
      }
    }

    /// <summary>
    ///   <para>Collection of text's translations to other languages.</para>
    /// </summary>
    [Description("Collection of text's translations to other languages")]
    [XmlArray("Translations")]
    [XmlArrayItem("Translation")]
    public virtual List<TextTranslation> Translations { get; set; }

    /// <summary>
    ///   <para>Creates new text.</para>
    /// </summary>
    public Text()
    {
      this.Translations = new List<TextTranslation>();
    }

    /// <summary>
    ///   <para>Creates new text.</para>
    /// </summary>
    /// <param name="name">Title of text.</param>
    /// <param name="text">Text's content.</param>
    /// <param name="category">Category of text.</param>
    /// <param name="person">Author of text.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="text"/> or <paramref name="person"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public Text(string name, string text, Person person, TextsCategory category = null) : base(name, text)
    {
      Assertion.NotEmpty(text);

      this.Translations = new List<TextTranslation>();
      this.Category = category;
      this.Person = person;
    }

    /// <summary>
    ///   <para>Determines whether two texts instances are equal.</para>
    /// </summary>
    /// <param name="other">The text to compare with the current one.</param>
    /// <returns><c>true</c> if specified text is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Text other)
    {
      return base.Equals(other) && this.Equality(other, text => text.Category, text => text.Person);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Text);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(text => text.Category, text => text.Person);
    }
  }
}