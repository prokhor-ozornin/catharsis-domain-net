using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Компания из справочника</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class DirectoryCompany : Entity, IComparable<DirectoryCompany>, IEquatable<DirectoryCompany>
  {
    /// <summary>
    ///   <para>Внешний служебный код компании</para>
    /// </summary>
    [Description(Schema.ColumnCommentCode)]
    [Column(Schema.ColumnNameCode)]
    public virtual string Code { get; set; }

    /// <summary>
    ///   <para>Контактные данные компании</para>
    /// </summary>
    [Description(Schema.ColumnCommentContact)]
    [Column(Schema.ColumnNameContact)]
    public virtual Contact Contact { get; set; }

    /// <summary>
    ///   <para>Полное наименование компании</para>
    /// </summary>
    [Description(Schema.ColumnCommentName)]
    [Column(Schema.ColumnNameName)]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Краткое наименование компании</para>
    /// </summary>
    [Description(Schema.ColumnCommentShortName)]
    [Column(Schema.ColumnNameShortName)]
    public virtual string ShortName { get; set; }

    public virtual int CompareTo(DirectoryCompany other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(DirectoryCompany other)
    {
      return this.Equality(other, it => it.CreatedOn, it => it.Name, it => it.ShortName);
    }

    public override bool Equals(object other)
    {
      return base.Equals(other);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.CreatedOn, it => it.Name, it => it.ShortName);
    }

    public override string ToString()
    {
      return this.Name?.Trim() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "directory_company";
      public const string TableComment = "Компании из справочника";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления компании";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения данных о компании";

      public const string ColumnNameCode = "code";
      public const string ColumnCommentCode = "Внешний служебный код компании";

      public const string ColumnNameContact = "contact_id";
      public const string ColumnCommentContact = "Контактные данные компании";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Полное наименование компании";

      public const string ColumnNameShortName = "short_name";
      public const string ColumnCommentShortName = "Краткое наименование компании";
    }
  }
}