using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Ключ доступа API</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Ключ доступа API")]
#endif
  public partial class ApiKey : Entity, IComparable<ApiKey>, IEquatable<ApiKey>
  {
    /// <summary>
    ///   <para>Описание приложения, использующего ключ доступа</para>
    /// </summary>
#if NET_35
    [Description("Описание приложения, использующего ключ доступа")]
#endif
    public virtual string AppDescription { get; set; }

    /// <summary>
    ///   <para>Доменное имя, с которого приложение осуществляет запросы к API</para>
    /// </summary>
#if NET_35
    [Description("Доменное имя, с которого приложение осуществляет запросы к API")]
#endif
    public virtual string AppDomain { get; set; }

    /// <summary>
    ///   <para>Наименование приложения, использующего ключ доступа</para>
    /// </summary>
#if NET_35
    [Description("Наименование приложения, использующего ключ доступа")]
#endif
    public virtual string AppName { get; set; }

    /// <summary>
    ///   <para>Контактные данные лица, на имя которого выдан ключ доступ</para>
    /// </summary>
#if NET_35
    [Description("Контактные данные лица, на имя которого выдан ключ доступ")]
#endif
    public virtual Contact Contact { get; set; }

    /// <summary>
    ///   <para>Ф.И.О. контактного лица, на имя которого выдан ключ доступа</para>
    /// </summary>
#if NET_35
    [Description("Ф.И.О. контактного лица, на имя которого выдан ключ доступа")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Значение ключа доступа</para>
    /// </summary>
#if NET_35
    [Description("Значение ключа доступа")]
#endif
    public virtual string Value { get; set; } = Guid.NewGuid().ToString();

    public virtual int CompareTo(ApiKey other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public bool Equals(ApiKey other)
    {
      return this.Equality(other, it => it.Value);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as ApiKey);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Value);
    }

    public override string ToString()
    {
      return this.Value?.Trim() ?? string.Empty;
    }
  }
}