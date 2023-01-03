namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Playcast"/>.</para>
/// </summary>
/// <seealso cref="Playcast"/>
public static class PlaycastExtensions
{
  public static IQueryable<Playcast> Name(this IQueryable<Playcast> playcasts, string name) => playcasts.Where(playcast => playcast.Name != null && playcast.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Playcast> Name(this IEnumerable<Playcast> playcasts, string name) => playcasts.Where(playcast => playcast?.Name != null && playcast.Name.ToLower().StartsWith(name.ToLower()));

  public static IQueryable<Playcast> Tag(this IQueryable<Playcast> playcasts, Tag tag) => playcasts.Where(playcast => playcast.Tags.Contains(tag));

  public static IEnumerable<Playcast> Tag(this IEnumerable<Playcast> playcasts, Tag tag) => playcasts.Where(playcast => playcast != null && playcast.Tags.Contains(tag));
}