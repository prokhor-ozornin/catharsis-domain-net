using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Бизнес-сущность</para>
  /// </summary>
  public abstract class Entity : IEntity
  {
    /// <summary>
    ///   <para>Дата/время создания</para>
    /// </summary>
    [Description("Дата/время создания")]
    [Column(Schema.ColumnNameCreatedOn)]
    public virtual DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///   <para>Уникальный идентификатор</para>
    /// </summary>
    [Description("Уникальный идентификатор")]
    [PrimaryKey]
    [AutoIncrement]
    [Column(Schema.ColumnNameId)]
    public virtual long? Id { get; set; }

    /// <summary>
    ///   <para>Дата/время создания/обновления</para>
    /// </summary>
    [Description("Дата/время создания/обновления")]
    public virtual DateTime? LastModified => this.UpdatedOn ?? this.CreatedOn;

    /// <summary>
    ///   <para>Уникальный ключ для кэширования</para>
    /// </summary>
    [Description("Уникальный ключ для кэширования")]
    public virtual string Tag => $"{this.GetType().FullName}:{this.Id}:{this.Version}";

    /// <summary>
    /// /  <para>Дата/время последнего обновления</para>
    /// </summary>
    [Description("Дата/время последнего обновления")]
    [Column(Schema.ColumnNameUpdatedOn)]
    public virtual DateTime? UpdatedOn { get; set; }

    /// <summary>
    ///   <para>Номер версии</para>
    /// </summary>
    [Description("Номер версии")]
    [Column(Schema.ColumnVersion)]
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

    public static class Schema
    {
      public const string ColumnNameId = "id";
      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnVersion = "version";
    }
  }
}