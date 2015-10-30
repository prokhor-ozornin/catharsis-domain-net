using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Видео</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Видео")]
#endif
  public partial class Video : Media, IComparable<Video>, IEquatable<Video>
  {
    /// <summary>
    ///   <para>Файл, представляющий видео</para>
    /// </summary>
#if NET_35
    [Description("Файл, представляющий видео")]
#endif
    public virtual StorageFile File { get; set; }

    public virtual int CompareTo(Video other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(Video other)
    {
      return this.Equality(other, it => it.File, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Video);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File, it => it.Uri);
    }
  }
}