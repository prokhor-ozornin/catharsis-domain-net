using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Video"/>.</para>
  /// </summary>
  public sealed class VideoTests : EntityUnitTests<Video>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Bitrate", "Category", "Duration", "File", "Height", "Version", "Width");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Video()"/>
    ///   <seealso cref="Video(string, short, long, short, short, VideosCategory)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var video = new Video();
      Assert.Equal(0, video.Bitrate);
      Assert.Null(video.Category);
      Assert.Equal(0, video.Duration);
      Assert.Equal(0, video.Id);
      Assert.Null(video.File);
      Assert.Equal(0, video.Height);
      Assert.Equal(0, video.Version);
      Assert.Equal(0, video.Width);

      Assert.Throws<ArgumentNullException>(() => new Video(null, 1, 2, 3, 4));
      video = new Video("file", 1, 2, 3, 4, new VideosCategory());
      Assert.Equal(1, video.Bitrate);
      Assert.NotNull(video.Category);
      Assert.Equal(2, video.Duration);
      Assert.Equal(0, video.Id);
      Assert.NotNull(video.File);
      Assert.Equal(3, video.Height);
      Assert.Equal(0, video.Version);
      Assert.Equal(4, video.Width);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.Bitrate"/> property.</para>
    /// </summary>
    [Fact]
    public void Bitrate_Property()
    {
      Assert.Equal(1, new Video { Bitrate = 1 }.Bitrate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new VideosCategory();
      Assert.True(ReferenceEquals(new Video { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.Duration"/> property.</para>
    /// </summary>
    [Fact]
    public void Duration_Property()
    {
      Assert.Equal(1, new Video { Duration = 1 }.Duration);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.File"/> property.</para>
    /// </summary>
    [Fact]
    public void File_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Video { File = null });
      Assert.Throws<ArgumentException>(() => new Video { File = string.Empty });

      Assert.Equal("file", new Video { File = "file" }.File);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.Height"/> property.</para>
    /// </summary>
    [Fact]
    public void Height_Property()
    {
      Assert.Equal(1, new Video { Height = 1 }.Height);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.Width"/> property.</para>
    /// </summary>
    [Fact]
    public void Width_Property()
    {
      Assert.Equal(1, new Video { Width = 1 }.Width);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.CompareTo(Video)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      Assert.True(new Video { File = "first" }.CompareTo(new Video { File = "second" }) < 0);
      Assert.Equal(0, new Video { File = "file" }.CompareTo(new Video { File = "file" }));
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Video.Equals(Video)"/></description></item>
    ///     <item><description><see cref="Video.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new VideosCategory { Name = "first" }, new VideosCategory { Name = "second" });
      this.TestEquality("File", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new VideosCategory { Name = "first" }, new VideosCategory { Name = "second" });
      this.TestHashCode("File", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Video.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("file", new Video { File = "file" }.ToString());
    }
  }
}