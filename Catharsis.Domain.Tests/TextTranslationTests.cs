using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="TextTranslation"/>.</para>
  /// </summary>
  public sealed class TextTranslationTests : EntityUnitTests<TextTranslation>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Language", "Name", "Text", "Translator");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="TextTranslation()"/>
    ///   <seealso cref="TextTranslation(string, string, string, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var translation = new TextTranslation();
      Assert.Equal(0, translation.Id);
      Assert.Null(translation.Language);
      Assert.Null(translation.Name);
      Assert.Null(translation.Text);
      Assert.Null(translation.Translator);

      Assert.Throws<ArgumentNullException>(() => new TextTranslation(null, "name", "text"));
      Assert.Throws<ArgumentNullException>(() => new TextTranslation("language", null, "text"));
      Assert.Throws<ArgumentNullException>(() => new TextTranslation("language", "name", null));
      Assert.Throws<ArgumentException>(() => new TextTranslation(string.Empty, "name", "text"));
      Assert.Throws<ArgumentException>(() => new TextTranslation("language", string.Empty, "text"));
      Assert.Throws<ArgumentException>(() => new TextTranslation("language", "name", string.Empty));
      translation = new TextTranslation("language", "name", "text", "translator");
      Assert.Equal(0, translation.Id);
      Assert.Equal("language", translation.Language);
      Assert.Equal("name", translation.Name);
      Assert.Equal("text", translation.Text);
      Assert.Equal("translator", translation.Translator);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.Language"/> property.</para>
    /// </summary>
    [Fact]
    public void Language_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new TextTranslation { Language = null });
      Assert.Throws<ArgumentException>(() => new TextTranslation { Language = string.Empty });
      
      Assert.Equal("language", new TextTranslation { Language = "language" }.Language);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new TextTranslation { Name = null });
      Assert.Throws<ArgumentException>(() => new TextTranslation { Name = string.Empty });
      
      Assert.Equal("name", new TextTranslation { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.Text"/> property.</para>
    /// </summary>
    [Fact]
    public void Text_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new TextTranslation { Text = null });
      Assert.Throws<ArgumentException>(() => new TextTranslation { Text = string.Empty });
      
      Assert.Equal("text", new TextTranslation { Text = "text" }.Text);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.Translator"/> property.</para>
    /// </summary>
    [Fact]
    public void Translator_Property()
    {
      Assert.Equal("translator", new TextTranslation { Translator = "translator" }.Translator);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.CompareTo(TextTranslation)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Methods()
    {
      this.TestCompareTo<TextTranslation, string>("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="TextTranslation.Equals(TextTranslation)"/></description></item>
    ///     <item><description><see cref="TextTranslation.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Language", "first", "second");
      this.TestEquality("Name", "first", "second");
      this.TestEquality("Translator", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Language", "first", "second");
      this.TestHashCode("Name", "first", "second");
      this.TestHashCode("Translator", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="TextTranslation.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new TextTranslation { Name = "name" }.ToString());
    }
  }
}