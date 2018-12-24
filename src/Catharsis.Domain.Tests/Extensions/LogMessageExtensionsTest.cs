using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catharsis.Domain
{
  public sealed class LogMessageExtensionsTests
  {
    [Fact]
    public void level_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<LogMessage>)null).Level("level"));
      Assert.Throws<ArgumentNullException>(() => new LogMessage[] { }.AsQueryable().Level(null));
      Assert.Throws<ArgumentException>(() => new LogMessage[] { }.AsQueryable().Level(string.Empty));

      Assert.Equal(1, new[] { new LogMessage { Level = "First" }, new LogMessage { Level = "Second" } }.AsQueryable().Level("first").Count());
    }

    [Fact]
    public void level_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<LogMessage>)null).Level("level"));
      Assert.Throws<ArgumentNullException>(() => new LogMessage[] { }.Level(null));
      Assert.Throws<ArgumentException>(() => new LogMessage[] { }.Level(string.Empty));

      Assert.Single(new[] { null, new LogMessage(), new LogMessage { Level = "First" }, new LogMessage { Level = "Second" } }.Level("first"));
    }

    [Fact]
    public void logger_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<LogMessage>)null).Logger("logger"));
      Assert.Throws<ArgumentNullException>(() => new LogMessage[] { }.AsQueryable().Logger(null));
      Assert.Throws<ArgumentException>(() => new LogMessage[] { }.AsQueryable().Logger(string.Empty));

      Assert.Equal(1, new[] { new LogMessage { Logger = "First" }, new LogMessage { Logger = "Second" } }.AsQueryable().Logger("first").Count());
    }

    [Fact]
    public void logger_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<LogMessage>)null).Logger("logger"));
      Assert.Throws<ArgumentNullException>(() => new LogMessage[] { }.Logger(null));
      Assert.Throws<ArgumentException>(() => new LogMessage[] { }.Logger(string.Empty));

      Assert.Single(new[] { null, new LogMessage(), new LogMessage { Logger = "First" }, new LogMessage { Logger = "Second" } }.Logger("first"));
    }

    [Fact]
    public void thread_queryable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IQueryable<LogMessage>)null).Thread("thread"));
      Assert.Throws<ArgumentNullException>(() => new LogMessage[] { }.AsQueryable().Thread(null));
      Assert.Throws<ArgumentException>(() => new LogMessage[] { }.AsQueryable().Thread(string.Empty));

      Assert.Equal(1, new[] { new LogMessage { Thread = "First" }, new LogMessage { Thread = "Second" } }.AsQueryable().Thread("first").Count());
    }

    [Fact]
    public void thread_enumerable()
    {
      Assert.Throws<ArgumentNullException>(() => ((IEnumerable<LogMessage>)null).Thread("logger"));
      Assert.Throws<ArgumentNullException>(() => new LogMessage[] { }.Thread(null));
      Assert.Throws<ArgumentException>(() => new LogMessage[] { }.Thread(string.Empty));

      Assert.Single(new[] { null, new LogMessage(), new LogMessage { Thread = "First" }, new LogMessage { Thread = "Second" } }.Thread("first"));
    }
  }
}