using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Страна</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class Country : Entity, IComparable<Country>, IEquatable<Country>
  {
    /// <summary>
    ///   <para>Наименование валюты, используемой в стране</para>
    /// </summary>
    [Description(Schema.ColumnCommentCurrency)]
    [Column(Schema.ColumnNameCurrency)]
    [NotNull]
    public virtual string Currency { get; set; }

    /// <summary>
    ///   <para>Код валюты, используемой в стране</para>
    /// </summary>
    [Description(Schema.ColumnCommentCurrencyCode)]
    [Column(Schema.ColumnNameCurrencyCode)]
    [NotNull]
    [MaxLength(3)]
    [Indexed(Name = "idx__country__currency_code")]
    public virtual string CurrencyCode { get; set; }

    /// <summary>
    ///   <para>Уникальный ISO код страны</para>
    /// </summary>
    [Description(Schema.ColumnCommentIsoCode)]
    [Column(Schema.ColumnNameIsoCode)]
    [NotNull]
    [MaxLength(2)]
    [Unique(Name = "country__iso_code")]
    public virtual string IsoCode { get; set; }

    /// <summary>
    ///   <para>Основной язык страны</para>
    /// </summary>
    [Description(Schema.ColumnCommentLanguage)]
    [Column(Schema.ColumnNameLanguage)]
    public virtual string Language { get; set; }

    /// <summary>
    ///   <para>Наименование страны</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Unique(Name = "country__name")]
    public virtual string Name { get; set; }

    public virtual int CompareTo(Country other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(Country other)
    {
      return this.Equality(other, it => it.IsoCode);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Country);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.IsoCode);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "country";
      public const string TableComment = "Географические страны";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления страны";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения страны";

      public const string ColumnNameCurrency = "currency";
      public const string ColumnCommentCurrency = "Наименование валюты, используемой в стране";

      public const string ColumnNameCurrencyCode = "currency_code";
      public const string ColumnCommentCurrencyCode = "Код валюты, используемой в стране";

      public const string ColumnNameIsoCode = "iso_code";
      public const string ColumnCommentIsoCode = "Уникальный ISO код страны";

      public const string ColumnNameLanguage = "language";
      public const string ColumnCommentLanguage = "Основной язык страны";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование страны";
    }
  }
}