using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Image"/>.</para>
/// </summary>
public sealed class ImageTest : EntityTest<Image>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Image.File"/> property.</para>
  /// </summary>
  [Fact]
  public void File_Property()
  {
    var file = new StorageFile();
    new Image { File = file }.File.Should().BeSameAs(file);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Image()"/>
  [Fact]
  public void Constructors()
  {
    var image = new Image();

    image.Id.Should().BeNull();
    image.Uuid.Should().NotBeNull();
    image.Version.Should().BeNull();
    image.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    image.UpdatedOn.Should().BeNull();

    image.File.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Image.CompareTo(Image)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Image.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Image.Equals(Image)"/></description></item>
  ///     <item><description><see cref="Image.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Image.File), new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
    TestEquality(nameof(Image.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Image.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Image.File), new StorageFile { Name = "first" }, new StorageFile { Name = "second" });
    TestHashCode(nameof(Image.Uri), "schema://first".ToUri(), "schema://second".ToUri());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Image.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Image().ToString().Should().BeEmpty();
    new Image { Uri = "schema://uri".ToUri() }.ToString().Should().Be("schema://uri/");
  }
}