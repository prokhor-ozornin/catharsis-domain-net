using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Аудио</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Аудио")]
#endif
  public partial class Audio : Media, IComparable<Audio>, IEquatable<Audio>
  {
    /// <summary>
    ///   <para>Битрейт аудио дорожки</para>
    /// </summary>
#if NET_35
    [Description("Битрейт аудио дорожки")]
#endif
    public virtual short? Bitrate { get; set; }

    /// <summary>
    ///   <para>Файл, представляющий аудио</para>
    /// </summary>
#if NET_35
    [Description("Файл, представляющий аудио")]
#endif
    public virtual StorageFile File { get; set; }

    public virtual int CompareTo(Audio other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(Audio other)
    {
      return this.Equality(other, it => it.File, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Audio);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File, it => it.Uri);
    }
  }
}