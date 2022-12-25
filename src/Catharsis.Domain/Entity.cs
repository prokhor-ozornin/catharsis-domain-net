using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain;

/// <summary>
///   <para>Бизнес-сущность</para>
/// </summary>
[Description("Бизнес-сущность")]
[Serializable]
[DataContract(Name = nameof(Entity))]
public abstract class Entity : IEntity
{
  /// <summary>
  ///   <para>Уникальный идентификатор</para>
  /// </summary>
  [Description("Уникальный идентификатор")]
  [DataMember(Name = nameof(Id))]
  public virtual long? Id { get; set; }

  /// <summary>
  ///   <para>Уникальный UUID идентификатор</para>
  /// </summary>
  [Description("Уникальный UUID идентификатор")]
  [DataMember(Name = nameof(Uuid))]
  public virtual Guid? Uuid { get; set; } = Guid.NewGuid();

  /// <summary>
  ///   <para>Номер версии</para>
  /// </summary>
  [Description("Номер версии")]
  [DataMember(Name = nameof(Version))]
  public virtual long? Version { get; set; }

  /// <summary>
  ///   <para>Дата/время создания</para>
  /// </summary>
  [Description("Дата/время создания")]
  [DataMember(Name = nameof(CreatedOn))]
  public virtual DateTimeOffset? CreatedOn { get; set; } = DateTimeOffset.UtcNow;

  /// <summary>
  /// /  <para>Дата/время последнего обновления</para>
  /// </summary>
  [Description("Дата/время последнего обновления")]
  [DataMember(Name = nameof(UpdatedOn))]
  public virtual DateTimeOffset? UpdatedOn { get; set; }

  public override bool Equals(object? other) => this.Equality(other as IEntity, entity => entity.GetType(), it => it.Id);

  /// <summary>
  ///   <para>Returns hash code for the current object.</para>
  /// </summary>
  /// <returns>Hash code of current instance.</returns>
  public override int GetHashCode() => this.HashCode(entity => entity.GetType(), it => it.Id);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString() => $"{GetType().Name}#{Id}";
}