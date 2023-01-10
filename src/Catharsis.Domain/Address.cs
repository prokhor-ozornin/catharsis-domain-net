using System.ComponentModel;
using System.Runtime.Serialization;
using Catharsis.Extensions;

namespace Catharsis.Domain;

/// <summary>
///   <para>Адрес</para>
/// </summary>
[Description("Адрес")]
[Serializable]
[DataContract(Name = nameof(Address))]
public class Address : Entity, IComparable<Address>
{
  /// <summary>
  ///   <para>Адрес (улица, дом)</para>
  /// </summary>
  [DataMember(Name = nameof(Name))]
  [Description("Адрес (улица, дом)")]
  public virtual string Name { get; set; }

  /// <summary>
  ///   <para>Город, к которому относится адрес</para>
  /// </summary>
  [DataMember(Name = nameof(City))]
  [Description("Город, к которому относится адрес")]
  public virtual City City { get; set; }

  /// <summary>
  ///   <para>Почтовый индекс</para>
  /// </summary>
  [DataMember(Name = nameof(Zip))]
  [Description("Почтовый индекс")]
  public virtual string Zip { get; set; }

  /// <summary>
  ///   <para>Географическая точка с координатами адреса</para>
  /// </summary>
  [DataMember(Name = nameof(Location))]
  [Description("Географическая точка с координатами адреса")]
  public virtual Location Location { get; set; }

  /// <summary>
  ///   <para>Дополнительные примечания, относящиеся к адресу</para>
  /// </summary>
  [DataMember(Name = nameof(Description))]
  [Description("Дополнительные примечания, относящиеся к адресу")]
  public virtual string Description { get; set; }

  /// <summary>
  ///   <para>Compares the current <see cref="Address"/> instance with another.</para>
  /// </summary>
  /// <returns>A value that indicates the relative order of the instances being compared.</returns>
  /// <param name="other">The <see cref="Address"/> to compare with this instance.</param>
  public virtual int CompareTo(Address other) => string.Compare(Name, other?.Name, StringComparison.InvariantCultureIgnoreCase);

  /// <summary>
  ///   <para>Returns a <see cref="string"/> that represents the current entity.</para>
  /// </summary>
  /// <returns>A string that represents the current entity.</returns>
  public override string ToString()
  {
    var parts = new List<string>();

    if (City != null)
    {
      parts.Add(City.ToString());
    }

    if (Name != null)
    {
      parts.Add(Name.Trim());
    }

    if (Zip != null)
    {
      parts.Add(Zip.Trim());
    }

    return parts.Join(",").Trim();
  }
}