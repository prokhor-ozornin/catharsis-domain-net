using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Аудио</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Audio : Media, IEquatable<Audio>
  {
    /// <summary>
    ///   <para>Битрейт аудио дорожки</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentBitrate)]
#endif
    [Column(Schema.ColumnNameBitrate)]
    [Indexed(Name = "idx__audios__bitrate")]
    public virtual short? Bitrate { get; set; }

    /// <summary>
    ///   <para>Файл, представляющий аудио</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentFile)]
#endif
    [Column(Schema.ColumnNameFile)]
    [Indexed(Name = "idx__audios__file_id")]
    public virtual StorageFile File { get; set; }

    public virtual bool Equals(Audio other)
    {
      return this.Equality(other, it => it.File, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Audio);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.File, it => it.Uri);
    }

    public static class Schema
    {
      public const string TableName = "audios";
      public const string TableComment = "Аудио файлы";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameBitrate = "bitrate";
      public const string ColumnCommentBitrate = "Битрейт аудио дорожки";

      public const string ColumnNameFile = "file_id";
      public const string ColumnCommentFile = "Файл, представляющий аудио";
    }
  }
}