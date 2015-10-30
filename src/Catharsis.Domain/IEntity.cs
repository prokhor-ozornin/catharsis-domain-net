using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Бизнес-сущность</para>
  /// </summary>
  public interface IEntity
  {
    /// <summary>
    ///   <para>Дата/время создания</para>
    /// </summary>
    DateTime? CreatedOn { get; set; }

    /// <summary>
    ///   <para>Уникальный идентификатор</para>
    /// </summary>
    long? Id { get; set; }

    /// <summary>
    ///   <para>Дата/время последнего обновления</para>
    /// </summary>
    DateTime? UpdatedOn { get; set; }

    /// <summary>
    ///   <para>Номер версии</para>
    /// </summary>
    long? Version { get; set; }
  }
}