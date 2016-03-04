using System;
using System.ComponentModel;
using Catharsis.Commons;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Настроечная опция</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description(Schema.TableComment)]
#endif
  [Table(Schema.TableName)]
  public class Setting : Entity, IComparable<Setting>, IEquatable<Setting>
  {
    /// <summary>
    ///   <para>Описание настроечной опции</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentDescription)]
#endif
    [Column(Schema.ColumnNameDescription)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Наименование настроечной опции</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentName)]
#endif
    [Column(Schema.ColumnNameName)]
    [NotNull]
    [Unique(Name = "idx__settings__name")]
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Тип данных для значения настроечной опции</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentType)]
#endif
    [Column(Schema.ColumnNameType)]
    [NotNull]
    [Indexed(Name = "idx__settings__type")]
    public virtual SettingType? Type { get; set; }

    /// <summary>
    ///   <para>Значение настроечной опции</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentValue)]
#endif
    [Column(Schema.ColumnNameValue)]
    public virtual string Value { get; set; }

    /// <summary>
    ///   <para>Список значений настроечной опции</para>
    /// </summary>
#if NET_35
    [Description(Schema.ColumnCommentValues)]
#endif
    [Column(Schema.ColumnNameValues)]
    public virtual IList<string> Values { get; set; } = new List<string>();

    public virtual int CompareTo(Setting other)
    {
      return this.Name.CompareTo(other.Name);
    }

    public virtual bool Equals(Setting other)
    {
      return this.Equality(other, it => it.Name);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as Setting);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Name);
    }

    public override string ToString()
    {
      return this.Value ?? this.Values.ToListString();
    }

    public static class Schema
    {
      public const string TableName = "settings";
      public const string TableComment = "Настроечные опции";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления настроечной опции";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения настроечной опции";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание настроечной опции";

      public const string ColumnNameName = "name";
      public const string ColumnCommentName = "Наименование настроечной опции";

      public const string ColumnNameType = "type";
      public const string ColumnCommentType = "Тип данных для значения настроечной опции";

      public const string ColumnNameValue = "value";
      public const string ColumnCommentValue = "Значение настроечной опции";

      public const string ColumnNameValues = "values";
      public const string ColumnCommentValues = "Список значений настроечной опции";
    }
  }
}