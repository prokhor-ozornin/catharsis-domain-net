using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Download"/>.</para>
/// </summary>
public sealed class DownloadTest : EntityTest<Download>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Download.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Download { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property()
  {
    new Download { Description = Guid.Empty.ToString() }.Description.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.File"/> property.</para>
  /// </summary>
  [Fact]
  public void File_Property()
  {
    var file = new StorageFile();
    new Download { File = file }.File.Should().BeSameAs(file);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.Image"/> property.</para>
  /// </summary>
  [Fact]
  public void Image_Property()
  {
    var image = new Image();
    new Download { Image = image }.Image.Should().BeSameAs(image);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.Downloads"/> property.</para>
  /// </summary>
  [Fact]
  public void Downloads_Property()
  {
    new Download { Downloads = long.MaxValue }.Downloads.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Download()"/>
  [Fact]
  public void Constructors()
  {
    var download = new Download();

    download.Id.Should().BeNull();
    download.Uuid.Should().NotBeNull();
    download.Version.Should().BeNull();
    download.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    download.UpdatedOn.Should().BeNull();

    download.Name.Should().BeNull();
    download.Description.Should().BeNull();
    download.File.Should().BeNull();
    download.Image.Should().BeNull();
    download.Downloads.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.CompareTo(Download)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Download.Name), "first", "second");
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
    TestEquality(nameof(Download.File), new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Download.File), new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Download.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Download().ToString().Should().BeEmpty();
    new Download { Name = string.Empty }.ToString().Should().BeEmpty();
    new Download { Name = " " }.ToString().Should().BeEmpty();
    new Download { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}