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
  ///   <para>Represents a literary text.</para>
  /// </summary>
  [Description("Represents a literary text")]
  public partial class Text : Item
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
    [JsonIgnore]
    [XmlIgnore]
    public virtual ICollection<TextTranslation> Translations { get; set; }

    /// <summary>
    ///   <para>Collection of text's translations to other languages.</para>
    /// </summary>
    [Description("Collection of text's translations to other languages")]
    [JsonProperty("Translations")]
    [XmlElement("Translation")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual TextTranslation[] TranslationsArray
    {
      get { return this.Translations.ToArray(); }
      set
      {
        this.Translations.Clear();
        this.Translations.Add(value);
      }
    }

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

      this.Category = category;
      this.Person = person;
      this.Translations = new List<TextTranslation>();
    }
  }
}