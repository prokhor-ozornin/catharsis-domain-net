using System;
using Xunit;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Setting"/>.</para>
  /// </summary>
  public sealed class SettingTests : EntityUnitTests<Setting>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Name", "Value");
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Setting()"/>
    /// <seealso cref="Setting(string, string)"/>
    [Fact]
    public void Constructors()
    {
      var setting = new Setting();
      Assert.Equal(0, setting.Id);
      Assert.Null(setting.Name);
      Assert.Null(setting.Value);
      Assert.Equal(0, setting.Version);

      Assert.Throws<ArgumentNullException>(() => new Setting(null, "value"));
      Assert.Throws<ArgumentException>(() => new Setting(string.Empty, "value"));
      
      setting = new Setting("name", "value");
      Assert.Equal(0, setting.Id);
      Assert.Equal("name", setting.Name);
      Assert.Equal("value", setting.Value);
      Assert.Equal(0, setting.Version);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Setting.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Throws<ArgumentNullException>(() => new Setting { Name = null });
      Assert.Throws<ArgumentException>(() => new Setting { Name = string.Empty });

      Assert.Equal("name", new Setting { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Setting.Value"/> property.</para>
    /// </summary>
    [Fact]
    public void Value_Property()
    {
      Assert.Equal("value", new Setting { Value = "value" }.Value);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Setting.CompareTo(Setting)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Name", "first", "second");
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
      this.TestEquality("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Setting.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Setting.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("value", new Setting { Value = "value" }.ToString());
    }
  }
}