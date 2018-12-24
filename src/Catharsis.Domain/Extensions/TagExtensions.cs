using Catharsis.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain
{
  public static class TagExtensions
  {
    public static Tag ForName(this IQueryable<Tag> tags, string name)
    {
      Assertion.NotNull(tags);
      Assertion.NotEmpty(name);

      return tags.SingleOrDefault(it => it.Name.ToLower() == name.ToLower());
    }

    public static Tag ForName(this IEnumerable<Tag> tags, string name)
    {
      Assertion.NotNull(tags);
      Assertion.NotEmpty(name);

      return tags.SingleOrDefault(it => it?.Name != null && it.Name.ToLower() == name.ToLower());
    }
  }
}