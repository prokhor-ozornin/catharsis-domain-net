using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Ключ доступа API</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class ApiKey : Entity, IComparable<ApiKey>, IEquatable<ApiKey>
  {
    /// <summary>
    ///   <para>Описание приложения, использующего ключ доступа</para>
    /// </summary>
    [Description(Schema.ColumnCommentAppDescription)]
    [Column(Schema.ColumnNameAppDescription)]
    [MaxLength(4000)]
    public virtual string AppDescription { get; set; }

    /// <summary>
    ///   <para>Доменное имя, с которого приложение осуществляет запросы к API</para>
    /// </summary>
    [Description(Schema.ColumnCommentAppDomain)]
    [Column(Schema.ColumnNameAppDomain)]
    [Indexed(Name = "idx__api_key__app_domain")]
    public virtual string AppDomain { get; set; }

    /// <summary>
    ///   <para>Наименование приложения, использующего ключ доступа</para>
    /// </summary>
    [Description(Schema.ColumnCommentAppName)]
    [Column(Schema.ColumnNameAppName)]
    [Indexed(Name = "idx__api_key__app_name")]
    public virtual string AppName { get; set; }

    /// <summary>
    ///   <para>Контактные данные лица, на имя которого выдан ключ доступ</para>
    /// </summary>
    [Description(Schema.ColumnCommentContact)]
    [Column(Schema.ColumnNameContact)]
    [Indexed(Name = "idx__api_key__contact_id")]
    public virtual Contact Contact { get; set; }

    /// <summary>
    ///   <para>Ф.И.О. контактного лица, на имя которого выдан ключ доступа</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__api_key__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Значение ключа доступа</para>
    /// </summary>
    [Description(Schema.ColumnCommentValue)]
    [Column(Schema.ColumnNameValue)]
    [NotNull]
    [Unique(Name = "api_key__value")]
    public virtual string Value { get; set; } = Guid.NewGuid().ToString();

    public virtual int CompareTo(ApiKey other)
    {
      return this.CreatedOn.Value.CompareTo(other.CreatedOn.Value);
    }

    public virtual bool Equals(ApiKey other)
    {
      return this.Equality(other, it => it.Value);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as ApiKey);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Value);
    }

    public override string ToString()
    {
      return this.Value?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "api_key";
      public const string TableComment = "Ключи доступа к API, выданные партнерам";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время выдачи ключа доступа";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения ключа доступа";

      public const string ColumnNameAppDescription = "app_description";
      public const string ColumnCommentAppDescription = "Описание приложения, использующего ключ доступа";

      public const string ColumnNameAppDomain = "app_domain";
      public const string ColumnCommentAppDomain = "Доменное имя, с которого приложение осуществляет запросы к API";

      public const string ColumnNameAppName = "app_name";
      public const string ColumnCommentAppName = "Наименование приложения, использующего ключ доступа";

      public const string ColumnNameContact = "contact_id";
      public const string ColumnCommentContact = "Контактные данные лица, на имя которого выдан ключ доступ";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Ф.И.О. контактного лица, на имя которого выдан ключ доступа";

      public const string ColumnNameValue = "value";
      public const string ColumnCommentValue = "Значение ключа доступа";
    }
  }
}