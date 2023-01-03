using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ScriptExtensions"/>.</para>
/// </summary>
public sealed class ScriptExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ScriptExtensions.Duration(IQueryable{Script}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Duration_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Script>) null).Duration()).ThrowExactly<ArgumentNullException>();

    var scripts = new[] {new Script {Duration = 1}, new Script {Duration = 2}}.AsQueryable();
    scripts.Duration().Should().HaveCount(2);
    scripts.Duration(0).Should().HaveCount(2);
    scripts.Duration(3).Should().BeEmpty();
    scripts.Duration(0, 1).Should().ContainSingle();
    scripts.Duration(1, 2).Should().HaveCount(2);
    scripts.Duration(to: 0).Should().BeEmpty();
    scripts.Duration(to: 1).Should().ContainSingle();
    scripts.Duration(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ScriptExtensions.Duration(IEnumerable{Script}, long?, long?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Duration_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Script>) null).Duration()).ThrowExactly<ArgumentNullException>();

    var downloads = new[] {null, new Script(), new Script {Duration = 1}, new Script {Duration = 2}};
    downloads.Duration().Should().HaveCount(3);
    downloads.Duration(0).Should().HaveCount(2);
    downloads.Duration(3).Should().BeEmpty();
    downloads.Duration(0, 1).Should().ContainSingle();
    downloads.Duration(1, 2).Should().HaveCount(2);
    downloads.Duration(to: 0).Should().BeEmpty();
    downloads.Duration(to: 1).Should().ContainSingle();
    downloads.Duration(to: 3).Should().HaveCount(2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ScriptExtensions.Executed(IQueryable{Script}, bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Executed_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Script>) null).Executed(true)).ThrowExactly<ArgumentNullException>();

    new[] {new Script {Executed = false}, new Script {Executed = true}}.AsQueryable().Executed(true).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ScriptExtensions.Executed(IEnumerable{Script}, bool?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Executed_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Script>) null).Executed(true)).ThrowExactly<ArgumentNullException>();

    new[] {null, new Script(), new Script {Executed = false}, new Script {Executed = true}}.Executed(true).Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ScriptExtensions.Name(IQueryable{Script}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Script>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Script>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Script>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Script {Name = "First"}, new Script {Name = "Second"}}.AsQueryable().Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ScriptExtensions.Name(IEnumerable{Script}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Script>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Script>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Script>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Script(), new Script {Name = "First"}, new Script {Name = "Second"}}.Name("f").Should().ContainSingle();
  }
}