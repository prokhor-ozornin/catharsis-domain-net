using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Аудио</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Audio : Media, IEquatable<Audio>
  {
    /// <summary>
    ///   <para>Битрейт аудио дорожки</para>
    /// </summary>
    [Description(Schema.ColumnCommentBitrate)]
    [Column(Schema.ColumnNameBitrate)]
    [Indexed(Name = "idx__audio__bitrate")]
    public virtual short? Bitrate { get; set; }

    /// <summary>
    ///   <para>Файл, представляющий аудио</para>
    /// </summary>
    [Description(Schema.ColumnCommentFile)]
    [Column(Schema.ColumnNameFile)]
    [Indexed(Name = "idx__audio__file_id")]
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

    public static new class Schema
    {
      public const string TableName = "audio";
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