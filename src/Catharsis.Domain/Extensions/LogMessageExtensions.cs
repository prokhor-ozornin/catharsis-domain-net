namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="LogMessage"/>.</para>
/// </summary>
/// <seealso cref="LogMessage"/>
public static class LogMessageExtensions
{
  public static IQueryable<LogMessage> Level(this IQueryable<LogMessage> messages, string level) => messages.Where(message => message.Level != null && message.Level.ToLower() == level.ToLower());

  public static IEnumerable<LogMessage> Level(this IEnumerable<LogMessage> messages, string level) => messages.Where(message => message?.Level != null && message.Level.ToLower() == level.ToLower());

  public static IQueryable<LogMessage> Logger(this IQueryable<LogMessage> messages, string logger) => messages.Where(message => message.Logger != null && message.Logger.ToLower().StartsWith(logger.ToLower()));

  public static IEnumerable<LogMessage> Logger(this IEnumerable<LogMessage> messages, string logger) => messages.Where(message => message?.Logger != null && message.Logger.ToLower().StartsWith(logger.ToLower()));

  public static IQueryable<LogMessage> Thread(this IQueryable<LogMessage> messages, string thread) => messages.Where(message => message.Thread != null && message.Thread.ToLower() == thread.ToLower());

  public static IEnumerable<LogMessage> Thread(this IEnumerable<LogMessage> messages, string thread) => messages.Where(message => message?.Thread != null && message.Thread.ToLower() == thread.ToLower());
}