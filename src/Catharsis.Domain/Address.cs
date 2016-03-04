using System;
using System.Collections.Generic;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Адрес</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Address : Entity, IComparable<Address>
  {
    /// <summary>
    ///   <para>Город, к которому относится адрес</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentCity)]
#endif
    [Column(Schema.ColumnNameCity)]
    [NotNull]
    [Indexed(Name = "idx__addresses__city_id")]
    public virtual City City { get; set; }

    /// <summary>
    ///   <para>Дополнительные примечания, относящиеся к адресу</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDescription)]
#endif
    [Column(Schema.ColumnNameDescription)]
    [MaxLength(350)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Географическая точка с координатами адреса</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentLocation)]
#endif
    [Column(Schema.ColumnNameLocation)]
    [Indexed(Name = "idx__addresses__location_id")]
    public virtual Location Location { get; set; }

    /// <summary>
    ///   <para>Адрес (улица, дом)</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [Indexed(Name = "idx__addresses__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Почтовый индекс</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentZip)]
#endif
    [Column(Schema.ColumnNameZip)]
    [Indexed(Name = "idx__addresses__zip")]
    public virtual string Zip { get; set; }

    public virtual int CompareTo(Address other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
      var parts = new List<string>();

      if (this.City != null)
      {
        parts.Add(this.City.ToString());
      }

      if (!this.Name.IsEmpty())
      {
        parts.Add(this.Name.Trim());
      }

      if (!this.Zip.IsEmpty())
      {
        parts.Add(this.Zip.Trim());
      }

      return parts.Join(",");
    }

    public static class Schema
    {
      public const string TableName = "addresses";
      public const string TableComment = "Географические адреса";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления адреса";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения адреса";

      public const string ColumnNameCity = "city_id";
      public const string ColumnCommentCity = "Город, к которому относится адрес";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Дополнительные примечания, относящиеся к адресу";

      public const string ColumnNameLocation = "location_id";
      public const string ColumnCommentLocation = "Географическая точка с координатами адреса";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Адрес (улица, дом)";

      public const string ColumnNameZip = "zip";
      public const string ColumnCommentZip = "Почтовый индекс";
    }
  }
}