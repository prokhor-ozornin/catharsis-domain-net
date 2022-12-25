 using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Setting"/>.</para>
/// </summary>
public sealed class SettingTest : EntityTest<Setting>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Setting { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property()
  {
    new Setting { Type = Setting.SettingType.String}.Type.Should().Be(Setting.SettingType.String);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.Description"/> property.</para>
  /// </summary>
  [Fact]
  public void Description_Property()
  {
    new Setting { Description = Guid.Empty.ToString() }.Description.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.Value"/> property.</para>
  /// </summary>
  [Fact]
  public void Value_Property()
  {
    new Setting { Value = Guid.Empty.ToString() }.Value.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.Values"/> property.</para>
  /// </summary>
  [Fact]
  public void Values_Property()
  {
    var values = new List<string>();
    new Setting { Values = values }.Values.Should().BeSameAs(values);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Setting()"/>
  [Fact]
  public void Constructors()
  {
    var setting = new Setting();

    setting.Id.Should().BeNull();
    setting.Uuid.Should().NotBeNull();
    setting.Version.Should().BeNull();
    setting.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    setting.UpdatedOn.Should().BeNull();

    setting.Name.Should().BeNull();
    setting.Type.Should().BeNull();
    setting.Description.Should().BeNull();
    setting.Value.Should().BeNull();
    setting.Values.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.CompareTo(Setting)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(Setting.Name), "fist", "second");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Setting.Equals(Setting)"/></description></item>
  ///     <item><description><see cref="Setting.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Setting.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Setting.Name), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Setting.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Setting().ToString().Should().Be("[]");
    new Setting { Value = string.Empty }.ToString().Should().BeEmpty();
    new Setting { Value = " " }.ToString().Should().Be(" ");
    new Setting { Value = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}