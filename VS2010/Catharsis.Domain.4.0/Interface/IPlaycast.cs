namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a playcast, which is a combination/mix of text/audio/image content.</para>
  /// </summary>
  public partial interface IPlaycast : IItem
  {
    /// <summary>
    ///   <para>URI of associated audio file.</para>
    /// </summary>
    string Audio { get; }

    /// <summary>
    ///   <para>Category of playcast.</para>
    /// </summary>
    IPlaycastsCategory Category { get; }

    /// <summary>
    ///   <para>URI of associated image file.</para>
    /// </summary>
    string Image { get; }
  }
}