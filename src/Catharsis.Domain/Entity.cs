using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Бизнес-сущность</para>
  /// </summary>
#if NET_35
  [Description("Бизнес-сущность")]
#endif
  public abstract partial class Entity : IEntity
  {
    /// <summary>
    ///   <para>Дата/время создания</para>
    /// </summary>
#if NET_35
    [Description("Дата/время создания")]
#endif
    public virtual DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///   <para>Уникальный идентификатор</para>
    /// </summary>
#if NET_35
    [Description("Уникальный идентификатор")]
#endif
    public virtual long? Id { get; set; }

    /// <summary>
    ///   <para>Дата/время создания/обновления</para>
    /// </summary>
#if NET_35
    [Description("Дата/время создания/обновления")]
#endif
    public virtual DateTime? LastModified => this.UpdatedOn ?? this.CreatedOn;

    /// <summary>
    ///   <para>Уникальный ключ для кэширования</para>
    /// </summary>
#if NET_35
    [Description("Уникальный ключ для кэширования")]
#endif
    public virtual string Tag => $"{this.GetType().FullName}:{this.Id}:{this.Version}";

    /// <summary>
    /// /  <para>Дата/время последнего обновления</para>
    /// </summary>
#if NET_35
    [Description("Дата/время последнего обновления")]
#endif
    public virtual DateTime? UpdatedOn { get; set; }

    /// <summary>
    ///   <para>Номер версии</para>
    /// </summary>
#if NET_35
    [Description("Номер версии")]
#endif
    public virtual long? Version { get; set; }

    public override bool Equals(object other)
    {
      return this.Equality(other as IEntity, entity => entity.GetType(), entity => entity.Id);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(entity => entity.GetType(), entity => entity.Id);
    }

    public override string ToString()
    {
      return $"{this.GetType().Name}#{this.Id}";
    }
  }
}