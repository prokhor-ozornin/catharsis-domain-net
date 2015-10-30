using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class IEntityExtensions
  {
    public static IQueryable<T> CreatedOn<T>(this IQueryable<T> entities, DateTime? from = null, DateTime? to = null) where T : IEntity
    {
      Assertion.NotNull(entities);

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

    public static IEnumerable<T> CreatedOn<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : IEntity
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.CreatedOn >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.CreatedOn <= to.Value);
      }

      return entities.Where(it => it != null);
    }

    public static T Id<T>(this IQueryable<T> entities, long id) where T : IEntity
    {
      Assertion.NotNull(entities);

      return entities.FirstOrDefault(it => it.Id == id);
    }

    public static T Id<T>(this IEnumerable<T> entities, long id) where T : IEntity
    {
      Assertion.NotNull(entities);

      return entities.FirstOrDefault(it => it != null && it.Id == id);
    }

    public static T Random<T>(this IQueryable<T> entities) where T : IEntity
    {
      Assertion.NotNull(entities);

      if (!entities.Any())
      {
        return (T)(object)null;
      }

      var identifiers = entities.Select(entity => entity.Id).Cast<long>().ToArray();
      return entities.Id(identifiers[new Random().Next(identifiers.Length)]);
    }

    public static T Random<T>(this IEnumerable<T> entities) where T : IEntity
    {
      Assertion.NotNull(entities);

      if (!entities.Any())
      {
        return (T) (object) null;
      }

      var identifiers = entities.Select(entity => entity.Id).Cast<long>().ToArray();
      return entities.Id(identifiers[new Random().Next(identifiers.Length)]);
    }

    public static IQueryable<T> UpdatedOn<T>(this IQueryable<T> entities, DateTime? from = null, DateTime? to = null) where T : IEntity
    {
      Assertion.NotNull(entities);

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

    public static IEnumerable<T> UpdatedOn<T>(this IEnumerable<T> entities, DateTime? from = null, DateTime? to = null) where T : IEntity
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(entity => entity != null && entity.UpdatedOn >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(entity => entity != null && entity.UpdatedOn <= to.Value);
      }

      return entities.Where(it => it != null);
    }
  }
}