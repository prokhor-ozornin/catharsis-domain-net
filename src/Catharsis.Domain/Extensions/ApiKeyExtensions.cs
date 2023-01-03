namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="ApiKey"/>.</para>
/// </summary>
/// <seealso cref="ApiKey"/>
public static class ApiKeyExtensions
{
  public static IQueryable<ApiKey> Name(this IQueryable<ApiKey> keys, string name) => keys.Where(key => key.Name != null && key.AppName != null && (key.AppName.ToLower().StartsWith(name.ToLower()) || key.Name.ToLower().StartsWith(name.ToLower())));

  public static IEnumerable<ApiKey> Name(this IEnumerable<ApiKey> keys, string name) => keys.Where(key => (key?.AppName != null && key.AppName.ToLower().StartsWith(name.ToLower())) || (key?.Name != null && key.Name.ToLower().StartsWith(name.ToLower())));
}