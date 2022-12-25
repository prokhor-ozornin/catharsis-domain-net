using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PlaycastExtensions"/>.</para>
/// </summary>
public sealed class PlaycastExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="PlaycastExtensions.Name(IQueryable{Playcast}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Playcast>) null!).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Playcast>().AsQueryable().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Playcast>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Playcast {Name = "First"}, new Playcast {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PlaycastExtensions.Name(IEnumerable{Playcast}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Playcast>) null!).Name("name"));
    AssertionExtensions.Should(() => Array.Empty<Playcast>().Name(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Playcast>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Playcast(), new Playcast {Name = "First"}, new Playcast {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PlaycastExtensions.Tag(IQueryable{Playcast}, Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void Tag_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Playcast>) null!).Tag(new Tag())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Playcast>().AsQueryable().Tag(null!)).ThrowExactly<ArgumentNullException>();

    new[] {new Playcast {Tags = new HashSet<Tag> {new() {Name = "first"}}}, new Playcast {Tags = new HashSet<Tag> {new() {Name = "second"}}}}.AsQueryable().Tag(new Tag {Name = "first"}).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PlaycastExtensions.Tag(IEnumerable{Playcast}, Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void Tag_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Playcast>) null!).Tag(new Tag())).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Playcast>().Tag(null!)).ThrowExactly<ArgumentNullException>();

    new[] {null, new Playcast(), new Playcast {Tags = new HashSet<Tag> {new() {Name = "first"}}}, new Playcast {Tags = new HashSet<Tag> {new() {Name = "second"}}}}.Tag(new Tag {Name = "first"}).Should().ContainSingle();
  }
}