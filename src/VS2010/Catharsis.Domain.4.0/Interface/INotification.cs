namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents short text information.</para>
  /// </summary>
  public partial interface INotification : IEntity, ILocalizable, ITypeable
  {
    /// <summary>
    ///   <para>Text of notification.</para>
    /// </summary>
    string Text { get; }
  }
}