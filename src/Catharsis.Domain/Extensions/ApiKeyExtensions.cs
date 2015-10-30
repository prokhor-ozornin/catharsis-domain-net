using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class ApiKeyExtensions
  {
    public static IQueryable<ApiKey> Name(this IQueryable<ApiKey> keys, string name)
    {
      Assertion.NotNull(keys);
      Assertion.NotEmpty(name);

      return keys.Where(it => it.AppName.ToLower().StartsWith(name.ToLower()) || it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<ApiKey> Name(this IEnumerable<ApiKey> keys, string name)
    {
      Assertion.NotNull(keys);
      Assertion.NotEmpty(name);

      return keys.Where(it => (it?.AppName != null && it.AppName.ToLower().StartsWith(name.ToLower())) || (it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower())));
    }
  }
}