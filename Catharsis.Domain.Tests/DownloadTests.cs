using System;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Download"/>.</para>
  /// </summary>
  public sealed class DownloadTests : EntityUnitTests<Download>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Category", "Comments", "DateCreated", "Downloads", "Language", "LastUpdated", "Name", "Tags", "Text", "Url");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    ///   <seealso cref="Download()"/>
    ///   <seealso cref="Download(string, string, DownloadsCategory, string)"/>
    /// </summary>
    [Fact]
    public void Constructors()
    {
      var download = new Download();
      Assert.Null(download.Category);
      Assert.False(download.Comments.Any());
      Assert.True(download.DateCreated >= DateTime.MinValue && download.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, download.Downloads);
      Assert.Equal(0, download.Id);
      Assert.Null(download.Language);
      Assert.True(download.LastUpdated >= DateTime.MinValue && download.LastUpdated <= DateTime.UtcNow);
      Assert.Null(download.Name);
      Assert.False(download.Tags.Any());
      Assert.Null(download.Text);
      Assert.Null(download.Url);
      Assert.Equal(0, download.Version);

      Assert.Throws<ArgumentNullException>(() => new Download(null, "url"));
      Assert.Throws<ArgumentNullException>(() => new Download("name", null));
      Assert.Throws<ArgumentException>(() => new Download(string.Empty, "url"));
      Assert.Throws<ArgumentException>(() => new Download("name", string.Empty));
      download = new Download("name", "url", new DownloadsCategory(), "text");
      Assert.NotNull(download.Category);
      Assert.False(download.Comments.Any());
      Assert.True(download.DateCreated >= DateTime.MinValue && download.DateCreated <= DateTime.UtcNow);
      Assert.Equal(0, download.Downloads);
      Assert.Equal(0, download.Id);
      Assert.Null(download.Language);
      Assert.True(download.LastUpdated >= DateTime.MinValue && download.LastUpdated <= DateTime.UtcNow);
      Assert.Equal("name", download.Name);
      Assert.False(download.Tags.Any());
      Assert.Equal("text", download.Text);
      Assert.Equal("url", download.Url);
      Assert.Equal(0, download.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Category"/> property.</para>
    /// </summary>
    [Fact]
    public void Category_Property()
    {
      var category = new DownloadsCategory();
      Assert.True(ReferenceEquals(new Download { Category = category }.Category, category));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Downloads"/> property.</para>
    /// </summary>
    [Fact]
    public void Downloads_Property()
    {
      Assert.Equal(1, new Download { Downloads = 1 }.Downloads);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.Url"/> property.</para>
    /// </summary>
    [Fact]
    public void Url_Property()
    {
      Assert.Equal("url", new Download { Url = "url" }.Url);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.CompareTo(Download)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      Assert.True(new Download { Name = "first" }.CompareTo(new Download { Name = "second" }) < 0);
      Assert.Equal(0, new Download { Name = "name" }.CompareTo(new Download { Name = "name" }));
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Download.Equals(Download)"/></description></item>
    ///     <item><description><see cref="Download.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Category", new DownloadsCategory { Name = "first" }, new DownloadsCategory { Name = "second" });
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Download.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Category", new DownloadsCategory { Name = "first" }, new DownloadsCategory { Name = "second" });
    }
  }
}