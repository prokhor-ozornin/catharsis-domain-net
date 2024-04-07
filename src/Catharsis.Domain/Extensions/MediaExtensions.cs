namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Media"/>.</para>
/// </summary>
/// <seealso cref="Media"/>
public static class MediaExtensions
{
  public static IQueryable<T> ContentType<T>(this IQueryable<T> entities, string contentType) where T : Media => entities.Where(media => media.ContentType != null && media.ContentType.ToLower() == contentType.ToLower());

  public static IEnumerable<T> ContentType<T>(this IEnumerable<T> entities, string contentType) where T : Media => entities.Where(media => media?.ContentType is not null && media.ContentType.ToLower() == contentType.ToLower());

  public static IQueryable<T> Name<T>(this IQueryable<T> entities, string name) where T : Media => entities.Where(media => media.Name != null && media.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<T> Name<T>(this IEnumerable<T> entities, string name) where T : Media => entities.Where(media => media?.Name is not null && media.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<T> Duration<T>(this IQueryable<T> entities, long? from = null, long? to = null) where T : Media
  {
    if (from is not null)
    {
      entities = entities.Where(media => media.Duration >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(media => media.Duration <= to.Value);
    }

    return entities;
  }

  public static IEnumerable<T> Duration<T>(this IEnumerable<T> entities, long? from = null, long? to = null) where T : Media
  {
    if (from is not null)
    {
      entities = entities.Where(media => media is not null && media.Duration >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(media => media is not null && media.Duration <= to.Value);
    }

    return entities.Where(media => media is not null);
  }

  public static IQueryable<T> Height<T>(this IQueryable<T> entities, short? from = null, short? to = null) where T : Media
  {
    if (from is not null)
    {
      entities = entities.Where(media => media.Height >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(media => media.Height <= to.Value);
    }

    return entities;
  }

  public static IEnumerable<T> Height<T>(this IEnumerable<T> entities, short? from = null, short? to = null) where T : Media
  {
    if (from is not null)
    {
      entities = entities.Where(media => media is not null && media.Height >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(media => media is not null && media.Height <= to.Value);
    }

    return entities.Where(media => media is not null);
  }

  public static IQueryable<T> Width<T>(this IQueryable<T> entities, short? from = null, short? to = null) where T : Media
  {
    if (from is not null)
    {
      entities = entities.Where(media => media.Width >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(media => media.Width <= to.Value);
    }

    return entities;
  }

  public static IEnumerable<T> Width<T>(this IEnumerable<T> entities, short? from = null, short? to = null) where T : Media
  {
    if (from is not null)
    {
      entities = entities.Where(media => media is not null && media.Width >= from.Value);
    }

    if (to is not null)
    {
      entities = entities.Where(media => media is not null && media.Width <= to.Value);
    }

    return entities.Where(media => media is not null);
  }
}