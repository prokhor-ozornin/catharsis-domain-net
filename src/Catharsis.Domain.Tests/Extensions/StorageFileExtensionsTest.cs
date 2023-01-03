using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StorageFileExtensions"/>.</para>
/// </summary>
public sealed class StorageFileExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFileExtensions.ContentType(IQueryable{StorageFile}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContentType_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<StorageFile>) null).ContentType("locale")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().AsQueryable().ContentType(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().AsQueryable().ContentType(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new StorageFile {ContentType = "First"}, new StorageFile {ContentType = "Second"}}.AsQueryable().ContentType("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFileExtensions.ContentType(IEnumerable{StorageFile}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContentType_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<StorageFile>) null).ContentType("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().ContentType(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().ContentType(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new StorageFile(), new StorageFile {ContentType = "First"}, new StorageFile {ContentType = "Second"}}.ContentType("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFileExtensions.Storage(IQueryable{StorageFile}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Storage_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<StorageFile>) null).Storage("storage")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().AsQueryable().Storage(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().AsQueryable().Storage(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new StorageFile {Storage = "First"}, new StorageFile {Storage = "Second"}}.AsQueryable().Storage("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StorageFileExtensions.Storage(IEnumerable{StorageFile}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Storage_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<StorageFile>) null).Storage("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().Storage(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<StorageFile>().Storage(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new StorageFile(), new StorageFile {Storage = "First"}, new StorageFile {Storage = "Second"}}.Storage("first").Should().ContainSingle();
  }
}