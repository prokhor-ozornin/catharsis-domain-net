namespace Catharsis.Domain;

/// <summary>
///   <para>Set of extension methods for class <see cref="Audio"/>.</para>
/// </summary>
/// <seealso cref="Audio"/>
public static class AudioExtensions
{
  public static IQueryable<Audio> Bitrate(this IQueryable<Audio> audios, short? bitrate) => audios.Where(audio => audio.Bitrate == bitrate);

  public static IEnumerable<Audio> Bitrate(this IEnumerable<Audio> audios, short? bitrate) => audios.Where(audio => audio is not null && audio.Bitrate == bitrate);
}