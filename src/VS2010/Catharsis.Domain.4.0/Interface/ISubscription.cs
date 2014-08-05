using System;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents user's subscription.</para>
  /// </summary>
  public partial interface ISubscription : IEntity, ITimestampable
  {
    /// <summary>
    ///   <para>Whether subscription is active/enabled or inactive/disabled.</para>
    /// </summary>
    bool Active { get; }

    /// <summary>
    ///   <para>Email address of subscriber.</para>
    /// </summary>
    string Email { get; }

    /// <summary>
    ///   <para>Date/time when subscription should expire.</para>
    /// </summary>
    DateTime? ExpiredAt { get; }

    /// <summary>
    ///   <para>Unique string token/marker of subscription.</para>
    /// </summary>
    string Token { get; }
  }
}