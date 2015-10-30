using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class MediaExtensions
  {
    public static IQueryable<T> ContentType<T>(this IQueryable<T> entities, string contentType) where T : Media
    {
      Assertion.NotNull(entities);
      Assertion.NotEmpty(contentType);

      return entities.Where(it => it.ContentType.ToLower() == contentType.ToLower());
    }

    public static IEnumerable<T> ContentType<T>(this IEnumerable<T> entities, string contentType) where T : Media
    {
      Assertion.NotNull(entities);
      Assertion.NotEmpty(contentType);

      return entities.Where(it => it?.ContentType != null && it.ContentType.ToLower() == contentType.ToLower());
    }

    public static IQueryable<T> Duration<T>(this IQueryable<T> entities, long? from = null, long? to = null) where T : Media
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(it => it.Duration >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(it => it.Duration <= to.Value);
      }

      return entities;
    }

    public static IEnumerable<T> Duration<T>(this IEnumerable<T> entities, long? from = null, long? to = null) where T : Media
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(it => it != null && it.Duration >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(it => it != null && it.Duration <= to.Value);
      }

      return entities.Where(it => it != null);
    }

    public static IQueryable<T> Height<T>(this IQueryable<T> entities, short? from = null, short? to = null) where T : Media
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(it => it.Height >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(it => it.Height <= to.Value);
      }

      return entities;
    }

    public static IEnumerable<T> Height<T>(this IEnumerable<T> entities, short? from = null, short? to = null) where T : Media
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(it => it != null && it.Height >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(it => it != null && it.Height <= to.Value);
      }

      return entities.Where(it => it != null);
    }

    public static IQueryable<T> Name<T>(this IQueryable<T> entities, string name) where T : Media
    {
      Assertion.NotNull(entities);
      Assertion.NotEmpty(name);

      return entities.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<T> Name<T>(this IEnumerable<T> entities, string name) where T : Media
    {
      Assertion.NotNull(entities);
      Assertion.NotEmpty(name);

      return entities.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IQueryable<T> Width<T>(this IQueryable<T> entities, short? from = null, short? to = null) where T : Media
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(it => it.Width >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(it => it.Width <= to.Value);
      }

      return entities;
    }

    public static IEnumerable<T> Width<T>(this IEnumerable<T> entities, short? from = null, short? to = null) where T : Media
    {
      Assertion.NotNull(entities);

      if (from != null)
      {
        entities = entities.Where(it => it != null && it.Width >= from.Value);
      }

      if (to != null)
      {
        entities = entities.Where(it => it != null && it.Width <= to.Value);
      }

      return entities.Where(it => it != null);
    }
  }
}