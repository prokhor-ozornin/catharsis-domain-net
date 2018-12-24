using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Территория</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Area : Entity, IComparable<Area>, IEquatable<Area>
  {
    /// <summary>
    ///   <para>Страна, в которой расположена территория</para>
    /// </summary>
    [Description(Schema.ColumnCommentCountry)]
    [Column(Schema.ColumnNameCountry)]
    [NotNull]
    [Indexed(Name = "idx__area__country_id")]
    public virtual Country Country { get; set; }

    /// <summary>
    ///   <para>Наименование территории</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__area__name")]
    public virtual string Name { get; set; }

    public virtual int CompareTo(Area other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(Area other)
    {
      return this.Equality(other, it => it.Country, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Area);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Country, it => it.Name);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "area";
      public const string TableComment = "Географические территории";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления территории";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего обновления территории";

      public const string ColumnNameCountry = "country_id";
      public const string ColumnCommentCountry = "Страна, в которой расположена территория";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование территории";
    }
  }
}