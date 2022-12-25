using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Tag"/>.</para>
/// </summary>
public sealed class TagTest : EntityTest<Tag>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Tag.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Tag { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Tag()"/>
  [Fact]
  public void Constructors()
  {
    var tag = new Tag();

    tag.Id.Should().BeNull();
    tag.Uuid.Should().NotBeNull();
    tag.Version.Should().BeNull();
    tag.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    tag.UpdatedOn.Should().BeNull();

    tag.Name.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Tag.CompareTo(Tag)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Tag.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Tag.Equals(Tag)"/></description></item>
  ///     <item><description><see cref="Tag.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Tag.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Tag.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Tag.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Tag.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Tag().ToString().Should().BeEmpty();
    new Tag { Name = string.Empty }.ToString().Should().BeEmpty();
    new Tag { Name = " " }.ToString().Should().BeEmpty();
    new Tag { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}