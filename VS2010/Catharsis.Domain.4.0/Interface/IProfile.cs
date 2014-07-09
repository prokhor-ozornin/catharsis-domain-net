namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a profile of user, which is a combination of credentials in external system like social network.</para>
  /// </summary>
  public partial interface IProfile : IEntity, INameable
  {
    /// <summary>
    ///   <para>Email address of user.</para>
    /// </summary>
    string Email { get; }

    /// <summary>
    ///   <para>URI of user's photo/avatar.</para>
    /// </summary>
    string Photo { get; }

    /// <summary>
    ///   <para>Type of profile, for example name of a social network.</para>
    /// </summary>
    string Type { get; }

    /// <summary>
    ///   <para>URL address of profile.</para>
    /// </summary>
    string Url { get; }

    /// <summary>
    ///   <para>Username/login of user.</para>
    /// </summary>
    string Username { get; }
  }
}