using System;
using System.Collections.Generic;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Адрес</para>
  /// </summary>
#if NET_35
  [Serializable]
  [Description("Адрес")]
#endif
  public partial class Address : Entity, IComparable<Address>
  {
    /// <summary>
    ///   <para>Город, к которому относится адрес</para>
    /// </summary>
#if NET_35
    [Description("Город, к которому относится адрес")]
#endif
    public virtual City City { get; set; }

    /// <summary>
    ///   <para>Дополнительные примечания, относящиеся к адресу</para>
    /// </summary>
#if NET_35
    [Description("Дополнительные примечания, относящиеся к адресу")]
#endif
    public virtual string Description { get; set; }

    /// <summary>
    ///   <para>Географическая точка с координатами адреса</para>
    /// </summary>
#if NET_35
    [Description("Географическая точка с координатами адреса")]
#endif
    public virtual Location Location { get; set; }

    /// <summary>
    ///   <para>Адрес (улица, дом)</para>
    /// </summary>
#if NET_35
    [Description("Адрес (улица, дом)")]
#endif
    public virtual string Name { get; set; }

    /// <summary>
    ///   <para>Почтовый индекс</para>
    /// </summary>
#if NET_35
    [Description("Почтовый индекс")]
#endif
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
  }
}