using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Изображение</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Изображение")]
#endif
  public partial class Image : Media, IComparable<Image>, IEquatable<Image>
  {
    /// <summary>
    ///   <para>Файл, представляющий изображение</para>
    /// </summary>
#if NET_35
    [Description("Файл, представляющий изображение")]
#endif
    public virtual StorageFile File { get; set; }

    public virtual int CompareTo(Image other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(Image other)
    {
      return this.Equality(other, it => it.File, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Image);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File, it => it.Uri);
    }
  }
}