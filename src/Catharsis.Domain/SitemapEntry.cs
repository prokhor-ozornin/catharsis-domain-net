using Catharsis.Commons;
using SQLite.Net.Attributes;
using System;
using System.ComponentModel;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Элемент карты сайта</para>
  /// </summary>
  [Serializable]
  [Description(Schema.TableComment)]
  [Table(Schema.TableName)]
  public class SitemapEntry : Entity, IComparable<SitemapEntry>, IEquatable<SitemapEntry>
  {
    /// <summary>
    ///   <para>Частота обновлений ресурса, доступного по URI адресу</para>
    /// </summary>
    [Description(Schema.ColumnCommentChangeFrequency)]
    [Column(Schema.ColumnNameChangeFrequency)]
    [Indexed(Name = "idx__sitemap_entry__change_frequency")]
    public virtual SitemapChangeFrequency? ChangeFrequency { get; set; }

    /// <summary>
    ///   <para>Дата/время последнего обновления ресурса, доступного по URI адресу</para>
    /// </summary>
    [Description(Schema.ColumnCommentDate)]
    [Column(Schema.ColumnNameDate)]
    [Indexed(Name = "idx__sitemap_entry__date")]
    public virtual DateTime? Date { get; set; }

    /// <summary>
    ///   <para>Описание ресурса, доступного по URI адресу</para>
    /// </summary>
    [Description(Schema.ColumnCommentDescription)]
    [Column(Schema.ColumnNameDescription)]
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Приоритет ресурса среди элементов карты сайта</para>
    /// </summary>
    [Description(Schema.ColumnCommentPriority)]
    [Column(Schema.ColumnNamePriority)]
    [Indexed(Name = "idx__sitemap_entry__priority")]
    public virtual decimal? Priority { get; set; }

    /// <summary>
    ///   <para>URI адрес ресурса</para>
    /// </summary>
    [Description(Schema.ColumnCommentUri)]
    [Column(Schema.ColumnNameUri)]
    [NotNull]
    [MaxLength(1000)]
    [Unique(Name = "sitemap_entry__uri")]
    public virtual Uri Uri { get; set; }

    public virtual int CompareTo(SitemapEntry other)
    {
      return this.Uri.ToString().CompareTo(other.Uri.ToString());
    }

    public bool Equals(SitemapEntry other)
    {
      return this.Equality(other, it => it.Uri);
    }

    public override bool Equals(object other)
    {
      return this.Equals(other as SitemapEntry);
    }

    public override int GetHashCode()
    {
      return this.GetHashCode(it => it.Uri);
    }

    public override string ToString()
    {
      return this.Uri?.ToString() ?? string.Empty;
    }

    public static new class Schema
    {
      public const string TableName = "sitemap_entry";
      public const string TableComment = "Элементы карты сайта, описывающие URI ресурсы";

      public const string ColumnNameId = "id";
      public const string ColumnCommentId = "Уникальный идентификатор";

      public const string ColumnNameCreatedOn = "created_on";
      public const string ColumnCommentCreatedOn = "Дата/время добавления URI ресурса";

      public const string ColumnNameUpdatedOn = "updated_on";
      public const string ColumnCommentUpdatedOn = "Дата/время последнего изменения URI ресурса";

      public const string ColumnNameChangeFrequency = "change_frequency";
      public const string ColumnCommentChangeFrequency = "Частота обновлений ресурса, доступного по URI адресу";

      public const string ColumnNameDate = "date";
      public const string ColumnCommentDate = "Дата/время последнего обновления ресурса, доступного по URI адресу";

      public const string ColumnNameDescription = "description";
      public const string ColumnCommentDescription = "Описание ресурса, доступного по URI адресу";

      public const string ColumnNamePriority = "priority";
      public const string ColumnCommentPriority = "Приоритет ресурса среди элементов карты сайта";

      public const string ColumnNameUri = "uri";
      public const string ColumnCommentUri = "URI адрес ресурса";
    }
  }
}