namespace Catharsis.Domain;

/// <summary>
///   <para>Бизнес-сущность</para>
/// </summary>
public interface IEntity
{
  /// <summary>
  ///   <para>Уникальный целочисленный идентификатор</para>
  /// </summary>
  long? Id { get; set; }

  /// <summary>
  ///   <para>Уникальный UUID идентификатор</para>
  /// </summary>
  Guid? Uuid { get; set; }

  /// <summary>
  ///   <para>Номер версии</para>
  /// </summary>
  long? Version { get; set; }

  /// <summary>
  ///   <para>Дата/время создания</para>
  /// </summary>
  DateTimeOffset? CreatedOn { get; set; }

  /// <summary>
  ///   <para>Дата/время последнего обновления</para>
  /// </summary>
  DateTimeOffset? UpdatedOn { get; set; }

  /// <summary>
  ///   <para>Дата/время создания/обновления</para>
  /// </summary>
  DateTimeOffset? ModifiedOn => UpdatedOn ?? CreatedOn;

  /// <summary>
  ///   <para>Уникальный ключ для кэширования</para>
  /// </summary>
  string Tag => $"{GetType().FullName}:{Id}:{Version}";
}