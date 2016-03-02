using System;
using System.ComponentModel;
using Catharsis.Commons;
using SQLite;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Ключ доступа API</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class ApiKey : Entity, IComparable<ApiKey>, IEquatable<ApiKey>
  {
    /// <summary>
    ///   <para>Описание приложения, использующего ключ доступа</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentAppDescription)]
#endif
    [Column(Schema.ColumnNameAppDescription)]
    [MaxLength(4000)]
    public virtual string AppDescription { get; set; }

    /// <summary>
    ///   <para>Доменное имя, с которого приложение осуществляет запросы к API</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentAppDomain)]
#endif
    [Column(Schema.ColumnNameAppDomain)]
    [Indexed(Name = "idx__api_keys__app_domain")]
    public virtual string AppDomain { get; set; }

    /// <summary>
    ///   <para>Наименование приложения, использующего ключ доступа</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentAppName)]
#endif
    [Column(Schema.ColumnNameAppName)]
    [Indexed(Name = "idx__api_keys__app_name")]
    public virtual string AppName { get; set; }

    /// <summary>
    ///   <para>Контактные данные лица, на имя которого выдан ключ доступ</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentContact)]
#endif
    [Column(Schema.ColumnNameContact)]
    [Indexed(Name = "idx__api_keys__contact_id")]
    public virtual Contact Contact { get; set; }

    /// <summary>
    ///   <para>Ф.И.О. контактного лица, на имя которого выдан ключ доступа</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Indexed(Name = "idx__api_keys__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Значение ключа доступа</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentValue)]
#endif
    [Column(Schema.ColumnNameValue)]
    [NotNull]
    [Unique(Name = "idx__api_keys__value")]
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

    public static class Schema
    {
      public const string TableName = "api_keys";
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