namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents base content element.</para>
  /// </summary>
  public partial interface IItem : IEntity, ILocalizable, INameable, ITaggable, ITimestampable
  {
    /// <summary>
    ///   <para>Text content of item.</para>
    /// </summary>
    string Text { get; }
  }
}