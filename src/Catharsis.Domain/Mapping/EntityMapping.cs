using FluentNHibernate.Mapping;

namespace Catharsis.Domain;

/// <summary>
///   <para></para>
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public abstract class EntityMapping<TEntity> : ClassMap<TEntity> where TEntity : class, IEntity
{
  /// <summary>
  ///   <para>Creates and setup new mapping.</para>
  /// </summary>
  protected EntityMapping()
  {
    Cache.ReadWrite();
    Access.FromString(NamingStrategy.LowerCaseUnderscore.ToString());
    Id(entity => entity.Id).Column("id").GeneratedBy.Native();
    Map(entity => entity.Uuid).Column("uuid").UniqueKey("uuid").Not.Nullable();
    Version(entity => entity.Version).Column("version").Not.Nullable().Default(0).Check("Version >= 0").Index($"ix-{nameof(TEntity).ToLowerInvariant()}-version");
    Map(entity => entity.CreatedOn).Column("created_on").Not.Nullable().Index($"ix-{nameof(TEntity).ToLowerInvariant()}-created_on").ReadOnly();
    Map(entity => entity.UpdatedOn).Column("updated_on").Index($"ix-{nameof(TEntity).ToLowerInvariant()}-updated_on");
  }
}