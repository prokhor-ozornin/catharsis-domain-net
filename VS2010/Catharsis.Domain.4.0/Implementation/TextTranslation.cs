﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a translation of literary text to target language.</para>
  /// </summary>
  [Description("Represents a translation of literary text to target language")]
  public partial class TextTranslation : IComparable<TextTranslation>, IEquatable<TextTranslation>, IEntity, ILocalizable, INameable
  {
    private string language;
    private string name;
    private string text;

    /// <summary>
    ///   <para>Unique identifier of translation.</para>
    /// </summary>
    [Description("Unique identifier of translation")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current translation instance.</para>
    /// </summary>
    [Description("Version number of current translation instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Target language to which original text was translated.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Target language to which original text was translated")]
    public virtual string Language
    {
      get { return this.language; }
      set
      {
        Assertion.NotEmpty(value);

        this.language = value;
      }
    }

    /// <summary>
    ///   <para>Translated title of original text.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Translated title of original text")]
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
    ///   <para>Translated text.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Translated text")]
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
    ///   <para>Name of translator.</para>
    /// </summary>
    [Description("Name of translator")]
    public virtual string Translator { get; set; }

    /// <summary>
    ///   <para>Creates new translation.</para>
    /// </summary>
    public TextTranslation()
    {
    }

    /// <summary>
    ///   <para>Creates new translation.</para>
    /// </summary>
    /// <param name="language">ISO language code of translation's content.</param>
    /// <param name="name">Translated title of original text.</param>
    /// <param name="text">Translation's content text.</param>
    /// <param name="translator">Translated text.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="language"/>, <paramref name="name"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="language"/>, <paramref name="name"/> or <paramref name="text"/> is <see cref="string.Empty"/> string.</exception>
    public TextTranslation(string language, string name, string text, string translator = null)
    {
      this.Language = language;
      this.Name = name;
      this.Text = text;
      this.Translator = translator;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="TextTranslation"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="TextTranslation"/> to compare with this instance.</param>
    public virtual int CompareTo(TextTranslation other)
    {
      return this.Name.CompareTo(other.Name, StringComparison.InvariantCulture);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="TextTranslation"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(TextTranslation other)
    {
      return this.Equality(other, translation => translation.Language, translation => translation.Name, translation => translation.Translator);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as TextTranslation);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(translation => translation.Language, translation => translation.Name, translation => translation.Translator);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="TextTranslation"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="TextTranslation"/>.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}