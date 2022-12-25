using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MediaExtensions"/>.</para>
/// </summary>
public sealed class MediaExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.ContentType{T}(IQueryable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContentType_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Media>) null!).ContentType("locale")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().AsQueryable().ContentType(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().AsQueryable().ContentType(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Media {ContentType = "First"}, new Media {ContentType = "Second"}}.AsQueryable().ContentType("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.ContentType{T}(IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContentType_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Media>) null!).ContentType("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().ContentType(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().ContentType(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Media(), new Media {ContentType = "First"}, new Media {ContentType = "Second"}}.ContentType("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Duration{T}(IQueryable{T}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Duration_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Media>) null!).Duration()).ThrowExactly<ArgumentNullException>();

    var medias = new[] {new Media {Duration = 1}, new Media {Duration = 2}}.AsQueryable();
    medias.Duration().Should().HaveCount(2);
    medias.Duration(0).Should().HaveCount(2);
    medias.Duration(3).Should().BeEmpty();
    medias.Duration(0, 1).Should().ContainSingle();
    medias.Duration(1, 2).Should().HaveCount(2);
    medias.Duration(to: 0).Should().BeEmpty();
    medias.Duration(to: 1).Should().ContainSingle();
    medias.Duration(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Duration{T}(IEnumerable{T}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Duration_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Media>) null!).Duration()).ThrowExactly<ArgumentNullException>();

    var medias = new[] {null, new Media(), new Media {Duration = 1}, new Media {Duration = 2}};
    medias.Duration().Should().HaveCount(3);
    medias.Duration(0).Should().HaveCount(2);
    medias.Duration(3).Should().BeEmpty();
    medias.Duration(0, 1).Should().ContainSingle();
    medias.Duration(1, 2).Should().HaveCount(2);
    medias.Duration(to: 0).Should().BeEmpty();
    medias.Duration(to: 1).Should().ContainSingle();
    medias.Duration(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Height{T}(IQueryable{T}, short?, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Height_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Media>) null!).Height()).ThrowExactly<ArgumentNullException>();

    var medias = new[] {new Media {Height = 1}, new Media {Height = 2}}.AsQueryable();
    medias.Height().Should().HaveCount(2);
    medias.Height(0).Should().HaveCount(2);
    medias.Height(3).Should().BeEmpty();
    medias.Height(0, 1).Should().ContainSingle();
    medias.Height(1, 2).Should().HaveCount(2);
    medias.Height(to: 0).Should().BeEmpty();
    medias.Height(to: 1).Should().ContainSingle();
    medias.Height(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Height{T}(IEnumerable{T}, short?, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Height_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Media>) null!).Height()).ThrowExactly<ArgumentNullException>();

    var medias = new[] {null, new Media(), new Media {Height = 1}, new Media {Height = 2}};
    medias.Height().Should().HaveCount(3);
    medias.Height(0).Should().HaveCount(2);
    medias.Height(3).Should().BeEmpty();
    medias.Height(0, 1).Should().ContainSingle();
    medias.Height(1, 2).Should().HaveCount(2);
    medias.Height(to: 0).Should().BeEmpty();
    medias.Height(to: 1).Should().ContainSingle();
    medias.Height(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Name{T}(IQueryable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Media>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().AsQueryable().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Media {Name = "First"}, new Media {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Name{T}(IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Media>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Media>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Media(), new Media {Name = "First"}, new Media {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Width{T}(IQueryable{T}, short?, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Width_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Media>) null!).Width()).ThrowExactly<ArgumentNullException>();

    var medias = new[] {new Media {Width = 1}, new Media {Width = 2}}.AsQueryable();
    medias.Width().Should().HaveCount(2);
    medias.Width(0).Should().HaveCount(2);
    medias.Width(3).Should().BeEmpty();
    medias.Width(0, 1).Should().ContainSingle();
    medias.Width(1, 2).Should().HaveCount(2);
    medias.Width(to: 0).Should().BeEmpty();
    medias.Width(to: 1).Should().ContainSingle();
    medias.Width(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MediaExtensions.Width{T}(IEnumerable{T}, short?, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Width_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Media>) null!).Width()).ThrowExactly<ArgumentNullException>();

    var medias = new[] {null, new Media(), new Media {Width = 1}, new Media {Width = 2}};
    medias.Width().Should().HaveCount(3);
    medias.Width(0).Should().HaveCount(2);
    medias.Width(3).Should().BeEmpty();
    medias.Width(0, 1).Should().ContainSingle();
    medias.Width(1, 2).Should().HaveCount(2);
    medias.Width(to: 0).Should().BeEmpty();
    medias.Width(to: 1).Should().ContainSingle();
    medias.Width(to: 3).Should().HaveCount(2);
  }
}