using System;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;

namespace Catharsis.Domain
{
  /// <summary>
  ///   <para>Represents a profile of user, which is a combination of credentials in external system like social network.</para>
  /// </summary>
  [Description("Represents a profile of user, which is a combination of credentials in external system like social network")]
  public partial class Profile : IComparable<Profile>, IEquatable<Profile>, IEntity, INameable
  {
    private string name;
    private string type;
    private string url;
    private string username;

    /// <summary>
    ///   <para>Unique identifier of profile.</para>
    /// </summary>
    [Description("Unique identifier of profile")]
    public virtual long Id { get; set; }

    /// <summary>
    ///   <para>Version number of current profile instance.</para>
    /// </summary>
    [Description("Version number of current profile instance")]
    [XmlIgnore]
    public virtual long Version { get; set; }

    /// <summary>
    ///   <para>Email address of user.</para>
    /// </summary>
    [Description("Email address of user")]
    public virtual string Email { get; set; }
    
    /// <summary>
    ///   <para>Real name of user.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Real name of user")]
    public virtual string Name
    {
      get { return this.name; }
      set
      {
        Assertion.NotEmpty(value);

        this.name = value;
      }
    }
    
    /// <summary>
    ///   <para>URI of user's photo/avatar.</para>
    /// </summary>
    [Description("URI of user's photo/avatar")]
    public virtual string Photo { get; set; }
    
    /// <summary>
    ///   <para>Type of profile, for example name of a social network.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Type of profile, for example name of a social network")]
    public virtual string Type
    {
      get { return this.type; }
      set
      {
        Assertion.NotEmpty(value);

        this.type = value;
      }
    }
    
    /// <summary>
    ///   <para>URL address of profile.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("URL address of profile")]
    public virtual string Url
    {
      get { return this.url; }
      set
      {
        Assertion.NotEmpty(value);

        this.url = value;
      }
    }
    
    /// <summary>
    ///   <para>Username/login of user.</para>
    /// </summary>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If <paramref name="value"/> is <see cref="string.Empty"/> string.</exception>
    [Description("Username/login of user")]
    public virtual string Username
    {
      get { return this.username; }
      set
      {
        Assertion.NotEmpty(value);

        this.username = value;
      }
    }

    /// <summary>
    ///   <para>Creates new profile.</para>
    /// </summary>
    public Profile()
    {
    }

    /// <summary>
    ///   <para>Creates new profile.</para>
    /// </summary>
    /// <param name="name">Name of profile's user.</param>
    /// <param name="username">Username/login of user.</param>
    /// <param name="type">Type of profile, for example name of a social network.</param>
    /// <param name="url">URL address of profile.</param>
    /// <param name="email">Email address of user.</param>
    /// <param name="photo">URI of user's photo/avatar.</param>
    /// <exception cref="ArgumentNullException">If either <paramref name="name"/>, <paramref name="username"/>, <paramref name="type"/> or <paramref name="url"/> is a <c>null</c> reference.</exception>
    /// <exception cref="ArgumentException">If either <paramref name="name"/>, <paramref name="username"/>, <paramref name="type"/> or <paramref name="url"/> is <see cref="string.Empty"/> string.</exception>
    public Profile(string name, string username, string type, string url, string email = null, string photo = null)
    {
      this.Name = name;
      this.Username = username;
      this.Type = type;
      this.Url = url;
      this.Email = email;
      this.Photo = photo;
    }

    /// <summary>
    ///   <para>Compares the current profile with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="Profile"/> to compare with this instance.</param>
    public virtual int CompareTo(Profile other)
    {
      return this.Username.Compare(other.Username, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two profiles instances are equal.</para>
    /// </summary>
    /// <param name="other">The profile to compare with the current one.</param>
    /// <returns><c>true</c> if specified profile is equal to the current, <c>false</c> otherwise.</returns>
    public virtual bool Equals(Profile other)
    {
      return this.Equality(other, profile => profile.Type, profile => profile.Username);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as Profile);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(profile => profile.Type, profile => profile.Username);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current profile.</para>
    /// </summary>
    /// <returns>A string that represents the current profile.</returns>
    public override string ToString()
    {
      return this.Name;
    }
  }
}