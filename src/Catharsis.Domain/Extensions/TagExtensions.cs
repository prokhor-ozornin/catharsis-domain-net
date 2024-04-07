namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Tag"/>.</para>
/// </summary>
/// <seealso cref="Tag"/>
public static class TagExtensions
{
  public static Tag ForName(this IQueryable<Tag> tags, string name) => tags.SingleOrDefault(tag => tag.Name != null && tag.Name.ToLower() == name.ToLower());

  public static Tag ForName(this IEnumerable<Tag> tags, string name) => tags.SingleOrDefault(tag => tag?.Name is not null && tag.Name.ToLower() == name.ToLower());
}