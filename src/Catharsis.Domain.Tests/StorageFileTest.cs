using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StorageFile"/>.</para>
/// </summary>
public sealed class StorageFileTest : EntityTest<StorageFile>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new StorageFile { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.Storage"/> property.</para>
  /// </summary>
  [Fact]
  public void Storage_Property()
  {
    new StorageFile { Storage = Guid.Empty.ToString() }.Storage.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.ContentType"/> property.</para>
  /// </summary>
  [Fact]
  public void ContentType_Property()
  {
    new StorageFile { ContentType = Guid.Empty.ToString() }.ContentType.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.Size"/> property.</para>
  /// </summary>
  [Fact]
  public void Size_Property()
  {
    new StorageFile { Size = long.MaxValue }.Size.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.Path"/> property.</para>
  /// </summary>
  [Fact]
  public void Path_Property()
  {
    new StorageFile { Path = Guid.Empty.ToString() }.Path.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.FullPath"/> property.</para>
  /// </summary>
  [Fact]
  public void FullPath_Property()
  {
    new StorageFile().FullPath.Should().BeEmpty();
    new StorageFile { Path = string.Empty, Name = string.Empty }.FullPath.Should().BeEmpty();
    new StorageFile { Path = " ", Name = " " }.FullPath.Should().Be("/");
    new StorageFile { Path = "/" }.FullPath.Should().Be("/");
    new StorageFile { Path = "\\" }.FullPath.Should().Be("\\");
    new StorageFile { Path = "path", Name = "name" }.FullPath.Should().Be("path/name");
    new StorageFile { Path = "/path/", Name = "name/" }.FullPath.Should().Be("/path/name/");
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="StorageFile()"/>
  [Fact]
  public void Constructors()
  {
    var file = new StorageFile();

    file.Id.Should().BeNull();
    file.Uuid.Should().NotBeNull();
    file.Version.Should().BeNull();
    file.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    file.UpdatedOn.Should().BeNull();

    file.Name.Should().BeNull();
    file.Storage.Should().BeNull();
    file.ContentType.Should().BeNull();
    file.Size.Should().BeNull();
    file.Path.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.CompareTo(StorageFile)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(StorageFile.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="StorageFile.Equals(StorageFile)"/></description></item>
  ///     <item><description><see cref="StorageFile.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(StorageFile.Name), "first", "second");
    TestEquality(nameof(StorageFile.Path), "first", "second");
    TestEquality(nameof(StorageFile.Storage), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(StorageFile.Name), "first", "second");
    TestHashCode(nameof(StorageFile.Path), "first", "second");
    TestHashCode(nameof(StorageFile.Storage), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFile.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new StorageFile().ToString().Should().BeEmpty();
    new StorageFile { Path = string.Empty, Name = string.Empty }.ToString().Should().BeEmpty();
    new StorageFile { Path = " ", Name = " " }.ToString().Should().Be("/");
    new StorageFile { Path = "/" }.ToString().Should().Be("/");
    new StorageFile { Path = "\\" }.ToString().Should().Be("\\");
    new StorageFile { Path = "path", Name = "name" }.ToString().Should().Be("path/name");
    new StorageFile { Path = "/path/", Name = "name/" }.ToString().Should().Be("/path/name/");
  }
}