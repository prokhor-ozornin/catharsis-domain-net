using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class LogMessageExtensions
  {
    public static IQueryable<LogMessage> Level(this IQueryable<LogMessage> messages, string level)
    {
      Assertion.NotNull(messages);
      Assertion.NotEmpty(level);

      return messages.Where(it => it.Level.ToLower() == level.ToLower());
    }

    public static IEnumerable<LogMessage> Level(this IEnumerable<LogMessage> messages, string level)
    {
      Assertion.NotNull(messages);
      Assertion.NotEmpty(level);

      return messages.Where(it => it?.Level != null && it.Level.ToLower() == level.ToLower());
    }

    public static IQueryable<LogMessage> Logger(this IQueryable<LogMessage> messages, string logger)
    {
      Assertion.NotNull(messages);
      Assertion.NotEmpty(logger);

      return messages.Where(it => it.Logger.ToLower().StartsWith(logger.ToLower()));
    }

    public static IEnumerable<LogMessage> Logger(this IEnumerable<LogMessage> messages, string logger)
    {
      Assertion.NotNull(messages);
      Assertion.NotEmpty(logger);

      return messages.Where(it => it?.Logger != null && it.Logger.ToLower().StartsWith(logger.ToLower()));
    }

    public static IQueryable<LogMessage> Thread(this IQueryable<LogMessage> messages, string thread)
    {
      Assertion.NotNull(messages);
      Assertion.NotEmpty(thread);

      return messages.Where(it => it.Thread.ToLower() == thread.ToLower());
    }

    public static IEnumerable<LogMessage> Thread(this IEnumerable<LogMessage> messages, string thread)
    {
      Assertion.NotNull(messages);
      Assertion.NotEmpty(thread);

      return messages.Where(it => it?.Thread != null && it.Thread.ToLower() == thread.ToLower());
    }
  }
}