using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Script"/>.</para>
/// </summary>
public sealed class ScriptTest : EntityTest<Script>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Script.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Script { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Script.Executed"/> property.</para>
  /// </summary>
  [Fact]
  public void Executed_Property()
  {
    new Script { Executed = true }.Executed.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Script.Duration"/> property.</para>
  /// </summary>
  [Fact]
  public void Duration_Property()
  {
    new Script { Duration = long.MaxValue }.Duration.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Script.Path"/> property.</para>
  /// </summary>
  [Fact]
  public void Path_Property()
  {
    new Script { Path = Guid.Empty.ToString() }.Path.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Script.Code"/> property.</para>
  /// </summary>
  [Fact]
  public void Code_Property()
  {
    new Script { Code = Guid.Empty.ToString() }.Code.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Script()"/>
  [Fact]
  public void Constructors()
  {
    var script = new Script();

    script.Id.Should().BeNull();
    script.Uuid.Should().NotBeNull();
    script.Version.Should().BeNull();
    script.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    script.UpdatedOn.Should().BeNull();

    script.Name.Should().BeNull();
    script.Executed.Should().BeNull();
    script.Duration.Should().BeNull();
    script.Path.Should().BeNull();
    script.Code.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Script.CompareTo(Script)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Script.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Script.Equals(Script)"/></description></item>
  ///     <item><description><see cref="Script.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Script.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Script.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Script.Name), "first", "second");
  }


  /// <summary>
  ///   <para>Performs testing of <see cref="Script.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Script().ToString().Should().BeEmpty();
    new Script { Name = string.Empty }.ToString().Should().BeEmpty();
    new Script { Name = " " }.ToString().Should().BeEmpty();
    new Script { Name = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}