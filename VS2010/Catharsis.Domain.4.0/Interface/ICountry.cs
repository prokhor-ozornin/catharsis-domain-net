namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents geographical country.</para>
  /// </summary>
  public partial interface ICountry : IEntity, INameable
  {
    /// <summary>
    ///   <para>URI of country's flag image.</para>
    /// </summary>
    string Image { get; }

    /// <summary>
    ///   <para>ISO code of country.</para>
    /// </summary>
    string IsoCode { get; }
  }
}