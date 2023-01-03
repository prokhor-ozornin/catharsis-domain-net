using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SettingExtensions"/>.</para>
/// </summary>
public sealed class SettingExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SettingExtensions.ForName(IQueryable{Setting}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ForName_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Setting>) null).ForName("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().AsQueryable().ForName(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().AsQueryable().ForName(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Setting {Name = "Name"}, new Setting {Name = "name"}}.AsQueryable().ForName("name")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Setting>().ForName("name").Should().BeNull();
    new[] {new Setting {Name = "First"}, new Setting {Name = "Second"}}.AsQueryable().ForName("first").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SettingExtensions.ForName(IEnumerable{Setting}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ForName_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Setting>) null).ForName("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().ForName(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().ForName(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Setting {Name = "Name"}, new Setting {Name = "name"}}.ForName("name")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Setting>().ForName("name").Should().BeNull();
    new[] {new Setting {Name = "First", Value = "value"}, new Setting {Name = "Second"}}.ForName("first").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SettingExtensions.Name(IQueryable{Setting}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Setting>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().AsQueryable().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().AsQueryable().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new Setting {Name = "First"}, new Setting {Name = "Second"}}.AsQueryable().Name("f").Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SettingExtensions.Name(IEnumerable{Setting}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Setting>) null).Name("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().Name(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().Name(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new Setting(), new Setting {Name = "First"}, new Setting {Name = "Second"}}.Name("f").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SettingExtensions.ValueOf(IQueryable{Setting}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<Setting>) null).ValueOf("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().AsQueryable().ValueOf(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().AsQueryable().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Setting {Name = "Name"}, new Setting {Name = "name"}}.AsQueryable().ValueOf("name")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Setting>().AsQueryable().ValueOf("name").Should().BeNull();
    new[] {new Setting {Name = "First", Value = "value"}, new Setting {Name = "Second"}}.AsQueryable().ValueOf("first").Should().NotBeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SettingExtensions.ValueOf(IEnumerable{Setting}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ValueOf_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<Setting>) null).ValueOf("name")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().ValueOf(null)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<Setting>().ValueOf(string.Empty)).ThrowExactly<ArgumentException>();
    AssertionExtensions.Should(() => new[] {new Setting {Name = "Name"}, new Setting {Name = "name"}}.ValueOf("name")).ThrowExactly<InvalidOperationException>();

    Array.Empty<Setting>().ValueOf("name").Should().BeNull();
    new[] {new Setting {Name = "First", Value = "value"}, new Setting {Name = "Second"}}.ValueOf("first").Should().NotBeNull();
  }
}