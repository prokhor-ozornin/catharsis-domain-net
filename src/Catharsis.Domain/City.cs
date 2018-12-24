using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Город</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class City : Entity, IComparable<City>, IEquatable<City>
  {
    /// <summary>
    ///   <para>Территория, к которой относится город</para>
    /// </summary>
    [Description(Schema.ColumnCommentArea)]
    [Column(Schema.ColumnNameArea)]
    [Indexed(Name = "idx__city__area_id")]
    public virtual Area Area { get; set; }

    /// <summary>
    ///   <para>Страна, в которой расположен город</para>
    /// </summary>
    [Description(Schema.ColumnCommentCountry)]
    [Column(Schema.ColumnNameCountry)]
    [NotNull]
    [Indexed(Name = "idx__city__country_id")]
    public virtual Country Country { get; set; }

    /// <summary>
    ///   <para>Признак того, что город имеет федеральное значение</para>
    /// </summary>
    [Description(Schema.ColumnCommentFederal)]
    [Column(Schema.ColumnNameFederal)]
    [Indexed(Name = "idx__city__federal")]
    public virtual bool? Federal { get; set; }

    /// <summary>
    ///   <para>Географические координаты города</para>
    /// </summary>
    [Description(Schema.ColumnCommentLocation)]
    [Column(Schema.ColumnNameLocation)]
    [Indexed(Name = "idx__city__location_id")]
    public virtual Location Location { get; set; }

    /// <summary>
    ///   <para>Наименование города</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__city__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Регион, к которому относится город</para>
    /// </summary>
    [Description(Schema.ColumnCommentRegion)]
    [Column(Schema.ColumnNameRegion)]
    [Indexed(Name = "idx__city__region_id")]
    public virtual Region Region { get; set; }

    public virtual int CompareTo(City other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(City other)
    {
      return this.Equality(other, it => it.Area, it => it.Country, it => it.Name, it => it.Region);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as City);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Area, it => it.Country, it => it.Name, it => it.Region);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "city";
      public const string TableComment = "Географические города";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления города";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения города";

      public const string ColumnNameArea = "area_id";
      public const string ColumnCommentArea = "Территория, к которой относится город";

      public const string ColumnNameCountry = "country_id";
      public const string ColumnCommentCountry = "Страна, в которой расположен город";

      public const string ColumnNameFederal = "federal";
      public const string ColumnCommentFederal = "Признак того, что город имеет федеральное значениеГеографические координаты города";

      public const string ColumnNameLocation = "location_id";
      public const string ColumnCommentLocation = "";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование города";

      public const string ColumnNameRegion = "region_id";
      public const string ColumnCommentRegion = "Регион, к которому относится город";
    }
  }
}