using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Регион</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Region : Entity, IComparable<Region>, IEquatable<Region>
  {
    /// <summary>
    ///   <para>Территория, к которой относится регион</para>
    /// </summary>
    [Description(Schema.ColumnCommentArea)]
    [Column(Schema.ColumnNameArea)]
    [NotNull]
    [Indexed(Name = "idx__region__area_id")]
    public virtual Area Area { get; set; }

    /// <summary>
    ///   <para>Наименование региона</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__region__name")]
    public virtual string Name { get; set; }

    public virtual int CompareTo(Region other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(Region other)
    {
      return this.Equality(other, it => it.Area, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Region);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Area, it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "region";
      public const string TableComment = "Географические регионы";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления региона";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения региона";

      public const string ColumnNameArea = "area_id";
      public const string ColumnCommentArea = "Территория, к которой относится регион";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование региона";
    }
  }
}