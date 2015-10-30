using System;
using System.ComponentModel;
using Catharsis.Commons;
using System.Collections.Generic;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Настроечная опция</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Настроечная опция")]
#endif
  public partial class Setting : Entity, IComparable<Setting>, IEquatable<Setting>
  {
    /// <summary>
    ///   <para>Описание настроечной опции</para>
    /// </summary>
#if NET_35
    [Description("Описание настроечной опции")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Наименование настроечной опции</para>
    /// </summary>
#if NET_35
    [Description("Наименование настроечной опции")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Тип данных для значения настроечной опции</para>
    /// </summary>
#if NET_35
    [Description("Тип данных для значения настроечной опции")]
#endif
    public virtual SettingType? Type { get; set; }

    /// <summary>
    ///   <para>Значение настроечной опции</para>
    /// </summary>
#if NET_35
    [Description("Значение настроечной опции")]
#endif
    public virtual string Value { get; set; }

    /// <summary>
    ///   <para>Список значений настроечной опции</para>
    /// </summary>
#if NET_35
    [Description("Список значений настроечной опции")]
#endif
    public virtual IList<string> Values { get; set; } = new List<string>();

    public virtual int CompareTo(Setting other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(Setting other)
    {
      return this.Equality(other, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Setting);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Name);
    }

    public override string ToString()
    {
      return this.Value ?? this.Values.ToListString();
    }
  }
}