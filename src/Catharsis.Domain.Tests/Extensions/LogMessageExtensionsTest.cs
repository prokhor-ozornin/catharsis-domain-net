using FluentAssertions;
using Xunit;

namespace Catharsis.Domain.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LogMessageExtensions"/>.</para>
/// </summary>
public sealed class LogMessageExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessageExtensions.Level(IQueryable{LogMessage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Level_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<LogMessage>) null!).Level("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().AsQueryable().Level(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().AsQueryable().Level(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new LogMessage {Level = "First"}, new LogMessage {Level = "Second"}}.AsQueryable().Level("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessageExtensions.Level(IEnumerable{LogMessage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Level_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<LogMessage>) null!).Level("level")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().Level(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().Level(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new LogMessage(), new LogMessage {Level = "First"}, new LogMessage {Level = "Second"}}.Level("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessageExtensions.Logger(IQueryable{LogMessage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Logger_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<LogMessage>) null!).Logger("logger")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().AsQueryable().Logger(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().AsQueryable().Logger(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new LogMessage {Logger = "First"}, new LogMessage {Logger = "Second"}}.AsQueryable().Logger("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessageExtensions.Logger(IEnumerable{LogMessage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Logger_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<LogMessage>) null!).Logger("logger")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().Logger(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().Logger(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new LogMessage(), new LogMessage {Logger = "First"}, new LogMessage {Logger = "Second"}}.Logger("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessageExtensions.Thread(IQueryable{LogMessage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Thread_Queryable_Method()
  {
    AssertionExtensions.Should(() => ((IQueryable<LogMessage>) null!).Thread("thread")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().AsQueryable().Thread(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().AsQueryable().Thread(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {new LogMessage {Thread = "First"}, new LogMessage {Thread = "Second"}}.AsQueryable().Thread("first").Should().ContainSingle();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LogMessageExtensions.Thread(IEnumerable{LogMessage}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Thread_Enumerable_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<LogMessage>) null!).Thread("logger")).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().Thread(null!)).ThrowExactly<ArgumentNullException>();
    AssertionExtensions.Should(() => Array.Empty<LogMessage>().Thread(string.Empty)).ThrowExactly<ArgumentException>();

    new[] {null, new LogMessage(), new LogMessage {Thread = "First"}, new LogMessage {Thread = "Second"}}.Thread("first").Should().ContainSingle();
  }
}