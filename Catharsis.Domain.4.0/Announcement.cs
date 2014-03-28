using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a free or paid informational message.</para>
  /// </summary>
  [Description("Represents a free or paid informational message")]
  public partial class Announcement : Item, IEquatable<Announcement>
  {
    /// <summary>
    ///   <para>Category of announcement.</para>
    /// </summary>
    [Description("Category of announcement")]
    public virtual AnnouncementsCategory Category { get; set; }

    /// <summary>
    ///   <para>Currency of announcement's price.</para>
    /// </summary>
    [Description("Currency of announcement's price")]
    public virtual string Currency { get; set; } 
    
    /// <summary>
    ///   <para>URI of announcement's image.</para>
    /// </summary>
    [Description("URI of announcement's image")]
    public virtual string Image { get; set; }
    
    /// <summary>
    ///   <para>Price of announcement.</para>
    /// </summary>
    [Description("Price of announcement")]
    public virtual decimal? Price { get; set; }

    /// <summary>
    ///   <para>Creates new announcement.</para>
    /// </summary>
    public Announcement()
    {
    }

    /// <summary>
    ///   <para>Creates new announcement.</para>
    /// </summary>
    /// <param name="name">Name of announcement.</param>
    /// <param name="text">Announcement's body text.</param>
    /// <param name="category">Category of announcement</param>
    /// <param name="image">URI of announcement's image</param>
    /// <param name="currency">Currency of announcement's price</param>
    /// <param name="price">Price of announcement</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/> or <paramref name="text"/> is a <c>null</c> reference.</exception>
    public Announcement(string name, string text, AnnouncementsCategory category = null, string image = null, string currency = null, decimal? price = null) : base(name, text)
    {
      Assertion.NotEmpty(text);

      this.Category = category;
      this.Image = image;
      this.Currency = currency;
      this.Price = price;
    }

    /// <summary>
    ///   <para>Determines whether two announcements instances are equal.</para>
    /// </summary>
    /// <param name="other">The announcement to compare with the current one.</param>
    /// <returns><c>true</c> if specified announcement is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Announcement other)
    {
      return base.Equals(other) && this.Equality(other, announcement => announcement.Category);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Announcement);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return base.GetHashCode() + this.GetHashCode(announcement => announcement.Category);
    }
  }
}