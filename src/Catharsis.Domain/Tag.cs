using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Ключевое слово</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Ключевое слово")]
#endif
  public partial class Tag : Entity, IComparable<Tag>, IEquatable<Tag>
  {
    /// <summary>
    ///   <para>Значение ключевого слова</para>
    /// </summary>
#if NET_35
    [Description("Значение ключевого слова")]
#endif
    public virtual string Name { get; set; }

    public virtual int CompareTo(Tag other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(Tag other)
    {
      return this.Equality(other, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Tag);
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