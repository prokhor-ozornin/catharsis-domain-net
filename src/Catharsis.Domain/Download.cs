using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Загружаемый материал</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Загружаемый материал")]
#endif
  public partial class Download : Entity, IComparable<Download>, IEquatable<Download>
  {
    /// <summary>
    ///   <para>Описание материала</para>
    /// </summary>
#if NET_35
    [Description("Описание материала")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Количество скачиваний</para>
    /// </summary>
#if NET_35
    [Description("Количество скачиваний")]
#endif
    public virtual long? Downloads { get; set; }

    /// <summary>
    ///   <para>Файл, представляющий загружаемый материал</para>
    /// </summary>
#if NET_35
    [Description("Файл, представляющий загружаемый материал")]
#endif
    public virtual StorageFile File { get; set; }

    /// <summary>
    ///   <para>Изображение, связанное с материалом</para>
    /// </summary>
#if NET_35
    [Description("Изображение, связанное с материалом")]
#endif
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование материала</para>
    /// </summary>
#if NET_35
    [Description("Наименование материала")]
#endif
    public virtual string Name { get; set; }

    public virtual int CompareTo(Download other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public bool Equals(Download other)
    {
      return this.Equality(other, it => it.File);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Download);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }
  }
}