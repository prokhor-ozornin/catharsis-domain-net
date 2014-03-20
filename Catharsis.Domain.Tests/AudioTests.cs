using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Audio"/>.</para>
  /// </summary>
  public sealed class AudioTests : EntityUnitTests<Audio>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Bitrate", "Category", "Duration", "File");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      var audio = new Audio();
      Assert.Equal(@"{""Id"":0,""Bitrate"":0,""Duration"":0}", audio.Json());

      audio = new Audio("file", 1, 2);
      Assert.Equal(@"{""Id"":0,""Bitrate"":1,""Duration"":2,""File"":""file""}", audio.Json());
      Assert.Equal(audio, audio.Json().Json<Audio>());

      audio = new Audio("file", 1, 2, new AudiosCategory("category.name")) { Id = 1 };
      Assert.Equal(@"{""Id"":1,""Bitrate"":1,""Category"":{""Id"":0,""Name"":""category.name""},""Duration"":2,""File"":""file""}", audio.Json());
      Assert.Equal(audio, audio.Json().Json<Audio>());
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Audio()"/>
    /// <seealso cref="Audio(string, short, short, AudiosCategory)"/>
    [Fact]
    public void Constructors()
    {
      var audio = new Audio();
      Assert.Equal(0, audio.Bitrate);
      Assert.Null(audio.Category);
      Assert.Equal(0, audio.Duration);
      Assert.Equal(0, audio.Id);
      Assert.Null(audio.File);
      Assert.Equal(0, audio.Version);

      Assert.Throws<ArgumentNullException>(() => new Audio(null, 1, 2));
      audio = new Audio("file", 1, 2, new AudiosCategory());
      Assert.Equal(1, audio.Bitrate);
      Assert.NotNull(audio.Category);
      Assert.Equal(2, audio.Duration);
      Assert.Equal(0, audio.Id);
      Assert.Equal("file", audio.File);
      Assert.Equal(0, audio.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.Bitrate"/> property.</para>
    /// </summary>
    [Fact]
    public void Bitrate_Property()
    {
      Assert.Equal(1, new Audio { Bitrate = 1 }.Bitrate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new AudiosCategory();
      Assert.True(ReferenceEquals(new Audio { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.Duration"/> property.</para>
    /// </summary>
    [Fact]
    public void Duration_Property()
    {
      Assert.Equal(1, new Audio { Duration = 1 }.Duration);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.File"/> property.</para>
    /// </summary>
    [Fact]
    public void File_Property()
    {
      Assert.Equal("file", new Audio { File = "file" }.File);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.CompareTo(Audio)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("File", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Audio.Equals(Audio)"/></description></item>
    ///     <item><description><see cref="Audio.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new AudiosCategory { Name = "first" }, new AudiosCategory { Name = "second" });
      this.TestEquality("File", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new AudiosCategory { Name = "first" }, new AudiosCategory { Name = "second" });
      this.TestHashCode("File", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Audio.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("file", new Audio { File = "file" }.ToString());
    }
  }
}