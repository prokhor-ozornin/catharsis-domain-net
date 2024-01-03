using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NewsExtensions"/>.</para>
/// </summary>
public sealed class NewsExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NewsExtensions.Name(IQueryable{News}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<News>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<News>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<News>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentNullException>();

    new[] {new News {Name = "First"}, new News {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NewsExtensions.Name(IEnumerable{News}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<News>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<News>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<News>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new News(), new News {Name = "First"}, new News {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NewsExtensions.Tag(IQueryable{News}, Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void Tag_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<News>) null).Tag(new Tag())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<News>().AsQueryable().Tag(null)).ThrowExactly<ArgumentNullException>();

    new[] {new News {Tags = new HashSet<Tag> {new() {Name = "first"}}}, new News {Tags = new HashSet<Tag> {new() {Name = "second"}}}}.AsQueryable().Tag(new Tag {Name = "first"}).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NewsExtensions.Tag(IEnumerable{News}, Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void Tag_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<News>) null).Tag(new Tag())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<News>().Tag(null)).ThrowExactly<ArgumentNullException>();

    new[] {null, new News(), new News {Tags = new HashSet<Tag> {new() {Name = "first"}}}, new News {Tags = new HashSet<Tag> {new() {Name = "second"}}}}.Tag(new Tag {Name = "first"}).Should().ContainSingle();
  }
}