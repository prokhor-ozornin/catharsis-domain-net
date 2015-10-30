using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Запись лога</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Запись лога")]
#endif
  public partial class LogMessage : Entity, IComparable<LogMessage>, IEquatable<LogMessage>
  {
    /// <summary>
    ///   <para>Уровень логгирования записей</para>
    /// </summary>
#if NET_35
    [Description("Уровень логгирования записей")]
#endif
    public virtual string Level { get; set; }

    /// <summary>
    ///   <para>Название класса логгера</para>
    /// </summary>
#if NET_35
    [Description("Название класса логгера")]
#endif
    public virtual string Logger { get; set; }

    /// <summary>
    ///   <para>Идентификатор API запроса</para>
    /// </summary>
#if NET_35
    [Description("Идентификатор API запроса")]
#endif
    public virtual string RequestId { get; set; }

    /// <summary>
    ///   <para>Текст записи</para>
    /// </summary>
#if NET_35
    [Description("Текст записи")]
#endif
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>Имя потока, осуществлявшего логгирование</para>
    /// </summary>
#if NET_35
    [Description("Имя потока, осуществлявшего логгирование")]
#endif
    public virtual string Thread { get; set; }

    public virtual int CompareTo(LogMessage other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(LogMessage other)
    {
      return this.Equality(other, it => it.RequestId);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as LogMessage);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.RequestId);
    }

    public override string ToString()
    {
      return this.Text?.Trim() ?? string.Empty;
    }
  }
}