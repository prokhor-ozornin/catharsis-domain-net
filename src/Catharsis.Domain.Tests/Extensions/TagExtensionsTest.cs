using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TagExtensions"/>.</para>
/// </summary>
public sealed class TagExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TagExtensions.ForName(IQueryable{Tag}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ForName_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Tag>) null).ForName("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Tag>().AsQueryable().ForName(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Tag>().AsQueryable().ForName(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Tag {Name = "Name"}, new Tag {Name = "name"}}.AsQueryable().ForName("name")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Tag>().AsQueryable().ForName("name").Should().BeNull();
    new[] {new Tag {Name = "First"}, new Tag {Name = "Second"}}.AsQueryable().ForName("first").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TagExtensions.ForName(IEnumerable{Tag}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ForName_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Tag>) null).ForName("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Tag>().ForName(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Tag>().ForName(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Tag {Name = "Name"}, new Tag {Name = "name"}}.ForName("name")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Tag>().ForName("name").Should().BeNull();
    new[] {new Tag {Name = "First"}, new Tag {Name = "Second"}}.ForName("first").Should().NotBeNull();
  }
}