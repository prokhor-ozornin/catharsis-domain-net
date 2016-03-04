using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Плейкаст</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Playcast : Entity, IComparable<Playcast>
  {
    /// <summary>
    ///   <para>Аудио-сопровождение плейкаста</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentAudio)]
#endif
    [Column(Schema.ColumnNameAudio)]
    [Indexed(Name = "idx__playcasts__audio_id")]
    public virtual Audio Audio { get; set; }

    /// <summary>
    ///   <para>Изображение для плейкаста</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentImage)]
#endif
    [Column(Schema.ColumnNameImage)]
    [NotNull]
    [Indexed(Name = "idx__playcasts__image_id")]
    public virtual Image Image { get; set; }

    /// <summary>
    ///   <para>Наименование плейкаста</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__playcasts__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Ключевые слова, описывающие содержимое плейкаста</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentTags)]
#endif
    [Column(Schema.ColumnNameTags)]
    public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>
    ///   <para>Текст плейкаста</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentText)]
#endif
    [Column(Schema.ColumnNameText)]
    [NotNull]
    [MaxLength(4000)]
    public virtual string Text { get; set; }

    /// <summary>
    ///   <para>Видео-содержимое плейкаста</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentVideo)]
#endif
    [Column(Schema.ColumnNameVideo)]
    [Indexed(Name = "idx__playcasts__video_id")]
    public virtual Video Video { get; set; }

    public virtual int CompareTo(Playcast other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static class Schema
    {
      public const string TableName = "playcasts";
      public const string TableComment = "Плейкасты";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время публикации плейкаста";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления плейкаста";

      public const string ColumnNameAudio = "audio_id";
      public const string ColumnCommentAudio = "Аудио-сопровождение плейкаста";

      public const string ColumnNameImage = "image_id";
      public const string ColumnCommentImage = "Изображение для плейкаста";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование плейкаста";

      public const string ColumnNameTags = "tags";
      public const string ColumnCommentTags = "Ключевые слова, описывающие содержимое плейкаста";

      public const string ColumnNameText = "text";
      public const string ColumnCommentText = "Текст плейкаста";

      public const string ColumnNameVideo = "video_id";
      public const string ColumnCommentVideo = "Видео-содержимое плейкаста";
    }
  }
}