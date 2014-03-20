using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents user's subscription.</para>
  /// </summary>
  [Description("Represents user's subscription")]
  public partial class Subscription : IComparable<Subscription>, IEquatable<Subscription>, IEntity, ITimestampable
  {
    private string email;
    private string token;

    /// <summary>
    ///   <para>Unique identifier of subscription.</para>
    /// </summary>
    [Description("Unique identifier of subscription")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current subscription instance.</para>
    /// </summary>
    [Description("Version number of current subscription instance")]
    [XmlIgnore]
    [JsonIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Whether subscription is active/enabled or inactive/disabled.</para>
    /// </summary>
    [Description("Whether subscription is active/enabled or inactive/disabled")]
    public virtual bool Active { get; set; }
    
    /// <summary>
    ///   <para>Date/time when subscription was made.</para>
    /// </summary>
    [Description("Date/time when subscription was made")]
    public virtual DateTime DateCreated { get; set; }
    
    /// <summary>
    ///   <para>Email address of subscriber.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Email address of subscriber")]
    public virtual string Email
    {
      get { return this.email; }
      set
      {
        Assertion.NotEmpty(value);

        this.email = value;
      }
    }
    
    /// <summary>
    ///   <para>Date/time when subscription should expire.</para>
    /// </summary>
    [Description("Date/time when subscription should expire")]
    public virtual DateTime? ExpiredOn { get; set; }
    
    /// <summary>
    ///   <para>Date/time when subscription was altered.</para>
    /// </summary>
    [Description("Date/time when subscription was altered")]
    public virtual DateTime LastUpdated { get; set; }
    
    /// <summary>
    ///   <para>Unique string token/marker of subscription.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Unique string token/marker of subscription")]
    public virtual string Token
    {
      get { return this.token; }
      set
      {
        Assertion.NotEmpty(value);

        this.token = value;
      }
    }
    
    /// <summary>
    ///   <para>Creates new subscription.</para>
    /// </summary>
    public Subscription()
    {
      this.DateCreated = DateTime.UtcNow;
      this.LastUpdated = DateTime.UtcNow;
      this.Active = true;
      this.Token = Guid.NewGuid().ToString();
    }

    /// <summary>
    ///   <para>Creates new subscription.</para>
    /// </summary>
    /// <param name="email">Email address of subscriber.</param>
    /// <param name="expiredOn">Date/time when subscription should expire.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="email"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="email"/> is <see cref="string.Empty"/> string.</exception>
    public Subscription(string email, DateTime? expiredOn = null) : this()
    {
      this.Email = email;
      this.ExpiredOn = expiredOn;
    }

    /// <summary>
    ///   <para>Compares the current subscription with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Subscription"/> to compare with this instance.</param>
    public virtual int CompareTo(Subscription other)
    {
      return this.DateCreated.CompareTo(other.DateCreated);
    }

    /// <summary>
    ///   <para>Determines whether two subscriptions instances are equal.</para>
    /// </summary>
    /// <param name="other">The subscription to compare with the current one.</param>
    /// <returns><c>true</c> if specified subscription is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Subscription other)
    {
      return this.Equality(other, subscription => subscription.Email);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Subscription);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(subscription => subscription.Email);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current subscription.</para>
    /// </summary>
    /// <returns>A string that represents the current subscription.</returns>
    public override string ToString()
    {
      return this.Email;
    }
  }
}