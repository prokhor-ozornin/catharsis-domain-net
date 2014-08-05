namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents custom text comment.</para>
  /// </summary>
  public partial interface IComment : IEntity, INameable, ITimestampable
  {
    /// <summary>
    ///   <para>Text of comment.</para>
    /// </summary>
    string Text { get; }
  }
}