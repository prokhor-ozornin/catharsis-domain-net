namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Setting"/>.</para>
/// </summary>
/// <seealso cref="Setting"/>
public static class SettingExtensions
{
  public static Setting ForName(this IQueryable<Setting> settings, string name) => settings.SingleOrDefault(setting => setting.Name != null && setting.Name.ToLower() == name.ToLower()); 

  public static Setting ForName(this IEnumerable<Setting> settings, string name) => settings.SingleOrDefault(setting => setting?.Name is not null && setting.Name.ToLower() == name.ToLower());

  public static IQueryable<Setting> Name(this IQueryable<Setting> settings, string name) => settings.Where(setting => setting.Name != null && setting.Name.ToLower().StartsWith(name.ToLower()));

  public static IEnumerable<Setting> Name(this IEnumerable<Setting> settings, string name) => settings.Where(setting => setting?.Name is not null && setting.Name.ToLower().StartsWith(name.ToLower()));

  public static string ValueOf(this IQueryable<Setting> settings, string name) => settings.ForName(name).Value;
  
  public static string ValueOf(this IEnumerable<Setting> settings, string name) => settings.ForName(name)?.Value;
}