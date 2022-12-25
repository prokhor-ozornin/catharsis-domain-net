using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LogMessage"/>.</para>
/// </summary>
public sealed class LogMessageTest : EntityTest<LogMessage>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.Level"/> property.</para>
  /// </summary>
  [Fact]
  public void Level_Property()
  {
    new LogMessage { Level = Guid.Empty.ToString() }.Level.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.Logger"/> property.</para>
  /// </summary>
  [Fact]
  public void Logger_Property()
  {
    new LogMessage { Logger = Guid.Empty.ToString() }.Logger.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.Thread"/> property.</para>
  /// </summary>
  [Fact]
  public void Thread_Property()
  {
    new LogMessage { Thread = Guid.Empty.ToString() }.Thread.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.RequestId"/> property.</para>
  /// </summary>
  [Fact]
  public void RequestId_Property()
  {
    new LogMessage { RequestId = Guid.Empty.ToString() }.RequestId.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.Text"/> property.</para>
  /// </summary>
  [Fact]
  public void Text_Property()
  {
    new LogMessage { Text = Guid.Empty.ToString() }.Text.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LogMessage()"/>
  [Fact]
  public void Constructors()
  {
    var message = new LogMessage();

    message.Id.Should().BeNull();
    message.Uuid.Should().NotBeNull();
    message.Version.Should().BeNull();
    message.CreatedOn.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
    message.UpdatedOn.Should().BeNull();

    message.Level.Should().BeNull();
    message.Logger.Should().BeNull();
    message.Thread.Should().BeNull();
    message.RequestId.Should().BeNull();
    message.Text.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.CompareTo(LogMessage)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo(nameof(LogMessage.CreatedOn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="LogMessage.Equals(LogMessage)"/></description></item>
  ///     <item><description><see cref="LogMessage.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(LogMessage.RequestId), "first", "second");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(LogMessage.RequestId), "first", "second");
  }
  
  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessage.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new LogMessage().ToString().Should().BeEmpty();
    new LogMessage { Text = string.Empty }.ToString().Should().BeEmpty();
    new LogMessage { Text = " " }.ToString().Should().BeEmpty();
    new LogMessage { Text = Guid.Empty.ToString() }.ToString().Should().Be(Guid.Empty.ToString());
  }
}