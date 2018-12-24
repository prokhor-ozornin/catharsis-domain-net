using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class SettingExtensions
  {
    public static Setting ForName(this IQueryable<Setting> settings, string name)
    {
      Assertion.NotNull(settings);
      Assertion.NotEmpty(name);

      return settings.SingleOrDefault(it => it.Name.ToLower() == name.ToLower()); 
    }

    public static Setting ForName(this IEnumerable<Setting> settings, string name)
    {
      Assertion.NotNull(settings);
      Assertion.NotEmpty(name);

      return settings.SingleOrDefault(it => it?.Name != null && it.Name.ToLower() == name.ToLower());
    }

    public static IQueryable<Setting> Name(this IQueryable<Setting> settings, string name)
    {
      Assertion.NotNull(settings);
      Assertion.NotEmpty(name);

      return settings.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Setting> Name(this IEnumerable<Setting> settings, string name)
    {
      Assertion.NotNull(settings);
      Assertion.NotEmpty(name);

      return settings.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static string ValueOf(this IQueryable<Setting> settings, string name)
    {
      Assertion.NotNull(settings);
      Assertion.NotEmpty(name);

      return settings.ForName(name)?.Value;
    }

    public static string ValueOf(this IEnumerable<Setting> settings, string name)
    {
      Assertion.NotNull(settings);
      Assertion.NotEmpty(name);

      return settings.ForName(name)?.Value;
    }
  }
}