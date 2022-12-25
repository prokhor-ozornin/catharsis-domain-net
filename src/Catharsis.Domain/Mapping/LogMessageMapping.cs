namespace Catharsis.Domain;

/// <summary>
///   <para>NHibernate ORM relational mapping for <see cref="LogMessage"/> entity.</para>
/// </summary>
public sealed class LogMessageMapping : EntityMapping<LogMessage>
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  public LogMessageMapping()
  {
    Table("log_message");
    Map(message => message.Level).Column("level").Not.Nullable().Index("ix-log_message-level");
    Map(message => message.Logger).Column("logger").Not.Nullable().Index("ix-log_message-logger");
    Map(message => message.Thread).Column("thread").Not.Nullable().Index("ix-log_message-thread");
    Map(message => message.RequestId).Column("request_id").Index("ix-log_message-request_id");
    Map(message => message.Text).Column("text").Not.Nullable();
  }
}