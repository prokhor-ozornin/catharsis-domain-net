using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  public static class AudioExtensions
  {
    public static IQueryable<Audio> Bitrate(this IQueryable<Audio> audios, short bitrate)
    {
      Assertion.NotNull(audios);

      return audios.Where(it => it.Bitrate == bitrate);
    }

    public static IEnumerable<Audio> Bitrate(this IEnumerable<Audio> audios, short bitrate)
    {
      Assertion.NotNull(audios);

      return audios.Where(it => it != null && it.Bitrate == bitrate);
    }
  }
}