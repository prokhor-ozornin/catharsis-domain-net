using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Персона</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Персона")]
#endif
  public partial class Person : Entity, IComparable<Person>, IEquatable<Person>
  {
    /// <summary>
    ///   <para>Дата рождения</para>
    /// </summary>
#if NET_35
    [Description("Дата рождения")]
#endif
    public virtual DateTime? BirthDate { get; set; }

    /// <summary>
    ///   <para>Дата смерти</para>
    /// </summary>
#if NET_35
    [Description("Дата смерти")]
#endif
    public virtual DateTime? DeathDate { get; set; }

    /// <summary>
    ///   <para>Имя</para>
    /// </summary>
#if NET_35
    [Description("Имя")]
#endif
    public virtual string FirstName { get; set; }

    /// <summary>
    ///   <para>Фамилия</para>
    /// </summary>
#if NET_35
    [Description("Фамилия")]
#endif
    public virtual string LastName { get; set; }

    /// <summary>
    ///   <para>Отчество</para>
    /// </summary>
#if NET_35
    [Description("Отчество")]
#endif
    public virtual string MiddleName { get; set; }

    public virtual int CompareTo(Person other)
    {
      return this.ToString().CompareTo(other.ToString());
    }

    public bool Equals(Person other)
    {
      return this.Equality(other, it => it.BirthDate, it => it.DeathDate, it => it.FirstName, it => it.LastName, it => it.MiddleName);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Person);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => BirthDate, it => it.DeathDate, it => it.FirstName, it => it.LastName, it => it.MiddleName);
    }

    public override string ToString()
    {
      return $"{this.LastName ?? string.Empty} {this.FirstName ?? string.Empty} {this.MiddleName ?? string.Empty}".Trim();
    }
  }
}