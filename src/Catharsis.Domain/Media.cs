using Catharsis.Commons;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Медиа ресурс</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Медиа ресурс")]
#endif
  public partial class Media : Entity, IComparable<Media>, IEquatable<Media>
  {
    /// <summary>
    ///   <para>Имя создателя медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("Имя создателя медиа ресурса")]
#endif
    public virtual string AuthorName { get; set; }

    /// <summary>
    ///   <para>URI адрес страницы создателя медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("URI адрес страницы создателя медиа ресурса")]
#endif
    public virtual string AuthorUri { get; set; }

    /// <summary>
    ///   <para>MIME тип медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("MIME тип медиа ресурса")]
#endif
    public virtual string ContentType { get; set; }

    /// <summary>
    ///   <para>Описание медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("Описание медиа ресурса")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Длительность воспроизведения медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("Длительность воспроизведения медиа ресурса")]
#endif
    public virtual long? Duration { get; set; }

    /// <summary>
    ///   <para>Высота медиа ресурса в пикселях</para>
    /// </summary>
#if NET_35
    [Description("Высота медиа ресурса в пикселях")]
#endif
    public virtual short? Height { get; set; }

    /// <summary>
    ///   <para>Внедряемый HTML код медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("Внедряемый HTML код медиа ресурса")]
#endif
    public virtual string Html { get; set; }

    /// <summary>
    ///   <para>Заголовок медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("Заголовок медиа ресурса")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>URI адрес сайта провайдера ресурсов данного типа</para>
    /// </summary>
#if NET_35
    [Description("URI адрес сайта провайдера ресурсов данного типа")]
#endif
    public virtual string ProviderUri { get; set; }

    /// <summary>
    ///   <para>Высота миниатюры медиа ресурса в пикселях</para>
    /// </summary>
#if NET_35
    [Description("Высота миниатюры медиа ресурса в пикселях")]
#endif
    public virtual short? ThumbnailHeight { get; set; }

    /// <summary>
    ///   <para>URI адрес миниатюры медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("URI адрес миниатюры медиа ресурса")]
#endif
    public virtual string ThumbnailUri { get; set; }

    /// <summary>
    ///   <para>Ширина миниатюры медиа ресурса в пикселях</para>
    /// </summary>
#if NET_35
    [Description("Ширина миниатюры медиа ресурса в пикселях")]
#endif
    public virtual short? ThumbnailWidth { get; set; }

    /// <summary>
    ///   <para>URI адрес медиа ресурса</para>
    /// </summary>
#if NET_35
    [Description("URI адрес медиа ресурса")]
#endif
    public virtual Uri Uri { get; set; }

    /// <summary>
    ///   <para>Ширина ресурса в пикселях</para>
    /// </summary>
#if NET_35
    [Description("Ширина ресурса в пикселях")]
#endif
    public virtual short? Width { get; set; }

    public virtual int CompareTo(Media other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(Media other)
    {
      return this.Equality(other, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Media);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.ToString() ?? string.Empty;
    }
  }
}