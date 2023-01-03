namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for interface <see cref="IEntity"/>.</para>
/// </summary>
/// <seealso cref="IEntity"/>
public static class IEntityExtensions
{
  public static T Id<T>(this IQueryable<T> entities, long id) where T : IEntity => entities.FirstOrDefault(entity => entity.Id == id);

  public static T Id<T>(this IEnumerable<T> entities, long id) where T : IEntity => entities.FirstOrDefault(entity => entity != null && entity.Id == id);

  public static IQueryable<T> CreatedOn<T>(this IQueryable<T> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) where T : IEntity
  {
    if (from != null)
    {
      entities = entities.Where(entity => entity.CreatedOn >= from.Value);
    }

    if (to != null)
    {
      entities = entities.Where(entity => entity.CreatedOn <= to.Value);
    }

    return entities;
  }

  public static IEnumerable<T> CreatedOn<T>(this IEnumerable<T> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) where T : IEntity
  {
    if (from != null)
    {
      entities = entities.Where(entity => entity != null && entity.CreatedOn >= from.Value);
    }

    if (to != null)
    {
      entities = entities.Where(entity => entity != null && entity.CreatedOn <= to.Value);
    }

    return entities.Where(entity => entity != null);
  }

  public static T Random<T>(this IQueryable<T> entities) where T : IEntity
  {
    if (!entities.Any())
    {
      return (T)(object) null;
    }

    var identifiers = entities.Select(entity => entity.Id).Cast<long>().ToArray();

    return entities.Id(identifiers[new Random().Next(identifiers.Length)]);
  }

  public static T Random<T>(this IEnumerable<T> entities) where T : IEntity
  {
    var identifiers = entities.Select(entity => entity?.Id).ToArray();

    if (!identifiers.Any())
    {
      return (T) (object) null;
    }

    var id = identifiers[new Random().Next(identifiers.Length)];
    
    return id != null ? entities.Id(id.Value) : (T) (object) null;
  }

  public static IQueryable<T> UpdatedOn<T>(this IQueryable<T> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) where T : IEntity
  {
    if (from != null)
    {
      entities = entities.Where(entity => entity.UpdatedOn >= from.Value);
    }

    if (to != null)
    {
      entities = entities.Where(entity => entity.UpdatedOn <= to.Value);
    }

    return entities;
  }

  public static IEnumerable<T> UpdatedOn<T>(this IEnumerable<T> entities, DateTimeOffset? from = null, DateTimeOffset? to = null) where T : IEntity
  {
    if (from != null)
    {
      entities = entities.Where(entity => entity != null && entity.UpdatedOn >= from.Value);
    }

    if (to != null)
    {
      entities = entities.Where(entity => entity != null && entity.UpdatedOn <= to.Value);
    }

    return entities.Where(entity => entity != null);
  }
}