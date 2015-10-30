using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Программный скрипт</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Программный скрипт")]
#endif
  public partial class Script : Entity, IComparable<Script>, IEquatable<Script>
  {
    /// <summary>
    ///   <para>Программный код скрипта</para>
    /// </summary>
#if NET_35
    [Description("Программный код скрипта")]
#endif
    public virtual string Code { get; set; }

    /// <summary>
    ///   <para>Длительность выполнения скрипта в миллисекундах</para>
    /// </summary>
#if NET_35
    [Description("Длительность выполнения скрипта в миллисекундах")]
#endif
    public virtual long? Duration { get; set; }

    /// <summary>
    ///   <para>Признак того, был ли выполнен скрипт</para>
    /// </summary>
#if NET_35
    [Description("Признак того, был ли выполнен скрипт")]
#endif
    public virtual bool? Executed { get; set; }

    /// <summary>
    ///   <para>Наименование скрипта</para>
    /// </summary>
#if NET_35
    [Description("Наименование скрипта")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Путь к файлу скрипта</para>
    /// </summary>
#if NET_35
    [Description("Путь к файлу скрипта")]
#endif
    public virtual string Path { get; set; }

    public virtual int CompareTo(Script other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(Script other)
    {
      return this.Equality(other, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Script);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}