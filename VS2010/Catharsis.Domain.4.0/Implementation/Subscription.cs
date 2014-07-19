using System;
using System.ComponentModel;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents user's subscription.</para>
  /// </summary>
  [Description("Represents user's subscription")]
  public partial class Subscription : Entity, IComparable<Subscription>, ITimestampable
  {
    private string email;
    private string token;

    /// <summary>
    ///   <para>Whether subscription is active/enabled or inactive/disabled.</para>
    /// </summary>
    [Description("Whether subscription is active/enabled or inactive/disabled")]
    public virtual bool Active { get; set; }
    
    /// <summary>
    ///   <para>Date/time when subscription was made.</para>
    /// </summary>
    [Description("Date/time when subscription was made")]
    public virtual DateTime CreatedAt { get; set; }
    
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
    public virtual DateTime? ExpiredAt { get; set; }
    
    /// <summary>
    ///   <para>Date/time when subscription was altered.</para>
    /// </summary>
    [Description("Date/time when subscription was altered")]
    public virtual DateTime UpdatedAt { get; set; }
    
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
      this.CreatedAt = DateTime.UtcNow;
      this.UpdatedAt = DateTime.UtcNow;
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
      this.ExpiredAt = expiredOn;
    }

    /// <summary>
    ///   <para>Compares the current <see cref="Subscription"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="Subscription"/> to compare with this instance.</param>
    public virtual int CompareTo(Subscription other)
    {
      return this.CreatedAt.CompareTo(other.CreatedAt);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="Subscription"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="Subscription"/>.</returns>
    public override string ToString()
    {
      return this.Email;
    }
  }
}