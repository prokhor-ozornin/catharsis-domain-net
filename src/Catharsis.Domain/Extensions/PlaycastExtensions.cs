using Catharsis.Commons;
using System.Collections.Generic;
using System.Linq;

namespace Catharsis.Domain
{
  public static class PlaycastExtensions
  {
    public static IQueryable<Playcast> Name(this IQueryable<Playcast> playcasts, string name)
    {
      Assertion.NotNull(playcasts);
      Assertion.NotEmpty(name);

      return playcasts.Where(it => it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IEnumerable<Playcast> Name(this IEnumerable<Playcast> playcasts, string name)
    {
      Assertion.NotNull(playcasts);
      Assertion.NotEmpty(name);

      return playcasts.Where(it => it?.Name != null && it.Name.ToLower().StartsWith(name.ToLower()));
    }

    public static IQueryable<Playcast> Tag(this IQueryable<Playcast> playcasts, Tag tag)
    {
      Assertion.NotNull(playcasts);
      Assertion.NotNull(tag);

      return playcasts.Where(it => it.Tags.Contains(tag));
    }

    public static IEnumerable<Playcast> Tag(this IEnumerable<Playcast> playcasts, Tag tag)
    {
      Assertion.NotNull(playcasts);
      Assertion.NotNull(tag);

      return playcasts.Where(it => it != null && it.Tags.Contains(tag));
    }
  }
}